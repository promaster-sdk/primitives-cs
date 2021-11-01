using System;
using System.Diagnostics;
using System.Linq;
using Promaster.Primitives.Measure.Quantity;
using Promaster.Primitives.Measure.Unit;
using System.Collections.Generic;
using System.Reflection;
using Promaster.Primitives.Portable.FloatingPoint;

namespace Promaster.Primitives.Measure
{
  internal static class AmountGenericMethodCache
  {
    static AmountGenericMethodCache()
    {
      var allMethods = typeof(Amount).GetMethods(BindingFlags.Public | BindingFlags.Static);
      var exactGenericMethod = allMethods.Single(m => m.Name == "Exact" && m.GetGenericArguments().Length == 1);

      foreach (var quantityType in Assembly.GetExecutingAssembly().GetExportedTypes().Where(t => typeof(IQuantity).IsAssignableFrom(t)))
      {
        var genericMethod = exactGenericMethod.MakeGenericMethod(quantityType);
        Exact.Add(quantityType, genericMethod);
      }
    }

    internal static readonly Dictionary<Type, MethodInfo> Exact = new Dictionary<Type, MethodInfo>();
  }

  [DebuggerDisplay("Amount {_value}, {_unit}")]
  public abstract class Amount : IComparable<Amount>, IComparable
  {
    protected readonly double _value;
    protected readonly Unit.Unit _unit;

    protected Amount(double value, Unit.Unit unit)
    {
      if (unit == null)
        throw new ArgumentException("unit");
      if (double.IsNaN(value) || double.IsInfinity(value))
        throw new ArgumentException("value");

      // Always create the Amount using the same unit as internal storage unit
      // to avoid incorrect additions when adding delta values. Eg. 10 Celsius + 30 Fahrenheit 
      // where the latter is considered a delta.

      var storageUnit = AmountStorageUnit.GetStorageUnit(GetQuantityType(unit));
      var converter = unit.GetConverterTo(storageUnit);
      _value = converter.Convert(value);
      _unit = storageUnit;

    }

    //public static Unit.Unit GetStorageUnit(Type quantityType)
    //{
    //  return AmountStorageUnit.GetStorageUnit(quantityType);
    //}

    /// <summary>
    /// Create this way if you need to create without generic parameter.
    /// </summary>
    public static Amount Exact(double value, Unit.Unit unit)
    {
      var quantityType = GetQuantityType(unit);
      MethodInfo genericMethod;

      if (!AmountGenericMethodCache.Exact.TryGetValue(quantityType, out genericMethod))
        throw new Exception("Could not find Amount.Exact<T> method");

      var amount = (Amount)genericMethod.Invoke(null, new object[] { value, unit });
      return amount;
    }

    public double ValueAsNonGeneric(Unit.Unit toUnit)
    {
      return _unit.GetConverterTo(toUnit).Convert(_value);
    }

    /// <summary>
    /// Creates an amount that represents the an exact/absolute value in the specified 
    /// unit. For example if you create an exact amount of 2 degrees Fahrenheit that 
    /// will represent -16.6666667 degrees Celsius.
    /// </summary>
    public static Amount<T> Exact<T>(double value, Unit<T> unit) where T : IQuantity
    {
      return new Amount<T>(value, unit);
    }

    /// <summary>
    /// Creates an amount that represents the a delta value in the specified 
    /// unit. For example if you create a delta amount of 2 degrees Fahrenheit that 
    /// will represent 1.11111 degrees Celsius.
    /// </summary>
    public static Amount<T> Delta<T>(double value, Unit<T> unit) where T : IQuantity
    {
      var storageUnit = AmountStorageUnit.GetStorageUnit(GetQuantityType(unit));
      var converter = unit.GetConverterTo(storageUnit);
      var zeroInStorageUnit = converter.Convert(0);
      var valueInStorageUnit = converter.Convert(value);
      var deltaValueInStorageUnit = valueInStorageUnit - zeroInStorageUnit;
      return (Amount<T>)Amount.Exact(deltaValueInStorageUnit, storageUnit);
    }

    /// <summary>
    /// Creates an amount that represents the a delta value in the specified 
    /// unit. For example if you create a delta amount of 2 degrees Fahrenheit that 
    /// will represent 1.11111 degrees Celsius.
    /// </summary>
    public static Amount Delta(double value, Unit.Unit unit)
    {
      var storageUnit = AmountStorageUnit.GetStorageUnit(GetQuantityType(unit));
      var converter = unit.GetConverterTo(storageUnit);
      var zeroInStorageUnit = converter.Convert(0);
      var valueInStorageUnit = converter.Convert(value);
      var deltaValueInStorageUnit = valueInStorageUnit - zeroInStorageUnit;
      return Exact(deltaValueInStorageUnit, storageUnit);
    }

    public override string ToString()
    {
      var unitname = _unit.Name;
      if (unitname.Length > 0)
        return _value.ToString("F6") + " " + unitname;
      return _value.ToString("F6");
    }

    public double Value
    {
      get { return _value; }
    }

    public Unit.Unit Unit
    {
      get { return _unit; }
    }

    // Negation unary operator
    public static Amount operator -(Amount a)
    {
      return Amount.Exact(-a.Value, a.Unit);
    }

    // Aritmetic operator
    public static Amount operator +(Amount left, Amount right)
    {
      if (left == null || right == null)
        throw new ArgumentNullException();
      if (left._unit != right._unit)
        throw new InvalidOperationException(string.Format("Cannot perform '+' operation between values of unit [{0}], and unit [{1}].", left._unit.Name, right._unit.Name));
      return Amount.Exact(left._value + right._value, left._unit);
    }

    public static Amount operator -(Amount left, Amount right)
    {
      if (left == null || right == null)
        throw new ArgumentNullException();
      if (left._unit != right._unit)
        throw new InvalidOperationException(string.Format("Cannot perform '-' operation between values of unit [{0}], and unit [{1}].", left._unit.Name, right._unit.Name));
      return Amount.Exact(left._value - right._value, left._unit);
    }

    public static Amount operator *(double left, Amount right)
    {
      return Amount.Exact(left * right._value, right.Unit);
    }

    public static Amount operator *(Amount left, double right)
    {
      return Amount.Exact(left._value * right, left.Unit);
    }

    public static Amount operator *(Amount left, Amount right)
    {
      if (left == null || right == null)
        throw new ArgumentNullException();

      var leftQuantityType = left.Unit.GetQuantityType();
      var rightQuantityType = right.Unit.GetQuantityType();

      if (leftQuantityType == rightQuantityType)
        return Amount.Exact(left.Value * right.ValueAsNonGeneric(left.Unit), left.Unit);
      else if (leftQuantityType == typeof(IDimensionless))
        return left.ValueAsNonGeneric(Units.One) * right;
      else if (rightQuantityType == typeof(IDimensionless))
        return right.ValueAsNonGeneric(Units.One) * left;
      else
        return RunAmountOperatorExtensionMethod(left, right, "Times");
    }

    public static Amount operator /(Amount left, double right)
    {
      return Amount.Exact(left._value / right, left.Unit);
    }

    public static Amount operator /(double left, Amount right)
    {
      return Amount.Exact(left / right._value, right.Unit);
    }

    public static Amount operator /(Amount left, Amount right)
    {
      if (left == null || right == null)
        throw new ArgumentNullException();

      var leftQuantityType = left.Unit.GetQuantityType();
      var rightQuantityType = right.Unit.GetQuantityType();

      if (leftQuantityType == rightQuantityType)
        return Amount.Exact(left.Value / right.ValueAsNonGeneric(left.Unit), left.Unit);
      else if (leftQuantityType == typeof(IDimensionless))
        return left.ValueAsNonGeneric(Units.One) / right;
      else if (rightQuantityType == typeof(IDimensionless))
        return left / right.ValueAsNonGeneric(Units.One);
      else
        return RunAmountOperatorExtensionMethod(left, right, "Divide");
    }

    public static Amount operator %(Amount left, double right)
    {
      return Amount.Exact(left._value % right, left.Unit);
    }

    public static Amount operator %(double left, Amount right)
    {
      return Amount.Exact(left % right._value, right.Unit);
    }

    public static Amount operator %(Amount left, Amount right)
    {
      if (left == null || right == null)
        throw new ArgumentNullException();

      var leftQuantityType = left.Unit.GetQuantityType();
      var rightQuantityType = right.Unit.GetQuantityType();

      if (leftQuantityType == rightQuantityType)
        return Amount.Exact(left.Value % right.ValueAsNonGeneric(left.Unit), left.Unit);
      else if (leftQuantityType == typeof(IDimensionless))
        return left.ValueAsNonGeneric(Units.One) % right;
      else if (rightQuantityType == typeof(IDimensionless))
        return left % right.ValueAsNonGeneric(Units.One);
      else
        return RunAmountOperatorExtensionMethod(left, right, "Modulo");
    }

    private static Amount RunAmountOperatorExtensionMethod(Amount left, Amount right, string extensionMethodName)
    {
      Amount result = null;
      foreach (var mi in typeof(AmountOperatorExtensions).GetMethods())
      {
        var parameters = mi.GetParameters();
        if (parameters.Length == 2)
        {
          if (mi.Name == extensionMethodName)
          {
            if ((parameters[0].ParameterType == left.GetType() && parameters[1].ParameterType == right.GetType()) ||
                (parameters[1].ParameterType == left.GetType() && parameters[0].ParameterType == right.GetType()))
            {
              result = mi.Invoke(null, new object[] { left, right }) as Amount;
              break;
            }
          }
        }
      }
      if (result == null)
        throw new InvalidOperationException(string.Format("No extension method found to Divide between quantities of {0} and {1} (values {2} and {3}).", left.Unit.GetQuantityType().Name, right.Unit.GetQuantityType().Name, left.ToString(), right.ToString()));
      return result;
    }


    // Comparsion operators

    public static bool operator <(Amount a1, Amount a2)
    {
      return Comparison(a1, a2, false) < 0;
    }

    public static bool operator >(Amount a1, Amount a2)
    {
      return Comparison(a1, a2, false) > 0;
    }

    public static bool operator ==(Amount a1, Amount a2)
    {
      return Comparison(a1, a2, true) == 0;
    }

    public static bool operator !=(Amount a1, Amount a2)
    {
      return Comparison(a1, a2, true) != 0;
    }

    public static bool operator <=(Amount a1, Amount a2)
    {
      return Comparison(a1, a2, false) <= 0;
    }

    public static bool operator >=(Amount a1, Amount a2)
    {
      return Comparison(a1, a2, false) >= 0;
    }

    private static int Comparison(Amount a1, Amount a2, bool allowNulls)
    {
      if (!allowNulls)
      {
        // We don't allow nulls for < and > because it would cause strange behavior, e.g. 1 < null would work which it shouldn't
        if (ReferenceEquals(a1, null)) throw new ArgumentNullException("a1");
        if (ReferenceEquals(a2, null)) throw new ArgumentNullException("a2");
      }
      else
      {
        // Handle nulls
        if (ReferenceEquals(a1, null) && ReferenceEquals(a2, null))
          return 0;
        if (ReferenceEquals(a1, null))
          return 1;
        if (ReferenceEquals(a2, null))
          return 2;
      }

      if (!a1._unit.Equals(a2._unit))
        throw new Exception("Cannot compare amounts of different units");

      // Do comparison of values while disregarding the least significant bits
      // of the floating point (double) values. We don't have to convert
      // the values to the same unit because values always have the same
      // storage unit.
      var a1Value = (Double42)a1._value;
      var a2Value = (Double42)a2._value;
      return a1Value.CompareTo(a2Value);
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Amount)) return false;
      return this == (Amount)obj;
    }

    public override int GetHashCode()
    {
      // Disregard the least significant bits when generating hashcode 
      // because we do this for equals and they have to work the same way
      //return _value.GetHashCode() ^ _unit.GetHashCode();
      var roundedValue = (Double42)_value;
      return roundedValue.GetHashCode() ^ _unit.GetHashCode();
    }

    public static Amount<T> Clamp<T>(Amount<T> val, Amount<T> min, Amount<T> max) where T : IQuantity
    {
      return Min(Max(val, min), max);
    }

    public static Amount<T> Max<T>(Amount<T> a1, Amount<T> a2) where T : IQuantity
    {
      if (a1 == null)
        return a2;
      if (a2 == null)
        return a1;
      return a1 > a2 ? a1 : a2;
    }

    public static Amount<T> Min<T>(Amount<T> a1, Amount<T> a2) where T : IQuantity
    {
      if (a1 == null)
        return a2;
      if (a2 == null)
        return a1;
      return a1 < a2 ? a1 : a2;
    }

    public static Amount Max(Amount a1, Amount a2)
    {
      if (a1 == null)
        return a2;
      if (a2 == null)
        return a1;
      return a1.Value > a2.Value ? a1 : a2;
    }

    public static Amount Min(Amount a1, Amount a2)
    {
      if (a1 == null)
        return a2;
      if (a2 == null)
        return a1;
      return a1.Value < a2.Value ? a1 : a2;
    }

    public Amount<TResult> Times<TResult>(Amount other) where TResult : IQuantity
    {
      return new Amount<TResult>(_value * other._value, _unit.Times<TResult>(other._unit));
    }

    public Amount<TResult> Divide<TResult>(Amount other) where TResult : IQuantity
    {
      if (other == Exact(0, other._unit))
        throw new DivideByZeroException();
      return new Amount<TResult>(_value / other._value, _unit.Divide<TResult>(other._unit));
    }

    public Amount RoundDown(Amount step)
    {
      var div = _value / step._value;
      return Amount.Exact(Math.Floor(div) * step.Value, step.Unit);
    }

    public Amount RoundUp(Amount step)
    {
      var div = _value / step._value;
      return Amount.Exact(Math.Ceiling(div) * step.Value, step.Unit);
    }

    private static Type GetQuantityType(Unit.Unit unit)
    {
      return unit.GetQuantityType();
    }

    #region IComparable<Amount<T>> Members

    public int CompareTo(Amount other)
    {
      return Comparison(this, other, true);
    }

    #endregion

    #region IComparable Members

    public int CompareTo(object obj)
    {
      if (obj != null && !(obj is Amount))
        throw new ArgumentException("Object must be of type Amount.");

      return CompareTo(obj as Amount);
    }

    #endregion
  }

  [DebuggerDisplay("Amount<T> {_value}, {_unit}")]
  public class Amount<T> : Amount where T : IQuantity
  {
    internal Amount(double value, Unit<T> unit)
      : base(value, unit)
    {
    }

    /// <summary>
    /// Get the absolute amount (equivalent of Math.Abs())
    /// </summary>
    public Amount<T> Abs()
    {
      return new Amount<T>(Math.Abs(_value), GetGenericUnit());
    }

    public Amount<T> RoundDown(Amount<T> step)
    {
      var div = _value / step._value;
      return new Amount<T>(Math.Floor(div) * step._value, GetGenericUnit());
    }

    public Amount<T> RoundUp(Amount<T> step)
    {
      var div = _value / step._value;
      return new Amount<T>(Math.Ceiling(div) * step._value, GetGenericUnit());
    }

    // Negation unary operator
    public static Amount<T> operator -(Amount<T> a)
    {
      return new Amount<T>(-a._value, a.GetGenericUnit());
    }

    public static Amount<T> operator *(Amount<T> left, double right)
    {
      return new Amount<T>(left._value * right, left.GetGenericUnit());
    }

    public static Amount<T> operator *(Amount<T> left, Amount<IDimensionless> right)
    {
      return new Amount<T>(left._value * right.ValueAs(Units.One), left.GetGenericUnit());
    }

    public static Amount<T> operator *(double left, Amount<T> right)
    {
      return new Amount<T>(left * right._value, right.GetGenericUnit());
    }

    public static Amount<T> operator *(Amount<IDimensionless> left, Amount<T> right)
    {
      return new Amount<T>(left.ValueAs(Units.One) * right._value, right.GetGenericUnit());
    }

    public static Amount<T> operator /(Amount<T> left, double right)
    {
      return new Amount<T>(left._value / right, left.GetGenericUnit());
    }

    public static Amount<T> operator /(Amount<T> left, Amount<IDimensionless> right)
    {
      return new Amount<T>(left._value / right.ValueAs(Units.One), left.GetGenericUnit());
    }

    public static Amount<T> operator /(double left, Amount<T> right)
    {
      return new Amount<T>(left / right._value, right.GetGenericUnit());
    }

    public static Amount<T> operator /(Amount<IDimensionless> left, Amount<T> right)
    {
      return new Amount<T>(left.ValueAs(Units.One) / right._value, right.GetGenericUnit());
    }

    public static Amount<T> operator +(Amount<T> left, Amount<T> right)
    {
      return new Amount<T>(left._value + right.ValueAs(left.GetGenericUnit()), left.GetGenericUnit());
    }

    public static Amount<T> operator -(Amount<T> left, Amount<T> right)
    {
      return new Amount<T>(left._value - right.ValueAs(left.GetGenericUnit()), left.GetGenericUnit());
    }

    private Unit<T> GetGenericUnit()
    {
      return _unit as Unit<T>;
    }

    public double ValueAs(Unit<T> toUnit)
    {
      return _unit.GetConverterTo(toUnit).Convert(_value);
    }
  }
}