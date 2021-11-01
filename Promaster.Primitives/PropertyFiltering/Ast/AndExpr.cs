using System.Collections.Generic;

namespace Promaster.Primitives.PropertyFiltering.Ast
{
  public class AndExpr : Expr
  {
    private readonly List<Expr> _children;

    public AndExpr(List<Expr> children)
    {
      _children = children;
    }

    public List<Expr> Children
    {
      get { return _children; }
    }

    public override void Accept(IFilterVisitor filterVisitor)
    {
      filterVisitor.Visit(this);
    }
  }
}