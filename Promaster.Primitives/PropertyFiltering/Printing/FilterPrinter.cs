using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Promaster.Primitives.PropertyFiltering.Ast;

namespace Promaster.Primitives.PropertyFiltering.Printing
{
  public class FilterPrinter : IFilterVisitor
  {
    private StringBuilder _builder;

    public string Print(Expr e)
    {
      _builder = new StringBuilder();
      e.Accept(this);
      return _builder.ToString();
    }

    #region IVisitor

    public void Visit(AndExpr e)
    {
      foreach (var child in e.Children)
      {
        child.Accept(this);
        if (child != e.Children.Last())
          Push("&");
      }
    }

    public void Visit(ComparisonExpr e)
    {
      e.LeftValue.Accept(this);
      Push(ToString(e.OperationType));
      e.RightValue.Accept(this);
    }

    public void Visit(EmptyExpr e)
    {
    }

    public void Visit(EqualsExpr e)
    {
      e.LeftValue.Accept(this);
      Push(ToString(e.OperationType));
      foreach (var range in e.RightValueRanges)
      {
        range.Accept(this);
        if (range != e.RightValueRanges.Last())
          Push(",");
      }
    }

    public void Visit(IdentifierExpr e)
    {
      Push(e.Name);
    }

    public void Visit(IdentifierAsExpr e)
    {
      Push(e.Name + ":" + e.Unit);
    }

    public void Visit(OrExpr e)
    {
      foreach (var child in e.Children)
      {
        child.Accept(this);
        if (child != e.Children.Last())
          Push("|");
      }
    }

    public void Visit(ValueExpr e)
    {
      Push(e.Value.ToString());
    }

    public void Visit(ValueRangeExpr e)
    {
      e.Min.Accept(this);
      Push("~");
      e.Max.Accept(this);
    }

    public void Visit(NullExpr e)
    {
      Push("null");
    }

    public void Visit(AddExpr e)
    {
      e.LeftValue.Accept(this);
      Push(e.OperationType == AddOperator.Plus ? "+" : "-");
      e.RightValue.Accept(this);
    }

    public void Visit(MultiplyExpr e)
    {
      e.LeftValue.Accept(this);
      if(e.OperationType == MultiplyOperator.Times)
        Push("*");
      if (e.OperationType == MultiplyOperator.Divide)
        Push("/"); 
      if (e.OperationType == MultiplyOperator.Modulo)
        Push("%");
      e.RightValue.Accept(this);
    }

    public void Visit(UnaryExpr e)
    {
      Push("-");
      e.Expr.Accept(this);
    }

    #endregion

    #region Private

    void Push(string s)
    {
      _builder.Append(s);
    }

    private string ToString(ComparisonOperationType type)
    {
      switch (type)
      {
        case ComparisonOperationType.LessOrEqual:
          return "<=";
        case ComparisonOperationType.GreaterOrEqual:
          return ">=";
        case ComparisonOperationType.Less:
          return "<";
        case ComparisonOperationType.Greater:
          return ">";
        default:
          throw new Exception("Unknown ComparisonOperationType " + type);
      }
    }

    private string ToString(EqualsOperationType type)
    {
      switch (type)
      {
        case EqualsOperationType.Equals:
          return "=";
        case EqualsOperationType.NotEquals:
          return "!=";
        default:
          throw new Exception("Unknown EqualsOperationType " + type);
      }
    }

    #endregion
  }
}