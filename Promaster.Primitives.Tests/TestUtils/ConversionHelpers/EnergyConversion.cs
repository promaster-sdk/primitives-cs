
namespace Promaster.Primitives.Tests.TestUtils.ConversionHelpers
{
  internal class EnergyConversion
  {
    public static double J2Kj(double j)
    {
      return j / 1000.0;
    }

    public static double Kj2J(double kj)
    {
      return kj * 1000.0;
    }
  }
}
