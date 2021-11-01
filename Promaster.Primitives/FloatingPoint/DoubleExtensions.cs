using System;

namespace Promaster.Primitives.Portable.FloatingPoint
{
  public static class DoubleExtensions
  {
    public static bool NearEquals(this double value, double other)
    {
      return Math.Abs(value - other) < 0.000001;
    }

    public static int ToInt(this double value)
    {
      return (0 < value) ? (int) (value + 0.5) : (int) (value - 0.5);
    }

    public static Sign GetSign(this double value)
    {
      return ((Binary64) value).Sign;
    }

    public static Binary64Exponent GetExponent(this double value)
    {
      return ((Binary64) value).Exponent;
    }

    public static Binary64Significand GetSignificand(this double value)
    {
      return ((Binary64) value).Significand;
    }

    public static bool GetIsNan(this double value)
    {
      return ((Binary64) value).IsNan;
    }

    public static bool GetIsInfinite(this double value)
    {
      return ((Binary64) value).IsInfinite;
    }

    public static bool IsNaNOrInfinity(this double value)
    {
      return double.IsNaN(value) || double.IsInfinity(value);
    }

    public static double GetNextRepresentableValue(this double value, Binary64InsignificantBits insignificantBits)
    {
      return ((Binary64) value).NextRepresentableValue(insignificantBits);
    }

    public static double GetPreviousRepresentableValue(this double value, Binary64InsignificantBits insignificantBits)
    {
      return ((Binary64) value).PreviousRepresentableValue(insignificantBits);
    }

    public static double RoundInsignificantBits(this double value, Binary64InsignificantBits insignificantBits)
    {
      return ((Binary64) value).Round(insignificantBits);
    }
  }
}