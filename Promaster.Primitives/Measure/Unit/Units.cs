using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Promaster.Primitives.Measure.Quantity;

namespace Promaster.Primitives.Measure.Unit
{
  public static class Units
  {
    private static readonly Dictionary<Unit, string> _unitToString = new Dictionary<Unit, string>();
    private static readonly Dictionary<string, Unit> _stringToUnit = new Dictionary<string, Unit>();
    // Default constructor (prevents this class from being instantiated).


    static Units()
    {
      foreach (var fi in typeof(Units).GetFields(BindingFlags.Public | BindingFlags.Static))
      {
        var fieldUnit = fi.GetValue(null);
        _unitToString.Add((Unit)fieldUnit, fi.Name);
        _stringToUnit.Add(fi.Name.ToLower(), (Unit)fieldUnit);
      }
    }

    public static readonly Unit<IDimensionless> One = new ProductUnit<IDimensionless>().WithLabel(" ");
    public static readonly Unit<IDimensionless> Percent = (One / 100).WithLabel("%");


    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////
    ///////////////////
    // SI BASE UNITS //
    ///////////////////
    // The International System of Units (SI) defines seven units of measure as a basic set from which 
    // all other SI units are derived. These SI base units and their physical quantities are:[1]
    // ampere for electric current
    // candela for luminous intensity
    // meter for length
    // kilogram for mass
    // second for time
    // kelvin for temperature
    // mole for the amount of substance
    /// BEGIN: System of Units - SI
    /// <summary>
    ///   The base unit for electric current quantities ( <code>A</code> ). The Ampere is that constant current which, if maintained in two straight parallel conductors of infinite length, of negligible circular cross-section, and placed 1 metre apart in vacuum, would produce between these conductors a force equal to 2 × 10-7 newton per metre of length. It is named after the French physicist Andre Ampere (1775-1836).
    /// </summary>
    public static readonly Unit<IElectricCurrent> Ampere = new BaseUnit<IElectricCurrent>("A").WithLabel("A");

    /// <summary>
    ///   The base unit for luminous intensity quantities ( <code>cd</code> ). The candela is the luminous intensity, in a given direction, of a source that emits monochromatic radiation of frequency 540 × 1012 hertz and that has a radiant intensity in that direction of 1/683 watt per steradian @see <a
    ///    href="http://en.wikipedia.org/wiki/Candela">Wikipedia: Candela</a>
    /// </summary>
    public static readonly Unit<ILuminousIntensity> Candela = Si(new BaseUnit<ILuminousIntensity>("cd"));

    /// <summary>
    ///   The base unit for thermodynamic temperature quantities ( <code>K</code> ). The kelvin is the 1/273.16th of the thermodynamic temperature of the triple point of water. It is named after the Scottish mathematician and physicist William Thomson 1st Lord Kelvin (1824-1907)
    /// </summary>
    public static readonly Unit<ITemperature> Kelvin = new BaseUnit<ITemperature>("K").WithLabel("K");

    /// <summary>
    ///   The base unit for mass quantities ( <code>kg</code> ). It is the only SI unit with a prefix as part of its name and symbol. The kilogram is equal to the mass of an international prototype in the form of a platinum-iridium cylinder kept at Sevres in France. @see #GRAM
    /// </summary>
    public static readonly Unit<IMass> Kilogram = new BaseUnit<IMass>("kg").WithLabel("kg");

    /// <summary>
    ///   The base unit for length quantities ( <code>m</code> ). One meter was redefined in 1983 as the distance traveled by light in a vacuum in 1/299,792,458 of a second.
    /// </summary>
    public static readonly Unit<ILength> Meter = new BaseUnit<ILength>("m").WithLabel("m");

    /// <summary>
    ///   The base unit for amount of substance quantities ( <code>mol</code> ). The mole is the amount of substance of a system which contains as many elementary entities as there are atoms in 0.012 kilogram of carbon 12.
    /// </summary>
    public static readonly Unit<IAmountOfSubstance> Mole = Si(new BaseUnit<IAmountOfSubstance>("mol"));

    /// <summary>
    ///   The base unit for duration quantities ( <code>s</code> ). It is defined as the duration of 9,192,631,770 cycles of radiation corresponding to the transition between two hyperfine levels of the ground state of cesium (1967 Standard).
    /// </summary>
    public static readonly Unit<IDuration> Second = new BaseUnit<IDuration>("s").WithLabel("s");


    ////////////////////////////////
    // SI DERIVED ALTERNATE UNITS //
    ////////////////////////////////

    // AlternateUnits seems to be units with names like "Newton", "Celsius" while ProductUnits seem to be units with names like "MeterPerSecond"

    /// <summary>
    ///   The derived unit for mass quantities ( <code>g</code> ). The base unit for mass quantity is {@link #KILOGRAM}.
    /// </summary>
    public static readonly Unit<IMass> Gram = (Kilogram / 1000).WithLabel("g");

    /// <summary>
    ///   The unit for plane angle quantities ( <code>rad</code> ). One radian is the angle between two radii of a circle such that the length of the arc between them is equal to the radius.
    /// </summary>
    public static readonly Unit<IAngle> Radian = new AlternateUnit<IAngle>("rad", One).WithLabel("rad");

    /// <summary>
    ///   The unit for solid angle quantities ( <code>sr</code> ). One steradian is the solid angle subtended at the center of a sphere by an area on the surface of the sphere that is equal to the radius squared. The total solid angle of a sphere is 4*Pi steradians.
    /// </summary>
    public static readonly Unit<ISolidAngle> Steradian = new AlternateUnit<ISolidAngle>("sr", One).WithLabel("sr");

    /// <summary>
    ///   The unit for binary information ( <code>bit</code> ).
    /// </summary>
    public static readonly Unit<IDataAmount> Bit = new AlternateUnit<IDataAmount>("bit", One).WithLabel("bit");

    /// <summary>
    ///   The derived unit for frequency ( <code>Hz</code> ). A unit of frequency equal to one cycle per second. After Heinrich Rudolf Hertz (1857-1894), German physicist who was the first to produce radio waves artificially.
    /// </summary>
    public static readonly Unit<IFrequency> Hertz = new AlternateUnit<IFrequency>("Hz", One.Divide(Second)).WithLabel("Hz");

    /// <summary>
    ///   The derived unit for force ( <code>N</code> ). One newton is the force required to give a mass of 1 kilogram an Force of 1 metre per second per second. It is named after the English mathematician and physicist Sir Isaac Newton (1642-1727).
    /// </summary>
    ////public static readonly Unit<IForce> Newton = new AlternateUnit<IForce>("N", Meter.Times(Kilogram).Divide(Second.Pow(2))).WithLabel("N");
    public static readonly Unit<IForce> Newton = new AlternateUnit<IForce>("N", Meter.Times(Kilogram).Divide<IQuantity>(Second.Times<IQuantity>(Second))).WithLabel("N");

    //public static readonly Unit<IForce> Newton = Kilogram.Times<IForce>(MeterPerSquareSecond).WithLabel("N");

    /// <summary>
    ///   The derived unit for pressure, stress ( <code>Pa</code> ). One pascal is equal to one newton per square meter. It is named after the French philosopher and mathematician Blaise Pascal (1623-1662).
    /// </summary>
    //public static readonly Unit<IPressure> Pascal = new AlternateUnit<IPressure>("Pa", Newton.Divide(Meter.Pow(2))).WithLabel("Pa");
    public static readonly Unit<IPressure> Pascal = new AlternateUnit<IPressure>("Pa", Newton.Divide(Squared(Meter))).WithLabel("Pa");

    //public static readonly Unit<IPressure> Pascal = Newton.Divide<IPressure>(SquareMeter).WithLabel("Pa");

    /// <summary>
    ///   The derived unit for energy, work, quantity of heat ( <code>J</code> ). One joule is the amount of work done when an applied force of 1 newton moves through a distance of 1 metre in the direction of the force. It is named after the English physicist James Prescott Joule (1818-1889).
    /// </summary>
    public static readonly Unit<IEnergy> Joule = new AlternateUnit<IEnergy>("J", Newton.Times(Meter)).WithLabel("J");

    //public static readonly Unit<IEnergy> Joule = Newton.Times(Meter).WithLabel("J");

    /// <summary>
    ///   The derived unit for power, radiant, flux ( <code>W</code> ). One watt is equal to one joule per second. It is named after the British scientist James Watt (1736-1819).
    /// </summary>
    public static readonly Unit<IPower> Watt = new AlternateUnit<IPower>("W", Joule.Divide(Second)).WithLabel("W");

    //public static readonly Unit<IPower> Watt = Joule.Divide(Second).WithLabel("W");

    /// <summary>
    ///   The derived unit for electric charge, quantity of electricity ( <code>C</code> ). One Coulomb is equal to the quantity of charge transferred in one second by a steady current of one ampere. It is named after the French physicist Charles Augustin de Coulomb (1736-1806).
    /// </summary>
    public static readonly Unit<IElectricCharge> Coulomb = new AlternateUnit<IElectricCharge>("C", Second.Times(Ampere)).WithLabel("C");

    /// <summary>
    ///   The derived unit for electric potential difference, electromotive force ( <code>V</code> ). One Volt is equal to the difference of electric potential between two points on a conducting wire carrying a constant current of one ampere when the power dissipated between the points is one watt. It is named after the Italian physicist Count Alessandro Volta (1745-1827).
    /// </summary>
    public static readonly Unit<IElectricPotential> Volt = new AlternateUnit<IElectricPotential>("V", Watt.Divide(Ampere)).WithLabel("V");

    //public static readonly Unit<IElectromotiveForce> Volt = Watt.Divide<IElectromotiveForce>(Ampere).WithLabel("V");

    /// <summary>
    ///   The derived unit for capacitance ( <code>F</code> ). One Farad is equal to the capacitance of a capacitor having an equal and opposite charge of 1 coulomb on each plate and a potential difference of 1 volt between the plates. It is named after the British physicist and chemist Michael Faraday (1791-1867).
    /// </summary>
    public static readonly Unit<IElectricCapacitance> Farad = new AlternateUnit<IElectricCapacitance>("F", Coulomb.Divide(Volt)).WithLabel("F");

    /// <summary>
    ///   The derived unit for electric resistance ( <code>Ω</code> or <code>Ohm</code> ). One Ohm is equal to the resistance of a conductor in which a current of one ampere is produced by a potential of one volt across its terminals. It is named after the German physicist Georg Simon Ohm (1789-1854).
    /// </summary>
    public static readonly Unit<IElectricResistance> Ohm = Si(new AlternateUnit<IElectricResistance>("Ω", Volt.Divide(Ampere)));

    /// <summary>
    ///   The derived unit for electric conductance ( <code>S</code> ). One Siemens is equal to one ampere per volt. It is named after the German engineer Ernst Werner von Siemens (1816-1892).
    /// </summary>
    public static readonly Unit<IElectricConductance> Siemens = Si(new AlternateUnit<IElectricConductance>("S", Ampere.Divide(Volt)));

    /// <summary>
    ///   The derived unit for magnetic flux ( <code>Wb</code> ). One Weber is equal to the magnetic flux that in linking a circuit of one turn produces in it an electromotive force of one volt as it is uniformly reduced to zero within one second. It is named after the German physicist Wilhelm Eduard Weber (1804-1891).
    /// </summary>
    public static readonly Unit<IMagneticFlux> Weber = Si(new AlternateUnit<IMagneticFlux>("Wb", Volt.Times(Second)));

    /// <summary>
    ///   The derived unit for magnetic flux density ( <code>T</code> ). One Tesla is equal equal to one weber per square meter. It is named after the Serbian-born American electrical engineer and physicist Nikola Tesla (1856-1943).
    /// </summary>
    //public static readonly Unit<IMagneticFluxDensity> Tesla = si(new AlternateUnit<IMagneticFluxDensity>("T", Weber.Divide(Meter.pow(2))));
    public static readonly Unit<IMagneticFluxDensity> Tesla = Si(new AlternateUnit<IMagneticFluxDensity>("T", Weber.Divide(Squared(Meter))));

    /// <summary>
    ///   The derived unit for inductance ( <code>H</code> ). One Henry is equal to the inductance for which an induced electromotive force of one volt is produced when the current is varied at the rate of one ampere per second. It is named after the American physicist Joseph Henry (1791-1878).
    /// </summary>
    public static readonly Unit<IElectricInductance> Henry = Si(new AlternateUnit<IElectricInductance>("H", Weber.Divide(Ampere)));

    /// <summary>
    ///   The derived unit for Celsius temperature ( <code>℃</code> ). This is a unit of temperature such as the freezing point of water (at one atmosphere of pressure) is 0 ℃, while the boiling point is 100 ℃.
    /// </summary>
    public static readonly Unit<ITemperature> Celsius = Si((Kelvin + 273.15).WithLabel("°C"));

    //public static readonly Unit<ITemperature> Celsius = (Kelvin + 273.15).WithLabel("°C");

    /// <summary>
    ///   The derived unit for luminous flux ( <code>lm</code> ). One Lumen is equal to the amount of light given out through a solid angle by a source of one candela intensity radiating equally in all directions.
    /// </summary>
    public static readonly Unit<ILuminousFlux> Lumen = Si(new AlternateUnit<ILuminousFlux>("lm", Candela.Times(Steradian)));

    /// <summary>
    ///   The derived unit for illuminance ( <code>lx</code> ). One Lux is equal to one lumen per square meter.
    /// </summary>
    //public static readonly Unit<IIlluminance> Lux = si(new AlternateUnit<IIlluminance>("lx", Lumen.Divide(Meter.pow(2))));
    public static readonly Unit<IIlluminance> Lux = Si(new AlternateUnit<IIlluminance>("lx", Lumen.Divide(Squared(Meter))));

    /// <summary>
    ///   The derived unit for activity of a radionuclide ( <code>Bq</code> ). One becquerel is the radiation caused by one disintegration per second. It is named after the French physicist, Antoine-Henri Becquerel (1852-1908).
    /// </summary>
    public static readonly Unit<IRadioactiveActivity> Becquerel = Si(new AlternateUnit<IRadioactiveActivity>("Bq", One.Divide(Second)));

    /// <summary>
    ///   The derived unit for absorbed dose, specific energy (imparted), kerma ( <code>Gy</code> ). One gray is equal to the dose of one joule of energy absorbed per one kilogram of matter. It is named after the British physician L. H. Gray (1905-1965).
    /// </summary>
    public static readonly Unit<IRadiationDoseAbsorbed> Gray = Si(new AlternateUnit<IRadiationDoseAbsorbed>("Gy", Joule.Divide(Kilogram)));

    /// <summary>
    ///   The derived unit for dose equivalent ( <code>Sv</code> ). One Sievert is equal is equal to the actual dose, in grays, multiplied by a "quality factor" which is larger for more dangerous forms of radiation. It is named after the Swedish physicist Rolf Sievert (1898-1966).
    /// </summary>
    public static readonly Unit<IRadiationDoseEffective> Sievert = Si(new AlternateUnit<IRadiationDoseEffective>("Sv", Joule.Divide(Kilogram)));

    /// <summary>
    ///   The derived unit for catalytic activity ( <code>kat</code> ).
    /// </summary>
    public static readonly Unit<ICatalyticActivity> Katal = Si(new AlternateUnit<ICatalyticActivity>("kat", Mole.Divide(Second)));

    //////////////////////////////
    // SI DERIVED PRODUCT UNITS //
    //////////////////////////////

    /// <summary>
    ///   The metric unit for velocity quantities ( <code>m/s</code> ).
    /// </summary>
    //public static readonly Unit<IVelocity> MeterPerSecond = si(new ProductUnit<IVelocity>(Meter.Divide(Second)));
    public static readonly Unit<IVelocity> MeterPerSecond = Meter.Divide(Second).WithLabel("m/s");

    /// <summary>
    ///   The metric unit for acceleration quantities ( <code>m/s²</code> ).
    /// </summary>
    //public static readonly Unit<IAcceleration> MeterPerSquareSecond = si(new ProductUnit<IAcceleration>(MeterPerSecond.Divide(Second)));
    public static readonly Unit<IAcceleration> MeterPerSquareSecond = MeterPerSecond.Divide(Second);

    /// <summary>
    ///   The metric unit for area quantities ( <code>m²</code> ).
    /// </summary>
    //public static readonly Unit<IArea> SquareMeter = si(new ProductUnit<IArea>(Meter.Times(Meter)).WithLabel("m²"));
    public static readonly Unit<IArea> SquareMeter = Squared(Meter).WithLabel("m²");

    /// <summary>
    ///   The metric unit for volume quantities ( <code>m³</code> ).
    /// </summary>
    //public static readonly Unit<IVolume> CubicMeter = si(new ProductUnit<IVolume>(SquareMeter.Times(Meter)).WithLabel("m³"));
    public static readonly Unit<IVolume> CubicMeter = Cubed(Meter).WithLabel("m³");

    /// <summary>
    ///   Equivalent to <code>KILO(METRE)</code> .
    /// </summary>
    //public static readonly Unit<ILength> KILOMETER = Meter.Times(1000);
    public static readonly Unit<ILength> Kilometer = Kilo(Meter).WithLabel("km");

    /// <summary>
    ///   Equivalent to <code>CENTI(METRE)</code> .
    /// </summary>
    //public static readonly Unit<ILength> CENTIMETER = Meter.Divide(100);
    public static readonly Unit<ILength> CentiMeter = Centi(Meter).WithLabel("cm");

    /// <summary>
    ///   Equivalent to <code>MILLI(METRE)</code> .
    /// </summary>
    //public static readonly Unit<ILength> MILLIMETER = Meter.Divide(1000);
    public static readonly Unit<ILength> Millimeter = Milli(Meter).WithLabel("mm");

    /////////////////
    // SI PREFIXES //
    /////////////////

    private static Unit<T> Giga<T>(Unit<T> u) where T : IQuantity
    {
      return u * Math.Pow(10, 9);
    }

    private static Unit<T> Mega<T>(Unit<T> u) where T : IQuantity
    {
      return u * Math.Pow(10, 6);
    }

    ///<summary>
    ///  Returns the specified unit multiplied by the factor <code>10
    ///                                                        <sup>3</sup>
    ///                                                      </code> @param unit any unit. @return <code>unit.multiply(1e3)</code> .
    ///</summary>
    private static Unit<T> Kilo<T>(Unit<T> u) where T : IQuantity
    {
      return u * Math.Pow(10, 3);
    }


    ///<summary>
    ///  Returns the specified unit multiplied by the factor <code>10
    ///                                                        <sup>2</sup>
    ///                                                      </code> @param unit any unit. @return <code>unit.multiply(1e2)</code> .
    ///</summary>
    private static Unit<T> Hecto<T>(Unit<T> u) where T : IQuantity
    {
      return u * Math.Pow(10, 2);
    }

    ///<summary>
    ///  Returns the specified unit multiplied by the factor <code>10
    ///                                                        <sup>-1</sup>
    ///                                                      </code> @param unit any unit. @return <code>unit.multiply(1e-1)</code> .
    ///</summary>
    private static Unit<T> Deci<T>(Unit<T> u) where T : IQuantity
    {
      return u * Math.Pow(10, -1);
    }

    ///<summary>
    ///  Returns the specified unit multiplied by the factor <code>10
    ///                                                        <sup>-2</sup>
    ///                                                      </code> @param unit any unit. @return <code>unit.multiply(1e-2)</code> .
    ///</summary>
    private static Unit<T> Centi<T>(Unit<T> u) where T : IQuantity
    {
      return u * Math.Pow(10, -2);
    }

    ///<summary>
    ///  Returns the specified unit multiplied by the factor <code>10
    ///                                                        <sup>-3</sup>
    ///                                                      </code> @param unit any unit. @return <code>unit.multiply(1e-3)</code> .
    ///</summary>
    private static Unit<T> Milli<T>(Unit<T> u) where T : IQuantity
    {
      return u * Math.Pow(10, -3);
    }

    private static Unit<T> Si<T>(Unit<T> toAdd) where T : IQuantity
    {
      // TODO
      return toAdd;
    }

    private static Unit<IArea> Squared(Unit<ILength> u)
    {
      return u.Times<IArea>(u);
    }

    private static Unit<IVolume> Cubed(Unit<ILength> u)
    {
      return u.Times<IArea>(u).Times<IVolume>(u);
    }

    ////////////////////////////////////////////////////////////////////////////
    /// END: System of Units - SI
    ////////////////////////////////////////////////////////////////////////////

    // Alternative Quantities for Humidity
    public static readonly Unit<IRelativeHumidity> HumidityFactor = new ProductUnit<IRelativeHumidity>().WithLabel("r.H. factor");
    // Factor of humidity, eg., 0.01 means 1%
    public static readonly Unit<IRelativeHumidity> PercentHumidity = (HumidityFactor / 100).WithLabel("% r.H."); // Percent of humidity, eg., 10.0 means 10%
    public static readonly Unit<IWetTemperature> CelsiusWet = new BaseUnit<IWetTemperature>("wb°C").WithLabel("wb°C");
    public static readonly Unit<IWetTemperature> FahrenheitWet = ((5.0 / 9.0) * CelsiusWet - 32).WithLabel("wb°F");
    public static readonly Unit<IWetTemperature> KelvinWet = (CelsiusWet - 273.15).WithLabel("wb°K");
    public static readonly Unit<IDewPointTemperature> CelsiusDewPoint = new BaseUnit<IDewPointTemperature>("dp°C").WithLabel("dp°C");
    public static readonly Unit<IDewPointTemperature> FahrenheitDewPoint = ((5.0 / 9.0) * CelsiusDewPoint - 32).WithLabel("dp°F");
    public static readonly Unit<IDewPointTemperature> KelvinDewPoint = (CelsiusDewPoint - 273.15).WithLabel("dp°K");

    // Mass
    public static readonly Unit<IMass> PoundLb = (Kilogram / (100000000.0 / 45359237.0)).WithLabel("lb"); // http://www.wolframalpha.com/input/?i=kg
    public static readonly Unit<IMass> Grain = (Kilogram / (100000000000.0 / 6479891.0)).WithLabel("gr"); // http://www.wolframalpha.com/input/?i=grain
    public static readonly Unit<IMass> Slug = (Kilogram * 14.5939).WithLabel("slug");
    public static readonly Unit<IMass> Tonne = (Kilogram * 1000).WithLabel("t");
    public static readonly Unit<IMass> MilliGram = Milli(Gram).WithLabel("mg");

    // Per mass
    public static readonly Unit<IDimensionlessPerMass> OnePerKilogram = One.Divide<IDimensionlessPerMass>(Kilogram).WithLabel("/kg");
    public static readonly Unit<IDimensionlessPerMass> OnePerPoundLb = One.Divide<IDimensionlessPerMass>(PoundLb).WithLabel("/lb");

    // Length
    public static readonly Unit<ILength> Foot = (Meter * 0.3048).WithLabel("ft");
    public static readonly Unit<ILength> Yard = (Foot * 3.0).WithLabel("yd");
    public static readonly Unit<ILength> Inch = (Foot / 12.0).WithLabel("in");
    public static readonly Unit<ILength> Mile = (Foot * 5280).WithLabel("mi");
    public static readonly Unit<ILength> Decimeter = Deci(Meter).WithLabel("dm");

    // Temperature
    public static readonly Unit<ITemperature> Rankine = (Kelvin * 5.0 / 9.0).WithLabel("Rankine");
    public static readonly Unit<ITemperature> Fahrenheit = ((Kelvin * 5.0 / 9.0) + 459.67).WithLabel("°F");

    // Delta temperature
    public static readonly Unit<IDeltaTemperature> DeltaCelsius = new BaseUnit<IDeltaTemperature>("°C").WithLabel("°C");
    public static readonly Unit<IDeltaTemperature> DeltaFahrenheit = (DeltaCelsius * (5.0 / 9.0)).WithLabel("°F");

    // Duration / Time
    public static readonly Unit<IDuration> Minute = (Second * 60.0).WithLabel("min");
    public static readonly Unit<IDuration> Hour = (Minute * 60.0).WithLabel("h");
    public static readonly Unit<IDuration> Day = (Hour * 24.0).WithLabel("days");
    public static readonly Unit<IDuration> Week = (Day * 7.0).WithLabel("weeks");
    public static readonly Unit<IDuration> Year = (Hour * 8760).WithLabel("year");

    // Frequency
    public static readonly Unit<IFrequency> RevolutionsPerMinute = new AlternateUnit<IFrequency>("rpm", One.Divide(Minute)).WithLabel("rpm");
    public static readonly Unit<IFrequency> RevolutionsPerHour = new AlternateUnit<IFrequency>("rph", One.Divide(Hour)).WithLabel("rph");

    // Area
    public static readonly Unit<IArea> SquareInch = Squared(Inch).WithLabel("in²");
    public static readonly Unit<IArea> SquareFeet = Squared(Foot).WithLabel("ft²");
    public static readonly Unit<IArea> SquareMillimeter = Squared(Millimeter).WithLabel("mm²");
    public static readonly Unit<IArea> SquareCentimeter = Squared(CentiMeter).WithLabel("cm²");
    public static readonly Unit<IArea> SquareDecimeter = Squared(Decimeter).WithLabel("dm²");

    // Angle
    public static readonly Unit<IAngle> Degrees = (180 * Radian / Math.PI).WithLabel("°");

    // Volume
    public static readonly Unit<IVolume> CubicCentiMeter = Cubed(CentiMeter).WithLabel("cm³");
    public static readonly Unit<IVolume> CubicInch = Cubed(Inch).WithLabel("in³");
    public static readonly Unit<IVolume> CubicFeet = Cubed(Foot).WithLabel("ft³");
    public static readonly Unit<IVolume> HundredCubicFeet = (CubicFeet * 100).WithLabel("100 ft³");
    public static readonly Unit<IVolume> Liter = (CubicMeter / 1000.0).WithLabel("L");
    public static readonly Unit<IVolume> MilliLiter = Milli(Liter).WithLabel("ml");
    public static readonly Unit<IVolume> Gallon = (Liter * 3.785).WithLabel("gal");

    // Velocity
    public static readonly Unit<IVelocity> FeetPerSecond = Foot.Divide(Second).WithLabel("ft/s");
    public static readonly Unit<IVelocity> FeetPerMinute = Foot.Divide(Minute).WithLabel("ft/min");
    public static readonly Unit<IVelocity> KilometerPerHour = Kilometer.Divide(Hour).WithLabel("km/h");
    public static readonly Unit<IVelocity> MeterPerHour = Meter.Divide(Hour).WithLabel("m/h");

    // Acceleration

    // Density
    public static readonly Unit<IDensity> KilogramPerCubicMeter = Kilogram.Divide(CubicMeter).WithLabel("kg/m³");
    public static readonly Unit<IDensity> GramPerCubicCentiMeter = Gram.Divide(CubicCentiMeter).WithLabel("g/cm³");
    public static readonly Unit<IDensity> SlugPerCubicFeet = Slug.Divide(CubicFeet).WithLabel("slug/ft³");
    public static readonly Unit<IDensity> PoundPerCubicFoot = PoundLb.Divide<IDensity>(CubicFeet).WithLabel("lb/ft³");

    // Force
    public static readonly Unit<IForce> PoundForce = (Newton * 2000000000000.0 / 8896443230521.0).WithLabel("lb");

    // Pressure
    //public static readonly Unit<IPressure> HectoPascal = Hecto(Pascal).WithLabel("hPa");
    public static readonly Unit<IPressure> KiloPascal = Kilo(Pascal).WithLabel("kPa");
    public static readonly Unit<IPressure> HectoPascal = Hecto(Pascal).WithLabel("hPa");
    public static readonly Unit<IPressure> NewtonPerSquareMeter = Newton.Divide<IPressure>(SquareMeter).WithLabel("N/m²");

    public static readonly Unit<IPressure> PoundForcePerSquareInch = (Pascal * 8896443230521.0 / 1290320000.0).WithLabel("psi");
    // http://www.wolframalpha.com/input/?i=psi and select 'Show exact conversions'

    public static readonly Unit<IPressure> InchOfMercury = (Pascal * 514731.0 / 152.0).WithLabel("in HG");
    // http://www.wolframalpha.com/input/?i=inHg and select 'Show exact conversions'

    public static readonly Unit<IPressure> InchOfWaterColumn = (Pascal * 249.0889).WithLabel("in WC"); // http://www.wolframalpha.com/input/?i=inWC
    public static readonly Unit<IPressure> FeetOfWaterColumn = (Pascal * 2989.067).WithLabel("ft WC");
    public static readonly Unit<IPressure> Bar = (Pascal * 100000).WithLabel("bar");
    public static readonly Unit<IPressure> MilliBar = Milli(Bar).WithLabel("mbar");

    // Power
    public static readonly Unit<IPower> KiloWatt = Kilo(Watt).WithLabel("kW");
    public static readonly Unit<IPower> MegaWatt = Mega(Watt).WithLabel("MW");
    public static readonly Unit<IPower> GigaWatt = Giga(Watt).WithLabel("GW");
    public static readonly Unit<IPower> BtuPerHour = (Watt * (52752792631.0 / 50000000.0) / 3600).WithLabel("BTU/h");
    public static readonly Unit<IPower> TonCooling = (BtuPerHour * 12000).WithLabel("tons");
    public static readonly Unit<IPower> KiloBtuPerHour = Kilo(BtuPerHour).WithLabel("MBH");
    public static readonly Unit<IPower> HorsePower = (Watt * 745.699872).WithLabel("hp");
    public static readonly Unit<IPower> VoltAmpere = new AlternateUnit<IPower>("VA", Watt).WithLabel("VA");

    // Energy
    public static readonly Unit<IEnergy> NewtonMeter = Newton.Times(Meter).WithLabel("Nm");
    public static readonly Unit<IEnergy> Kilojoule = Kilo(Joule).WithLabel("kJ");
    public static readonly Unit<IEnergy> Megajoule = Mega(Joule).WithLabel("MJ");
    public static readonly Unit<IEnergy> KiloWattHour = KiloWatt.Times<IEnergy>(Hour).WithLabel("kWh");
    public static readonly Unit<IEnergy> MegaWattHour = MegaWatt.Times<IEnergy>(Hour).WithLabel("MWh");
    public static readonly Unit<IEnergy> GigaWattHour = GigaWatt.Times<IEnergy>(Hour).WithLabel("GWh");
    public static readonly Unit<IEnergy> WattHour = Watt.Times<IEnergy>(Hour).WithLabel("Wh");
    public static readonly Unit<IEnergy> WattSecond = Watt.Times<IEnergy>(Second).WithLabel("Ws");
    public static readonly Unit<IEnergy> Btu = (Joule * (52752792631.0 / 50000000.0)).WithLabel("BTU");
    public static readonly Unit<IEnergy> KiloBtu = Kilo(Btu).WithLabel("MBTU");
    // http://www.wolframalpha.com/input/?i=BTU and select 'Show exact conversions'

    // Per Energy
    public static readonly Unit<IDimensionlessPerEnergy> OnePerKiloWattHour = One.Divide<IDimensionlessPerEnergy>(KiloWattHour).WithLabel("/kWh");
    public static readonly Unit<IDimensionlessPerEnergy> OnePerBtu = One.Divide<IDimensionlessPerEnergy>(Btu).WithLabel("/BTU");
    public static readonly Unit<IDimensionlessPerEnergy> OnePerKilojoule = One.Divide<IDimensionlessPerEnergy>(Kilojoule).WithLabel("/kJ");
    public static readonly Unit<IDimensionlessPerEnergy> OnePerMegajoule = One.Divide<IDimensionlessPerEnergy>(Megajoule).WithLabel("/MJ");
    public static readonly Unit<IDimensionlessPerEnergy> OnePerJoule = One.Divide<IDimensionlessPerEnergy>(Joule).WithLabel("/J");

    // Emission
    public static readonly Unit<IEmission> KilogramPerKiloWattHour = Kilogram.Divide<IEmission>(KiloWattHour).WithLabel("kg/kWh");
    public static readonly Unit<IEmission> GramPerKiloWattHour = Gram.Divide<IEmission>(KiloWattHour).WithLabel("g/kWh");

    // MassFlow
    public static readonly Unit<IMassFlow> KilogramPerSecond = Kilogram.Divide(Second).WithLabel("kg/s");
    public static readonly Unit<IMassFlow> GramPerSecond = Gram.Divide(Second).WithLabel("g/s");
    public static readonly Unit<IMassFlow> KilogramPerHour = Kilogram.Divide(Hour).WithLabel("kg/h");
    public static readonly Unit<IMassFlow> SlugPerSecond = Slug.Divide(Second).WithLabel("slug/s");
    public static readonly Unit<IMassFlow> SlugPerHour = Slug.Divide(Hour).WithLabel("slug/h");
    public static readonly Unit<IMassFlow> PoundLbPerHour = PoundLb.Divide(Hour).WithLabel("lb/h");
    public static readonly Unit<IMassFlow> StandardCubicMeterPerHour = (KilogramPerHour * 1.2041).WithLabel("Sm³/h");
    public static readonly Unit<IMassFlow> StandardCubicMeterPerSecond = (StandardCubicMeterPerHour * 3600).WithLabel("Sm³/s");
    public static readonly Unit<IMassFlow> StandardCubicFeetPerMinute = (StandardCubicMeterPerHour * 60 * 0.02831684660923049289319782819867).WithLabel("SCFM");

    // VolumeFlow
    public static readonly Unit<IVolumeFlow> CubicMeterPerSecond = CubicMeter.Divide(Second).WithLabel("m³/s");
    public static readonly Unit<IVolumeFlow> CubicMeterPerHour = CubicMeter.Divide(Hour).WithLabel("m³/h");
    public static readonly Unit<IVolumeFlow> CubicFeetPerMinute = CubicFeet.Divide(Minute).WithLabel("acfm");
    public static readonly Unit<IVolumeFlow> CubicFeetPerHour = CubicFeet.Divide(Hour).WithLabel("acfh");
    public static readonly Unit<IVolumeFlow> HundredCubicFeetPerHour = HundredCubicFeet.Divide(Hour).WithLabel("cch");
    public static readonly Unit<IVolumeFlow> LiterPerSecond = Liter.Divide(Second).WithLabel("l/s");
    public static readonly Unit<IVolumeFlow> LiterPerMinute = Liter.Divide(Minute).WithLabel("l/m");
    public static readonly Unit<IVolumeFlow> LiterPerHour = Liter.Divide(Hour).WithLabel("l/h");
    public static readonly Unit<IVolumeFlow> GallonsPerMinute = Gallon.Divide(Minute).WithLabel("gal/min");
    public static readonly Unit<IVolumeFlow> GallonsPerHour = Gallon.Divide(Hour).WithLabel("gal/h");

    // Per Volume
    public static readonly Unit<IDimensionlessPerVolume> OnePerLiter = One.Divide<IDimensionlessPerVolume>(Liter).WithLabel("/l");
    public static readonly Unit<IDimensionlessPerVolume> OnePerCubicMeter = One.Divide<IDimensionlessPerVolume>(CubicMeter).WithLabel("/m³");
    public static readonly Unit<IDimensionlessPerVolume> OnePerGallon = One.Divide<IDimensionlessPerVolume>(Gallon).WithLabel("/gal");
    public static readonly Unit<IDimensionlessPerVolume> OnePerHundredCubicFeet = One.Divide<IDimensionlessPerVolume>(HundredCubicFeet).WithLabel("/100 ft³");

    // Water use efficiency
    public static readonly Unit<IWaterUseEfficiency> LiterPerKiloWattHour = Liter.Divide<IWaterUseEfficiency>(KiloWattHour).WithLabel("l/kWh");

    public static readonly Unit<IMassFlowPerArea> KilogramPerSquareMeterSecond = KilogramPerSecond.Divide<IMassFlowPerArea>(SquareMeter).WithLabel("kg/m²s");

    // Humidity
    public static readonly Unit<IHumidityRatio> KilogramPerKilogram = Kilogram.Divide<IHumidityRatio>(Kilogram).WithLabel("kg/kg");
    public static readonly Unit<IHumidityRatio> GramPerKilogram = Gram.Divide<IHumidityRatio>(Kilogram).WithLabel("g/kg");
    public static readonly Unit<IHumidityRatio> PoundLbPerPoundLb = PoundLb.Divide<IHumidityRatio>(PoundLb).WithLabel("lb/lb");
    public static readonly Unit<IHumidityRatio> GrainPerPoundLb = Grain.Divide<IHumidityRatio>(PoundLb).WithLabel("gr/lb");

    // Specific energy
    public static readonly Unit<ISpecificEnthalpy> KilojoulePerKilogram = Kilojoule.Divide(Kilogram).WithLabel("kJ/kg");
    public static readonly Unit<ISpecificEnthalpy> KiloWattHourPerKilogram = KiloWattHour.Divide(Kilogram).WithLabel("kWh/kg");
    //    public static readonly Unit<ISpecificEnthalpy> BtuPerPoundLb = Btu.Divide<ISpecificEnthalpy>(PoundLb).WithLabel("BTU/lb");
    public static readonly Unit<ISpecificEnthalpy> BtuPerPoundLb = ((KilojoulePerKilogram * 2.326) - 7.68).WithLabel("BTU/lb");

    // Energy per volume
    public static readonly Unit<IHeatingValue> KiloWattHourPerCubicMeter = KiloWattHour.Divide<IHeatingValue>(CubicMeter).WithLabel("kWh/m³");

    // Specific heat capacity of air at constant pressure (kJ/kg°C, kWs/kgK, Btu/lb°F)
    // Heat capacity is the measurable physical quantity that characterizes the amount of heat required to change a body's temperature by a given amount.
    // Check if this really is correct
    public static readonly Unit<ISpecificHeatCapacity> KilojoulePerKilogramKelvin = KilojoulePerKilogram.Times(Kelvin).WithLabel("kJ/kg°K");
    public static readonly Unit<ISpecificHeatCapacity> KilojoulePerKilogramCelsius = KilojoulePerKilogram.Times(Celsius).WithLabel("kJ/kg°C");

    // Heat Capacity Rate
    public static readonly Unit<IHeatCapacityRate> KilowattPerCelsius = KiloWatt.Divide(Celsius).WithLabel("kW/°C");
    public static readonly Unit<IHeatCapacityRate> KilowattPerKelvin = KiloWatt.Divide(Kelvin).WithLabel("kW/K");

    // Moment of inertia
    public static readonly Unit<IMomentOfInertia> KilogramSquareMeter = Kilogram.Times(SquareMeter).WithLabel("kg·m²");

    // Intensity
    public static readonly Unit<IIntensity> WattPerSquareMeter = Watt.Divide<IIntensity>(SquareMeter).WithLabel("W/m²");

    // Specific Fan Power
    public static readonly Unit<ISpecificFanPower> KiloWattPerCubicMeterPerSecond = KiloWatt.Divide<ISpecificFanPower>(CubicMeterPerSecond).WithLabel("kW/m³/s");
    public static readonly Unit<ISpecificFanPower> WattPerCubicMeterPerSecond = Watt.Divide<ISpecificFanPower>(CubicMeterPerSecond).WithLabel("W/m³/s");

    // Sound pressure level
    public static readonly Unit<ISoundPressureLevel> Decibel = new AlternateUnit<ISoundPressureLevel>("dB", One.Times<ISoundPressureLevel>(One)).WithLabel("dB");

    // Sound power level
    public static readonly Unit<ISoundPowerLevel> DecibelLw = new AlternateUnit<ISoundPowerLevel>("dB", One.Times<ISoundPowerLevel>(One)).WithLabel("dB");

    // Water hardness
    public static readonly Unit<IWaterHardness> MilliGramCalciumPerLiter = new BaseUnit<IWaterHardness>("mg Ca²⁺/l").WithLabel("mg Ca²⁺/l");
    public static readonly Unit<IWaterHardness> FrenchDegree = (MilliGramCalciumPerLiter * 4.0043).WithLabel("°f");

    // ElectricPotential
    public static readonly Unit<IElectricPotential> MilliVolt = Milli(Volt).WithLabel("mV");
    public static readonly Unit<IElectricPotential> KiloVolt = Kilo(Volt).WithLabel("kV");

    // Discrete
    public static readonly Unit<IDiscrete> Integer = new ProductUnit<IDiscrete>().WithLabel(" ");

    // Text
    public static readonly Unit<IText> Text = new ProductUnit<IText>().WithLabel(" ");

    // Alkalinity
    public static readonly Unit<IAlkalinity> MilliGramHydrogenCarbonatePerLiter = new BaseUnit<IAlkalinity>("mg HCO₃⁻/l").WithLabel("mg HCO₃⁻/l");

    public static readonly Unit<IViscosity> PascalSecond = new BaseUnit<IViscosity>("Pa·s");

    // Volume flow per cooling power
    public static readonly Unit<IVolumeFlowPerPower> GallonsPerMinutePerTonCooling = GallonsPerMinute.Divide<IVolumeFlowPerPower>(TonCooling).WithLabel("gpm/ton");
    public static readonly Unit<IVolumeFlowPerPower> LiterPerSecondPerKiloWatt = LiterPerSecond.Divide<IVolumeFlowPerPower>(KiloWatt).WithLabel("l/s/kW");

    public static Unit Parse(string unitString)
    {
      Unit unit;
      if (_stringToUnit.TryGetValue(unitString.Trim().ToLower(), out unit))
        return unit;
      throw new Exception("Unknown unit " + unitString);
    }

    public static bool TryParse(string unitString, out Unit unit)
    {
      return _stringToUnit.TryGetValue(unitString.Trim().ToLower(), out unit);
    }

    public static bool TryParse<TQuantity>(string unitString, out Unit<TQuantity> unit) where TQuantity : IQuantity
    {
      Unit unit2;
      if (!_stringToUnit.TryGetValue(unitString.Trim().ToLower(), out unit2))
      {
        unit = default(Unit<TQuantity>);
        return false;
      }
      unit = unit2 as Unit<TQuantity>;
      if (unit != null)
        return true;
      else
        return false;
    }

    public static Type GetQuantityTypeFromString(string quantity)
    {
      quantity = quantity.Trim();
      var referenceType = typeof(IQuantity);
      var quantityType = referenceType.Assembly.GetType(referenceType.Namespace + ".I" + quantity);
      if (quantityType == null)
        throw new Exception(string.Format("Invalid quantity '{0}'.", quantity));
      return quantityType;
    }

    public static bool IsUnit(string unit)
    {
      return _stringToUnit.ContainsKey(unit.Trim().ToLower());
    }

    public static string GetStringFromUnit(Unit unit)
    {
      string name;
      if (_unitToString.TryGetValue(unit, out name))
        return name;
      throw new Exception("Unknown Unit " + unit);
    }

    public static IList<Unit> GetUnitsForQuantity(Type quantityType)
    {
      var list = new List<Unit>();
      foreach (var fi in typeof(Units).GetFields(BindingFlags.Public | BindingFlags.Static))
      {
        Type fieldQuantityType = fi.FieldType.GetGenericArguments()[0];
        if (fieldQuantityType.Equals(quantityType))
        {
          var unit = fi.GetValue(null);
          list.Add(unit as Unit);
        }
      }
      return list;
    }

    public static IEnumerable<Unit> GetAllUnits()
    {
      var list = new List<Unit>();
      foreach (var fi in typeof(Units).GetFields(BindingFlags.Public | BindingFlags.Static))
      {
        Type fieldQuantityType = fi.FieldType.GetGenericArguments()[0];
        if ((typeof(IQuantity)).IsAssignableFrom(fieldQuantityType))
        {
          var unit = fi.GetValue(null);
          list.Add(unit as Unit);
        }
      }
      return list;
    }
  }
}
