using System;

namespace Promaster.Primitives.Measure.Unit.Converters
{
  public abstract partial class UnitConverter
  {
    /// <summary>
    /// Inner class OffsetConverter
    /// </summary>
    private class OffsetConverter : UnitConverter
    {
      private readonly double _offset;

      public OffsetConverter(double offset)
      {
        //Debug.Assert(offset != 0.0);
        _offset = offset;
      }

      public override double Convert(double value)
      {
        return value + _offset;
      }

      public override UnitConverter Concatenate(UnitConverter converter)
      {
        var other = converter as OffsetConverter;
        if (other != null)
        {
          if (Math.Abs(_offset - other._offset) > double.Epsilon)
          {
            return new OffsetConverter(_offset + other._offset);
          }
          return Identity;
        }
        return base.Concatenate(converter);
      }

      public override UnitConverter Inverse
      {
        get { return new OffsetConverter(-_offset); }
      }

      public override int GetHashCode()
      {
        return _offset.GetHashCode();
      }
    }

  }
}