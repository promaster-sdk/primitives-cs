
namespace Promaster.Primitives.Tests.TestUtils.ConversionHelpers
{
  internal class VolumeConversion
  {
    public static double M32L(double m3)
    {
      return m3*1000.0;
    }

    public static double L2M3(double l)
    {
      return l/1000.0;
    }
  }
}
