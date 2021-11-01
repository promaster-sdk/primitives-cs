using System;
using System.Globalization;

namespace Promaster.Primitives.Portable.FloatingPoint
{
  /// <summary>
  ///   Double42 represents a floating point value with a 42-bit mantissa instead of the standard 52 that a regular Double has.
  /// </summary>
  public struct Double42 : IEquatable<Double42>, IComparable<Double42>
  {
    public Double42(double value)
    {
      _value = value;
    }

    public static implicit operator double(Double42 value)
    {
      return value._value;
    }

    public static implicit operator Double42(double value)
    {
      return new Double42(value);
    }

    public static bool operator ==(Double42 a, Double42 b)
    {
      return a.Equals(b);
    }

    public static bool operator !=(Double42 a, Double42 b)
    {
      return !a.Equals(b);
    }

    public static bool operator <(Double42 a, Double42 b)
    {
      if (double.IsNaN(a._value) || double.IsNaN(b._value))
        return false;
      return a.CompareTo(b) < 0;
    }

    public static bool operator <=(Double42 a, Double42 b)
    {
      if (double.IsNaN(a._value) && double.IsNaN(b._value))
        return true;
      if (double.IsNaN(a._value) || double.IsNaN(b._value))
        return false;
      return a.CompareTo(b) <= 0;
    }

    public static bool operator >(Double42 a, Double42 b)
    {
      if (double.IsNaN(a._value) || double.IsNaN(b._value))
        return false;
      return a.CompareTo(b) > 0;
    }

    public static bool operator >=(Double42 a, Double42 b)
    {
      if (double.IsNaN(a._value) && double.IsNaN(b._value))
        return true;
      if (double.IsNaN(a._value) || double.IsNaN(b._value))
        return false;
      return a.CompareTo(b) >= 0;
    }

    // IEquatable
    public bool Equals(Double42 other)
    {
      var a = new Binary64(_value);
      var b = new Binary64(other._value);

      if (a.IsNan && b.IsNan)
        return true;

      if (a.IsNan || b.IsNan)
        return false;

      // Round away the insignificant bits of both.
      a = a.Round(INSIGNIFICANT_BITS);
      b = b.Round(INSIGNIFICANT_BITS);

      return a.Bits == b.Bits;
    }

    // IComparable
    public int CompareTo(Double42 other)
    {

      Binary64 a = new Binary64(_value);
      Binary64 b = new Binary64(other._value);

      if (a.IsNan || b.IsNan)
      {
        throw new ArithmeticException("CompareTo cannot accept Nans.");
      }

      // Round away the insignificant bits of both.
      a = a.Round(INSIGNIFICANT_BITS);
      b = b.Round(INSIGNIFICANT_BITS);

      // Added by Jonas Kello 2013-10-14: 
      // Need to take care when comparing negative and positive numbers:
      // http://en.wikipedia.org/wiki/IEEE_754-1985:
      // "The binary representation has the special property that, excluding NaNs, any two numbers can be 
      // compared like sign and magnitude integers (although with modern computer processors this is no 
      // longer directly applicable): if the sign bit is different, the negative number precedes the 
      // positive number (except that negative zero and positive zero should be considered equal), otherwise, 
      // relative order is the same as lexicographical order but inverted for two negative numbers; endianness issues apply."
      long a_long = (long)a.Bits;
      long b_long = (long)b.Bits;
      unchecked
      {
        // Make the longs lexicographically ordered as a twos-complement longs
        if (a_long < 0)
          a_long = (long)Binary64.BITS_SIGN - a_long;
        if (b_long < 0)
          b_long = (long)Binary64.BITS_SIGN - b_long;
      }

      if (a_long < b_long)
        return -1;
      else if (a_long > b_long)
        return 1;
      else
        return 0;
    }

    public override bool Equals(object other)
    {
      if (other is double)
        return Equals((double)other);
      else if (other is Double42)
        return Equals((Double42)other);
      else
        return base.Equals(other);
    }

    public override int GetHashCode()
    {
      var a = new Binary64(_value);

      // Round away the insignificant bits.
      a = a.Round(INSIGNIFICANT_BITS);
      return a.GetHashCode();
    }

    public override string ToString()
    {
      return _value.ToString(CultureInfo.InvariantCulture);
    }

    public string ToString(IFormatProvider format)
    {
      return _value.ToString(format);
    }

    public Double42 NextRepresentableValue()
    {
      var a = new Binary64(_value);
      return a.NextRepresentableValue(INSIGNIFICANT_BITS).Value;
    }

    public Double42 PreviousRepresentableValue()
    {
      var a = new Binary64(_value);
      return a.PreviousRepresentableValue(INSIGNIFICANT_BITS).Value;
    }

    private readonly double _value;
    private static readonly Binary64InsignificantBits INSIGNIFICANT_BITS = 10;
  }
}