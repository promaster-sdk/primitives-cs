using System;
using Promaster.Primitives.Measure;
using Promaster.Primitives.Measure.Quantity;
using Promaster.Primitives.Measure.Unit;
using Promaster.Primitives.Tests.TestUtils.Builders;
using Promaster.Primitives.Tests.TestUtils.ConversionHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Promaster.Primitives.Tests.Measure
{
  [TestClass]
  public class AmountTemperatureTest
  {
    //kelvin

    //kelvin 2 kelvin

    [TestMethod]
    public void For_Value_0_kelvin_we_should_get_value_0_kelvin()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Kelvin)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_10_kelvin_we_should_get_value_10_kelvin()
    {
      double value = 10.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Kelvin)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_5_kelvin_we_should_get_value_minus_5_kelvin()
    {
      double value = -5.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Kelvin)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_87_1_kelvin_we_should_get_value_87_1_kelvin()
    {
      double value = 87.1;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Kelvin)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    //kelvin 2 celsius
    [TestMethod]
    public void For_Value_0_kelvin_we_should_get_value_minus_273_15_celsius()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Kelvin)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Celsius);
      Assert.AreEqual(Math.Round(TemperatureConversion.K2C(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_354_kelvin_we_should_get_value_80_85_celsius()
    {
      double value = 354;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Kelvin)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Celsius);
      Assert.AreEqual(Math.Round(TemperatureConversion.K2C(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_56_kelvin_we_should_get_value_minus_329_15_celsius()
    {
      double value = -56;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Kelvin)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Celsius);
      Assert.AreEqual(Math.Round(TemperatureConversion.K2C(value), 5), Math.Round(convertedAmount, 5));
    }

    //kelvin 2 rankine

    [TestMethod]
    public void For_Value_0_kelvin_we_should_get_value_0_rankine()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Kelvin)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Rankine);
      Assert.AreEqual(Math.Round(TemperatureConversion.K2R(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_245_kelvin_we_should_get_value_441_rankine()
    {
      double value = 245.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Kelvin)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Rankine);
      Assert.AreEqual(Math.Round(TemperatureConversion.K2R(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_56_8_kelvin_we_should_get_value_102_24_rankine()
    {
      double value = 56.8;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Kelvin)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Rankine);
      Assert.AreEqual(Math.Round(TemperatureConversion.K2R(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_143_4_kelvin_we_should_get_value_minus_258_12_rankine()
    {
      double value = -143.4;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Kelvin)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Rankine);
      Assert.AreEqual(Math.Round(TemperatureConversion.K2R(value), 5), Math.Round(convertedAmount, 5));
    }

    //kelvin 2 fahrenheit
    [TestMethod]
    public void For_Value_0_kelvin_we_should_get_value_minus_459_67_fahrenheit()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Kelvin)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Fahrenheit);
      Assert.AreEqual(Math.Round(TemperatureConversion.K2F(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_459_67_kelvin_we_should_get_value_367_736_fahrenheit()
    {
      double value = 459.67;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Kelvin)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Fahrenheit);
      Assert.AreEqual(Math.Round(TemperatureConversion.K2F(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_10_kelvin_we_should_get_value_minus_477_67_fahrenheit()
    {
      double value = -10.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Kelvin)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Fahrenheit);
      Assert.AreEqual(Math.Round(TemperatureConversion.K2F(value), 5), Math.Round(convertedAmount, 5));
    }

    //celsius

    //celsius 2 kelvin
    [TestMethod]
    public void For_Value_0_celsius_we_should_get_value_273_15_kelvin()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Celsius)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(TemperatureConversion.C2K(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_50_celsius_we_should_get_value_323_15_kelvin()
    {
      double value = 50.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Celsius)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(TemperatureConversion.C2K(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_20_celsius_we_should_get_value_253_15_kelvin()
    {
      double value = -20.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Celsius)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(TemperatureConversion.C2K(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_13_58_celsius_we_should_get_value_286_73_kelvin()
    {
      double value = 13.58;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Celsius)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(TemperatureConversion.C2K(value), 5), Math.Round(convertedAmount, 5));
    }

    //celsius 2 celsius
    [TestMethod]
    public void For_Value_0_celsius_we_should_get_value_0_celsius()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Celsius)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Celsius);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_30_celsius_we_should_get_value_minus_30_celsius()
    {
      double value = -30.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Celsius)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Celsius);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_42_8_celsius_we_should_get_value_42_8_celsius()
    {
      double value = 42.8;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Celsius)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Celsius);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    //celsius 2 rankine
    [TestMethod]
    public void For_Value_0_celsius_we_should_get_value_491_67_rankine()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Celsius)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Rankine);
      Assert.AreEqual(Math.Round(TemperatureConversion.C2R(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_500_celsius_we_should_get_value_1391_67_rankine()
    {
      double value = 500.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Celsius)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Rankine);
      Assert.AreEqual(Math.Round(TemperatureConversion.C2R(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_50_celsius_we_should_get_value_401_67_rankine()
    {
      double value = -50.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Celsius)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Rankine);
      Assert.AreEqual(Math.Round(TemperatureConversion.C2R(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_204_97_celsius_we_should_get_value_122_724_rankine()
    {
      double value = -204.97;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Celsius)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Rankine);
      Assert.AreEqual(Math.Round(TemperatureConversion.C2R(value), 5), Math.Round(convertedAmount, 5));
    }

    //celsius 2 fahrenheit
    [TestMethod]
    public void For_Value_0_celsius_we_should_get_value_32_fahrenheit()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Celsius)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Fahrenheit);
      Assert.AreEqual(Math.Round(TemperatureConversion.C2F(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_35_celsius_we_should_get_value_95_fahrenheit()
    {
      double value = 35.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Celsius)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Fahrenheit);
      Assert.AreEqual(Math.Round(TemperatureConversion.C2F(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_104_587_celsius_we_should_get_value_220_2566_fahrenheit()
    {
      double value = 104.587;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Celsius)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Fahrenheit);
      Assert.AreEqual(Math.Round(TemperatureConversion.C2F(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_51_45_celsius_we_should_get_value_minus_60_61_fahrenheit()
    {
      double value = -51.45;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Celsius)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Fahrenheit);
      Assert.AreEqual(Math.Round(TemperatureConversion.C2F(value), 5), Math.Round(convertedAmount, 5));
    }

    //rankine

    //rankine 2 kelvin
    [TestMethod]
    public void For_Value_0_rankine_we_should_get_value_0_kelvin()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Rankine)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(TemperatureConversion.R2K(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_38_rankine_we_should_get_value_21_11111_kelvin()
    {
      double value = 38.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Rankine)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(TemperatureConversion.R2K(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_204_569_rankine_we_should_get_value_113_66056_kelvin()
    {
      double value = 204.589;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Rankine)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(TemperatureConversion.R2K(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_45_rankine_we_should_get_value_minus_25_kelvin()
    {
      double value = -45;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Rankine)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(TemperatureConversion.R2K(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_1_18_rankine_we_should_get_value_minus_0_65556_kelvin()
    {
      double value = -1.18;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Rankine)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(TemperatureConversion.R2K(value), 5), Math.Round(convertedAmount, 5));
    }

    //rankine 2 celsius
    [TestMethod]
    public void For_Value_0_rankine_we_should_get_value_minus_273_15_celcius()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Rankine)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Celsius);
      Assert.AreEqual(Math.Round(TemperatureConversion.R2C(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_300_rankine_we_should_get_value_minus_106_48333_celcius()
    {
      double value = 300.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Rankine)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Celsius);
      Assert.AreEqual(Math.Round(TemperatureConversion.R2C(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_521_03_rankine_we_should_get_value_16_31111_celcius()
    {
      double value = 521.03;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Rankine)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Celsius);
      Assert.AreEqual(Math.Round(TemperatureConversion.R2C(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_98_rankine_we_should_get_value_minus_327_59444_celcius()
    {
      double value = -98.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Rankine)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Celsius);
      Assert.AreEqual(Math.Round(TemperatureConversion.R2C(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_0_01_rankine_we_should_get_value_minus_273_15556_celcius()
    {
      double value = -0.01;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Rankine)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Celsius);
      Assert.AreEqual(Math.Round(TemperatureConversion.R2C(value), 5), Math.Round(convertedAmount, 5));
    }

    //rankine 2 rankine
    [TestMethod]
    public void For_Value_0_rankine_we_should_get_value_0_rankine()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Rankine)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Rankine);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_3_3_rankine_we_should_get_value_3_3_rankine()
    {
      double value = 3.3;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Rankine)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Rankine);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_10_18_rankine_we_should_get_value_minus_10_18_rankine()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Rankine)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Rankine);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    //rankine 2 fahrenheit
    [TestMethod]
    public void For_Value_0_rankine_we_should_get_value_minus_459_67_fahrenheit()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Rankine)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Fahrenheit);
      Assert.AreEqual(Math.Round(TemperatureConversion.R2F(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_895_2_rankine_we_should_get_value_435_53_fahrenheit()
    {
      double value = 895.2;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Rankine)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Fahrenheit);
      Assert.AreEqual(Math.Round(TemperatureConversion.R2F(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_108_236_rankine_we_should_get_value_minus_567_906_fahrenheit()
    {
      double value = -108.236;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Rankine)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Fahrenheit);
      Assert.AreEqual(Math.Round(TemperatureConversion.R2F(value), 5), Math.Round(convertedAmount, 5));
    }

    //fahrenheit

    //fahrenheit 2 kelvin
    [TestMethod]
    public void For_Value_0_fahrenheit_we_should_get_value_255_37222_kelvin()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(TemperatureConversion.F2K(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_114_fahrenheit_we_should_get_value_318_70556_kelvin()
    {
      double value = 114.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(TemperatureConversion.F2K(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_5_05_fahrenheit_we_should_get_value_258_17778_kelvin()
    {
      double value = 5.05;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(TemperatureConversion.F2K(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_222_fahrenheit_we_should_get_value_132_03889_kelvin()
    {
      double value = -222.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(TemperatureConversion.F2K(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_547_123_fahrenheit_we_should_get_value_minus_48_585_kelvin()
    {
      double value = -547.123;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kelvin);
      Assert.AreEqual(Math.Round(TemperatureConversion.F2K(value), 5), Math.Round(convertedAmount, 5));
    }

    //fahrenheit 2 celcius
    [TestMethod]
    public void For_Value_0_fahrenheit_we_should_get_value_minus_17_77778_celcius()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Celsius);
      Assert.AreEqual(Math.Round(TemperatureConversion.F2C(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_74_fahrenheit_we_should_get_value_23_33333_celcius()
    {
      double value = 74.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Celsius);
      Assert.AreEqual(Math.Round(TemperatureConversion.F2C(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_88_88_fahrenheit_we_should_get_value_31_6_celcius()
    {
      double value = 88.88;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Celsius);
      Assert.AreEqual(Math.Round(TemperatureConversion.F2C(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_5_fahrenheit_we_should_get_value_minus_20_55556_celcius()
    {
      double value = -5.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Celsius);
      Assert.AreEqual(Math.Round(TemperatureConversion.F2C(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_200_66_fahrenheit_we_should_get_value_minus_129_25556_celcius()
    {
      double value = -200.66;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Celsius);
      Assert.AreEqual(Math.Round(TemperatureConversion.F2C(value), 5), Math.Round(convertedAmount, 5));
    }

    //fahrenheit 2 rankine
    [TestMethod]
    public void For_Value_0_fahrenheit_we_should_get_value_minus_459_67_rankine()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Rankine);
      Assert.AreEqual(Math.Round(TemperatureConversion.F2R(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_55_fahrenheit_we_should_get_value_514_67_rankine()
    {
      double value = 55.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Rankine);
      Assert.AreEqual(Math.Round(TemperatureConversion.F2R(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_2_033_fahrenheit_we_should_get_value_461_703_rankine()
    {
      double value = 2.033;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Rankine);
      Assert.AreEqual(Math.Round(TemperatureConversion.F2R(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_5_fahrenheit_we_should_get_value_454_67_rankine()
    {
      double value = -5.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Rankine);
      Assert.AreEqual(Math.Round(TemperatureConversion.F2R(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_879_65_fahrenheit_we_should_get_value_minus_419_98_rankine()
    {
      double value = -879.65;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Rankine);
      Assert.AreEqual(Math.Round(TemperatureConversion.F2R(value), 5), Math.Round(convertedAmount, 5));
    }

    //fahrenheit 2 fahrenheit
    [TestMethod]
    public void For_Value_0_fahrenheit_we_should_get_value_0_fahrenheit()
    {
      double value = 0.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Fahrenheit);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_7_fahrenheit_we_should_get_value_0_fahrenheit()
    {
      double value = 7.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Fahrenheit);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_minus_20_fahrenheit_we_should_get_value_minus_20_fahrenheit()
    {
      double value = -20.0;
      Amount<ITemperature> amountToTest = new AmountBuilder<ITemperature>()
        .WithUnit(Units.Fahrenheit)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Fahrenheit);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    //[TestMethod]
    //public void Make_sure_31_6_Celsius_minus_neg_30_Fahrenheit_equals_118_88_Fahrenheit_temperature_difference()
    //{
    //  // Arrange
    //  Amount<ITemperature> c = Amount.Create(31.6, Units.Celsius);
    //  Amount<ITemperature> f = Amount.Create(-30.0, Units.Fahrenheit);

    //  // Act
    //  double result = (c - f).ValueAs(Units.Fahrenheit);

    //  // Assert
    //  Assert.AreEqual(118.88, result, 0.01);
    //}

    //[TestMethod]
    //public void Make_sure_31_6_Celsius_minus_neg_30_Fahrenheit_equals_66_04_Celsius_temperature_difference()
    //{
    //  // Arrange
    //  Amount<ITemperature> c = Amount.Create(31.6, Units.Celsius);
    //  Amount<ITemperature> f = Amount.Create(-30.0, Units.Fahrenheit);

    //  // Act
    //  double result = (c - f).ValueAs(Units.Celsius);

    //  // Assert
    //  Assert.AreEqual(66.04, result, 0.01);
    //}

    [TestMethod]
    public void Make_sure_20_Celsius_plus_60_Fahrenheit_equals_35_556_Celsius()
    {
      // Arrange
      Amount<ITemperature> c = Amount.Exact(20.0, Units.Celsius);
      Amount<ITemperature> f = Amount.Exact(60.0, Units.Fahrenheit);

      // Act
      double result = (c + f).ValueAs(Units.Celsius);

      // Assert
      Assert.AreEqual(35.556, result, 0.001);
    }

    [TestMethod]
    public void Make_sure_20_Celsius_plus_60_Fahrenheit_equals_96_Fahrenheit()
    {
      // Arrange
      Amount<ITemperature> c = Amount.Exact(20.0, Units.Celsius);
      Amount<ITemperature> f = Amount.Exact(60.0, Units.Fahrenheit);

      // Act
      double result = (c + f).ValueAs(Units.Fahrenheit);

      // Assert
      Assert.AreEqual(96.0, result, 0.1);
    }
  }
}
