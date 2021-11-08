
namespace Promaster.Primitives.Tests.TestUtils.ConversionHelpers
{
  internal class LengthConversion
  {
    public static double Cm2Km(double cm)
    {
      return cm/100000.0;
    }

    public static double Cm2M(double cm)
    {
      return cm / 100.0;
    }

    public static double Cm2Ft(double cm)
    {
      return M2Ft(Cm2M(cm));
    }

    public static double In2Cm(double inch)
    {
      return M2Cm(In2M(inch));
    }

    public static double In2M(double inch)
    {
      return Ft2M(In2Ft(inch));
    }

    public static double In2Km(double inch)
    {
      return M2Km(In2M(inch));
    }

    public static double Yd2In(double yd)
    {
      return Ft2In(Yd2Ft(yd));
    }

    public static double Yd2Km(double yd)
    {
      return M2Km(Yd2M(yd));
    }

    public static double Yd2Cm(double yd)
    {
      return M2Cm(Yd2M(yd));
    }

    public static double Yd2M(double yd)
    {
      return Ft2M(Yd2Ft(yd));
    }

    public static double Yd2Ft(double yd)
    {
      return yd*3;
    }

    public static double In2Yd(double inch)
    {
      return Ft2Yd(In2Ft(inch));
    }

    public static double Ft2Km(double ft)
    {
      return M2Km(Ft2M(ft));
    }

    public static double Ft2Cm(double ft)
    {
      return M2Cm(Ft2M(ft));
    }

    public static double In2Ft(double inch)
    {
      return inch/12.0;
    }

    public static double Ft2M(double ft)
    {
      return ft*0.3048;
    }

    public static double M2Ft(double m)
    {
      return m / 0.3048;
    }

    public static double M2Km(double m)
    {
      return m/1000.0;
    }

    public static double Ft2In(double ft)
    {
      return ft * 12;
    }

    public static double Ft2Yd(double ft)
    {
      return ft / 3.0;
    }

    public static double Cm2Yd(double cm)
    {
      return Ft2Yd(M2Ft(Cm2M(cm)));
    }

    public static double Km2Cm(double km)
    {
      return M2Cm(Km2M(km));
    }

    public static double Km2M(double km)
    {
      return km * 1000.0;
    }

    public static double Km2Ft(double km)
    {
      return M2Ft(Km2M(km));
    }

    public static double Km2In(double km)
    {
      return Ft2In(M2Ft(Km2M(km)));
    }

    public static double Km2Yd(double km)
    {
      return M2Yd(Km2M(km));
    }

    public static double M2Cm(double m)
    {
      return m * 100;
    }

    public static double M2In(double m)
    {
      return Ft2In(M2Ft(m));
    }

    public static double M2Yd(double m)
    {
      return Ft2Yd(M2Ft(m));
    }

    public static double Cm2In(double cm)
    {
      return M2In(Cm2M(cm));
    }
  }
}
