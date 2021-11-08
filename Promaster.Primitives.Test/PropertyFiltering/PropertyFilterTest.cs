using Promaster.Primitives.ProductProperties;
using Promaster.Primitives.PropertyFiltering;
using Promaster.Primitives.PropertyFiltering.Evaluation;
using Promaster.Primitives.PropertyFiltering.PropertyReferences;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Promaster.Primitives.Tests.PropertyFiltering
{
  [TestClass]
  public class PropertyFilterTest
  {
    #region Old syntax

    [TestMethod]
    public void should_accept_single_value_filter()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a=1;"));
    }

    [TestMethod]
    public void should_accept_single_range_filter()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a=1~2;"));
    }

    [TestMethod]
    public void should_accept_the_single_negative_value()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a=-1;"));
    }

    [TestMethod]
    public void should_accept_the_single_set_of_values()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a=1,4;"));
    }

    [TestMethod]
    public void should_accept_the_single_mixed_set_of_values_and_ranges()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a=1,2~5,8;"));
    }

    [TestMethod]
    public void should_accept_several_properties_with_single_value()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a=1;b=2;c=3;"));
    }

    [TestMethod]
    public void should_accept_several_properties_with_mixed_values()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a=1;b=2,4,5;c=-5~5,10;d=-8;z=1~5,8~12;"));
    }

    [TestMethod]
    public void should_accept_multifilter_with_several_subfilters_and_no_nesting()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("{a=1;}{b=1;}"));
    }

    [TestMethod]
    public void should_accept_multifilter_with_single_subfilter_and_no_nesting()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("{a=1;}"));
    }

    [TestMethod]
    public void should_reject_multifilter_with_several_subfilters_and_missing_closing_curly_brace()
    {
      Assert.IsFalse(PropertyFilter.IsSyntaxValid("{a=1;}{b=1;"));
    }

    [TestMethod]
    public void should_reject_multifilter_with_single_subfilter_and_missing_opening_curly_brace()
    {
      Assert.IsFalse(PropertyFilter.IsSyntaxValid("a=1;}"));
    }

    [TestMethod]
    public void should_reject_multifilter_with_several_subfilters_and_non_braced_text_between_them()
    {
      Assert.IsFalse(PropertyFilter.IsSyntaxValid("{a=1;}blablalba{b=1;"));
    }

    #endregion

    [TestMethod]
    public void empty_filter_is_valid()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid(""));
    }

    [TestMethod]
    public void should_accept_null_filter()
    {
      string f = null;
      Assert.IsTrue(PropertyFilter.IsSyntaxValid(f));
    }

    [TestMethod]
    public void should_accept_filter_containing_only_whitespaces()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("   "));
    }

    [TestMethod]
    public void atomic_value_filter_is_valid()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a=1"));
    }

    [TestMethod]
    public void convert_value_filter_is_valid()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a:Celcius=b"));
    }

    [TestMethod]
    public void atomic_value_range_filter_is_valid()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a=1~5"));
    }

    [TestMethod]
    public void atomic_mixed_value_filter_is_valid()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a=1~5,10"));
    }

    [TestMethod]
    public void atomic_mixed_value_filter_with_negative_value_is_valid()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a=1~5,-10"));
    }

    [TestMethod]
    public void atomic_value_filter_with_negative_value_is_valid()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("ccc=-20"));
    }

    [TestMethod]
    public void and_value_filter_is_valid()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("ccc=20&a=1"));
    }

    [TestMethod]
    public void and_with_mixed_value_filter_is_valid()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("ccc=20&a=1,2,3~10&d=-50"));
    }

    [TestMethod]
    public void or_value_filter_is_valid()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("ccc=20|a=1,2"));
    }

    [TestMethod]
    public void and_or_mixed_value_filter_is_valid()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("ccc=20|a=1,2&d=5|z=50"));
    }

    [TestMethod]
    public void and_or_mixed_value_filter_with_parenthesis_is_valid()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("(ccc=20|a=1,2)&d=5|z=50"));
    }

    [TestMethod]
    public void greater_value_filter_syntax_is_valid()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a>1"));
    }

    [TestMethod]
    public void comparison_value_filter_syntax_is_invalid_for_range()
    {
      Assert.IsFalse(PropertyFilter.IsSyntaxValid("a>1,2"));
    }

    [TestMethod]
    public void handles_valid_old_syntax()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a=1;b=2;c=1,2,3;d=1~5;"));
    }

    [TestMethod]
    public void any_string_is_invalid()
    {
      Assert.IsFalse(PropertyFilter.IsSyntaxValid("szdxgdfhfgh"));
    }

    [TestMethod]
    public void should_reject_nonfilter_containing_semicolon()
    {
      Assert.IsFalse(PropertyFilter.IsSyntaxValid("func;"));
    }

    [TestMethod]
    public void should_reject_nonfilter_containing_semicolon_and_parenthesis()
    {
      Assert.IsFalse(PropertyFilter.IsSyntaxValid("func=(;"));
    }

    [TestMethod]
    public void should_reject_nonfilter_containing_confusing_mix_of_valid_filter_symbols()
    {
      Assert.IsFalse(PropertyFilter.IsSyntaxValid("func=();"));
    }

    #region Match PVS

    [TestMethod]
    public void should_not_match_missing_property()
    {
      var pvs = PropertyValueSet.ParseOrDefault("firstprop=2", null);
      Assert.IsFalse(PropertyFilter.Create("secondprop=2").IsValid(pvs));
    }

    [TestMethod]
    public void convert_filter_value()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a=1;", null);
      Assert.IsTrue(PropertyFilter.Create("a:meter<=2:meter").IsValid(pvs));
    }

    [TestMethod]
    public void should_accept_properties_when_filter_contains_several_matching_properties_with_single_value()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a=1;b=2;c=3;d=4;e=5;f=6;", null);
      Assert.IsTrue(PropertyFilter.Create("a=1;c=3;f=6;").IsValid(pvs));
    }

    [TestMethod]
    public void should_accept_properties_when_filter_contains_one_matching_property_with_single_value()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a=1;b=2;c=3;d=4;e=5;f=6;", null);
      Assert.IsTrue(PropertyFilter.Create("a=1;").IsValid(pvs));
    }

    [TestMethod]
    public void should_accept_properties_when_filter_contains_one_matching_property_with_single_range_value2()
    {
      Assert.IsFalse(PropertyFilter.IsSyntaxValid("unitsize=4060&filteraccess=5&filtertype=2~4,6~9,11-13"));
    }

    [TestMethod]
    public void should_accept_properties_when_filter_contains_one_matching_property_with_single_range_value()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a=1;b=2;c=3;d=4;e=5;f=6;", null);
      Assert.IsTrue(PropertyFilter.Create("a=-1~10;").IsValid(pvs));
    }

    [TestMethod]
    public void should_evaluate_to_false_if_matching_against_non_existent_property()
    {
      var pvs = PropertyValueSet.ParseOrDefault("property1=1", null);
      Assert.IsFalse(PropertyFilter.Create("property1=nonexistentproperty").IsValid(pvs));
    }


    [TestMethod]
    public void should_accept_properties_when_filter_contains_one_matching_property_with_set_of_values()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a=1;b=2;c=3;d=4;e=5;f=6;", null);
      Assert.IsTrue(PropertyFilter.Create("b=1,2,5;").IsValid(pvs));
    }

    [TestMethod]
    public void should_accept_properties_when_filter_contains_one_matching_property_with_mixed_values()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a=1;b=2;c=3;d=4;e=5;f=6;", null);
      Assert.IsTrue(PropertyFilter.Create("b=-1,1,2,5,10~15;").IsValid(pvs));
    }

    [TestMethod]
    public void should_accept_properties_when_multifilter_contains_one_matching_filter_and_one_nonmatching_filter()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a=1;b=2;c=3;d=4;e=5;f=6;", null);
      Assert.IsTrue(PropertyFilter.Create("{a=10;}{c=3;}").IsValid(pvs));
    }

    [TestMethod]
    public void should_reject_properties_when_filter_contains_single_nonmatching_property_with_single_value()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a=1;b=2;c=3;d=4;e=5;f=6;", null);
      Assert.IsFalse(PropertyFilter.Create("{a=10;}").IsValid(pvs));
    }

    [TestMethod]
    public void should_reject_properties_when_filter_contains_both_matching_and_nonmatching_mixed_values()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a=1;b=2;c=3;d=4;e=5;f=6;", null);
      Assert.IsFalse(PropertyFilter.Create("{a=10;b=2;c=5;}{e=5;f=9;}").IsValid(pvs));
    }

    [TestMethod]
    public void should_reject_nonfilter_containing_semicolon_and_parenthesis1()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("unittype=01,04;insalt=1,2,7;hearec=0;cooleralt=0~2;"));
    }

    [TestMethod]
    public void should_support_properties_on_right_hand()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a=10;b=2;", null);
      Assert.IsTrue(PropertyFilter.Create("a>=b").IsValid(pvs));
    }

    [TestMethod]
    public void should_support_not_present_properties()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a=10;b=2;", null);
      Assert.IsFalse(PropertyFilter.Create("a>=c").IsValid(pvs));
    }

    [TestMethod]
    public void amount_value_is_supported()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a>=20:Celsius&b=20:Meter~30:Meter"));
    }

    [TestMethod]
    public void not_equals_is_supported()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a!=20"));
    }

    [TestMethod]
    public void not_equals_works_as_expected1()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a=5", null);
      Assert.IsTrue(PropertyFilter.Create("a!=20").IsValid(pvs));
    }

    [TestMethod]
    public void not_equals_works_as_expected2()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a=5", null);
      Assert.IsFalse(PropertyFilter.Create("a!=5").IsValid(pvs));
    }

    [TestMethod]
    public void supports_settings1()
    {
      var svs = PropertyValueSet.ParseOrDefault("a=5:Celsius", null);
      Assert.IsTrue(PropertyFilter.Create("a>2:Celsius").IsValid(svs));
    }

    [TestMethod]
    public void supports_settings2()
    {
      var svs = PropertyValueSet.ParseOrDefault("a=5:Celsius", null);
      Assert.IsFalse(PropertyFilter.Create("a<2:Celsius").IsValid(svs));
    }

    [TestMethod]
    public void supports_addition()
    {
      var svs = PropertyValueSet.ParseOrDefault("length=20:meter;width=2:meter", null);
      Assert.IsTrue(PropertyFilter.Create("length+15:meter>width").IsValid(svs));
    }

    [TestMethod]
    public void supports_integer_subtraction()
    {
      var svs = PropertyValueSet.ParseOrDefault("length=20;width=2", null);
      Assert.IsTrue(PropertyFilter.Create("length-width>0").IsValid(svs));
    }

    [TestMethod]
    public void supports_integer_negation()
    {
      var svs = PropertyValueSet.ParseOrDefault("width=2", null);
      Assert.IsTrue(PropertyFilter.Create("-width<0").IsValid(svs));
    }

    [TestMethod]
    public void supports_amount_negation()
    {
      var svs = PropertyValueSet.ParseOrDefault("width=2:meter", null);
      Assert.IsTrue(PropertyFilter.Create("-width<0:meter").IsValid(svs));
    }

    [TestMethod]
    public void supports_integer_multiplication()
    {
      var svs = PropertyValueSet.ParseOrDefault("width=2", null);
      Assert.IsTrue(PropertyFilter.Create("width*5=10").IsValid(svs));
    }

    [TestMethod]
    public void supports_integer_and_amount_multiplication()
    {
      var svs = PropertyValueSet.ParseOrDefault("width=2", null);
      Assert.IsTrue(PropertyFilter.Create("width*5:meter=10:meter").IsValid(svs));
    }

    [TestMethod]
    public void supports_text_addition()
    {
      var svs = PropertyValueSet.ParseOrDefault("blah=\"test\"", null);
      Assert.IsTrue(PropertyFilter.Create("blah+\"ing\"=\"testing\"").IsValid(svs));
    }

    [TestMethod]
    public void supports_null()
    {
      Assert.IsTrue(PropertyFilter.IsSyntaxValid("a=null"));
    }

    [TestMethod]
    public void supports_null_validation()
    {
      var pvs = PropertyValueSet.ParseOrDefault("b=5", null);
      var filter = PropertyFilter.Create("a=null");
      Assert.IsTrue(filter.IsValid(pvs));
    }

    [TestMethod]
    public void supports_null_validation_using_evaluator()
    {
      var pvs = PropertyValueSet.ParseOrDefault("b=5", null);
      var filter = PropertyFilter.Create("a=null");
      var evaluator = new FilterEvaluator();
      var result = evaluator.Evaluate(filter.Ast, pvs, false);
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void supports_null_validation2()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a=2", null);
      Assert.IsFalse(PropertyFilter.Create("a=null").IsValid(pvs));
    }

    [TestMethod]
    public void supports_string()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a=test:text", null);
      Assert.IsTrue(PropertyFilter.Create("a=\"test\"").IsValid(pvs));
    }

    [TestMethod]
    public void supports_dot_in_propertynames()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a.b=1", null);
      Assert.IsTrue(PropertyFilter.Create("a.b>0").IsValid(pvs));
    }

    [TestMethod]
    public void supports_dot_in_propertynames_inverse()
    {
      var pvs = PropertyValueSet.ParseOrDefault("a.b=1", null);
      Assert.IsFalse(PropertyFilter.Create("a.b>2").IsValid(pvs));
    }

    #endregion

    #region PropertyReferences

    [TestMethod]
    public void finds_property_references()
    {
      var filter = PropertyFilter.Create("a>b&c=1|d<2");
      var finder = new PropertyReferencesFinder();
      var references = finder.GetPropertyReferences(filter);
      Assert.IsTrue(references.Count == 4);
    }

    #endregion
  }
}