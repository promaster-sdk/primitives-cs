namespace Promaster.Primitives.PropertyFiltering.Ast
{
  public interface IFilterVisitor
  {
    void Visit(AndExpr e);
    void Visit(ComparisonExpr e);
    void Visit(EmptyExpr e);
    void Visit(EqualsExpr e);
    void Visit(IdentifierExpr e);
    void Visit(IdentifierAsExpr e);
    void Visit(OrExpr e);
    void Visit(ValueRangeExpr e);
    void Visit(NullExpr e);
    void Visit(ValueExpr e);
    void Visit(AddExpr e);
    void Visit(MultiplyExpr e);
    void Visit(UnaryExpr e);
  }
}