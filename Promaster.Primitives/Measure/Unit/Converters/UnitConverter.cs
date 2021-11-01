namespace Promaster.Primitives.Measure.Unit.Converters
{
  /// <summary>
  /// This class represents a converter of numeric values.
  /// 
  /// It is not required for sub-classes to be immutable
  /// (e.g. currency converter).
  /// 
  /// Sub-classes must ensure unicity of the identity
  /// converter. In other words, if the result of an operation is equivalent
  /// to the identity converter, then the unique IDENTITY instance 
  /// should be returned.
  /// </summary>
  public abstract partial class UnitConverter
  {

    // Holds the identity converter (unique). This converter does nothing
    // (ONE.convert(x) == x).
    public static readonly UnitConverter Identity = new IdentityConverter();

    /// <summary>
    /// Returns the inverse of this converter. If x is a valid
    /// value, then x == inverse().convert(convert(x)) to within
    /// the accuracy of computer arithmetic.
    /// </summary>
    public abstract UnitConverter Inverse { get; }

    /// <summary>
    /// Converts a double value.
    /// </summary>
    /// <param name="x">the numeric value to convert.</param>
    /// <returns>the converted numeric value.</returns>
    public abstract double Convert(double x);

    /// <summary>
    /// Concatenates this converter with another converter. The resulting
    /// converter is equivalent to first converting by the specified converter,
    /// and then converting by this converter.
    /// 
    /// Note: Implementations must ensure that the IDENTITY instance
    ///       is returned if the resulting converter is an identity 
    ///       converter.
    /// </summary>
    /// <param name="converter">the other converter.</param>
    /// <returns>the concatenation of this converter with the other converter.</returns>
    public virtual UnitConverter Concatenate(UnitConverter converter)
    {
      return object.ReferenceEquals(converter, Identity) ? this : new Compound(converter, this);
    }

    public static UnitConverter Offset(double off)
    {
      return new OffsetConverter(off);
    }

    public static UnitConverter Factor(double f)
    {
      return new FactorConverter(f);
    }

    /// <summary>
    /// Indicates whether this converter is considered the same as the  
    /// converter specified. To be considered equal this converter 
    /// concatenated with the one specified must returns the {@link #IDENTITY}.
    /// </summary>
    /// <param name="cvtr">the converter with which to compare.</param>
    /// <returns>true if the specified object is a converter considered equals to this converter; false otherwise.</returns>
    public override bool Equals(object cvtr)
    {
      var that = cvtr as UnitConverter;
      if (that == null)
      {
        return false;
      }
      return object.ReferenceEquals(this.Concatenate(that.Inverse), Identity);
    }

    /// <summary>
    /// Returns a hash code value for this converter. Equals object have equal
    /// hash codes.
    /// </summary>
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }









  }

}

