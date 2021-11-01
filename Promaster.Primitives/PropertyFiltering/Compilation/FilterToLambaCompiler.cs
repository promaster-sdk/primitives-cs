using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Promaster.Primitives.ProductProperties;
using Promaster.Primitives.PropertyFiltering.Ast;

namespace Promaster.Primitives.PropertyFiltering.Compilation
{
  public delegate bool CompiledFilter(LookupPropertyValueDelegate lookupPropertyValueFunc, LookupPropertyValueAndConvertDelegate lookupPropertyValueAndConvertDelegate);

  public delegate PropertyValue LookupPropertyValueDelegate(string identifier);
  public delegate PropertyValue LookupPropertyValueAndConvertDelegate(string identifier, string unit);

  public class FilterToLambaCompiler : IFilterVisitor
  {
    private readonly ParameterExpression _lookupPropertyValueDelegateExpression = Expression.Parameter(typeof (LookupPropertyValueDelegate));
    private readonly ParameterExpression _lookupPropertyValueAndConvertDelegateExpression = Expression.Parameter(typeof (LookupPropertyValueAndConvertDelegate));

    public ParameterExpression LookupPropertyValueDelegateExpression
    {
      get { return _lookupPropertyValueDelegateExpression; }
    }

    public ParameterExpression LookupPropertyValueAndConvertDelegateExpression
    {
      get { return _lookupPropertyValueAndConvertDelegateExpression; }
    }

    private Stack<Expression> _stack;

    public CompiledFilter Compile(Expr e)
    {
      _stack = new Stack<Expression>();
      e.Accept(this);
      var expression = Pop();
      var lambda = Expression.Lambda<CompiledFilter>(expression, _lookupPropertyValueDelegateExpression, _lookupPropertyValueAndConvertDelegateExpression);
      return lambda.Compile();
    }

    public void Visit(AndExpr e)
    {
      var first = e.Children.First();
      first.Accept(this);

      foreach (var child in e.Children.Skip(1))
      {
        var last = Pop();
        child.Accept(this);
        var next = Pop();
        Push(Expression.AndAlso(last, next));
      }
    }

    public void Visit(ComparisonExpr e)
    {
      e.LeftValue.Accept(this);
      var left = Pop();
      e.RightValue.Accept(this);
      var right = Pop();

      switch (e.OperationType)
      {
        case ComparisonOperationType.LessOrEqual:
          Push(Expression.LessThanOrEqual(left, right));
          break;
        case ComparisonOperationType.Less:
          Push(Expression.LessThan(left, right));
          break;
        case ComparisonOperationType.GreaterOrEqual:
          Push(Expression.GreaterThanOrEqual(left, right));
          break;
        case ComparisonOperationType.Greater:
          Push(Expression.GreaterThan(left, right));
          break;
        default:
          throw new Exception("Unknown ComparisonOperationType " + e.OperationType);
      }
    }

    public void Visit(EmptyExpr e)
    {
      Push(Expression.Constant(true));
    }

    public void Visit(EqualsExpr e)
    {
      e.LeftValue.Accept(this);
      e.RightValueRanges.First().Accept(this);

      foreach (var range in e.RightValueRanges.Skip(1))
      {
        range.Accept(this);
        var left = Pop();
        var next = Pop();
        var last = Pop();
        Push(Expression.OrElse(last, next));
        Push(left);
      }
      Pop();

      if (e.OperationType == EqualsOperationType.NotEquals)
        Push(Expression.Not(Pop()));
    }

    public void Visit(IdentifierExpr e)
    {
      Push(Expression.Invoke(_lookupPropertyValueDelegateExpression, Expression.Constant(e.Name)));
    }

    public void Visit(IdentifierAsExpr e)
    {
      Push(Expression.Invoke(_lookupPropertyValueAndConvertDelegateExpression, Expression.Constant(e.Name), Expression.Constant(e.Unit)));
    }

    public void Visit(OrExpr e)
    {
      var first = e.Children.First();
      first.Accept(this);

      foreach (var child in e.Children.Skip(1))
      {
        var last = Pop();
        child.Accept(this);
        var next = Pop();
        Push(Expression.OrElse(last, next));
      }
    }

    public void Visit(ValueExpr e)
    {
      Push(Expression.Constant(e.Value));
    }

    public void Visit(ValueRangeExpr e)
    {
      var left = Pop();
      e.Min.Accept(this);
      var min = Pop();
      e.Max.Accept(this);
      var max = Pop();

      Push(Expression.And(Expression.LessThanOrEqual(min, left), Expression.LessThanOrEqual(left, max)));
      Push(left);
    }

    public void Visit(AddExpr e)
    {
      e.LeftValue.Accept(this);
      var left = Pop();
      e.RightValue.Accept(this);
      var right = Pop();
      if (e.OperationType == AddOperator.Plus)
        Push(Expression.Add(left, right));
      if (e.OperationType == AddOperator.Minus)
        Push(Expression.Subtract(left, right));
    }

    public void Visit(MultiplyExpr e)
    {
      e.LeftValue.Accept(this);
      var left = Pop();
      e.RightValue.Accept(this);
      var right = Pop();
      if (e.OperationType == MultiplyOperator.Times)
        Push(Expression.Multiply(left, right));
      if (e.OperationType == MultiplyOperator.Divide)
        Push(Expression.Divide(left, right));
      if (e.OperationType == MultiplyOperator.Modulo)
        Push(Expression.Modulo(left, right));
    }

    public void Visit(UnaryExpr e)
    {
      e.Expr.Accept(this);
      var value = Pop();
      Push(Expression.Negate(value));
    }

    #region Implementation of IFilterVisitor

    public void Visit(NullExpr e)
    {
      Push(Expression.Constant(null, typeof(PropertyValue)));
    }

    #endregion

    #region Private

    private void Push(Expression e)
    {
      _stack.Push(e);
    }

    private Expression Pop()
    {
      return _stack.Pop();
    }

    #endregion
  }
}