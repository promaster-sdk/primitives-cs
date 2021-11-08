
namespace Promaster.Primitives.Tests.TestUtils.ConversionHelpers
{
  internal class DurationConversion
  {
    public static double S2M(double s)
    {
      return s/60.0;
    }

    public static double S2H(double s)
    {
      return M2H(S2M(s));
    }

    public static double M2S(double m)
    {
      return m*60.0;
    }

    public static double M2H(double m)
    {
      return m/60.0;
    }

    public static double H2S(double h)
    {
      return M2S(H2M(h));
    }

    public static double H2M(double h)
    {
      return h*60.0;
    }
  }
}
