namespace Promaster.Primitives.PropertyFiltering.Ast
{
  public class MultiplyExpr : Expr
  {
    private readonly Expr _leftValue;
    private readonly MultiplyOperator _operationType;
    private readonly Expr _rightValue;

    public MultiplyExpr(Expr leftValue, MultiplyOperator operationType, Expr rightValue)
    {
      _leftValue = leftValue;
      _operationType = operationType;
      _rightValue = rightValue;
    }

    public Expr LeftValue
    {
      get { return _leftValue; }
    }

    public MultiplyOperator OperationType
    {
      get { return _operationType; }
    }

    public Expr RightValue
    {
      get { return _rightValue; }
    }

    public override void Accept(IFilterVisitor filterVisitor)
    {
      filterVisitor.Visit(this);
    }
  }
}