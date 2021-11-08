using Promaster.Primitives.Measure;
using Promaster.Primitives.Measure.Quantity;
using Promaster.Primitives.Measure.Unit;
using Promaster.Primitives.Tests.TestUtils.Builders;
using Promaster.Primitives.Tests.TestUtils.ConversionHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Promaster.Primitives.Tests.Measure
{
  [TestClass]
  public class AmountEnergyTest
  {
    [TestMethod]
    public void ForValue1JouleWeShouldGetValue0001Kilojoules()
    {
      const double value = 1.0;
      Amount<IEnergy> amountToTest = new AmountBuilder<IEnergy>()
        .WithUnit(Units.Joule)
        .WithValue(value).Build();
      double valueInKilojoules = amountToTest.ValueAs(Units.Kilojoule);
      Assert.AreEqual(EnergyConversion.J2Kj(value), valueInKilojoules);
    }

    [TestMethod]
    public void ForValue1KilojouleWeShouldGetValue1000Joules()
    {
      const double value = 1.0;
      Amount<IEnergy> amountToTest = new AmountBuilder<IEnergy>()
        .WithUnit(Units.Kilojoule)
        .WithValue(value).Build();
      double valueInJoules = amountToTest.ValueAs(Units.Joule);
      Assert.AreEqual(EnergyConversion.Kj2J(value), valueInJoules);
    }

    [TestMethod]
    public void ForValue0JouleWeShouldGetValue0Kilojoules()
    {
      const double value = 0.0;
      Amount<IEnergy> amountToTest = new AmountBuilder<IEnergy>()
        .WithUnit(Units.Joule)
        .WithValue(value).Build();
      double valueInKilojoules = amountToTest.ValueAs(Units.Kilojoule);
      Assert.AreEqual(EnergyConversion.J2Kj(value), valueInKilojoules);
    }

    [TestMethod]
    public void ForValue0KilojouleWeShouldGetValue0Joules()
    {
      const double value = 0.0;
      Amount<IEnergy> amountToTest = new AmountBuilder<IEnergy>()
        .WithUnit(Units.Kilojoule)
        .WithValue(value).Build();
      double valueInJoules = amountToTest.ValueAs(Units.Joule);
      Assert.AreEqual(EnergyConversion.Kj2J(value), valueInJoules);
    }

    [TestMethod]
    public void ForValue1JouleWeShouldGetValue1Joule()
    {
      const double value = 1.0;
      Amount<IEnergy> amountToTest = new AmountBuilder<IEnergy>()
        .WithUnit(Units.Joule)
        .WithValue(value).Build();
      double valueInJoules = amountToTest.ValueAs(Units.Joule);
      Assert.AreEqual(value, valueInJoules);
    }

    [TestMethod]
    public void ForValue1KilojouleWeShouldGetValue1Kilojoule()
    {
      const double value = 1.0;
      Amount<IEnergy> amountToTest = new AmountBuilder<IEnergy>()
        .WithUnit(Units.Kilojoule)
        .WithValue(value).Build();
      double valueInKilojoules = amountToTest.ValueAs(Units.Kilojoule);
      Assert.AreEqual(value, valueInKilojoules);
    }

    [TestMethod]
    public void ForValue063JouleWeShouldGetValue000063Kilojoules()
    {
      const double value = 0.63;
      Amount<IEnergy> amountToTest = new AmountBuilder<IEnergy>()
        .WithUnit(Units.Joule)
        .WithValue(value).Build();
      double valueInKilojoules = amountToTest.ValueAs(Units.Kilojoule);
      Assert.AreEqual(EnergyConversion.J2Kj(value), valueInKilojoules);
    }

    [TestMethod]
    public void ForValue589KilojouleWeShouldGetValue5890Joules()
    {
      const double value = 5.89;
      Amount<IEnergy> amountToTest = new AmountBuilder<IEnergy>()
        .WithUnit(Units.Kilojoule)
        .WithValue(value).Build();
      double valueInJoules = amountToTest.ValueAs(Units.Joule);
      Assert.AreEqual(EnergyConversion.Kj2J(value), valueInJoules);
    }

    [TestMethod]
    public void ForValue1BtuWeShouldGetValue1055Joules()
    {
      // http://www.wolframalpha.com/input/?i=btu

      // Arrange
      Amount<IEnergy> p = Amount.Exact(1.0, Units.Btu);

      // Act
      double result = p.ValueAs(Units.Joule);

      // Assert
      Assert.AreEqual(1055, result, 1.0);
    }

    //[TestMethod]
    //public void ForValue1BtuPerPoundlbWeShouldGetValue2326KilojoulesPerKilogram()
    //{
    //  // http://www.wolframalpha.com/input/?i=btu+per+lb

    //  // Arrange
    //  Amount<ISpecificEnthalpy> p = Amount.Exact(1.0, Units.BtuPerPoundLb);

    //  // Act
    //  double result = p.ValueAs(Units.KilojoulePerKilogram);

    //  // Assert
    //  Assert.AreEqual(2.326, result, 0.001);
    //}

    //[TestMethod]
    //public void ForValue970BtuPerPoundlbWeShouldGetValue2256KiloJoules()
    //{
    //  // http://www.wolframalpha.com/input/?i=970+BTU%2Flb+to+kJ%2Fkg+

    //  // Arrange
    //  Amount<ISpecificEnthalpy> p = Amount.Exact(970.0, Units.BtuPerPoundLb);

    //  // Act
    //  double result = p.ValueAs(Units.KilojoulePerKilogram);

    //  // Assert
    //  Assert.AreEqual(2256, result, 1.0);
    //}

    //[TestMethod]
    //public void ForValue2501KilojoulesPerKilogramWeShouldGetValue1075BtuPerPoundlb()
    //{
    //  // http://www.wolframalpha.com/input/?i=2501%20kJ%2Fkg%20to%20BTU%2Flb&t=wvg01

    //  // Arrange
    //  Amount<ISpecificEnthalpy> p = Amount.Exact(2501.0, Units.KilojoulePerKilogram);

    //  // Act
    //  double result = p.ValueAs(Units.BtuPerPoundLb);

    //  // Assert
    //  Assert.AreEqual(1075, result, 1.0);
    //}
  }
}