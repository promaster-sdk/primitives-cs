using System;
using System.Linq;
using System.Collections.Generic;
using Promaster.Primitives.Measure;
using Promaster.Primitives.Measure.Unit;
using Promaster.Primitives.ProductProperties;
using Promaster.Primitives.PropertyFiltering.Ast;

namespace Promaster.Primitives.PropertyFiltering.Evaluation
{
  public class FilterEvaluator : IFilterVisitor
  {
    private Stack<object> _stack;
    private PropertyValueSet _properties;
    private bool _matchMissingIdentifiers;

    public bool Evaluate(Expr e, PropertyValueSet properties, bool matchMissingIdentifiers)
    {
      _stack = new Stack<object>();
      _properties = properties;
      _matchMissingIdentifiers = matchMissingIdentifiers;
      e.Accept(this);
      return PopBool();
    }

    #region IVisitor

    public void Visit(AndExpr e)
    {
      bool result = true;
      foreach (var child in e.Children)
      {
        child.Accept(this);
        result &= PopBool();
      }
      Push(result);
    }

    public void Visit(ComparisonExpr e)
    {
      // Handle match missing identifier
      if (_matchMissingIdentifiers)
      {
        if (IsMissingIdent(e.LeftValue) || IsMissingIdent(e.RightValue))
        {
          Push(true);
          return;
        }
      }

      e.LeftValue.Accept(this);
      var left = PopValue();
      if (left == null)
      {
        //Push(_matchMissingIdentifiers);
        Push(false);
        return;
      }

      e.RightValue.Accept(this);
      var right = PopValue();
      if (right == null)
      {
        //Push(_matchMissingIdentifiers);
        Push(false);
        return;
      }

      switch (e.OperationType)
      {
        case ComparisonOperationType.Less:
          Push(left < right);
          break;
        case ComparisonOperationType.Greater:
          Push(left > right);
          break;
        case ComparisonOperationType.LessOrEqual:
          Push(left <= right);
          break;
        case ComparisonOperationType.GreaterOrEqual:
          Push(left >= right);
          break;
        default:
          throw new Exception("Unknown comparisontype: " + e.OperationType);
      }
    }

    public void Visit(EmptyExpr e)
    {
      Push(true);
    }

    public void Visit(EqualsExpr e)
    {
      // Handle match missing identifier
      if (_matchMissingIdentifiers)
      {
        if (IsMissingIdent(e.LeftValue) ||
        e.RightValueRanges.Cast<ValueRangeExpr>().Any((ValueRangeExpr vr) => IsMissingIdent(vr.Min) || IsMissingIdent(vr.Min)))
        {
          Push(true);
          return;
        }
      }

      e.LeftValue.Accept(this);
      var left = PopValue();

      foreach (var range in e.RightValueRanges)
      {
        range.Accept(this);
        var max = PopValue();
        var min = PopValue();


        // Match on NULL or inclusive in range
        if (((max == null || min == null) && left == null) ||
        (left != null && min != null && max != null && (left >= min && left <= max)))
        {
          Push(e.OperationType == EqualsOperationType.Equals);
          return;
        }
      }

      Push(e.OperationType == EqualsOperationType.NotEquals);
    }

    public void Visit(IdentifierExpr e)
    {
      if (_properties != null && _properties.HasProperty(e.Name))
        Push(_properties[e.Name]);
      else
        Push(null);
    }

    public void Visit(IdentifierAsExpr e)
    {
      if (_properties != null && _properties.HasProperty(e.Name))
      {
        var name = _properties[e.Name].ToInteger();
        var unit = Units.Parse(e.Unit);
        Push(new PropertyValue(Amount.Exact(name, unit)));
      }
      else
        Push(null);
    }

    public void Visit(OrExpr e)
    {
      foreach (var child in e.Children)
      {
        child.Accept(this);
        if (PopBool())
        {
          Push(true);
          return;
        }
      }
      Push(false);
    }

    public void Visit(ValueExpr e)
    {
      Push(e.Value);
    }

    public void Visit(ValueRangeExpr e)
    {
      e.Min.Accept(this);
      e.Max.Accept(this);
    }

    public void Visit(NullExpr e)
    {
      Push(null);
    }

    public void Visit(AddExpr e)
    {
      e.LeftValue.Accept(this);
      var left = PopValue();
      e.RightValue.Accept(this);
      var right = PopValue();
      if (e.OperationType == AddOperator.Plus)
        Push(left + right);
      if (e.OperationType == AddOperator.Minus)
        Push(left - right);
    }

    public void Visit(MultiplyExpr e)
    {
      e.LeftValue.Accept(this);
      var left = PopValue();
      e.RightValue.Accept(this);
      var right = PopValue();
      if (e.OperationType == MultiplyOperator.Times)
        Push(left * right);
      if (e.OperationType == MultiplyOperator.Divide)
        Push(left / right);
      if(e.OperationType == MultiplyOperator.Modulo)
        Push(left % right);
    }

    public void Visit(UnaryExpr e)
    {
      e.Accept(this);
      var value = PopValue();
      Push(-value);
    }

    #endregion

    #region Private

    private bool IsMissingIdent(Expr expr)
    {
      // If expression is an missing identifier it should match anything
      if (expr is IdentifierExpr)
      {
        var ident = (IdentifierExpr)expr;
        if (!_properties.HasProperty(ident.Name))
          return true;
      }
      return false;
    }

    private void Push(PropertyValue d)
    {
      _stack.Push(d);
    }

    private void Push(bool b)
    {
      _stack.Push(b);
    }

    private bool PopBool()
    {
      return (bool)_stack.Pop();
    }

    private PropertyValue PopValue()
    {
      return (PropertyValue)_stack.Pop();
    }

    #endregion

  }

}
