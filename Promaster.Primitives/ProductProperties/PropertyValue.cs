using System;
using System.Globalization;
using Promaster.Primitives.Measure;
using Promaster.Primitives.Measure.Unit;
using Promaster.Primitives.Measure.Quantity;

namespace Promaster.Primitives.ProductProperties
{
  public class PropertyValue : IComparable<PropertyValue>
  {
    private readonly PropertyType _type;
    private readonly object _value;

    /// <summary>
    /// String-values are in a serialized format (with enclosing quotation marks etc.).
    /// </summary>
    /// <param name="encodedValue"></param>
    /// <returns></returns>
    public static PropertyValue Parse(string encodedValue)
    {
      var pv = FromSerializedStringOrNullIfInvalidString(encodedValue);
      if (pv == null)
        throw new Exception("Invalid PropertyValue string.");
      return pv;
    }

    public static bool TryParse(string encodedValue, out PropertyValue result)
    {
      result = FromSerializedStringOrNullIfInvalidString(encodedValue);
      if (result != null)
        return true;
      else
        return false;
    }

    /// <summary>
    /// RULES:
    /// 
    /// Strings-values *MUST* be enclosed in double quote (") and if they contains 
    /// double quote (") characters they *MUST* be encoded as %22. 
    /// No other encodings are supported.
    /// 
    /// Integer-values should not be enclosed in quotation marks.
    /// 
    /// Amount-values must be in format Value:Unit without quotation marks.
    /// </summary>
    /// <param name="encodedValue"></param>
    /// <returns></returns>
    private static PropertyValue FromSerializedStringOrNullIfInvalidString(string encodedValue)
    {
      PropertyValue deserializedValue;
      if (encodedValue.StartsWith("\"") && encodedValue.EndsWith("\""))
      {
        var valueString = DecodeFromSafeString(encodedValue);
        deserializedValue = new PropertyValue(valueString);
      }
      else if (encodedValue.Contains(":"))
      {
        var split2 = encodedValue.Split(':');
        var unitString = split2[1];
        if (unitString.ToLowerInvariant() == "text")
        {
          // **** OBSOLETE BEGIN - WE ONLY SUPPORT ":TEXT" AS STRING FOR BACKWARDS COMPABILITY, ENCLOSE IN double quote (") instead! ****
          var unsafeString = DecodeFromSafeString(split2[0]);
          deserializedValue = new PropertyValue(unsafeString);
          // **** OBSOLETE END ****
        }
        else if (unitString.ToLowerInvariant() == "integer")
        {
          int integerValue;
          if (!int.TryParse(split2[0], NumberStyles.Number, CultureInfo.InvariantCulture, out integerValue))
          {
            throw new Exception("Invalid integer value.");
          }
          deserializedValue = new PropertyValue(integerValue);
        }
        else
        {
          double doubleValue;
          if (!double.TryParse(split2[0], NumberStyles.Float, CultureInfo.InvariantCulture, out doubleValue))
            return null;
          if (!Units.IsUnit(unitString))
            return null;
          var unit = Units.Parse(unitString);
          deserializedValue = new PropertyValue(Amount.Exact(doubleValue, unit));
        }
      }
      else
      {
        int integerValue;
        if (int.TryParse(encodedValue, NumberStyles.Number, CultureInfo.InvariantCulture, out integerValue))
          return new PropertyValue(integerValue);

        double doubleValue;
        if (double.TryParse(encodedValue, NumberStyles.Number, CultureInfo.InvariantCulture, out doubleValue))
          return new PropertyValue(Amount.Exact(doubleValue, Units.One));

        return new PropertyValue(encodedValue);
      }
      return deserializedValue;
    }

    public PropertyValue(Amount value)
    {
      if (value == null)
        throw new ArgumentNullException("value");
      var discreteAmount = value as Amount<IDiscrete>;
      if (discreteAmount != null)
      {
        _value = (int)discreteAmount.ValueAs(Units.Integer);
        _type = PropertyType.Integer;
      }
      else
      {
        _value = value;
        _type = PropertyType.Amount;
      }
    }

    /// <summary>
    /// NOTE: The string value should *NOT* be encoded in any way (such as being enclosed in 
    /// quotation marks or having quotation marks encoded as %22). If you want to create
    /// a value from a string that is encoded then use the Parse() or TryParse() methods instead.
    /// </summary>
    public PropertyValue(string value)
    {
      if (value == null)
        throw new ArgumentNullException("value");
      _value = value;
      _type = PropertyType.Text;
    }

    public PropertyValue(int value)
    {
      _value = value;
      _type = PropertyType.Integer;
    }

    public PropertyType Type
    {
      get { return _type; }
    }

    public object Value
    {
      get { return _value; }
    }

    public Amount ToAmount()
    {
      return (Amount)_value;
    }

    public Amount<T> ToAmount<T>() where T : IQuantity
    {
      return (Amount<T>)_value;
    }

    public string ToText()
    {
      return (string)_value;
    }

    public int ToInteger()
    {
      return (int)_value;
    }

    public int? GetIntegerOrNull()
    {
      return _value as int?;
    }

    public Amount GetAmountOrNull()
    {
      return _value as Amount;
    }

    public string GetTextOrNull()
    {
      return _value as string;
    }

    public static bool operator <(PropertyValue a, PropertyValue b)
    {
      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        return true;
      if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        return false;
      if (a.Type != b.Type)
        return false;

      return a.CompareTo(b) < 0;
    }

    public static bool operator <=(PropertyValue a, PropertyValue b)
    {
      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        return true;
      if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        return false;
      if (a.Type != b.Type)
        return false;

      return a.CompareTo(b) <= 0;
    }

    public static bool operator >(PropertyValue a, PropertyValue b)
    {
      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        return true;
      if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        return false;
      if (a.Type != b.Type)
        return false;

      return a.CompareTo(b) > 0;
    }

    public static bool operator >=(PropertyValue a, PropertyValue b)
    {
      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        return true;
      if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        return false;
      if (a.Type != b.Type)
        return false;

      return a.CompareTo(b) >= 0;
    }

    public static PropertyValue operator +(PropertyValue a, PropertyValue b)
    {
      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        return null;
      if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        return null;
      if (a.Type != b.Type)
        throw new Exception("Cannot add values " + a + " and " + b);
      if (a.Type == PropertyType.Integer)
        return new PropertyValue(a.ToInteger() + b.ToInteger());
      if (a.Type == PropertyType.Amount)
        return new PropertyValue(a.ToAmount() + b.ToAmount());
      return new PropertyValue(a.ToText() + b.ToText());
    }

    public static PropertyValue operator -(PropertyValue a, PropertyValue b)
    {
      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        return null;
      if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        return null;
      if (a.Type != b.Type)
        throw new Exception("Cannot subtract values " + a + " and " + b);
      if (a.Type == PropertyType.Integer)
        return new PropertyValue(a.ToInteger() - b.ToInteger());
      if (a.Type == PropertyType.Amount)
        return new PropertyValue(a.ToAmount() - b.ToAmount());
      throw new Exception("Cannot subract strings " + a.ToText() + " and " + b.ToText());
    }

    public static PropertyValue operator *(PropertyValue a, PropertyValue b)
    {
      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        return null;
      if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        return null;
      if (a.Type == PropertyType.Text || b.Type == PropertyType.Text)
        throw new Exception("Cannot multiply " + a + " and " + b);
      if (a.Type == PropertyType.Integer && b.Type == PropertyType.Integer)
        return new PropertyValue(a.ToInteger() * b.ToInteger());
      if (a.Type == PropertyType.Integer)
        return new PropertyValue(a.ToInteger() * b.ToAmount());
      if (b.Type == PropertyType.Integer)
        return new PropertyValue(a.ToAmount() * b.ToInteger());
      return new PropertyValue(a.ToAmount() * b.ToAmount());
    }

    public static PropertyValue operator /(PropertyValue a, PropertyValue b)
    {
      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        return null;
      if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        return null;
      if (a.Type == PropertyType.Text || b.Type == PropertyType.Text)
        throw new Exception("Cannot divide " + a + " and " + b);
      if (a.Type == PropertyType.Integer && b.Type == PropertyType.Integer)
        return new PropertyValue(a.ToInteger() / b.ToInteger());
      if (a.Type == PropertyType.Integer)
        return new PropertyValue(a.ToInteger() / b.ToAmount());
      return new PropertyValue(a.ToAmount() / b.ToInteger());
    }

    public static PropertyValue operator %(PropertyValue a, PropertyValue b)
    {
      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        return null;
      if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        return null;
      if (a.Type == PropertyType.Text || b.Type == PropertyType.Text)
        throw new Exception("Cannot modulo " + a + " and " + b);
      if (a.Type == PropertyType.Integer && b.Type == PropertyType.Integer)
        return new PropertyValue(a.ToInteger() % b.ToInteger());
      if (a.Type == PropertyType.Integer)
        return new PropertyValue(a.ToInteger() % b.ToAmount());
      return new PropertyValue(a.ToAmount() % b.ToInteger());
    }

    public static PropertyValue operator -(PropertyValue a)
    {
      if (ReferenceEquals(a, null))
        return null;
      if (a.Type == PropertyType.Text)
        throw new Exception("Cannot negate " + a);
      if (a.Type == PropertyType.Integer)
        return new PropertyValue(-a.ToInteger());
      return new PropertyValue(-a.ToAmount());
    }

    public int CompareTo(PropertyValue other)
    {
      if (_type != other._type)
        throw new Exception("Cannot compare two property values of different type");

      switch (_type)
      {
        case PropertyType.Integer:
          return ToInteger().CompareTo(other.ToInteger());
        case PropertyType.Amount:
          return ToAmount().CompareTo(other.ToAmount());
        case PropertyType.Text:
          return String.Compare(ToText(), other.ToText(), StringComparison.OrdinalIgnoreCase);
        default:
          throw new Exception("Unknown property type");
      }
    }

    public double ValueAs(Unit unit)
    {
      var amount = ToAmount();
      var mi = amount.GetType().GetMethod("ValueAs");
      double value = (double)mi.Invoke(amount, new object[] { unit });
      return value;
    }

    public override string ToString()
    {
      if (_type == PropertyType.Amount)
      {
        var amountValue = this.ToAmount();
        var valueString = amountValue.Value.ToString(CultureInfo.InvariantCulture);
        var unitString = Units.GetStringFromUnit(amountValue.Unit);
        return valueString + ':' + unitString;
      }
      else if (_type == PropertyType.Text)
      {
        return EncodeToSafeString(ToText());
      }
      else if (_type == PropertyType.Integer)
      {
        return this.ToInteger().ToString(CultureInfo.InvariantCulture);
      }
      throw new Exception("Invalid type.");
    }

    private static string EncodeToSafeString(string unsafeString)
    {
      // We use '"' to enclose a string so it must be encoded as %22 inside strings
      if (unsafeString == null)
        return "";
      var safeString = unsafeString;
      safeString = safeString.Replace("\"", "%22");
      return "\"" + safeString + "\"";
    }

    private static string DecodeFromSafeString(string safeString)
    {
      // We use '"' to enclose a string so it must be encoded as %22 inside strings
      var unsafeString = safeString.Trim('"');
      unsafeString = unsafeString.Replace("%22", "\"");

      // **** OBSOLETE BEGIN - WE ONLY SUPPORT DECODING OF THESE CHARS FOR BACKWARDS COMPABILITY ****
      unsafeString = unsafeString.Replace("%3B", ";");
      unsafeString = unsafeString.Replace("%3D", "=");
      unsafeString = unsafeString.Replace("%3A", ":");
      // **** OBSOLETE END ****

      return unsafeString;
    }

    protected bool Equals(PropertyValue other)
    {
      return _type == other._type && Equals(_value, other._value);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((PropertyValue)obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return ((int)_type * 397) ^ (_value != null ? _value.GetHashCode() : 0);
      }
    }

    public static bool operator ==(PropertyValue left, PropertyValue right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(PropertyValue left, PropertyValue right)
    {
      return !Equals(left, right);
    }

    //protected bool Equals(PropertyValue other)
    //{
    //  if (!_type.Equals(other._type))
    //    return false;
    //  if (_type == PropertyType.Integer)
    //    return ToInteger() == other.ToInteger();
    //  if (_type == PropertyType.Text)
    //    return ToText() == other.ToText();
    //  var a = ToAmount();
    //  var b = other.ToAmount();
    //  return a.Equals(b);
    //}

    //public override bool Equals(object obj)
    //{
    //  if (ReferenceEquals(null, obj)) return false;
    //  if (ReferenceEquals(this, obj)) return true;
    //  if (obj.GetType() != this.GetType()) return false;
    //  return Equals((PropertyValue)obj);
    //}

    //public override int GetHashCode()
    //{
    //  unchecked
    //  {
    //    return (_type.GetHashCode() * 397) ^ (_value != null ? _value.GetHashCode() : 0);
    //  }
    //}

  }

}
