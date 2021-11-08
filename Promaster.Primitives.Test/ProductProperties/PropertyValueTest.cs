using Promaster.Primitives.Measure;
using Promaster.Primitives.Measure.Unit;
using Promaster.Primitives.ProductProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Promaster.Primitives.Tests.ProductProperties
{

  [TestClass]
  public class PropertyValueTest
  {

    [TestMethod]
    public void should_parse_amount_with_decimal_dot()
    {
      var pv1 = PropertyValue.Parse("2.1:Celsius");
      var amount2 = Amount.Exact(2.1, Units.Celsius);
      Assert.IsTrue(pv1.ToAmount() == amount2);
    }

    [TestMethod]
    public void should_parse_integer()
    {
      var pv1 = PropertyValue.Parse("2");
      Assert.IsTrue(pv1.ToInteger() == 2);
    }

    [TestMethod]
    public void should_do_value_compare_integer_with_equals_method()
    {
      var pv1 = new PropertyValue(2);
      var pv2 = new PropertyValue(2);
      Assert.IsTrue(pv1.Equals(pv2));
    }

    [TestMethod]
    public void should_do_value_compare_amount_with_equals_method()
    {
      var pv1 = new PropertyValue(Amount.Exact(2.0, Units.Celsius));
      var pv2 = new PropertyValue(Amount.Exact(2.0, Units.Celsius));
      Assert.IsTrue(pv1.Equals(pv2));
    }

    [TestMethod]
    public void should_do_value_compare_string_with_equals_method()
    {
      var pv1 = new PropertyValue("abcABC");
      var pv2 = new PropertyValue("abcABC");
      Assert.IsTrue(pv1.Equals(pv2));
    }

    [TestMethod]
    public void should_do_value_compare_integer_with_equality_operator()
    {
      var pv1 = new PropertyValue(2);
      var pv2 = new PropertyValue(2);
      Assert.IsTrue(pv1 == pv2);
    }

    [TestMethod]
    public void should_do_value_compare_amount_with_equality_operator()
    {
      var pv1 = new PropertyValue(Amount.Exact(2.0, Units.Celsius));
      var pv2 = new PropertyValue(Amount.Exact(2.0, Units.Celsius));
      Assert.IsTrue(pv1 == pv2);
    }

    [TestMethod]
    public void should_do_value_compare_string_with_equality_operator()
    {
      var pv1 = new PropertyValue("abcABC");
      var pv2 = new PropertyValue("abcABC");
      Assert.IsTrue(pv1 == pv2);
    }

    [TestMethod]
    public void should_parse_string_in_quotes_same_as_explicit_text_constructor()
    {
      var pv1 = PropertyValue.Parse("\"abcABC\"");
      var pv2 = new PropertyValue("abcABC");
      Assert.IsTrue(pv1 == pv2);
    }
    
  }

}
