using System;
using System.Collections.Generic;
using Promaster.Primitives.Measure.Quantity;
using Promaster.Primitives.Measure.Unit;

namespace Promaster.Primitives.Measure
{
  /// <summary>
  ///   This class determines for each IQuantity which unit will be used internally in the Amount objects member fields.
  ///   Keeping the unit the same in all Amount objects avoids trouble that stem from adding delta values.
  ///   Eg. 10 Celsius + 30 Fahrenheit where the latter is considered a delta will work if both are internally Celsius
  ///   but will otherwise cause unexpected results.
  /// </summary>
  public static class AmountStorageUnit
  {
    private static readonly Dictionary<Type, Unit.Unit> _storageUnits;

    static AmountStorageUnit()
    {
      _storageUnits = new Dictionary<Type, Unit.Unit>();

      AddStorageUnit(Units.MeterPerSquareSecond);
      AddStorageUnit(Units.MilliGramHydrogenCarbonatePerLiter);
      AddStorageUnit(Units.Mole);
      AddStorageUnit(Units.Radian);
      AddStorageUnit(Units.SquareMeter);
      AddStorageUnit(Units.Katal);
      AddStorageUnit(Units.Bit);
      AddStorageUnit(Units.KilogramPerCubicMeter);
      AddStorageUnit(Units.One);
      AddStorageUnit(Units.Second);
      AddStorageUnit(Units.Farad);
      AddStorageUnit(Units.Coulomb);
      AddStorageUnit(Units.Siemens);
      AddStorageUnit(Units.Ampere);
      AddStorageUnit(Units.Henry);
      AddStorageUnit(Units.Volt);
      AddStorageUnit(Units.Ohm);
      AddStorageUnit(Units.Joule);
      AddStorageUnit(Units.Newton);
      AddStorageUnit(Units.Hertz);
      AddStorageUnit(Units.Lux);
      AddStorageUnit(Units.Meter);
      AddStorageUnit(Units.Lumen);
      AddStorageUnit(Units.Candela);
      AddStorageUnit(Units.Weber);
      AddStorageUnit(Units.Tesla);
      AddStorageUnit(Units.Kilogram);
      AddStorageUnit(Units.KilogramPerSecond);
      AddStorageUnit(Units.KilogramSquareMeter);
      AddStorageUnit(Units.Watt);
      AddStorageUnit(Units.Pascal);
      AddStorageUnit(Units.Gray);
      AddStorageUnit(Units.Sievert);
      AddStorageUnit(Units.Becquerel);
      AddStorageUnit(Units.PercentHumidity);
      AddStorageUnit(Units.Steradian);
      AddStorageUnit(Units.Decibel);
      AddStorageUnit(Units.DecibelLw);
      AddStorageUnit(Units.KilojoulePerKilogram);
      AddStorageUnit(Units.KiloWattPerCubicMeterPerSecond);
      AddStorageUnit(Units.KilowattPerKelvin);
      AddStorageUnit(Units.KilojoulePerKilogramKelvin);
      AddStorageUnit(Units.GramPerKilogram);
      AddStorageUnit(Units.MeterPerSecond);
      AddStorageUnit(Units.MilliGramCalciumPerLiter);
      AddStorageUnit(Units.CelsiusWet);
      AddStorageUnit(Units.CubicMeter);
      AddStorageUnit(Units.CubicMeterPerSecond);
      AddStorageUnit(Units.Celsius);
      AddStorageUnit(Units.PascalSecond);
      AddStorageUnit(Units.Integer);
      AddStorageUnit(Units.Text);
      AddStorageUnit(Units.CelsiusDewPoint);
      AddStorageUnit(Units.OnePerCubicMeter);
      AddStorageUnit(Units.OnePerJoule);
      AddStorageUnit(Units.WattPerSquareMeter);
      AddStorageUnit(Units.LiterPerKiloWattHour);
      AddStorageUnit(Units.GramPerKiloWattHour);
      AddStorageUnit(Units.KilogramPerSquareMeterSecond);
      AddStorageUnit(Units.KiloWattHourPerCubicMeter);
      AddStorageUnit(Units.DeltaCelsius);
      AddStorageUnit(Units.LiterPerSecondPerKiloWatt);
      AddStorageUnit(Units.OnePerKilogram);
    }

    public static Unit.Unit GetStorageUnit(Type quantityType)
    {
      Unit.Unit storageUnit;
      if (!_storageUnits.TryGetValue(quantityType, out storageUnit))
        throw new Exception(string.Format("Storage unit not found for quantity {0}.", quantityType.Name));
      return storageUnit;
    }

    private static void AddStorageUnit<T>(Unit<T> unit) where T : IQuantity
    {
      _storageUnits.Add(typeof (T), unit);
    }
  }
}