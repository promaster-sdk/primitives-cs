namespace Promaster.Primitives.PropertyFiltering.Ast
{
  public class EmptyExpr : Expr
  {
    public override void Accept(IFilterVisitor filterVisitor)
    {
      filterVisitor.Visit(this);
    }
  }
}