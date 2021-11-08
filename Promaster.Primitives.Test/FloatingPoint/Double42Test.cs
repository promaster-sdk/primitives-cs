using Promaster.Primitives.Portable.FloatingPoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Promaster.Primitives.Tests.FloatingPoint
{
  [TestClass]
  public class Double42Test
  {

    [TestMethod]
    public void hash_should_be_same_for_same_value()
    {
      var a1 = new Double42(4.0);
      var a2 = new Double42(4.0);
      int hash1 = a1.GetHashCode();
      int hash2 = a2.GetHashCode();
      Assert.AreEqual(hash1, hash2);
    }


    [TestMethod]
    public void Compare_Positive_and_negative()
    {
      Double42 left = 16.2;
      Double42 right = -200;
      Assert.AreEqual(true, left > right);
    }

    [TestMethod]
    public void Compare_Negative_and_Positive()
    {
      Double42 left = -200;
      Double42 right = 16.2;
      Assert.AreEqual(true, left < right);
    }

    [TestMethod]
    public void Compare_Positive_and_Positive()
    {
      Double42 left = 16.2;
      Double42 right = 16.1;
      Assert.AreEqual(true, left > right);
    }

    [TestMethod]
    public void Compare_Positive_and_Positive2()
    {
      Double42 left = 1001E2;
      Double42 right = 1.001E4;
      Assert.AreEqual(true, left > right);
    }

    [TestMethod]
    public void Compare_Negative_and_Negative()
    {
      Double42 left = -10;
      Double42 right = -16.1;
      Assert.AreEqual(true, left > right);
    }

    [TestMethod]
    public void Compare_Close_Large()
    {
      double large1 = 999999999999999.0;
      double large2 = 999999999999999.1;
      Assert.AreNotEqual(large1, large2);

      var large1_42 = (Double42)large1;
      var large2_42 = (Double42)large2;
      Assert.AreEqual(true, large1_42 == large2_42);
      Assert.AreEqual(false, large1_42 > large2_42);
      Assert.AreEqual(false, large1_42 < large2_42);
    }

    [TestMethod]
    public void Compare_Close_Large_With_Different_Sign()
    {
      double large1 = -999999999999999.0;
      double large2 = 999999999999999.1;
      Assert.AreNotEqual(large1, large2);

      var large1_42 = (Double42)large1;
      var large2_42 = (Double42)large2;
      Assert.AreEqual(false, large1_42 == large2_42);
      Assert.AreEqual(true, large1_42 < large2_42);
      Assert.AreEqual(false, large1_42 > large2_42);
    }

  }

}
