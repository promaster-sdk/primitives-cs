
namespace Promaster.Primitives.Tests.TestUtils.ConversionHelpers
{
  internal class PressureConversion
  {
    public static double Pa2KPa(double pa)
    {
      return pa/1000.0;
    }

    public static double KPa2Pa(double kPa)
    {
      return kPa*1000.0;
    }
  }
}
