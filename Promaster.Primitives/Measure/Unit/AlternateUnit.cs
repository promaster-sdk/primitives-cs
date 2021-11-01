using Promaster.Primitives.Measure.Quantity;
using Promaster.Primitives.Measure.Unit.Converters;
using System;

namespace Promaster.Primitives.Measure.Unit
{

  /// <summary>
  /// This class represents the units used in expressions to distinguish
  /// between quantities of a different nature but of the same dimensions.
  /// 
  /// Instances of this class are created through the 
  /// {@link Unit#alternate(String)} method.
  /// </summary>
  internal class AlternateUnit<T> : Unit<T> where T : IQuantity
  {

    // Holds the symbol.
    private readonly string _symbol;

    // Holds the parent unit (a system unit).
    private readonly Unit _parent;

    /// <summary>
    /// Creates an alternate unit for the specified unit identified by the 
    /// specified symbol. 
    /// </summary>
    /// <param name="symbol">the symbol for this alternate unit.</param>
    /// <param name="parent">parent the system unit from which this alternate unit is derived.</param>
    public AlternateUnit(string symbol, Unit parent)
    {

      //if (!parent.IsStandardUnit())
      //  throw new InvalidOperationException(this.ToString() + " is not a standard unit");

      _symbol = symbol;
      _parent = parent;


       // Checks if the symbol is associated to a different unit.
        //synchronized (Unit.SYMBOL_TO_UNIT) {
        //    Unit<?> unit = Unit.SYMBOL_TO_UNIT.get(symbol);
        //    if (unit == null) {
        //        Unit.SYMBOL_TO_UNIT.put(symbol, this );
        //        return;
        //    }
        //    if (unit instanceof  AlternateUnit) {
        //        AlternateUnit<?> existingUnit = (AlternateUnit<?>) unit;
        //        if (symbol.equals(existingUnit._symbol)
        //                && _parent.equals(existingUnit._parent))
        //            return; // OK, same unit.
        //    }
        //    throw new IllegalArgumentException("Symbol " + symbol
        //            + " is associated to a different unit");
    }

    /// <summary>
    /// Indicates if this alternate unit is considered equals to the specified 
    /// object (both are alternate units with equal symbol, equal base units
    /// and equal converter to base units).
    /// </summary>
    /// <param name="that">the object to compare for equality.</param>
    /// <returns>true if this and that are considered equals; false otherwise.</returns>
    public override bool Equals(Unit<T> that)
    {
      if (object.ReferenceEquals(this, that))
      {
        return true;
      }
      var that2 = that as AlternateUnit<T>;
      if (that2 == null)
      {
        return false;
      }
      return this._symbol.Equals(that2._symbol);
    }

    // Implements abstract method.
    public override int GetHashCode()
    {
      return _symbol.GetHashCode();
    }

    // Implements abstract method.
    internal override Unit StandardUnit
    {
      get { return this; }
    }

    // Implements abstract method.
    internal override UnitConverter ToStandardUnit()
    {
      return _parent.ToStandardUnit();
    }

    protected override string BuildDerivedName()
    {
      return _symbol;
    }

  }
}

