namespace Promaster.Primitives.PropertyFiltering.Ast
{
  public abstract class Expr
  {
    public abstract void Accept(IFilterVisitor filterVisitor);
  }
}
