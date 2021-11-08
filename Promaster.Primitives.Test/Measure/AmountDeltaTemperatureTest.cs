using System;
using Promaster.Primitives.Measure;
using Promaster.Primitives.Measure.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Promaster.Primitives.Tests.Measure
{
  [TestClass]
  public class AmountDeltaTemperatureTest
  {
    [TestMethod]
    public void ZeroCelsiusIsZeroFahrenheit()
    {
      var zeroCelsius = Amount.Exact(0, Units.DeltaCelsius);
      Assert.IsTrue(Math.Abs(zeroCelsius.ValueAs(Units.DeltaFahrenheit)) < 0.000001);
    }
  }
}