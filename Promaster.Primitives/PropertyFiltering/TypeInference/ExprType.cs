namespace Promaster.Primitives.PropertyFiltering.TypeInference
{
  public enum ExprTypeEnum
  {
    Unknown,
    Bool,
    Amount,
    Property,
    Text,
    Range
  }

  public struct ExprType
  {
    public readonly ExprTypeEnum ExprTypeEnum;
    public readonly string PropertyName;

    public ExprType(ExprTypeEnum exprTypeEnum = ExprTypeEnum.Unknown, string propertyName = null)
    {
      ExprTypeEnum = exprTypeEnum;
      PropertyName = propertyName;
    }
  }
}