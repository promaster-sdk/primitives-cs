using System.Collections.Generic;

namespace Promaster.Primitives.PropertyFiltering.Ast
{
  public class EqualsExpr : Expr
  {
    private readonly Expr _leftValue;
    private readonly EqualsOperationType _operationType;
    private readonly List<Expr> _rightValueRanges;

    public EqualsExpr(Expr leftValue, EqualsOperationType operationType, List<Expr> rightValueRanges)
    {
      _leftValue = leftValue;
      _operationType = operationType;
      _rightValueRanges = rightValueRanges;
    }

    public Expr LeftValue
    {
      get { return _leftValue; }
    }

    public EqualsOperationType OperationType
    {
      get { return _operationType; }
    }

    public List<Expr> RightValueRanges
    {
      get { return _rightValueRanges; }
    }

    public override void Accept(IFilterVisitor filterVisitor)
    {
      filterVisitor.Visit(this);
    }
  }
}