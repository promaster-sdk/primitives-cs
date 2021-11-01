namespace Promaster.Primitives.Measure.Unit.Converters
{
  public abstract partial class UnitConverter
  {
    /// <summary>
    /// This inner class represents a compound converter.
    /// </summary>
    private class Compound : UnitConverter
    {
      // Holds the first converter.
      private UnitConverter _first;

      // Holds the second converter.
      private UnitConverter _second;

      /// <summary>
      /// Creates a compound converter resulting from the combined
      /// transformation of the specified converters.
      /// </summary>
      /// <param name="first">the first converter.</param>
      /// <param name="second">second the second converter.</param>
      public Compound(UnitConverter first, UnitConverter second)
      {
        _first = first;
        _second = second;
      }

      // Implements abstract method.
      public override double Convert(double value)
      {
        return _second.Convert(_first.Convert(value));
      }

      // Implements abstract method.
      public override UnitConverter Inverse
      {
        get { return new Compound(_second.Inverse, _first.Inverse); }
      }

      // Implements abstract method.
      public override int GetHashCode()
      {
        return _first.GetHashCode() ^ _second.GetHashCode();
      }
    }

  }
}