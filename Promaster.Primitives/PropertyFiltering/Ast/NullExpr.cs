namespace Promaster.Primitives.PropertyFiltering.Ast
{
  public class NullExpr : Expr
  {
    public override void Accept(IFilterVisitor filterVisitor)
    {
      filterVisitor.Visit(this);
    }
  }
}