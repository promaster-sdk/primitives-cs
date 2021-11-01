namespace Promaster.Primitives.PropertyFiltering.Ast
{
  public class UnaryExpr : Expr
  {
    private readonly UnaryOperator _operator;
    private readonly Expr _expr;

    public UnaryExpr(UnaryOperator @operator, Expr expr)
    {
      _operator = @operator;
      _expr = expr;
    }

    public UnaryOperator Operator
    {
      get { return _operator; }
    }

    public Expr Expr
    {
      get { return _expr; }
    }

    public override void Accept(IFilterVisitor filterVisitor)
    {
      filterVisitor.Visit(this);
    }
  }
}