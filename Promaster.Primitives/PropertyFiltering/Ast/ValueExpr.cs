using Promaster.Primitives.ProductProperties;
namespace Promaster.Primitives.PropertyFiltering.Ast
{
  public class ValueExpr : Expr
  {
    private readonly string _unparsed;
    private readonly PropertyValue _parsed;

    public ValueExpr(string unparsed)
    {
      _unparsed = unparsed;
      _parsed = PropertyValue.Parse(_unparsed);
    }

    public string Unparsed
    {
      get { return _unparsed; }
    }

    public PropertyValue Value
    {
      get { return _parsed; }
    }

    public override void Accept(IFilterVisitor filterVisitor)
    {
      filterVisitor.Visit(this);
    }
  }
}