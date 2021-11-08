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
  public class AmountVolumeTest
  {
    //liter 2 cubic_meter
    [TestMethod]
    public void For_Value_0_liter_we_should_get_value_0_cubic_meter()
    {
      double value = 0.0;
      Amount<IVolume> amountToTest = new AmountBuilder<IVolume>()
        .WithUnit(Units.Liter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeter);
      Assert.AreEqual(VolumeConversion.L2M3(value), convertedAmount);
    }

    [TestMethod]
    public void For_Value_3_liter_we_should_get_value_0_003_cubic_meter()
    {
      double value = 3.0;
      Amount<IVolume> amountToTest = new AmountBuilder<IVolume>()
        .WithUnit(Units.Liter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeter);
      Assert.AreEqual(VolumeConversion.L2M3(value), convertedAmount);
    }

    [TestMethod]
    public void For_Value_78945_liter_we_should_get_value_78_945_cubic_meter()
    {
      double value = 78945.0;
      Amount<IVolume> amountToTest = new AmountBuilder<IVolume>()
        .WithUnit(Units.Liter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeter);
      Assert.AreEqual(Math.Round(VolumeConversion.L2M3(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_5_liter_we_should_get_value_0_0005_cubic_meter()
    {
      double value = 0.5;
      Amount<IVolume> amountToTest = new AmountBuilder<IVolume>()
        .WithUnit(Units.Liter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeter);
      Assert.AreEqual(Math.Round(VolumeConversion.L2M3(value), 5), Math.Round(convertedAmount, 5));
    }

    //cubic_meter 2 liter
    [TestMethod]
    public void For_Value_0_cubic_meter_we_should_get_value_0_liter()
    {
      double value = 0.0;
      Amount<IVolume> amountToTest = new AmountBuilder<IVolume>()
        .WithUnit(Units.CubicMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Liter);
      Assert.AreEqual(VolumeConversion.M32L(value), convertedAmount);
    }

    [TestMethod]
    public void For_Value_5_cubic_meter_we_should_get_value_5000_liter()
    {
      double value = 5.0;
      Amount<IVolume> amountToTest = new AmountBuilder<IVolume>()
        .WithUnit(Units.CubicMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Liter);
      Assert.AreEqual(VolumeConversion.M32L(value), convertedAmount);
    }

    [TestMethod]
    public void For_Value_100_hcf_we_should_get_value_10000_ft3()
    {
      // Arrange
      Amount<IVolume> a = Amount.Exact(100, Units.HundredCubicFeet);

      // Act
      double cf = a.ValueAs(Units.CubicFeet);

      // Assert
      Assert.AreEqual(10000, cf, 0.001);
    }
    
    [TestMethod]
    public void For_Value_0_865_cubic_meter_we_should_get_value_865_liter()
    {
      double value = 0.865;
      Amount<IVolume> amountToTest = new AmountBuilder<IVolume>()
        .WithUnit(Units.CubicMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Liter);
      Assert.AreEqual(VolumeConversion.M32L(value), convertedAmount);
    }

    [TestMethod]
    public void For_Value_0_0007_cubic_meter_we_should_get_value_0_7_liter()
    {
      double value = 0.0007;
      Amount<IVolume> amountToTest = new AmountBuilder<IVolume>()
        .WithUnit(Units.CubicMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Liter);
      Assert.AreEqual(VolumeConversion.M32L(value), convertedAmount);
    }


    //liter 2 liter

    [TestMethod]
    public void For_Value_0_liter_we_should_get_value_0_liter()
    {
      double value = 0.0;
      Amount<IVolume> amountToTest = new AmountBuilder<IVolume>()
        .WithUnit(Units.Liter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Liter);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_3_liter_we_should_get_value_3_liter()
    {
      double value = 3.0;
      Amount<IVolume> amountToTest = new AmountBuilder<IVolume>()
        .WithUnit(Units.Liter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Liter);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_5_34_liter_we_should_get_value_5_34_liter()
    {
      double value = 5.34;
      Amount<IVolume> amountToTest = new AmountBuilder<IVolume>()
        .WithUnit(Units.Liter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Liter);
      Assert.AreEqual(value, convertedAmount);
    }

    //cubic_meter 2 cubic_meter

    [TestMethod]
    public void For_Value_0_cubic_meter_we_should_get_value_0_cubic_meter()
    {
      double value = 0.0;
      Amount<IVolume> amountToTest = new AmountBuilder<IVolume>()
        .WithUnit(Units.CubicMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeter);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_3_cubic_meter_we_should_get_value_3_cubic_meter()
    {
      double value = 3.0;
      Amount<IVolume> amountToTest = new AmountBuilder<IVolume>()
        .WithUnit(Units.CubicMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeter);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_5_34_cubic_meter_we_should_get_value_5_34_cubic_meter()
    {
      double value = 5.34;
      Amount<IVolume> amountToTest = new AmountBuilder<IVolume>()
        .WithUnit(Units.CubicMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CubicMeter);
      Assert.AreEqual(value, convertedAmount);
    }
  }
}
