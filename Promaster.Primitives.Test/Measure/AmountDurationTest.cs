using Promaster.Primitives.Measure;
using Promaster.Primitives.Measure.Quantity;
using Promaster.Primitives.Measure.Unit;
using Promaster.Primitives.Tests.TestUtils.Builders;
using Promaster.Primitives.Tests.TestUtils.ConversionHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Promaster.Primitives.Tests.Measure
{
  [TestClass]
  public class AmountDurationTest
  {
    [TestMethod]
    public void ForValue0SecondsWeShouldGetValue0Minutes()
    {
      const double value = 0.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Second)
        .WithValue(value).Build();
      double valueInMinutes = amountToTest.ValueAs(Units.Minute);
      Assert.AreEqual(DurationConversion.S2M(value), valueInMinutes);
    }

    [TestMethod]
    public void ForValue0SecondsWeShouldGetValue0Hours()
    {
      const double value = 0.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Second)
        .WithValue(value).Build();
      double valueInHours = amountToTest.ValueAs(Units.Hour);
      Assert.AreEqual(DurationConversion.S2H(value), valueInHours);
    }

    [TestMethod]
    public void ForValue10SecondsWeShouldGetValue10Seconds()
    {
      const double value = 10.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Second)
        .WithValue(value).Build();
      double valueInSeconds = amountToTest.ValueAs(Units.Second);
      Assert.AreEqual(value, valueInSeconds);
    }

    [TestMethod]
    public void ForValue15SecondsWeShouldGetValue025Minutes()
    {
      const double value = 15.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Second)
        .WithValue(value).Build();
      double valueInMinutes = amountToTest.ValueAs(Units.Minute);
      Assert.AreEqual(DurationConversion.S2M(value), valueInMinutes);
    }

    [TestMethod]
    public void ForValue60SecondsWeShouldGetValue1Minute()
    {
      const double value = 60.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Second)
        .WithValue(value).Build();
      double valueInMinutes = amountToTest.ValueAs(Units.Minute);
      Assert.AreEqual(DurationConversion.S2M(value), valueInMinutes);
    }

    [TestMethod]
    public void ForValue135SecondsWeShouldGetValue225Minutes()
    {
      const double value = 135.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Second)
        .WithValue(value).Build();
      double valueInMinutes = amountToTest.ValueAs(Units.Minute);
      Assert.AreEqual(DurationConversion.S2M(value), valueInMinutes);
    }

    [TestMethod]
    public void ForValue36SecondsWeShouldGetValue001Hours()
    {
      const double value = 36.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Second)
        .WithValue(value).Build();
      double valueInHours = amountToTest.ValueAs(Units.Hour);
      Assert.AreEqual(DurationConversion.S2H(value), valueInHours);
    }

    [TestMethod]
    public void ForValue3600SecondsWeShouldGetValue1Hour()
    {
      const double value = 3600.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Second)
        .WithValue(value).Build();
      double valueInHours = amountToTest.ValueAs(Units.Hour);
      Assert.AreEqual(DurationConversion.S2H(value), valueInHours);
    }

    [TestMethod]
    public void ForValue7236SecondsWeShouldGetValue201Hours()
    {
      const double value = 7236.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Second)
        .WithValue(value).Build();
      double valueInHours = amountToTest.ValueAs(Units.Hour);
      Assert.AreEqual(DurationConversion.S2H(value), valueInHours);
    }

    [TestMethod]
    public void ForValue15MinutesWeShouldGetValue15Minutes()
    {
      const double value = 15.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Minute)
        .WithValue(value).Build();
      double valueInMinutes = amountToTest.ValueAs(Units.Minute);
      Assert.AreEqual(value, valueInMinutes);
    }

    [TestMethod]
    public void ForValue0MinutesWeShouldGetValue0Seconds()
    {
      const double value = 0.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Minute)
        .WithValue(value).Build();
      double valueInSeconds = amountToTest.ValueAs(Units.Second);
      Assert.AreEqual(DurationConversion.M2S(value), valueInSeconds);
    }

    [TestMethod]
    public void ForValue01MinutesWeShouldGetValue6Seconds()
    {
      const double value = 0.1;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Minute)
        .WithValue(value).Build();
      double valueInSeconds = amountToTest.ValueAs(Units.Second);
      Assert.AreEqual(DurationConversion.M2S(value), valueInSeconds);
    }

    [TestMethod]
    public void ForValue00025MinutesWeShouldGetValue015Seconds()
    {
      const double value = 0.0025;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Minute)
        .WithValue(value).Build();
      double valueInSeconds = amountToTest.ValueAs(Units.Second);
      Assert.AreEqual(DurationConversion.M2S(value), valueInSeconds);
    }

    [TestMethod]
    public void ForValue15MinutesWeShouldGetValue900Seconds()
    {
      const double value = 15.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Minute)
        .WithValue(value).Build();
      double valueInSeconds = amountToTest.ValueAs(Units.Second);
      Assert.AreEqual(DurationConversion.M2S(value), valueInSeconds);
    }

    [TestMethod]
    public void ForValue0MinutesWeShouldGetValue0Hours()
    {
      const double value = 0.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Minute)
        .WithValue(value).Build();
      double valueInHours = amountToTest.ValueAs(Units.Hour);
      Assert.AreEqual(DurationConversion.M2H(value), valueInHours);
    }

    [TestMethod]
    public void ForValue15MinutesWeShouldGetValue025Hours()
    {
      const double value = 15.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Minute)
        .WithValue(value).Build();
      double valueInHours = amountToTest.ValueAs(Units.Hour);
      Assert.AreEqual(DurationConversion.M2H(value), valueInHours);
    }

    [TestMethod]
    public void ForValue60MinutesWeShouldGetValue1Hour()
    {
      const double value = 60.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Minute)
        .WithValue(value).Build();
      double valueInHours = amountToTest.ValueAs(Units.Hour);
      Assert.AreEqual(DurationConversion.M2H(value), valueInHours);
    }

    [TestMethod]
    public void ForValue135MinutesWeShouldGetValue225Hours()
    {
      const double value = 135.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Minute)
        .WithValue(value).Build();
      double valueInHours = amountToTest.ValueAs(Units.Hour);
      Assert.AreEqual(DurationConversion.M2H(value), valueInHours);
    }

    [TestMethod]
    public void ForValue2HoursWeShouldGetValue2Hours()
    {
      const double value = 2.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Hour)
        .WithValue(value).Build();
      double valueInHours = amountToTest.ValueAs(Units.Hour);
      Assert.AreEqual(value, valueInHours);
    }

    [TestMethod]
    public void ForValue0HoursWeShouldGetValue0Seconds()
    {
      const double value = 0.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Hour)
        .WithValue(value).Build();
      double valueInSeconds = amountToTest.ValueAs(Units.Second);
      Assert.AreEqual(DurationConversion.H2S(value), valueInSeconds);
    }

    [TestMethod]
    public void ForValue1HourWeShouldGetValue3600Seconds()
    {
      const double value = 1.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Hour)
        .WithValue(value).Build();
      double valueInSeconds = amountToTest.ValueAs(Units.Second);
      Assert.AreEqual(DurationConversion.H2S(value), valueInSeconds);
    }

    [TestMethod]
    public void ForValue1HourWeShouldGetValue60Minutes()
    {
      const double value = 1.0;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Hour)
        .WithValue(value).Build();
      double valueInMinutes = amountToTest.ValueAs(Units.Minute);
      Assert.AreEqual(DurationConversion.H2M(value), valueInMinutes);
    }

    [TestMethod]
    public void ForValue01HoursWeShouldGetValue360Seconds()
    {
      const double value = 0.1;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Hour)
        .WithValue(value).Build();
      double valueInSeconds = amountToTest.ValueAs(Units.Second);
      Assert.AreEqual(DurationConversion.H2S(value), valueInSeconds);
    }

    [TestMethod]
    public void ForValue01HoursWeShouldGetValue6Minutes()
    {
      const double value = 0.1;
      Amount<IDuration> amountToTest = new AmountBuilder<IDuration>()
        .WithUnit(Units.Hour)
        .WithValue(value).Build();
      double valueInMinutes = amountToTest.ValueAs(Units.Minute);
      Assert.AreEqual(DurationConversion.H2M(value), valueInMinutes);
    }
  }
}