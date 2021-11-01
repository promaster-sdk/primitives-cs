using System;
using System.Collections.Generic;
using System.Diagnostics;
using Promaster.Primitives.Measure.Quantity;
using Promaster.Primitives.Measure.Unit.Converters;
//using System.Linq;

namespace Promaster.Primitives.Measure.Unit
{
  /// <summary>
  /// This class represents a determinate quantity (as of length, time, heat, or value) 
  /// adopted as a standard of measurement.
  ///
  /// It is helpful to think of instances of this class as recording the history by which 
  /// they are created. Thus, for example, the string "g/kg" (which is a dimensionless unit) 
  /// would result from invoking the method toString() on a unit that was created by 
  /// dividing a gram unit by a kilogram unit. Yet, "kg" divided by "kg" returns ONE and 
  /// not "kg/kg" due to automatic unit factorization.
  ///
  /// This class supports the multiplication of offsets units. The result is usually a unit 
  /// not convertible to its standard unit. Such units may appear in derivative quantities. 
  /// For example °C/m is an unit of gradient, which is common in atmospheric and oceanographic research.
  ///
  /// Units raised at rational powers are also supported. For example the cubic root of liter 
  /// is a unit compatible with meter.
  ///
  /// Instances of this class and sub-classes are immutable.
  /// </summary>
  public abstract class Unit : IEquatable<Unit>
  {
    private static readonly string _labelLock = new string(' ', 0);

    /// <summary>
    /// We keep a global repository of Labels becasue if a Unit object is derived from arithmetic operations
    /// it may still be considered equal to an existing unit and thus should have the same label.
    /// </summary>
    private static readonly Dictionary<Unit, string> _typeLabels = new Dictionary<Unit, string>();
    private readonly IList<Element> _elements;

    internal Unit()
    {
      // Init elements to standard, some other constructors can override this by re-setting _elements
      _elements = new List<Element>();
      _elements.Add(new Element(this, 1));
    }

    public string Label
    {
      get
      {
        foreach (var k in _typeLabels)
        {
          if (k.Key.Equals(this))
          {
            return k.Value;
          }
        }
        return null;
      }
      set
      {
        lock (_labelLock)
        {
          //if (_typeLabels.ContainsKey(this))
          //  throw new Exception(string.Format("Label registry already contains a Unit that is equal to {0}.", value.ToString()));
          _typeLabels[this] = value;
        }
      }
    }

    /// <summary>
    /// Creates a ProductUnit.
    /// </summary>
    internal Unit<TResult> Times<TResult>(Unit u) where TResult : IQuantity
    {
      return ProductUnit<TResult>.Product(this, u);
    }

    /// <summary>
    /// Creates a ProductUnit.
    /// </summary>
    internal Unit<TResult> Divide<TResult>(Unit u) where TResult : IQuantity
    {
      return ProductUnit<TResult>.Quotient(this, u);
    }

    public abstract string Name { get; }

    /// <summary>
    /// Returns the BaseUnit, AlternateUnit or product of base units 
    /// and alternate units this unit is derived
    /// from. The standard unit identifies the "type" of 
    /// Quantity for which this unit is employed.
    /// </summary>
    internal abstract Unit StandardUnit { get; }

    /// <summary>
    /// Returns the converter from this unit to its system unit.
    /// </summary>
    internal abstract UnitConverter ToStandardUnit();

    /// <summary>
    /// Indicates if this unit is a standard unit (base units and 
    /// alternate units are standard units). The standard unit identifies 
    /// the "type" of {@link javax.measure.quantity.Quantity quantity} for 
    /// which the unit is employed.
    /// </summary>
    /// <returns><code>getStandardUnit().equals(this)</code></returns>
    public bool IsStandardUnit()
    {
      return this.StandardUnit.Equals(this);
    }

    /// <summary>
    /// Returns a converter of numeric values from this unit to another unit.
    /// </summary>
    /// <param name="that">the unit to which to convert the numeric values.</param>
    /// <returns>the converter from this unit to <code>that</code> unit.</returns>
    public UnitConverter GetConverterTo(Unit that)
    {
      if (this.Equals(that))
      {
        return UnitConverter.Identity;
      }
      return that.ToStandardUnit().Inverse.Concatenate(this.ToStandardUnit());
    }

    // ProductUnit overrides this because it has multiple elements
    internal virtual IList<Element> Elements
    {
      get
      {
        //if (_elements == null)
        //{
        //  _elements = new List<Element>();
        //  _elements.Add(new Element(this, 1));
        //}
        return _elements;
      }
    }

    public override string ToString()
    {
      return this.Name;
    }

    public abstract Type GetQuantityType();

    #region Equality members

    public bool Equals(Unit other)
    {
      if (ReferenceEquals(null, other))
        return false;
      if (ReferenceEquals(this, other))
        return true;
      return Equals(_elements, other._elements);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj))
        return false;
      if (ReferenceEquals(this, obj))
        return true;
      if (obj.GetType() != this.GetType())
        return false;
      return Equals((Unit)obj);
    }

    public override int GetHashCode()
    {
      int result = 0;
      foreach (var e in _elements)
      {
        result = result ^ e.GetHashCode();
      }
      return result;
    }

    #endregion
  }

  /// <summary>
  /// This class represents a determinate Quantity
  /// (as of length, time, heat, or value) adopted as a standard
  /// of measurement.
  /// 
  /// It is helpful to think of instances of this class as recording the
  /// history by which they are created. Thus, for example, the string
  /// "g/kg" (which is a dimensionless unit) would result from invoking
  /// the method toString() on a unit that was created by dividing a
  /// gram unit by a kilogram unit. Yet, "kg" divided by "kg" returns
  /// ONE and not "kg/kg" due to automatic unit factorization.
  /// 
  /// This class supports the multiplication of offsets units. The result is
  /// usually a unit not convertible to its standard unit.
  /// Such units may appear in derivative quantities. For example °C/m is an 
  /// unit of gradient, which is common in atmospheric and oceanographic
  /// research.
  /// 
  /// Units raised at rational powers are also supported. For example
  /// the cubic root of "liter" is a unit compatible with meter.
  /// 
  /// Instances of this class are immutable.
  /// </summary>
  [DebuggerDisplay("Unit ({Name})")]
  public abstract class Unit<T> : Unit, IEquatable<Unit<T>> where T : IQuantity
  {
    ///// <summary>
    ///// Holds the dimensionless unit ONE
    ///// </summary>
    //public static readonly Unit<T> One = new ProductUnit<T>();

    internal Unit()
      : base()
    {
    }

    /// <summary>
    /// Indicates if the specified unit can be considered equals to 
    /// the one specified.
    /// </summary>
    /// <param name="that">the object to compare to</param>
    /// <returns>true if this unit is considered equal to that unit; false otherwise.</returns>
    public virtual bool Equals(Unit<T> that)
    {
      return (ReferenceEquals(this, that));
    }


    public override Type GetQuantityType()
    {
      return typeof (T);
    }

    /// <summary>
    /// Untyped version of Equals that forwards to typed version of Equals.
    /// </summary>
    /// <param name="that">the object to compare to</param>
    /// <returns>true if this unit is considered equal to that unit; false otherwise.</returns>
    public override bool Equals(object that)
    {
      return this.Equals(that as Unit<T>);
    }

    // Implements abstract method.
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override string Name
    {
      get { return this.Label ?? this.BuildDerivedName(); }
    }

    protected virtual string BuildDerivedName()
    {
      return string.Empty;
    }

    internal Unit<T> WithLabel(string label)
    {
      base.Label = label;
      return this;
    }

    ///// <summary>
    ///// Creates a ProductUnit.
    ///// </summary>
    //internal Unit<TResult> Times<TResult>(Unit u) where TResult : IQuantity
    //{
    //  return ProductUnit<TResult>.Product(this, u);
    //}

    ///// <summary>
    ///// Creates a ProductUnit.
    ///// </summary>
    //internal Unit<TResult> Divide<TResult>(Unit u) where TResult : IQuantity
    //{
    //  return ProductUnit<TResult>.Quotient(this, u);
    //}

    /// <summary>
    /// Returns the unit derived from this unit using the specified converter.
    /// The converter does not need to be linear.
    /// </summary>
    /// <param name="operation">the converter from the transformed unit to this unit.</param>
    /// <returns>the unit after the specified transformation.</returns>
    protected virtual Unit<T> Transform(UnitConverter operation)
    {
      if (ReferenceEquals(operation, UnitConverter.Identity))
      {
        return this;
      }
      return new TransformedUnit<T>(this, operation);
    }

    ///// <summary>
    ///// Returns a unit equals to this unit raised to an exponent.
    ///// </summary>
    ///// <param name="n">the exponent.</param>
    ///// <returns>the result of raising this unit to the exponent.</returns>
    //public Unit<T> Pow(int n)
    //{
    //  if (n > 0)
    //  {
    //    return this.Times<T>(this.Pow(n - 1));
    //  }
    //  else if (n == 0)
    //  {
    //    //return Units.One;
    //    throw new InvalidOperationException("Invalid power.");
    //  }
    //  else // n < 0
    //  { 
    //    return Units.One.Divide<T>(this.Pow(-n));
    //  }
    //}

    // Operator overload
    public static Unit<T> operator *(Unit<T> u, double factor)
    {
      return u.Transform(UnitConverter.Factor(factor));
    }

    // Operator overload
    public static Unit<T> operator *(double factor, Unit<T> u)
    {
      return u.Transform(UnitConverter.Factor(factor));
    }

    // Operator overload
    public static Unit<T> operator /(Unit<T> u, double factor)
    {
      return u.Transform(UnitConverter.Factor(1.0 / factor));
    }

    // Operator overload
    public static Unit<T> operator /(double factor, Unit<T> u)
    {
      return u.Transform(UnitConverter.Factor(1.0 / factor));
    }

    // Operator overload
    public static Unit<T> operator +(Unit<T> u, double offset)
    {
      return u.Transform(UnitConverter.Offset(offset));
    }

    // Operator overload
    public static Unit<T> operator +(double offset, Unit<T> u)
    {
      return u.Transform(UnitConverter.Offset(offset));
    }

    // Operator overload
    public static Unit<T> operator -(Unit<T> u, double offset)
    {
      return u.Transform(UnitConverter.Offset(-offset));
    }

    // Operator overload
    public static Unit<T> operator -(double offset, Unit<T> u)
    {
      return u.Transform(UnitConverter.Offset(-offset));
    }
  }
}