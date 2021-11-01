using System;
using Promaster.Primitives.Portable.FloatingPoint;

namespace Promaster.Primitives.Measure.Unit.Converters
{
  public abstract partial class UnitConverter
  {

    /// <summary>
    /// Inner class FactorConverter
    /// </summary>
    private class FactorConverter : UnitConverter
    {
      private readonly double _factor;

      public FactorConverter(double factor)
      {
        // Must be casted to function with Mac
        if (factor == (Double42)1.0)
          throw new ArgumentException("factor " + factor.ToString());
        _factor = factor;
      }

      public override double Convert(double value)
      {
        return value * _factor;
      }

      public override UnitConverter Concatenate(UnitConverter converter)
      {
        var factorConverter = converter as FactorConverter;
        if (factorConverter != null)
        {
          var f = _factor * factorConverter._factor;
          // Must be casted to function with Mac
          if (f == (Double42)1.0)
            return Identity;
          return new FactorConverter(f);
        }

        return base.Concatenate(converter);
      }

      public override UnitConverter Inverse
      {
        get { return new FactorConverter(1.0 / _factor); }
      }

      public override int GetHashCode()
      {
        return _factor.GetHashCode();
      }
    }

  }
}