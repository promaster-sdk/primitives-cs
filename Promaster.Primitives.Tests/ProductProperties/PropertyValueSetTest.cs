using Microsoft.VisualStudio.TestTools.UnitTesting;
using Promaster.Primitives.ProductProperties;

namespace Promaster.Primitives.Tests.ProductProperties
{
  [TestClass]
  public class PropertyValueSetTest
  {

    [TestMethod]
    public void propertyvalueset_equals1()
    {
      var pvs1 = PropertyValueSet.ParseOrDefault("a=2;b=4:Celsius", null);
      var pvs2 = PropertyValueSet.ParseOrDefault("a=2;b=4:Celsius", null);
      Assert.IsTrue(pvs1.Equals(pvs2));
    }

    [TestMethod]
    public void propertyvalueset_equals2()
    {
      var pvs1 = PropertyValueSet.ParseOrDefault("a=2;b=4:Celsius", null);
      var pvs2 = PropertyValueSet.ParseOrDefault("a=2;b=4.5:Celsius", null);
      Assert.IsFalse(pvs1.Equals(pvs2));
    }


  }

}