namespace Promaster.Primitives.PropertyFiltering.Ast
{
  public class ValueRangeExpr : Expr
  {
    private readonly Expr _min;
    private readonly Expr _max;

    public ValueRangeExpr(Expr min, Expr max)
    {
      _min = min;
      _max = max;
    }

    public Expr Min
    {
      get { return _min; }
    }

    public Expr Max
    {
      get { return _max; }
    }

    public override void Accept(IFilterVisitor filterVisitor)
    {
      filterVisitor.Visit(this);
    }
  }
}