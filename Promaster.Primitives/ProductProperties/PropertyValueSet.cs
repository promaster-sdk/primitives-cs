using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Promaster.Primitives.Collections;
using Promaster.Primitives.Measure;
using Promaster.Primitives.Measure.Quantity;

namespace Promaster.Primitives.ProductProperties
{
  /// <summary>
  ///   Represents a set of properties and a selected value for each of the properties. IMPORTANT: Keep this class immutable!
  /// </summary>
  [DebuggerDisplay("PropertyValueSet ({DebugString})")]
  public class PropertyValueSet
  {
    public static readonly PropertyValueSet Empty = new PropertyValueSet();

    private readonly IReadOnlyDictionaryPortable<string, PropertyValue> _entries;

    public static bool IsNullOrEmpty(PropertyValueSet propertyValueSet)
    {
      return propertyValueSet == null || propertyValueSet.Equals(Empty);
    }

    public static PropertyValueSet ParseOrDefault(string encodedValueSet, PropertyValueSet defaultValue)
    {
      PropertyValueSet result;
      if (TryParse(encodedValueSet, out result))
      {
        return result;
      }
      else
      {
        return defaultValue;
      }
    }

    public static PropertyValueSet Parse(string encodedValueSet)
    {
      PropertyValueSet result;
      if (TryParse(encodedValueSet, out result))
      {
        return result;
      }
      else
      {
        throw new InvalidOperationException("Invalid string. Use TryParse() or ParseOrDefault() to do parsing without exceptions.");
      }
    }

    public static PropertyValueSet FromObject(object o)
    {
      var result = new PropertyValueSetBuilder();
      var propertyInfos = o.GetType().GetProperties();
      foreach (var pi in propertyInfos)
      {
        var valueToMap = pi.GetValue(o, null);
        if (valueToMap == null)
          continue;
        PropertyValue pv;
        if (valueToMap is string)
          pv = new PropertyValue((string)valueToMap);
        else if (valueToMap is int)
          pv = new PropertyValue((int)valueToMap);
        else if (valueToMap is Amount)
          pv = new PropertyValue((Amount)valueToMap);
        else
          throw new Exception("Cannot map type " + valueToMap.GetType().Name + " into a PropertyValueSet");

        result.Add(pi.Name, pv);
      }
      return result.Build();
    }

    public static bool TryParse(string encodedValueSet, out PropertyValueSet propertyValueSet)
    {
      if (string.IsNullOrEmpty(encodedValueSet))
      {
        propertyValueSet = Empty;
        return true;
      }

      var entries = StringToEntriesOrNullIfInvalidString(encodedValueSet);
      if (entries == null)
      {
        propertyValueSet = default(PropertyValueSet);
        return false;
      }
      else
      {
        propertyValueSet = new PropertyValueSet(entries);
        return true;
      }
    }

    public PropertyValueSet(string propertyName, PropertyValue propertyValue)
    {
      var entries = new SafeDictionary<string, PropertyValue>(StringComparer.OrdinalIgnoreCase);
      entries.Add(propertyName, propertyValue);
      _entries = entries;
    }

    private PropertyValueSet()
    {
      _entries = new SafeDictionary<string, PropertyValue>(StringComparer.OrdinalIgnoreCase);
    }

    internal PropertyValueSet(IReadOnlyDictionaryPortable<string, PropertyValue> dictionary)
    {
      if (dictionary.Any(e => e.Value == null))
        throw new Exception("No values are allowed to be null");
      if (!Equals(dictionary.Comparer, StringComparer.OrdinalIgnoreCase))
        throw new Exception("Comparer must be StringComparer.OrdinalIgnoreCase");
      _entries = dictionary;
    }


    /// <summary>
    /// RULES:
    /// Format should be
    /// Name1=Value1;Name2=Value2;Name3=Value3
    /// Values that represents strings must be enclosed in double quote (") and if they contains double quote characters they must be encoded as %22.
    /// </summary>
    private static IReadOnlyDictionaryPortable<string, PropertyValue> StringToEntriesOrNullIfInvalidString(string encodedValueSet)
    {
      var entries = new SafeDictionary<string, PropertyValue>(StringComparer.OrdinalIgnoreCase);
      // Add extra semicolon on the end to close last name/value pair
      var toParse = encodedValueSet;
      if (!toParse.EndsWith(";"))
        toParse += ";";
      StringBuilder name = new StringBuilder();
      StringBuilder value = new StringBuilder();
      bool isInNamePart = true;
      bool isInQuote = false;
      for (int i = 0; i < toParse.Length; i++)
      {
        char c = toParse[i];
        switch (c)
        {
          case '=':
            if (!isInQuote)
            {
              if (!isInNamePart)
              {
                // Parse error
                return null;
              }
              isInNamePart = false;
            }
            else
            {
              value.Append(c);
            }
            break;
          case ';':
            if (!isInQuote)
            {
              if (isInNamePart)
              {
                // Parse error
                return null;
              }
              PropertyValue entryValue;
              if (!PropertyValue.TryParse(value.ToString(), out entryValue))
              {
                // Parse error
                return null;
              }
              entries.Add(name.ToString(), entryValue);
              isInNamePart = true;
              name = new StringBuilder();
              value = new StringBuilder();
            }
            else
            {
              value.Append(c);
            }
            break;
          case '"':
            isInQuote = !isInQuote;
            value.Append(c);
            break;
          default:
            if (isInNamePart)
            {
              name.Append(c);
            }
            else
            {
              value.Append(c);
            }
            break;
        }
      }
      return entries;

    }

    public object ToObject(Type t)
    {
      var constructor = t.GetConstructors().FirstOrDefault();
      if (constructor == null)
        throw new Exception("Could not find a constructor for type " + t.Name);

      var parameters = new List<object>();
      foreach (var parameter in constructor.GetParameters())
      {
        PropertyValue value;
        if (!_entries.TryGetValue(parameter.Name.ToLower(), out value))
          throw new Exception("Could not find constructor parameter " + parameter.Name + " in PropertyValueSet");

        if (value.Type == PropertyType.Integer && parameter.ParameterType == typeof(int))
          parameters.Add(value.ToInteger());
        else if (value.Type == PropertyType.Amount && parameter.ParameterType == typeof(Amount))
          parameters.Add(value.ToAmount());
        else if (value.Type == PropertyType.Text && parameter.ParameterType == typeof(string))
          parameters.Add(value.ToText());
        else
          throw new Exception("Type of constructor parameter " + parameter.Name + " does not match the property type");
      }

      return constructor.Invoke(parameters.ToArray());
    }

    //private static IReadOnlyDictionary<string, PropertyValue> OLD_StringToEntriesOrNullIfInvalidString(string encodedValueSet)
    //{
    //  var entries = new SafeDictionary<string, PropertyValue>(StringComparer.OrdinalIgnoreCase);
    //  var nameValuePairs = encodedValueSet.TrimEnd(';').Split(';');
    //  if (nameValuePairs.Length == 0)
    //    return null;
    //  foreach (var t in nameValuePairs)
    //  {
    //    var split = t.Split('=');
    //    if (split.Length != 2)
    //      return null;
    //    var namePart = split[0];
    //    var valuePart = split[1];
    //    PropertyValue entryValue;
    //    if (!PropertyValue.TryParse(valuePart, out entryValue))
    //      return null;
    //    entries[namePart] = entryValue;
    //  }
    //  return entries;
    //}

    public IReadOnlyDictionaryPortable<string, PropertyValue> ToDictionary()
    {
      return _entries;
    }

    private SafeDictionary<string, PropertyValue> ToSafeDictionary()
    {
      var dict = new SafeDictionary<string, PropertyValue>(StringComparer.OrdinalIgnoreCase);
      foreach (var entry in _entries)
        dict[entry.Key] = entry.Value;
      return dict;
    }

    public PropertyValue this[string propertyName]
    {
      get
      {
        try
        {
          return _entries[propertyName];
        }
        catch (KeyNotFoundException)
        {
          throw new Exception(string.Format("Could not find property '{0}' in value set '{1}'.", propertyName, ToString()));
        }
      }
    }

    public bool HasProperty(string propertyName)
    {
      return _entries.ContainsKey(propertyName);
    }

    public IEnumerable<string> GetPropertyNames()
    {
      return _entries.Keys;
    }

    public PropertyValueSet Merge(PropertyValueSet mergeWith)
    {
      var builder = new PropertyValueSetBuilder(mergeWith);
      builder.Add(this);
      return builder.Build();
    }

    public PropertyValueSet ReplaceValue(string propertyName, PropertyValue propertyValue)
    {
      var dict = ToSafeDictionary();
      dict[propertyName] = propertyValue;
      return new PropertyValueSet(dict);
    }

    public PropertyValueSet ReplaceValue(string propertyName, Amount propertyValue)
    {
      var dict = ToSafeDictionary();
      dict[propertyName] = new PropertyValue(propertyValue);
      return new PropertyValueSet(dict);
    }

    public PropertyValueSet ReplaceValue(string propertyName, int propertyValue)
    {
      var dict = ToSafeDictionary();
      dict[propertyName] = new PropertyValue(propertyValue);
      return new PropertyValueSet(dict);
    }

    public PropertyValueSet ReplaceValue(string propertyName, string propertyValue)
    {
      var dict = ToSafeDictionary();
      dict[propertyName] = new PropertyValue(propertyValue);
      return new PropertyValueSet(dict);
    }

    /// <summary>
    ///   If a property exists with the same name in the PropertyValueSet as in the replacement set then the value of that property will be replaced.
    /// </summary>
    public PropertyValueSet ReplaceValues(PropertyValueSet replacementSet)
    {
      if (replacementSet == null)
        return this;

      var dict = ToSafeDictionary();
      foreach (var entry in replacementSet._entries)
        dict[entry.Key] = entry.Value;
      return new PropertyValueSet(dict);
    }

    public PropertyValueSet KeepProperties(IEnumerable<string> propertyNames)
    {
      if (propertyNames == null)
        return this;
      var dict = propertyNames.Where(n => _entries.ContainsKey(n)).ToSafeDictionary(n => n, n => _entries[n], StringComparer.OrdinalIgnoreCase);
      return new PropertyValueSet(dict);
    }

    public PropertyValueSet RemoveProperties(IEnumerable<string> propertyNames)
    {
      if (propertyNames == null)
        return this;

      var dict = ToSafeDictionary();
      foreach (var propertyName in propertyNames)
        dict.Remove(propertyName);
      return new PropertyValueSet(dict);
    }

    public PropertyValueSet RemoveProperty(string propertyName)
    {
      var dict = ToSafeDictionary();
      dict.Remove(propertyName);
      return new PropertyValueSet(dict);
    }

    public bool TryGetValue(string propertyName, out PropertyValue value)
    {
      return _entries.TryGetValue(propertyName, out value);
    }

    public PropertyValue GetValueOrNull(string propertyName)
    {
      if (!_entries.ContainsKey(propertyName))
        return null;
      return _entries[propertyName];
    }

    public Amount GetAmount(string propertyName)
    {
      if (!_entries.ContainsKey(propertyName))
        throw new Exception("Property " + propertyName + " was not found");
      return _entries[propertyName].ToAmount();
    }

    public Amount<T> GetAmount<T>(string propertyName) where T : IQuantity
    {
      if (!_entries.ContainsKey(propertyName))
        throw new Exception("Property " + propertyName + " was not found");
      return _entries[propertyName].ToAmount<T>();
    }

    public Amount GetAmountOrNull(string propertyName)
    {
      if (!_entries.ContainsKey(propertyName))
        return null;
      return _entries[propertyName].ToAmount();
    }

    public Amount<T> GetAmountOrNull<T>(string propertyName) where T : IQuantity
    {
      if (!_entries.ContainsKey(propertyName))
        return null;
      return _entries[propertyName].ToAmount<T>();
    }

    public bool TryGetAmount(string propertyName, out Amount value)
    {
      PropertyValue propertyValue;
      bool found = TryGetValue(propertyName, out propertyValue);
      value = found ? propertyValue.ToAmount() : default(Amount);
      return found;
    }

    public bool TryGetAmount<T>(string propertyName, out Amount<T> value) where T : IQuantity
    {
      value = null;
      PropertyValue propertyValue;
      bool found = TryGetValue(propertyName, out propertyValue);
      if (!found)
        return false;
      value = propertyValue.ToAmount<T>();
      return value != null;
    }

    public string GetText(string propertyName)
    {
      if (!_entries.ContainsKey(propertyName))
        throw new Exception("Property " + propertyName + " was not found");
      return _entries[propertyName].ToText();
    }

    public string GetTextOrNull(string propertyName)
    {
      if (!_entries.ContainsKey(propertyName))
        return null;
      return _entries[propertyName].ToText();
    }

    public bool TryGetText(string propertyName, out string value)
    {
      PropertyValue propertyValue;
      bool found = TryGetValue(propertyName, out propertyValue);
      value = found ? propertyValue.ToText() : default(string);
      return found;
    }

    public int GetInteger(string propertyName)
    {
      if (!_entries.ContainsKey(propertyName))
        throw new Exception("Property " + propertyName + " was not found");
      return _entries[propertyName].ToInteger();
    }

    public int? GetIntegerOrNull(string propertyName)
    {
      if (!_entries.ContainsKey(propertyName))
        return null;
      return _entries[propertyName].ToInteger();
    }

    public bool TryGetInteger(string propertyName, out int value)
    {
      PropertyValue propertyValue;
      bool found = TryGetValue(propertyName, out propertyValue);
      if (found == false || propertyValue.Type != PropertyType.Integer)
      {
        value = default(int);
        return false;
      }
      value = propertyValue.ToInteger();
      return found;
    }

    public PropertyValueSet AddPrefixToValues(string prefix)
    {
      var entries = new SafeDictionary<string, PropertyValue>(StringComparer.OrdinalIgnoreCase);
      foreach (var entry in _entries)
        entries.Add(prefix + entry.Key, entry.Value);
      return new PropertyValueSet(entries);
    }

    public PropertyValueSet GetValuesWithPrefix(string prefix, bool removePrefix = false)
    {
      var entries = new SafeDictionary<string, PropertyValue>(StringComparer.OrdinalIgnoreCase);
      foreach (var entry in _entries)
      {
        if (entry.Key.StartsWith(prefix))
          entries.Add(removePrefix ? entry.Key.Substring(prefix.Length) : entry.Key, entry.Value);
      }
      return new PropertyValueSet(entries);
    }

    public PropertyValueSet GetValuesWithoutPrefix(string prefix)
    {
      var entries = new SafeDictionary<string, PropertyValue>(StringComparer.OrdinalIgnoreCase);
      foreach (var entry in _entries)
      {
        if (!entry.Key.StartsWith(prefix))
          entries.Add(entry.Key, entry.Value);
      }
      return new PropertyValueSet(entries);
    }

    public int Count
    {
      get { return _entries.Count; }
    }

    public PropertyValueSet GetValuesOfType(PropertyType type)
    {
      var builder = new PropertyValueSetBuilder();
      foreach (var entry in _entries.Where(entry => entry.Value.Type == type))
        builder.Add(entry.Key, entry.Value);
      return builder.Build();
    }

    public PropertyValueSet GetProperties(IEnumerable<string> propertiesToGet)
    {
      if (propertiesToGet == null)
        return null;
      var builder = new PropertyValueSetBuilder();
      foreach (var property in propertiesToGet)
        if (_entries.ContainsKey(property))
          builder.Add(property, _entries[property]);
      return builder.Build();
    }

    public override string ToString()
    {
      return string.Join(";", _entries.Select(e => e.Key + "=" + e.Value));
    }

    // Need to have property getter for debug to work with untrusted assemblies
    private string DebugString
    {
      get { return ToString(); }
    }

    public string ToStringInSpecifiedOrder(IEnumerable<string> propertyNamesInOrder)
    {
      //return string.Join(";", order.Select(entry => entry + "=" + _entries[entry].ToString()));
      var sb = new StringBuilder();
      foreach (var propertyName in propertyNamesInOrder)
      {
        PropertyValue value;
        if (_entries.TryGetValue(propertyName, out value))
        {
          sb.Append(propertyName);
          sb.Append("=");
          sb.Append(value.ToString());
          sb.Append(";");
        }
      }
      if (sb.Length > 0)
        sb.Remove(sb.Length - 1, 1);
      return sb.ToString();
    }

    public bool InnerEquals(PropertyValueSet other)
    {
      if (ReferenceEquals(null, other))
        return false;
      if (ReferenceEquals(this, other))
        return true;

      foreach (var entry in _entries.Where(kvp => !kvp.Key.StartsWith("source_")))
      {
        if (entry.Value.Type == PropertyType.Text)
          continue;
        PropertyValue otherVal;
        if (other.TryGetValue(entry.Key, out otherVal) && !otherVal.Equals(entry.Value))
          return false;
      }
      return true;
    }

    public bool Equals(PropertyValueSet other)
    {
      if (ReferenceEquals(null, other))
        return false;
      if (ReferenceEquals(this, other))
        return true;
      if (_entries.Count != other._entries.Count)
        return false;
      if (GetHashCode() != other.GetHashCode())
        return false;

      foreach (var entry in _entries)
      {
        PropertyValue otherVal;
        if (!other.TryGetValue(entry.Key, out otherVal))
          return false;
        if (!otherVal.Equals(entry.Value))
          return false;
      }
      return true;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj))
        return false;
      if (ReferenceEquals(this, obj))
        return true;
      if (obj.GetType() != GetType())
        return false;
      return Equals((PropertyValueSet)obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        int hash = 0;
        foreach (var kvp in _entries)
        {
          hash = hash ^ kvp.Key.ToUpperInvariant().GetHashCode();
          hash = hash ^ kvp.Value.GetHashCode();
        }
        return hash;
      }
    }
  }
}