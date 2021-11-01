namespace Promaster.Primitives.PropertyFiltering.Ast
{
  public class IdentifierExpr : Expr
  {
    private readonly string _name;

    public IdentifierExpr(string name)
    {
      _name = name;
    }

    public string Name
    {
      get { return _name; }
    }

    public override void Accept(IFilterVisitor filterVisitor)
    {
      filterVisitor.Visit(this);
    }
  }
}