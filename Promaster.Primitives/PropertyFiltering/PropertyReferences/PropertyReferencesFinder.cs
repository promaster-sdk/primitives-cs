using System.Collections.Generic;
using Promaster.Primitives.PropertyFiltering.Ast;

namespace Promaster.Primitives.PropertyFiltering.PropertyReferences
{
  public class PropertyReferencesFinder : IFilterVisitor
  {
    private readonly HashSet<string> _properties = new HashSet<string>();

    public HashSet<string> GetPropertyReferences(PropertyFilter filter)
    {
      if (filter == null)
        return new HashSet<string>();
      _properties.Clear();
      filter.Ast.Accept(this);
      return _properties;
    }

    public void Visit(AndExpr e)
    {
      foreach (var child in e.Children)
        child.Accept(this);
    }

    public void Visit(ComparisonExpr e)
    {
      e.LeftValue.Accept(this);
      e.RightValue.Accept(this);
    }

    public void Visit(EmptyExpr e)
    {
    }

    public void Visit(EqualsExpr e)
    {
      e.LeftValue.Accept(this);
      foreach (var range in e.RightValueRanges)
        range.Accept(this);
    }

    public void Visit(IdentifierExpr e)
    {
      _properties.Add(e.Name);
    }

    public void Visit(IdentifierAsExpr e)
    {
      _properties.Add(e.Name);
    }

    public void Visit(OrExpr e)
    {
      foreach (var child in e.Children)
        child.Accept(this);
    }

    public void Visit(ValueExpr e)
    {
    }

    public void Visit(ValueRangeExpr e)
    {
      e.Min.Accept(this);
      e.Max.Accept(this);
    }

    public void Visit(NullExpr e)
    {
    }

    public void Visit(AddExpr e)
    {
      e.LeftValue.Accept(this);
      e.RightValue.Accept(this);
    }

    public void Visit(MultiplyExpr e)
    {
      e.LeftValue.Accept(this);
      e.RightValue.Accept(this);
    }

    public void Visit(UnaryExpr e)
    {
      e.Expr.Accept(this);
    }
  }
}