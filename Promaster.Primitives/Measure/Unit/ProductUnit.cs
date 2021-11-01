using System;
using System.Linq;
using System.Collections.Generic;
using Promaster.Primitives.Measure.Quantity;
using System.Reflection;
using System.Diagnostics;
using Promaster.Primitives.Measure.Unit.Converters;

namespace Promaster.Primitives.Measure.Unit
{

  /// <summary>
  /// Inner product element represents a rational power of a single unit.
  /// </summary>
  [DebuggerDisplay("Element ({_unit.Name}, {_pow})")]
  internal class Element
  {

    // Holds the single unit.
    private readonly Unit _unit;

    // Holds the power exponent.
    private readonly int _pow;

    /// Structural constructor.
    /// <param name="unit">the unit.</param>
    /// <param name="pow">the power exponent.</param>
    public Element(Unit unit, int pow)
    {
      _unit = unit;
      _pow = pow;
    }

    /// <summary>
    ///  Returns this element's unit.
    /// </summary>
    public Unit Unit
    {
      get { return _unit; }
    }

    /// <summary>
    /// Returns the power exponent. The power exponent can be negative
    /// but is always different from zero.
    /// </summary>
    public int Pow
    {
      get { return _pow; }
    }

    public override bool Equals(object that)
    {
      if (object.ReferenceEquals(that, this))
      {
        return true;
      }
      var that2 = that as Element;
      if (that2 == null)
      {
        return false;
      }
      return _unit.Equals(that2._unit) && _pow.Equals(that2._pow);
    }

    public override int GetHashCode()
    {
      return _unit.GetHashCode() ^ _pow.GetHashCode();
    }

  }

  /// <summary>
  /// This class represents units formed by the product of rational powers of
  /// existing units.
  /// 
  /// This class maintains the canonical form of this product (simplest
  /// form after factorization). For example:
  /// METER.pow(2).divide(METER) returns METER.
  /// </summary>
  internal class ProductUnit<T> : Unit<T> where T : IQuantity
  {

    // Holds the units composing this product unit.
    private List<Element> _elements = new List<Element>();

    // Default constructor (used solely to create ONE instance).
    public ProductUnit()
    {
    }

    /// <summary>
    // Product unit constructor.
    /// </summary>
    /// <param name="elements">the product elements.</param>
    private ProductUnit(IList<Element> elements)
    {
      _elements.Clear();
      _elements.AddRange(elements);
    }

    /// <summary>
    /// Creates the unit defined from the product of the specifed elements.
    /// </summary>
    /// <param name="leftElems">left multiplicand elements</param>
    /// <param name="rightElems">right multiplicand elements.</param>
    private ProductUnit(IList<Element> leftElems, IList<Element> rightElems)
    {
      // If we have several elements of the same unit then we can merge them by summing their power
      List<Element> allElements = new List<Element>();
      allElements.AddRange(leftElems);
      allElements.AddRange(rightElems);
      List<Element> resultElements = new List<Element>();
      var unitGroups = allElements.GroupBy(e => e.Unit);
      foreach (var unitGroup in unitGroups)
      {
        var sumpow = unitGroup.Sum(e => e.Pow);
        if (sumpow != 0)
        {
          resultElements.Add(new Element(unitGroup.Key, sumpow));
        }
      }
      _elements = resultElements;

      //var newlist = new List<Element>();
      //newlist.AddRange(leftElems);
      //newlist.AddRange(rightElems);
      //var l = from e in newlist group e by e.Unit into Group select g;

      //var newelements = new List<Element>();

      //foreach (var litem in l)
      //{
      //  var sumpow = Aggregate tmp in litem.Group into s = Sum(tmp.Pow);
      //  if(sumpow != 0)
      //  {
      //    newelements.Add(new Element(litem.Unit, sumpow));
      //  }
      //}

      //_elements = newelements;

    }

    /// <summary>
    /// Returns the product of the specified units.
    /// </summary>
    /// <param name="left">the left unit operand.</param>
    /// <param name="right">the right unit operand.</param>
    /// <returns>left * right</returns>
    internal static Unit<T> Product(Unit left, Unit right)
    {
      var leftelements = left.Elements;
      var rightelements = right.Elements;
      return new ProductUnit<T>(leftelements, rightelements);
    }

    /// <summary>
    /// Indicates if this product unit is considered equals to the specified 
    /// object. Two products are equals if they have the same elements
    /// regardless of the elements' order.
    /// </summary>
    /// <param name="other">the object to compare for equality.</param>
    /// <returns>true if this and that are considered equals; false otherwise.</returns>
    public override bool Equals(Unit<T> other)
    {
      if (object.ReferenceEquals(this, other))
      {
        return true;
      }

      var that = other as ProductUnit<T>;
      if (that == null)
      {
        return false;
      }

      // Two products are equals if they have the same elements
      // regardless of the elements' order.

      if (this.Elements.Count != that.Elements.Count)
        return false;

      // Check if same hash
      if (this.GetHashCode() == that.GetHashCode())
      {
        return !(this.Elements.Except(that.Elements).Any() || that.Elements.Except(this.Elements).Any());
      }
      return false;

      //return _elements.All(element => that.Elements.Contains(element));

      //return !(this.Elements.Except(that.Elements).Any() || that.Elements.Except(this.Elements).Any());

      //var that2 = that as ProductUnit<T>;
      //if (that2 != null)
      //{

      //  IList<Element> elems = that2._elements;
      //  if (_elements.Count == elems.Count)
      //  {
      //    for (int i = 0; i < _elements.Count; i++)
      //    {
      //      bool unitFound = false;
      //      for (int j = 0; j < elems.Count; j++)
      //      {
      //        if (_elements[i].Unit.Equals(elems[j].Unit))
      //        {
      //          if (!_elements[i].Equals(elems[j]))
      //          {
      //            return false;
      //          }
      //          else
      //          {
      //            unitFound = true;
      //            break;
      //          }
      //        }
      //      }
      //      if (!unitFound)
      //      {
      //        return false;
      //      }
      //    }
      //    return true;
      //  }
      //}
      //return false;

    }

    // Implements abstract method.
    public override int GetHashCode()
    {
      int result = 0;
      foreach (var e in _elements)
      {
        result = result ^ e.GetHashCode();
      }
      return result;
    }

    /// <summary>
    /// Returns the quotient of the specified units.
    /// </summary>
    /// <param name="left">the dividend unit operand.</param>
    /// <param name="right">right the divisor unit operand.</param>
    /// <returns>dividend / divisor</returns>
    internal static Unit<T> Quotient(Unit left, Unit right)
    {
      var leftelements = left.Elements;
      List<Element> invertedRightelements = new List<Element>();
      foreach (var element in right.Elements)
      {
        invertedRightelements.Add(new Element(element.Unit, -element.Pow));
      }
      return new ProductUnit<T>(leftelements, invertedRightelements);
    }

    // Implements abstract method.
    internal override Unit StandardUnit
    {
      get
      {
        List<Element> standardelements = new List<Element>();
        foreach (var e in _elements)
        {
          //var p = e.Unit.GetType().GetProperty("StandardUnit", BindingFlags.NonPublic | BindingFlags.Instance);
          //Unit newstandardunit = (Unit)p.GetValue(e.Unit, null);
          Unit newstandardunit = e.Unit.StandardUnit;
          standardelements.Add(new Element(newstandardunit, e.Pow));
        }
        return new ProductUnit<T>(standardelements);
      }
    }

    // Implements abstract method.
    internal override UnitConverter ToStandardUnit()
    {
      var converter = UnitConverter.Identity;
      foreach (var element in _elements)
      {
        //var p = element.Unit.GetType().GetProperty("ToStandardUnit", BindingFlags.NonPublic | BindingFlags.Instance);
        //var conv = (UnitConverter)p.GetValue(element.Unit, null);
        var conv = element.Unit.ToStandardUnit();
        var pow = element.Pow;
        if (pow < 0)
        {
          pow = -pow;
          conv = conv.Inverse;
        }
        for (var i = 1; i <= pow; i++)
        {
          converter = converter.Concatenate(conv);
        }
      }
      return converter;
    }

    protected override string BuildDerivedName()
    {
      var pospow = from e in _elements where e.Pow > 0 orderby e.Pow descending select e;
      var posname = BuildNameFromElements(pospow);
      var negpow = from e in _elements where e.Pow < 0 orderby e.Pow ascending select e;
      var negname = BuildNameFromElements(negpow);

      string name = posname;
      if (negname.Length > 0)
      {
        if (name.Length == 0)
        {
          name += "1";
        }

        name += "/" + negname;
      }

      return name;
    }

    private string BuildNameFromElements(IEnumerable<Element> elements)
    {
      string name = string.Empty;
      foreach (var e in elements)
      {
        //var p = e.Unit.GetType().GetProperty("Name");
        //name += Convert.ToString(p.GetValue(e.Unit, null));
        name += e.Unit.Name;

        switch (Math.Abs(e.Pow))
        {
          case 1:
            break;
          case 2:
            name += "²";
            break;
          case 3:
            name += "³";
            break;
          default:
            name += "^" + Math.Abs(e.Pow).ToString();
            break;
        }
      }

      return name;
    }

    /// <summary>
    /// Needed for reflection since we don't have wildcard generic types like in Java
    /// </summary>
    internal override IList<Element> Elements
    {
      get { return _elements; }
    }

  }


}


