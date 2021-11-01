using System.Collections.Generic;
using Promaster.Primitives.ProductProperties;
using Promaster.Primitives.PropertyFiltering.Ast;

namespace Promaster.Primitives.PropertyFiltering.TypeInference
{
  public class FilterTypeInferrer : IFilterVisitor
  {
    private ExprType _lastPropertyType;
    private Dictionary<Expr, ExprType> _typeMap;

    public Dictionary<Expr, ExprType> GetTypeMap(PropertyFilter filter)
    {
      _typeMap = new Dictionary<Expr, ExprType>();
      _lastPropertyType = new ExprType(ExprTypeEnum.Unknown);
      filter.Ast.Accept(this);
      return _typeMap;
    }

    public void Visit(AndExpr e)
    {
      foreach (var child in e.Children)
        child.Accept(this);
      _typeMap[e] = new ExprType(ExprTypeEnum.Bool);
    }

    public void Visit(ComparisonExpr e)
    {
      _lastPropertyType = new ExprType(ExprTypeEnum.Unknown);

      e.LeftValue.Accept(this);
      e.RightValue.Accept(this);

      e.LeftValue.Accept(this);
      e.RightValue.Accept(this);

      _typeMap[e] = new ExprType(ExprTypeEnum.Bool);
    }

    public void Visit(EmptyExpr e)
    {
      _typeMap[e] = new ExprType(ExprTypeEnum.Unknown);
    }

    public void Visit(EqualsExpr e)
    {
      _lastPropertyType = new ExprType(ExprTypeEnum.Unknown);

      e.LeftValue.Accept(this);
      foreach (var range in e.RightValueRanges)
        range.Accept(this);

      e.LeftValue.Accept(this);
      foreach (var range in e.RightValueRanges)
        range.Accept(this);

      _typeMap[e] = new ExprType(ExprTypeEnum.Bool);
    }

    public void Visit(IdentifierExpr e)
    {
      _typeMap[e] = new ExprType(ExprTypeEnum.Property, e.Name);
      _lastPropertyType = _typeMap[e];
    }

    public void Visit(IdentifierAsExpr e)
    {
      _typeMap[e] = new ExprType(ExprTypeEnum.Amount);
    }

    public void Visit(OrExpr e)
    {
      foreach (var child in e.Children)
        child.Accept(this);
      _typeMap[e] = new ExprType(ExprTypeEnum.Bool);
    }

    public void Visit(ValueExpr e)
    {
      switch (e.Value.Type)
      {
        case PropertyType.Integer:
          _typeMap[e] = _lastPropertyType;
          break;
        case PropertyType.Amount:
          _typeMap[e] = new ExprType(ExprTypeEnum.Amount);
          break;
        case PropertyType.Text:
          _typeMap[e] = new ExprType(ExprTypeEnum.Text);
          break;
      }
    }

    public void Visit(ValueRangeExpr e)
    {
      e.Min.Accept(this);
      e.Max.Accept(this);

      e.Min.Accept(this);
      e.Max.Accept(this);

      _typeMap[e] = new ExprType(ExprTypeEnum.Range);
    }

    public void Visit(AddExpr e)
    {
      e.LeftValue.Accept(this);
      e.RightValue.Accept(this);
      _typeMap[e] = new ExprType();
    }

    public void Visit(MultiplyExpr e)
    {
      e.LeftValue.Accept(this);
      e.RightValue.Accept(this);
      _typeMap[e] = new ExprType();
    }

    public void Visit(UnaryExpr e)
    {
      e.Expr.Accept(this);
      _typeMap[e] = new ExprType();
    }

    #region Implementation of IFilterVisitor

    public void Visit(NullExpr e)
    {
      _typeMap[e] = _lastPropertyType;
    }

    #endregion
  }
}