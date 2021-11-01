using Promaster.Primitives.Measure.Quantity;

namespace Promaster.Primitives.Measure
{
  public static class AmountOperatorExtensions
  {

    /// <summary>
    /// Skapar ett volymflöde genom att dividera ett massflöde med en densitet
    /// </summary>
    /// <param name="left">massflöde</param>
    /// <param name="right">densitet</param>
    /// <returns>massflöde / densitet</returns>
    /// <remarks></remarks>
    public static Amount<IVolumeFlow> Divide(this Amount<IMassFlow> left, Amount<IDensity> right)
    {
      return left.Divide<IVolumeFlow>(right);
    }

    /// <summary>
    /// skapar ett massflöde genom att multiplicera ett volymflöde med en densitet
    /// </summary>
    /// <param name="left">volymflöde</param>
    /// <param name="right">densitet</param>
    /// <returns>volymflöde * densitet</returns>
    /// <remarks></remarks>
    public static Amount<IMassFlow> Times(this Amount<IVolumeFlow> left, Amount<IDensity> right)
    {
      return left.Times<IMassFlow>(right);
    }

    /// <summary>
    /// Skapa en ny effekt genom att multiplicera en effekt med en dimensionslös faktor.
    /// </summary>
    /// <param name="left">effekt</param>
    /// <param name="right">faktor</param>
    /// <returns>effekt*faktor</returns>
    /// <remarks></remarks>
    public static Amount<IPower> Times(this Amount<IPower> left, Amount<IDimensionless> right)
    {
      return left.Times<IPower>(right);
    }

    public static Amount<IEnergy> Times(this Amount<IPower> left, Amount<IDuration> right)
    {
      return left.Times<IEnergy>(right);
    }

    public static Amount<IEnergy> Times(this Amount<IDuration> left, Amount<IPower> right)
    {
      return left.Times<IEnergy>(right);
    }

    /// <summary>
    /// skapar ett massflöde genom att multiplicera en densitet med ett volymflöde
    /// </summary>
    /// <param name="left">densitet</param>
    /// <param name="right">volymflöde</param>
    /// <returns>densitet * volymflöde</returns>
    /// <remarks></remarks>
    public static Amount<IMassFlow> Times(this Amount<IDensity> left, Amount<IVolumeFlow> right)
    {
      return left.Times<IMassFlow>(right);
    }

    public static Amount<IDensity> Times(this Amount<IDensity> left, Amount<IHumidityRatio> right)
    {
      return left.Times<IDensity>(right);
    }

    public static Amount<IHeatCapacityRate> Times(this Amount<ISpecificHeatCapacity> left, Amount<IMassFlow> right)
    {
      return left.Times<IHeatCapacityRate>(right);
    }

    public static Amount<IVolume> Times(this Amount<IVolumeFlow> left, Amount<IDuration> right)
    {
      return left.Times<IVolume>(right);
    }

    public static Amount<ITemperature> Divide(this Amount<IPower> left, Amount<IHeatCapacityRate> right)
    {
      return left.Divide<ITemperature>(right);
    }

    public static Amount<ISpecificFanPower> Divide(this Amount<IPower> left, Amount<IVolumeFlow> right)
    {
      return left.Divide<ISpecificFanPower>(right);
    }

    public static Amount<IDimensionless> Divide(this Amount<IPower> left, Amount<IPower> right)
    {
      return left.Divide<IDimensionless>(right);
    }

    public static Amount<IArea> Divide(this Amount<IVolumeFlow> left, Amount<IVelocity> right)
    {
      return left.Divide<IArea>(right);
    }

    public static Amount<IDimensionless> Divide(this Amount<ITemperature> left, Amount<ITemperature> right)
    {
      return left.Divide<IDimensionless>(right);
    }

    public static Amount<IArea> Times(this Amount<ILength> left, Amount<ILength> right)
    {
      return left.Times<IArea>(right);
    }

    public static Amount<IVolume> Times(this Amount<IArea> left, Amount<ILength> right)
    {
      return left.Times<IVolume>(right);
    }

    public static Amount<IDimensionless> Times(this Amount<IVolume> left, Amount<IDimensionlessPerVolume> right)
    {
      return left.Times<IDimensionless>(right);
    }

    public static Amount<IDimensionless> Times(this Amount<IEnergy> left, Amount<IDimensionlessPerEnergy> right)
    {
      return left.Times<IDimensionless>(right);
    }

    public static Amount<IDimensionless> Times(this Amount<IMass> left, Amount<IDimensionlessPerMass> right)
    {
      return left.Times<IDimensionless>(right);
    }

    public static Amount<IDimensionless> Times(this Amount<IDimensionlessPerMass> left, Amount<IMass> right)
    {
      return left.Times<IDimensionless>(right);
    }
  }
}