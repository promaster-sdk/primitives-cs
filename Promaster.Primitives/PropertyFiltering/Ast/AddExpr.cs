namespace Promaster.Primitives.PropertyFiltering.Ast
{
  public class AddExpr : Expr
  {
    private readonly Expr _leftValue;
    private readonly AddOperator _operationType;
    private readonly Expr _rightValue;

    public AddExpr(Expr leftValue, AddOperator operationType, Expr rightValue)
    {
      _leftValue = leftValue;
      _operationType = operationType;
      _rightValue = rightValue;
    }

    public Expr LeftValue
    {
      get { return _leftValue; }
    }

    public AddOperator OperationType
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