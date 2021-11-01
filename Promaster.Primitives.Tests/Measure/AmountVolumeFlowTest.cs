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
  public class AmountVolumeFlowTest
  {
    //m3/sec 2 m3/h

    [TestMethod]
    public void For_Value_0_m3persec_we_should_get_value_0_m3perhour()
    {
      double value = 0.0;
      Amount<IVolumeFlow> amountToTest = new AmountBuilder<IVolumeFlow>()
        .WithUnit(Units.CubicMeterPerSecond)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeterPerHour);
      Assert.AreEqual(Math.Round(VolumeFlowConversion.M3PerSec2M3PerHour(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_2_m3persec_we_should_get_value_7200_m3perhour()
    {
      double value = 2.0;
      Amount<IVolumeFlow> amountToTest = new AmountBuilder<IVolumeFlow>()
        .WithUnit(Units.CubicMeterPerSecond)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeterPerHour);
      Assert.AreEqual(Math.Round(VolumeFlowConversion.M3PerSec2M3PerHour(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_1_23_m3persec_we_should_get_value_4428_m3perhour()
    {
      double value = 1.23;
      Amount<IVolumeFlow> amountToTest = new AmountBuilder<IVolumeFlow>()
        .WithUnit(Units.CubicMeterPerSecond)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeterPerHour);
      Assert.AreEqual(Math.Round(VolumeFlowConversion.M3PerSec2M3PerHour(value), 5), Math.Round(convertedAmount, 5));
    }

    //m3/h 2 m3/sec
    [TestMethod]
    public void For_Value_0_m3perhour_we_should_get_value_0_m3persec()
    {
      double value = 0.0;
      Amount<IVolumeFlow> amountToTest = new AmountBuilder<IVolumeFlow>()
        .WithUnit(Units.CubicMeterPerHour)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeterPerSecond);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_7200_m3perhour_we_should_get_value_2_m3persec()
    {
      double value = 7200.0;
      Amount<IVolumeFlow> amountToTest = new AmountBuilder<IVolumeFlow>()
        .WithUnit(Units.CubicMeterPerHour)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeterPerSecond);
      Assert.AreEqual(Math.Round(VolumeFlowConversion.M3PerHour2M3PerSec(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_1500_85_m3perhour_we_should_get_value_0_4169_m3persec()
    {
      double value = 1500.85;
      Amount<IVolumeFlow> amountToTest = new AmountBuilder<IVolumeFlow>()
        .WithUnit(Units.CubicMeterPerHour)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeterPerSecond);
      Assert.AreEqual(Math.Round(VolumeFlowConversion.M3PerHour2M3PerSec(value), 5), Math.Round(convertedAmount, 5));
    }

    //m3/sec 2 m3/sec
    [TestMethod]
    public void For_Value_0_m3persec_we_should_get_value_0_m3persec()
    {
      double value = 0.0;
      Amount<IVolumeFlow> amountToTest = new AmountBuilder<IVolumeFlow>()
        .WithUnit(Units.CubicMeterPerSecond)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeterPerSecond);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_4_m3persec_we_should_get_value_4_m3persec()
    {
      double value = 4.0;
      Amount<IVolumeFlow> amountToTest = new AmountBuilder<IVolumeFlow>()
        .WithUnit(Units.CubicMeterPerSecond)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeterPerSecond);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_1_2_m3persec_we_should_get_value_1_2_m3persec()
    {
      double value = 1.2;
      Amount<IVolumeFlow> amountToTest = new AmountBuilder<IVolumeFlow>()
        .WithUnit(Units.CubicMeterPerSecond)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeterPerSecond);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    //m3/h 2 m3/h
    [TestMethod]
    public void For_Value_0_m3perhour_we_should_get_value_0_m3perhour()
    {
      double value = 0.0;
      Amount<IVolumeFlow> amountToTest = new AmountBuilder<IVolumeFlow>()
        .WithUnit(Units.CubicMeterPerHour)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeterPerHour);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_3000_m3perhour_we_should_get_value_3000_m3perhour()
    {
      double value = 3000.0;
      Amount<IVolumeFlow> amountToTest = new AmountBuilder<IVolumeFlow>()
        .WithUnit(Units.CubicMeterPerHour)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeterPerHour);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_896_8_m3perhour_we_should_get_value_896_8_m3perhour()
    {
      double value = 896.8;
      Amount<IVolumeFlow> amountToTest = new AmountBuilder<IVolumeFlow>()
        .WithUnit(Units.CubicMeterPerHour)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeterPerHour);
      Assert.AreEqual(Math.Round(value, 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_1_m3persecond_we_should_get_value_3600_m3perhour()
    {
      // Test values from
      //http://www.wolframalpha.com/input/?i=1+cubic+meter+per+second

      // Arrange
      Amount<IVolumeFlow> a = Amount.Exact(1, Units.CubicMeterPerSecond);

      // Act
      double cmph = a.ValueAs(Units.CubicMeterPerHour);

      // Assert
      Assert.AreEqual(3600, cmph, 0.01);
    }

    [TestMethod]
    public void For_Value_100_cf_we_should_get_value_2_point_832_m3()
    {
      // Test values from
      // http://www.wolframalpha.com/input/?i=100+cf

      // Arrange
      Amount<IVolume> a = Amount.Exact(100, Units.CubicFeet);

      // Act
      double m3 = a.ValueAs(Units.CubicMeter);

      // Assert
      Assert.AreEqual(2.832, m3, 0.001);
    }


    [TestMethod]
    public void For_Value_3795_cfm_we_should_get_value_6754_m3perhour()
    {
      // Test values from
      // http://www.wolframalpha.com/input/?i=77.14+grain%2Flb+in+g%2Fkg

      // Arrange
      Amount<IVolumeFlow> a = Amount.Exact(3975, Units.CubicFeetPerMinute);

      // Act
      double m3ph = a.ValueAs(Units.CubicMeterPerHour);
      
      // Assert
      Assert.AreEqual(6754, m3ph, 1);
    }

    [TestMethod]
    public void For_Value_8000_m3perh_we_should_get_value_4709_cfm()
    {
      double value = 8000;
      Amount<IVolumeFlow> amountToTest = new AmountBuilder<IVolumeFlow>()
        .WithUnit(Units.CubicMeterPerHour)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicFeetPerMinute);
      Assert.AreEqual(4709, Math.Round(convertedAmount, 0));
    }
  }
}
