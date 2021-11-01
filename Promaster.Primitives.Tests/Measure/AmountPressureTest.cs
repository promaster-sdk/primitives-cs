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
  public class AmountPressureTest
  {
    //pascal 2 kilopascal
    [TestMethod]
    public void For_Value_0_pascal_we_should_get_value_0_kilopascal()
    {
      double value = 0.0;
      Amount<IPressure> amountToTest = new AmountBuilder<IPressure>()
        .WithUnit(Units.Pascal)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.KiloPascal);
      Assert.AreEqual(PressureConversion.Pa2KPa(value), convertedAmount);
    }

    [TestMethod]
    public void For_Value_3_pascal_we_should_get_value_0_003_kilopascal()
    {
      double value = 3.0;
      Amount<IPressure> amountToTest = new AmountBuilder<IPressure>()
        .WithUnit(Units.Pascal)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.KiloPascal);
      Assert.AreEqual(PressureConversion.Pa2KPa(value), convertedAmount);
    }

    [TestMethod]
    public void For_Value_78945_pascal_we_should_get_value_78_945_kilopascal()
    {
      double value = 78945.0;
      Amount<IPressure> amountToTest = new AmountBuilder<IPressure>()
        .WithUnit(Units.Pascal)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.KiloPascal);
      Assert.AreEqual(Math.Round(PressureConversion.Pa2KPa(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_5_pascal_we_should_get_value_0_0005_kilopascal()
    {
      double value = 0.5;
      Amount<IPressure> amountToTest = new AmountBuilder<IPressure>()
        .WithUnit(Units.Pascal)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.KiloPascal);
      Assert.AreEqual(Math.Round(PressureConversion.Pa2KPa(value), 5), Math.Round(convertedAmount, 5));
    }

    //kilopascal 2 pascal
    [TestMethod]
    public void For_Value_0_kilopascal_we_should_get_value_0_pascal()
    {
      double value = 0.0;
      Amount<IPressure> amountToTest = new AmountBuilder<IPressure>()
        .WithUnit(Units.KiloPascal)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Pascal);
      Assert.AreEqual(PressureConversion.KPa2Pa(value), convertedAmount);
    }

    [TestMethod]
    public void For_Value_5_kilopascal_we_should_get_value_5000_pascal()
    {
      double value = 5.0;
      Amount<IPressure> amountToTest = new AmountBuilder<IPressure>()
        .WithUnit(Units.KiloPascal)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Pascal);
      Assert.AreEqual(PressureConversion.KPa2Pa(value), convertedAmount);
    }

    [TestMethod]
    public void For_Value_0_865_kilopascal_we_should_get_value_865_pascal()
    {
      double value = 0.865;
      Amount<IPressure> amountToTest = new AmountBuilder<IPressure>()
        .WithUnit(Units.KiloPascal)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Pascal);
      Assert.AreEqual(PressureConversion.KPa2Pa(value), convertedAmount);
    }

    [TestMethod]
    public void For_Value_0_0007_kilopascal_we_should_get_value_0_7_pascal()
    {
      double value = 0.0007;
      Amount<IPressure> amountToTest = new AmountBuilder<IPressure>()
        .WithUnit(Units.KiloPascal)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Pascal);
      Assert.AreEqual(PressureConversion.KPa2Pa(value), convertedAmount);
    }


    //pascal 2 pascal

    [TestMethod]
    public void For_Value_0_pascal_we_should_get_value_0_pascal()
    {
      double value = 0.0;
      Amount<IPressure> amountToTest = new AmountBuilder<IPressure>()
        .WithUnit(Units.Pascal)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Pascal);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_3_pascal_we_should_get_value_3_pascal()
    {
      double value = 3.0;
      Amount<IPressure> amountToTest = new AmountBuilder<IPressure>()
        .WithUnit(Units.Pascal)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Pascal);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_5_34_pascal_we_should_get_value_5_34_pascal()
    {
      double value = 5.34;
      Amount<IPressure> amountToTest = new AmountBuilder<IPressure>()
        .WithUnit(Units.Pascal)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Pascal);
      Assert.AreEqual(value, convertedAmount);
    }

    //kilopascal 2 kilopascal

    [TestMethod]
    public void For_Value_0_kilopascal_we_should_get_value_0_kilopascal()
    {
      double value = 0.0;
      Amount<IPressure> amountToTest = new AmountBuilder<IPressure>()
        .WithUnit(Units.KiloPascal)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.KiloPascal);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_3_kilopascal_we_should_get_value_3_kilopascal()
    {
      double value = 3.0;
      Amount<IPressure> amountToTest = new AmountBuilder<IPressure>()
        .WithUnit(Units.KiloPascal)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.KiloPascal);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_5_34_kilopascal_we_should_get_value_5_34_kilopascal()
    {
      double value = 5.34;
      Amount<IPressure> amountToTest = new AmountBuilder<IPressure>()
        .WithUnit(Units.KiloPascal)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.KiloPascal);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_29_921_inHG_we_should_get_value_101_325_kilopascal()
    {
      // Arrange
      Amount<IPressure> p = Amount.Exact(29.921, Units.InchOfMercury);

      // Act
      double result = p.ValueAs(Units.KiloPascal);

      // Assert
      Assert.AreEqual(101.325, result, 0.001);
    }

    [TestMethod]
    public void For_Value_1_psi_we_should_get_value_6895_pascal()
    {
      // Arrange
      Amount<IPressure> p = Amount.Exact(1.0, Units.PoundForcePerSquareInch);

      // Act
      double result = p.ValueAs(Units.Pascal);

      // Assert
      Assert.AreEqual(6895, result, 0.5);
    }
  }
}
