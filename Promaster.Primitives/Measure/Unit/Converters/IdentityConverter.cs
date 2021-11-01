namespace Promaster.Primitives.Measure.Unit.Converters
{

  public abstract partial class UnitConverter
  {

    /// <summary>
    /// This inner class represents the identity converter (singleton).
    /// </summary>
    private class IdentityConverter : UnitConverter
    {

      // Implements abstract method.
      public override UnitConverter Concatenate(UnitConverter converter)
      {
        return converter;
      }

      // Implements abstract method.
      public override double Convert(double value)
      {
        return value;
      }

      // Implements abstract method.
      public override UnitConverter Inverse
      {
        get { return this; }
      }
    }

  }

}