namespace Promaster.Primitives.PropertyFiltering.Ast
{
  public class ComparisonExpr : Expr
  {
    private readonly Expr _leftValue;
    private readonly ComparisonOperationType _operationType;
    private readonly Expr _rightValue;

    public ComparisonExpr(Expr leftValue, ComparisonOperationType operationType, Expr rightValue)
    {
      _leftValue = leftValue;
      _operationType = operationType;
      _rightValue = rightValue;
    }

    public Expr LeftValue
    {
      get { return _leftValue; }
    }

    public ComparisonOperationType OperationType
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