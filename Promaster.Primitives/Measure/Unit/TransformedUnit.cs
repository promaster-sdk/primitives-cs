using Promaster.Primitives.Measure.Quantity;
using Promaster.Primitives.Measure.Unit.Converters;

namespace Promaster.Primitives.Measure.Unit
{
  /// <summary>
  /// This class represents the units derived from other units using
  /// UnitConverter converters.
  ///   
  /// Examples of transformed units:
  ///       CELSIUS = KELVIN.add(273.15);
  ///       FOOT = METER.multiply(0.3048);
  ///       MILLISECOND = MILLI(SECOND); 
  /// 
  ///   
  /// Transformed units have no label. But like any other units,
  ///  they may have labels attached to them:
  ///       UnitFormat.getStandardInstance().label(FOOT, "ft");
  ///   
  ///   or aliases:
  ///       UnitFormat.getStandardInstance().alias(CENTI(METER)), "centimeter");
  ///       UnitFormat.getStandardInstance().alias(CENTI(METER)), "centimetre");
  /// 
  /// </summary>
  internal class TransformedUnit<T> : Unit<T> where T : IQuantity
  {

    // Holds the parent unit (not a transformed unit).
    private readonly Unit<T> _parentUnit;

    // Holds the converter to the parent unit.
    private readonly UnitConverter _toParentUnitConverter;

    /// <summary>
    /// Creates a transformed unit from the specified parent unit.
    /// </summary>
    /// <param name="parentUnit">the untransformed unit from which this unit is derived.</param>
    /// <param name="toParentUnitConverter">the converter to the parent units.</param>
    internal TransformedUnit(Unit<T> parentUnit, UnitConverter toParentUnitConverter) 
    {
      _parentUnit = parentUnit;
      _toParentUnitConverter = toParentUnitConverter;
    }

    /// <summary>
    /// Indicates if this transformed unit is considered equals to the specified 
    /// object (both are transformed units with equal parent unit and equal
    /// converter to parent unit).
    /// </summary>
    /// <param name="that">the object to compare for equality.</param>
    /// <returns>true if this and that are considered equals; false otherwise.</returns>
    public override bool Equals(Unit<T> that)
    {
      if (object.ReferenceEquals(this, that))
      {
        return true;
      }

      var thatTransformedUnit = that as TransformedUnit<T>;
      if ((thatTransformedUnit == null))
      {
        return false;
      }

      return this._parentUnit.Equals(thatTransformedUnit._parentUnit) && this._toParentUnitConverter.Equals(thatTransformedUnit._toParentUnitConverter);
    }

    // Implements abstract method.
    public override int GetHashCode()
    {
      return _parentUnit.GetHashCode() ^ _toParentUnitConverter.GetHashCode();
    }

    // Implements abstract method.
    internal override Unit StandardUnit
    {
      get { return _parentUnit.StandardUnit; }
    }

    // Implements abstract method.
    internal override UnitConverter ToStandardUnit()
    {
      return _parentUnit.ToStandardUnit().Concatenate(_toParentUnitConverter);
    }

    // Factory method
    protected override Unit<T> Transform(UnitConverter operation)
    {
      var tmptoparent = this._toParentUnitConverter.Concatenate(operation);
      if (object.ReferenceEquals(tmptoparent, UnitConverter.Identity))
      {
        return _parentUnit;
      }
      return new TransformedUnit<T>(_parentUnit, tmptoparent);
    }

  }

}

