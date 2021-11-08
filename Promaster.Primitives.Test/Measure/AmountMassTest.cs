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
  public class AmountMassTest
  {
    //gram 2 kilogram
    [TestMethod]
    public void For_Value_0_gram_we_should_get_value_0_kilogram()
    {
      double value = 0.0;
      Amount<IMass> amountToTest = new AmountBuilder<IMass>()
        .WithUnit(Units.Gram)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilogram);
      Assert.AreEqual(MassConversion.G2Kg(value), convertedAmount);
    }

    [TestMethod]
    public void For_Value_3_gram_we_should_get_value_0_003_kilogram()
    {
      double value = 3.0;
      Amount<IMass> amountToTest = new AmountBuilder<IMass>()
        .WithUnit(Units.Gram)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilogram);
      Assert.AreEqual(MassConversion.G2Kg(value), convertedAmount);
    }

    [TestMethod]
    public void For_Value_78945_gram_we_should_get_value_78_945_kilogram()
    {
      double value = 78945.0;
      Amount<IMass> amountToTest = new AmountBuilder<IMass>()
        .WithUnit(Units.Gram)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilogram);
      Assert.AreEqual(Math.Round(MassConversion.G2Kg(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_5_gram_we_should_get_value_0_0005_kilogram()
    {
      double value = 0.5;
      Amount<IMass> amountToTest = new AmountBuilder<IMass>()
        .WithUnit(Units.Gram)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilogram);
      Assert.AreEqual(Math.Round(MassConversion.G2Kg(value), 5), Math.Round(convertedAmount, 5));
    }

    //kilogram 2 gram
    [TestMethod]
    public void For_Value_0_kilogram_we_should_get_value_0_gram()
    {
      double value = 0.0;
      Amount<IMass> amountToTest = new AmountBuilder<IMass>()
        .WithUnit(Units.Kilogram)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Gram);
      Assert.AreEqual(MassConversion.Kg2G(value), convertedAmount);
    }

    [TestMethod]
    public void For_Value_5_kilogram_we_should_get_value_5000_gram()
    {
      double value = 5.0;
      Amount<IMass> amountToTest = new AmountBuilder<IMass>()
        .WithUnit(Units.Kilogram)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Gram);
      Assert.AreEqual(MassConversion.Kg2G(value), convertedAmount);
    }

    [TestMethod]
    public void For_Value_0_865_kilogram_we_should_get_value_865_gram()
    {
      double value = 0.865;
      Amount<IMass> amountToTest = new AmountBuilder<IMass>()
        .WithUnit(Units.Kilogram)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Gram);
      Assert.AreEqual(MassConversion.Kg2G(value), convertedAmount);
    }

    [TestMethod]
    public void For_Value_0_0007_kilogram_we_should_get_value_0_7_gram()
    {
      double value = 0.0007;
      Amount<IMass> amountToTest = new AmountBuilder<IMass>()
        .WithUnit(Units.Kilogram)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Gram);
      Assert.AreEqual(MassConversion.Kg2G(value), convertedAmount);
    }


    //gram 2 gram

    [TestMethod]
    public void For_Value_0_gram_we_should_get_value_0_gram()
    {
      double value = 0.0;
      Amount<IMass> amountToTest = new AmountBuilder<IMass>()
        .WithUnit(Units.Gram)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Gram);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_3_gram_we_should_get_value_3_gram()
    {
      double value = 3.0;
      Amount<IMass> amountToTest = new AmountBuilder<IMass>()
        .WithUnit(Units.Gram)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Gram);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_5_34_gram_we_should_get_value_5_34_gram()
    {
      double value = 5.34;
      Amount<IMass> amountToTest = new AmountBuilder<IMass>()
        .WithUnit(Units.Gram)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Gram);
      Assert.AreEqual(value, convertedAmount);
    }

    //kilogram 2 kilogram

    [TestMethod]
    public void For_Value_0_kilogram_we_should_get_value_0_kilogram()
    {
      double value = 0.0;
      Amount<IMass> amountToTest = new AmountBuilder<IMass>()
        .WithUnit(Units.Kilogram)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilogram);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_3_kilogram_we_should_get_value_3_kilogram()
    {
      double value = 3.0;
      Amount<IMass> amountToTest = new AmountBuilder<IMass>()
        .WithUnit(Units.Kilogram)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilogram);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_5_34_kilogram_we_should_get_value_5_34_kilogram()
    {
      double value = 5.34;
      Amount<IMass> amountToTest = new AmountBuilder<IMass>()
        .WithUnit(Units.Kilogram)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilogram);
      Assert.AreEqual(value, convertedAmount);
    }
  }
}
