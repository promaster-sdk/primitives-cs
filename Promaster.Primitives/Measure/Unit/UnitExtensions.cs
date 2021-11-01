using Promaster.Primitives.Measure.Quantity;

namespace Promaster.Primitives.Measure.Unit
{

  /// <summary>
  /// Methods that deterime a resulting quantity when multiplying or dividing units.
  /// </summary>
  public static class UnitExtensions
  {
    public static Unit<IMassFlow> Divide(this Unit<IMass> left, Unit<IDuration> right)
    {
      return left.Divide<IMassFlow>(right);
    }

    public static Unit<IDensity> Divide(this Unit<IMass> left, Unit<IVolume> right)
    {
      return left.Divide<IDensity>(right);
    }

    public static Unit<IArea> Times(this Unit<ILength> left, Unit<ILength> right)
    {
      return left.Times<IArea>(right);
    }

    public static Unit<IVolume> Times(this Unit<IArea> left, Unit<ILength> right)
    {
      return left.Times<IVolume>(right);
    }

    public static Unit<IVolume> Times(this Unit<ILength> left, Unit<IArea> right)
    {
      return left.Times<IVolume>(right);
    }

    public static Unit<IForce> Times(this Unit<IMass> left, Unit<IAcceleration> right)
    {
      return left.Times<IForce>(right);
    }

    public static Unit<IForce> Times(this Unit<IAcceleration> left, Unit<IMass> right)
    {
      return left.Times<IForce>(right);
    }

    public static Unit<IPressure> Divide(this Unit<IForce> left, Unit<IArea> right)
    {
      return left.Times<IPressure>(right);
    }

    public static Unit<IVolumeFlow> Divide(this Unit<IVolume> left, Unit<IDuration> right)
    {
      return left.Divide<IVolumeFlow>(right);
    }

    public static Unit<IVelocity> Divide(this Unit<ILength> left, Unit<IDuration> right)
    {
      return left.Divide<IVelocity>(right);
    }

    public static Unit<IAcceleration> Divide(this Unit<IVelocity> left, Unit<IDuration> right)
    {
      return left.Divide<IAcceleration>(right);
    }

    public static Unit<IFrequency> Divide(this Unit<IDimensionless> left, Unit<IDuration> right)
    {
      return left.Divide<IFrequency>(right);
    }

    public static Unit<IEnergy> Times(this Unit<IForce> left, Unit<ILength> right)
    {
      return left.Times<IEnergy>(right);
    }

    public static Unit<IPower> Divide(this Unit<IEnergy> left, Unit<IDuration> right)
    {
      return left.Divide<IPower>(right);
    }

    public static Unit<ISpecificEnthalpy> Divide(this Unit<IEnergy> left, Unit<IMass> right)
    {
      return left.Divide<ISpecificEnthalpy>(right);
    }

    public static Unit<ISpecificHeatCapacity> Times(this Unit<ISpecificEnthalpy> left, Unit<ITemperature> right)
    {
      return left.Divide<ISpecificHeatCapacity>(right);
    }

    public static Unit<IHeatCapacityRate> Divide(this Unit<IPower> left, Unit<ITemperature> right)
    {
      return left.Divide<IHeatCapacityRate>(right);
    }

    public static Unit<IMomentOfInertia> Times(this Unit<IMass> left, Unit<IArea> right)
    {
      return left.Times<IMomentOfInertia>(right);
    }

    public static Unit<IElectricCharge> Times(this Unit<IDuration> left, Unit<IElectricCurrent> right)
    {
      return left.Times<IElectricCharge>(right);
    }

    public static Unit<IElectricPotential> Divide(this Unit<IPower> left, Unit<IElectricCurrent> right)
    {
      return left.Divide<IElectricPotential>(right);
    }

    public static Unit<IElectricCapacitance> Divide(this Unit<IElectricCharge> left, Unit<IElectricPotential> right)
    {
      return left.Divide<IElectricCapacitance>(right);
    }

    public static Unit<IElectricResistance> Divide(this Unit<IElectricPotential> left, Unit<IElectricCurrent> right)
    {
      return left.Divide<IElectricResistance>(right);
    }

    public static Unit<IElectricInductance> Divide(this Unit<IMagneticFlux> left, Unit<IElectricCurrent> right)
    {
      return left.Divide<IElectricInductance>(right);
    }

    public static Unit<IElectricResistance> Divide(this Unit<IElectricCurrent> left, Unit<IElectricPotential> right)
    {
      return left.Divide<IElectricResistance>(right);
    }

    public static Unit<IMagneticFlux> Times(this Unit<IElectricPotential> left, Unit<IDuration> right)
    {
      return left.Times<IMagneticFlux>(right);
    }

    public static Unit<ILuminousFlux> Times(this Unit<ILuminousIntensity> left, Unit<ISolidAngle> right)
    {
      return left.Times<ILuminousFlux>(right);
    }

    public static Unit<ICatalyticActivity> Divide(this Unit<IAmountOfSubstance> left, Unit<IDuration> right)
    {
      return left.Divide<ICatalyticActivity>(right);
    }

    public static Unit<IMagneticFluxDensity> Divide(this Unit<IMagneticFlux> left, Unit<IArea> right)
    {
      return left.Divide<IMagneticFluxDensity>(right);
    }

    public static Unit<IIlluminance> Divide(this Unit<ILuminousFlux> left, Unit<IArea> right)
    {
      return left.Divide<IIlluminance>(right);
    }

    /// <summary>
    /// kil·o·gram-me·ter (kl-grm-mtr)
    /// A unit of energy and work in the meter-kilogram-second system, equal to the work performed by a one-kilogram force acting through a distance of one meter.
    /// </summary>
    public static Unit<IEnergy> Times(this Unit<ILength> left, Unit<IMass> right)
    {
      return left.Times<IEnergy>(right);
    }

    public static Unit<IArea> Squared(this Unit<ILength> u)
    {
      return u.Times(u);
    }

    public static Unit<IVolume> Cubed(this Unit<ILength> u)
    {
      return u.Times(u).Times(u);
    }
  }

}


