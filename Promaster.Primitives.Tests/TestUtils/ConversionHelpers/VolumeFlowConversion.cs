
namespace Promaster.Primitives.Tests.TestUtils.ConversionHelpers
{
  internal class VolumeFlowConversion
  {
    public static double M3PerSec2M3PerHour(double m3PerSec)
    {
      return m3PerSec*3600.0;
    }

    public static double M3PerHour2M3PerSec(double m3PerHour)
    {
      return m3PerHour/3600.0;
    }
  }
}
