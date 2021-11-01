namespace Promaster.Primitives.PropertyFiltering.Ast
{
  public class IdentifierAsExpr : Expr
  {
    private readonly string _name;
    private readonly string _unit;

    public IdentifierAsExpr(string name, string unit)
    {
      _name = name;
      _unit = unit;
    }

    public string Name
    {
      get { return _name; }
    }

    public string Unit
    {
      get { return _unit; }
    }

    public override void Accept(IFilterVisitor filterVisitor)
    {
      filterVisitor.Visit(this);
    }
  }
}