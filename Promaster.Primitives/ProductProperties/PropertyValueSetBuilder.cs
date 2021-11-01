using Promaster.Primitives.Collections;
using Promaster.Primitives.Measure;
using System;

namespace Promaster.Primitives.ProductProperties
{
  public class PropertyValueSetBuilder : SafeDictionary<string, PropertyValue>
  {
    public PropertyValueSetBuilder()
      : base(StringComparer.OrdinalIgnoreCase)
    {
    }

    public PropertyValueSetBuilder(PropertyValueSet existingValueSet)
      : base(StringComparer.OrdinalIgnoreCase)
    {
      if (existingValueSet == null)
        return;
      foreach (var keyValuePair in existingValueSet.ToDictionary())
        Add(keyValuePair.Key, keyValuePair.Value);
    }

    public void Add(string name, Amount value)
    {
      if (value != null)
        Add(name, new PropertyValue(value));
    }

    public void Add(string name, string value)
    {
      if (value != null)
        Add(name, new PropertyValue(value));
    }

    public void Add(string name, int value)
    {
      Add(name, new PropertyValue(value));
    }

    public void AddOrUpdate(PropertyValueSet properties)
    {
      if (properties == null)
        return;
      foreach (var property in properties.ToDictionary())
        AddOrUpdate(property.Key, property.Value);
    }

    public void AddOrUpdate(string name, int value)
    {
      this[name] = new PropertyValue(value);
    }

		public void AddOrUpdate(string name, Amount value)
		{
		  this[name] = new PropertyValue(value);
		}

    public void AddOrUpdate(string name, string value)
    {
      this[name] = new PropertyValue(value);
    }

    public void AddOrUpdate(string name, PropertyValue value)
    {
      this[name] = value;
    }

    public void AddWithPrefix(PropertyValueSet set, string prefix)
    {
      if (set == null)
        return;

      foreach (var keyValuePair in set.ToDictionary())
        this[prefix + keyValuePair.Key] = keyValuePair.Value;
    }

    public void Add(PropertyValueSet set)
    {
      if (set == null)
        return;

      foreach (var keyValuePair in set.ToDictionary())
        this[keyValuePair.Key] = keyValuePair.Value;
    }

    public PropertyValueSet Build()
    {
      var dict = new SafeDictionary<string, PropertyValue>(StringComparer.OrdinalIgnoreCase);
      foreach (var kvp in this)
        dict[kvp.Key] = kvp.Value;
      return new PropertyValueSet(dict);
    }
  }
}
