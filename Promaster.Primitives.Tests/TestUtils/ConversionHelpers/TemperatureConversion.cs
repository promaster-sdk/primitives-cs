
namespace Promaster.Primitives.Tests.TestUtils.ConversionHelpers
{
  internal class TemperatureConversion
  {
    public static double K2C(double k)
    {
      return k - 273.15;
    }

    public static double K2R(double k)
    {
      return k * 9.0 / 5.0;
    }

    public static double K2F(double k)
    {
      return R2F(K2R(k));
    }

    public static double C2K(double c)
    {
      return c + 273.15;
    }

    public static double C2R(double c)
    {
      return K2R(C2K(c));
    }

    public static double C2F(double c)
    {
      return R2F(C2R(c));
    }

    public static double R2K(double r)
    {
      return r * 5.0 / 9.0;
    }

    public static double R2C(double r)
    {
      return K2C(R2K(r));
    }

    public static double R2F(double r)
    {
      return r - 459.67;
    }

    public static double F2K(double f)
    {
      return R2K(F2R(f));
    }

    public static double F2C(double f)
    {
      return R2C(F2R(f));
    }

    public static double F2R(double f)
    {
      return f + 459.67;
    }
  }
}
