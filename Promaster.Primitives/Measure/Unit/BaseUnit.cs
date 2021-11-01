using Promaster.Primitives.Measure.Quantity;
using Promaster.Primitives.Measure.Unit.Converters;

namespace Promaster.Primitives.Measure.Unit
{

  /// <summary>
  /// This class represents the building blocks on top of which all others
  /// units are created. 
  /// This class represents the "standard base units" which includes SI base 
  /// units and possibly others user-defined base units. It does not represent 
  /// the base units of any specific System Of Units (they would have 
  /// be base units accross all possible systems otherwise).
  /// </summary>
  internal class BaseUnit<T> : Unit<T> where T : IQuantity
  {

    // Holds the unique symbol for this base unit.
    private readonly string _symbol;

    /// <summary>
    /// Creates a base unit having the specified symbol. 
    /// </summary>
    /// <param name="symbol">the symbol of this base unit.</param>
    public BaseUnit(string symbol)
    {
      _symbol = symbol;
    }

    ///// <summary>
    ///// Returns the unique symbol 
    ///// </summary>
    //public string Symbol
    //{
    //  get { return _symbol; }
    //}

    /// <summary>
    /// Indicates if this base unit is considered equals to the specified 
    /// object (both are base units with equal symbol, standard dimension and 
    /// standard transform).
    /// </summary>
    /// <param name="that">the object to compare for equality.</param>
    /// <returns>true if this and that are considered equals; false otherwise.</returns>
    public override bool Equals(Unit<T> that)
    {
      if (object.ReferenceEquals(this, that))
      {
        return true;
      }
      var that2 = that as BaseUnit<T>;
      if (that2 == null)
      {
        return false;
      }
      return _symbol.Equals(that2._symbol);
    }

    // Implements abstract method.
    public override int GetHashCode()
    {
      return _symbol.GetHashCode();
    }

    protected override string BuildDerivedName()
    {
      return _symbol;
    }

    // Implements abstract method.
    internal override UnitConverter ToStandardUnit()
    {
      return UnitConverter.Identity;
    }

    // Implements abstract method.
    internal override Unit StandardUnit
    {
      get { return this; }
    }

  }
}
