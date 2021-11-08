using Promaster.Primitives.Measure.Quantity;
using Promaster.Primitives.Measure.Unit;
using Promaster.Primitives.Tests.TestUtils.Builders;
using Promaster.Primitives.Tests.TestUtils.ConversionHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Promaster.Primitives.Measure;

namespace Promaster.Primitives.Tests.Measure
{
  [TestClass]
  public class AmountTest
  {
    
    [TestMethod]
    public void hash_should_be_same_for_same_value()
    {
      Amount<ITemperature> a1 = new AmountBuilder<ITemperature>().WithUnit(Units.Celsius).WithValue(4).Build();
      Amount<ITemperature> a2 = new AmountBuilder<ITemperature>().WithUnit(Units.Celsius).WithValue(4).Build();
      int hash1 = a1.GetHashCode();
      int hash2 = a2.GetHashCode();
      Assert.AreEqual(hash1 , hash2);
    }

    [TestMethod]
    public void Multiply_double_to_amount()
    {
      double valueLeft = 2.0;
      double valueRight = 5.5;

      var amountLeft = new AmountBuilder<IMass>()
        .WithValue(valueLeft)
        .WithUnit(Units.Gram).Build();

      var res1 = amountLeft * valueRight;
      Assert.AreEqual(valueLeft * valueRight, res1.ValueAs(Units.Gram), 0.000001);
    }

    [TestMethod]
    public void Divide_amount_by_double()
    {
      double valueLeft = 55.39;
      double valueRight = 58.456;

      var amountLeft = new AmountBuilder<ILength>()
        .WithValue(valueLeft)
        .WithUnit(Units.Inch).Build();

      var res1 = amountLeft / valueRight;
      Assert.AreEqual(valueLeft / valueRight, res1.ValueAs(Units.Inch), 0.00001);
    }

    [TestMethod]
    public void Subtract_amounts_with_same_unit()
    {
      double valueLeft = 0.8;
      double valueRight = 99.56;

      var amountLeft = new AmountBuilder<IEnergy>()
        .WithValue(valueLeft)
        .WithUnit(Units.Kilojoule).Build();
      var amountRight = new AmountBuilder<IEnergy>()
        .WithValue(valueRight)
        .WithUnit(Units.Kilojoule).Build();

      var res1 = amountLeft - amountRight;
      Assert.AreEqual(valueLeft - valueRight, res1.ValueAs(Units.Kilojoule), 0.00001);
    }

    [TestMethod]
    public void Add_amounts_with_same_unit()
    {
      double valueLeft = 12.8;
      double valueRight = 10.0;

      var amountLeft = new AmountBuilder<ILength>()
        .WithValue(valueLeft)
        .WithUnit(Units.Inch).Build();
      var amountRight = new AmountBuilder<ILength>()
         .WithValue(valueRight)
         .WithUnit(Units.Inch).Build();

      var res1 = amountLeft + amountRight;
      Assert.AreEqual(valueLeft + valueRight, res1.ValueAs(Units.Inch), 0.0001);
    }

    [TestMethod]
    public void Add_amounts_with_different_units()
    {
      double valueLeft = 2.0;
      double valueRight = 5.5;

      var amountLeft = new AmountBuilder<ILength>()
        .WithValue(valueLeft)
        .WithUnit(Units.Inch).Build();
      var amountRight = new AmountBuilder<ILength>()
         .WithValue(valueRight)
         .WithUnit(Units.CentiMeter).Build();

      var res1 = amountLeft + amountRight;
      Assert.AreEqual(valueLeft + LengthConversion.Cm2In(valueRight), res1.ValueAs(Units.Inch), 0.0001);
    }

    [TestMethod]
    public void Subtract_amounts_with_different_units()
    {
      double valueLeft = 360;
      double valueRight = 2;

      var amountLeft = new AmountBuilder<IDuration>()
        .WithValue(valueLeft).
        WithUnit(Units.Second).Build();
      var amountRight = new AmountBuilder<IDuration>()
        .WithValue(valueRight)
        .WithUnit(Units.Hour).Build();

      var res1 = amountLeft - amountRight;
      Assert.AreEqual(valueLeft - DurationConversion.H2S(valueRight), res1.ValueAs(Units.Second), 0.00001);
    }

    [TestMethod]
    public void Multiply_amount_to_double()
    {
      double valueLeft = 2.0;
      double valueRight = 5.5;

      var amountRight = new AmountBuilder<IDuration>()
        .WithValue(valueRight)
        .WithUnit(Units.Hour).Build();

      var res1 = valueLeft * amountRight;
      Assert.AreEqual(valueLeft * valueRight, res1.ValueAs(Units.Hour));
    }

    [TestMethod]
    public void Create_Amount_And_Check_Explicit_Conversion()
    {
      double valueLeft = -568.25;
      double valueRight = 15.369852;

      var amountLeft = new AmountBuilder<IDuration>()
         .WithValue(valueLeft).
         WithUnit(Units.Second).Build();
      var amountRight = new AmountBuilder<IDuration>()
        .WithValue(valueRight)
        .WithUnit(Units.Hour).Build();

      Assert.AreEqual(valueLeft, amountLeft.ValueAs(Units.Second), 0.0001);
      Assert.AreEqual(valueRight, amountRight.ValueAs(Units.Hour), 0.0001);
    }

    [TestMethod]
    public void Operator_Equals()
    {
      var valueLeft = Amount.Exact(0.8, Units.Celsius);
      var valueRight = Amount.Exact(0.8, Units.Celsius);

      Assert.AreEqual(true, valueLeft == valueRight);
    }

    [TestMethod]
    public void Operator_Equals_with_base_class()
    {
      var valueLeft = (Amount)Amount.Exact(0.8, Units.Celsius);
      var valueRight = (Amount)Amount.Exact(0.8, Units.Celsius);

      Assert.AreEqual(true, valueLeft == valueRight);
    }

    [TestMethod]
    public void Operator_GreaterThan()
    {
      var valueLeft = Amount.Exact(0.9, Units.Celsius);
      var valueRight = Amount.Exact(0.8, Units.Celsius);

      Assert.AreEqual(true, valueLeft > valueRight);
    }

    [TestMethod]
    public void Operator_LessThan()
    {
      var valueLeft = Amount.Exact(0.8, Units.Celsius);
      var valueRight = Amount.Exact(0.9, Units.Celsius);

      Assert.AreEqual(true, valueLeft < valueRight);
    }

    [TestMethod]
    public void Operator_LessThanOrEquals()
    {
      var valueLeft = Amount.Exact(0.8, Units.Celsius);
      var valueRight = Amount.Exact(0.9, Units.Celsius);

      Assert.AreEqual(true, valueLeft <= valueRight);
    }

    [TestMethod]
    public void Operator_GreaterThanOrEquals()
    {
      var valueLeft = Amount.Exact(0.9, Units.Celsius);
      var valueRight = Amount.Exact(0.8, Units.Celsius);

      Assert.AreEqual(true, valueLeft >= valueRight);
    }

    [TestMethod]
    public void Tolerance_Result_Of_Substraction_Equals_Constant()
    {
      var valueLeft = Amount.Exact(0.8, Units.Celsius);
      var valueRight = Amount.Exact(0.7, Units.Celsius);
      var result = valueLeft - valueRight;

      Assert.AreEqual(Amount.Exact(0.1, Units.Celsius), result);
    }

    [TestMethod]
    public void Operator_GraterThan_Positive_and_Negative()
    {
      var left = Amount.Exact(16.2, Units.Celsius);
      var right = Amount.Exact(-200, Units.Celsius);
      Assert.AreEqual(true, left > right);
    }

    [TestMethod]
    public void Operator_GraterThan_Negative_and_Positive()
    {
      var left = Amount.Exact(-200, Units.Celsius);
      var right = Amount.Exact(16.2, Units.Celsius);
      Assert.AreEqual(true, left < right);
    }

    [TestMethod]
    public void Operator_Equals_Tolerance()
    {
      var x1 = Amount.Exact(44000.000000000065, Units.Celsius);
      var x2 = Amount.Exact(44000.000000000007, Units.Celsius);
      Assert.AreEqual(true, x1 == x2);
    }

    private const double normal1 = 0.0002777777777777701;
    private const double normal2 = 0.0002777777777777901;
    private const double normal3 = 0.0002777777777778300;

    [TestMethod]
    public void Test_Amount_Compare_SameRef_True()
    {
        Amount<IMassFlow> a = Amount.Exact<IMassFlow>(+normal1, Units.KilogramPerSecond);
        Amount<IMassFlow> b = a;

        int compare = a.CompareTo(b);
        Assert.IsTrue(compare == 0);
    }

    [TestMethod]
    public void Test_Amount_Compare_Null__True()
    {
        Amount<IMassFlow> a = null;
        Amount<IMassFlow> b = null;

        Assert.IsTrue(a == b);
    }

    [TestMethod]
    public void Test_Amount_Compare_Null_2_True()
    {
        Amount<IMassFlow> a = Amount.Exact<IMassFlow>(+normal1, Units.KilogramPerSecond);
        Amount<IMassFlow> b = null;

        int compare = a.CompareTo(b);
        Assert.IsFalse(compare == 0);
    }

    [TestMethod]
    public void Test_Amount_Compare_Normal_Normal_1_True()
    {
        Amount<IMassFlow> a = Amount.Exact<IMassFlow>(+normal1, Units.KilogramPerSecond);
        Amount<IMassFlow> b = Amount.Exact<IMassFlow>(+normal2, Units.KilogramPerSecond);

        int compare = a.CompareTo(b);
        Assert.IsTrue(compare == 0);
    }

    [TestMethod]
    public void Test_Amount_Compare_Normal_Normal_2_True()
    {
        Amount<IMassFlow> a = Amount.Exact<IMassFlow>(-normal1, Units.KilogramPerSecond);
        Amount<IMassFlow> b = Amount.Exact<IMassFlow>(-normal2, Units.KilogramPerSecond);

        int compare = a.CompareTo(b);
        Assert.IsTrue(compare == 0);
    }

    [TestMethod]
    public void Test_Amount_Compare_Normal_Normal_1_False()
    {
        Amount<IMassFlow> a = Amount.Exact<IMassFlow>(+normal1, Units.KilogramPerSecond);
        Amount<IMassFlow> b = Amount.Exact<IMassFlow>(+normal3, Units.KilogramPerSecond);

        int compare = a.CompareTo(b);
        Assert.IsFalse(compare == 0);
    }

    [TestMethod]
    public void Test_Amount_Compare_Normal_Normal_2_False()
    {
        Amount<IMassFlow> a = Amount.Exact<IMassFlow>(-normal1, Units.KilogramPerSecond);
        Amount<IMassFlow> b = Amount.Exact<IMassFlow>(-normal3, Units.KilogramPerSecond);

        int compare = a.CompareTo(b);
        Assert.IsFalse(compare == 0);
    }

    private const double Normal10 = 2777777777777701;
    private const double Normal20 = 2777777777777710;
    private const double Normal30 = 2777777777778200;

    [TestMethod]
    public void Test_Amount_Compare_Normal10_Normal20_Positive()
    {
        Amount<IMassFlow> a = Amount.Exact<IMassFlow>(+Normal10, Units.KilogramPerSecond);
        Amount<IMassFlow> b = Amount.Exact<IMassFlow>(+Normal20, Units.KilogramPerSecond);

        int compare = a.CompareTo(b);
        Assert.IsTrue(compare == 0);
    }

    [TestMethod]
    public void Test_Amount_Compare_Normal10_Normal_20_Negative()
    {
        Amount<IMassFlow> a = Amount.Exact<IMassFlow>(-Normal10, Units.KilogramPerSecond);
        Amount<IMassFlow> b = Amount.Exact<IMassFlow>(-Normal20, Units.KilogramPerSecond);

        int compare = a.CompareTo(b);
        Assert.IsTrue(compare == 0);
    }

    [TestMethod]
    public void Test_Amount_Compare_Normal10_Normal30_Positive()
    {
        Amount<IMassFlow> a = Amount.Exact<IMassFlow>(+Normal10, Units.KilogramPerSecond);
        Amount<IMassFlow> b = Amount.Exact<IMassFlow>(+Normal30, Units.KilogramPerSecond);

        int compare = a.CompareTo(b);
        Assert.IsFalse(compare == 0);
    }

    [TestMethod]
    public void Test_Amount_Compare_Normal10_Normal30_Negative()
    {
        Amount<IMassFlow> a = Amount.Exact<IMassFlow>(-Normal10, Units.KilogramPerSecond);
        Amount<IMassFlow> b = Amount.Exact<IMassFlow>(-Normal30, Units.KilogramPerSecond);

        int compare = a.CompareTo(b);
        Assert.IsFalse(compare == 0);
    }

    private const double zero0 = 0.0;
    private const double zero1 = 0.0000000000000000077;
    private const double zero2 = 0.0000000000000000079;
    private const double zero3 = 0.0000000000000000080;

    [TestMethod]
    public void Test_Amount_Compare_Zero0_Zero0_Positive()
    {
        Amount<IMassFlow> a = Amount.Exact<IMassFlow>(+zero0, Units.KilogramPerSecond);
        Amount<IMassFlow> b = Amount.Exact<IMassFlow>(+zero0, Units.KilogramPerSecond);

        int compare = a.CompareTo(b);
        Assert.IsTrue(compare == 0);
    }

    [TestMethod]
    public void Test_Amount_Compare_Zero0_Zero0_Negative()
    {
        Amount<IMassFlow> a = Amount.Exact<IMassFlow>(-zero0, Units.KilogramPerSecond);
        Amount<IMassFlow> b = Amount.Exact<IMassFlow>(-zero0, Units.KilogramPerSecond);

        int compare = a.CompareTo(b);
        Assert.IsTrue(compare == 0);
    }

    [TestMethod]
    public void Test_Amount_Compare_Zero1_Zero2_Positive()
    {
        Amount<IMassFlow> a = Amount.Exact<IMassFlow>(+zero1, Units.KilogramPerSecond);
        Amount<IMassFlow> b = Amount.Exact<IMassFlow>(+zero2, Units.KilogramPerSecond);

        int compare = a.CompareTo(b);
        Assert.IsFalse(compare == 0);
    }

    [TestMethod]
    public void Test_Amount_Compare_Zero1_Zero2_Negative()
    {
        Amount<IMassFlow> a = Amount.Exact<IMassFlow>(-zero1, Units.KilogramPerSecond);
        Amount<IMassFlow> b = Amount.Exact<IMassFlow>(-zero2, Units.KilogramPerSecond);

        int compare = a.CompareTo(b);
        Assert.IsFalse(compare == 0);
    }

    [TestMethod]
    public void Test_Amount_Compare_Zero1_Zero3_Positive()
    {
        Amount<IMassFlow> a = Amount.Exact<IMassFlow>(+zero1, Units.KilogramPerSecond);
        Amount<IMassFlow> b = Amount.Exact<IMassFlow>(+zero3, Units.KilogramPerSecond);

        int compare = a.CompareTo(b);
        Assert.IsFalse(compare == 0);
    }

    [TestMethod]
    public void Test_Amount_Compare_Zero1_Zero3_Negative()
    {
        Amount<IMassFlow> a = Amount.Exact<IMassFlow>(-zero1, Units.KilogramPerSecond);
        Amount<IMassFlow> b = Amount.Exact<IMassFlow>(-zero3, Units.KilogramPerSecond);

        int compare = a.CompareTo(b);
        Assert.IsFalse(compare == 0);
    }
  }
}
