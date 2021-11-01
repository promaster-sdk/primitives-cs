using System;
using Promaster.Primitives.Measure;
using Promaster.Primitives.Measure.Quantity;
using Promaster.Primitives.Measure.Unit;
using Promaster.Primitives.Tests.TestUtils.Builders;
using Promaster.Primitives.Tests.TestUtils.ConversionHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Promaster.Primitives.Tests.Measure
{
  [TestClass]
  public class AmountLengthTest
  {
    [TestMethod]
    public void For_Value_0_centimeters_we_should_get_value_0_centimeters()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_10_centimeters_we_should_get_value_10_centimeters()
    {
      double value = 10.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_0_centimeters_we_should_get_value_0_meters()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_centimeter_we_should_get_value_0_01_meter()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2M(value), 5), Math.Round(convertedAmount, 5));
    }


    [TestMethod]
    public void For_Value_12_centimeters_we_should_get_value_0_12_meters()
    {
      double value = 12.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_357_centimeter_we_should_get_value_3_57_meter()
    {
      double value = 357.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_56_centimeters_we_should_get_value_0_0056_meters()
    {
      double value = 0.56;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_centimeters_we_should_get_value_0_kilometers()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_centimeter_we_should_get_value_0_00001_kilometers()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2Km(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_120000_centimeters_we_should_get_value_1_2_kilometers()
    {
      double value = 120000.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2Km(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_78_centimeters_we_should_get_value_0_00078_kilometers()
    {
      double value = 78.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2Km(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_centimeter_we_should_get_value_0_inch()
    {
      double value = 0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_centimeter_we_should_get_value_0_3937_inch()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_10_centimeter_we_should_get_value_3_937_inch()
    {
      double value = 10.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_87_centimeter_we_should_get_value_0_34252_inch()
    {
      double value = 0.87;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_245_centimeter_we_should_get_value_96_45669_inch()
    {
      double value = 245.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_3_centimeter_we_should_get_value_0_11811_inch()
    {
      double value = 0.3;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_centimeter_we_should_get_value_0_foot()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_centimeter_we_should_get_value_0_03281_foot()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_10_centimeter_we_should_get_value_0_328_foot()
    {
      double value = 10.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_378_centimeter_we_should_get_value_12_40157_foot()
    {
      double value = 378.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2Ft(value), 5) , Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_9_centimeter_we_should_get_value_0_02953_foot()
    {
      double value = 0.9;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_centimeter_we_should_get_value_0_yard()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_centimeter_we_should_get_value_0_01094_yard()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_100_centimeter_we_should_get_value_1_09361_yard()
    {
      double value = 100.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_501_centimeter_we_should_get_value_5_479_yard()
    {
      double value = 501.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_5_centimeter_we_should_get_value_0_00547_yard()
    {
      double value = 0.5;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.CentiMeter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.Cm2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    // meter

    //meter2meter

    [TestMethod]
    public void For_Value_0_meter_we_should_get_value_0_meter()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_10_meter_we_should_get_value_10_meter()
    {
      double value = 10.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(value, convertedAmount);
    }

    //meter2centimeter

    [TestMethod]
    public void For_Value_0_meter_we_should_get_value_0_centimeter()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_meter_we_should_get_value_100_centimeter()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.M2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_12_meter_we_should_get_value_1200_centimeter()
    {
      double value = 12.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.M2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_56_meter_we_should_get_value_56_centimeter()
    {
      double value = 0.56;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.M2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_001_meter_we_should_get_value_0_1_centimeter()
    {
      double value = 0.001;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.M2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_meter_we_should_get_value_0_kilometer()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_meter_we_should_get_value_0_001_kilometer()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(Math.Round(LengthConversion.M2Km(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_1200_meter_we_should_get_value_1_2_kilometer()
    {
      double value = 1200.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(Math.Round(LengthConversion.M2Km(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_78_meter_we_should_get_value_0_00078_kilometer()
    {
      double value = 0.78;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(Math.Round(LengthConversion.M2Km(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_meter_we_should_get_value_0_inch()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_meter_we_should_get_value_39_37008_inch()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.M2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_1_meter_we_should_get_value_3_93701_inch()
    {
      double value = 0.1;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.M2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_0087_meter_we_should_get_value_0_34252_inch()
    {
      double value = 0.0087;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.M2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_2_45_meter_we_should_get_value_96_45669_inch()
    {
      double value = 2.45;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.M2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_003_meter_we_should_get_value_0_11811_inch()
    {
      double value = 0.003;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.M2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_meter_we_should_get_value_0_foot()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_meter_we_should_get_value_3_28084_foot()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.M2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_1_meter_we_should_get_value_0_32808_foot()
    {
      double value = 0.1;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.M2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_3_78_meter_we_should_get_value_12_40157_foot()
    {
      double value = 3.78;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.M2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_009_meter_we_should_get_value_0_02953_foot()
    {
      double value = 0.009;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.M2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_meter_we_should_get_value_0_yard()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_meter_we_should_get_value_1_09361_yard()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.M2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_5_01_meter_we_should_get_value_5_479_yard()
    {
      double value = 5.01;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.M2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_005_meter_we_should_get_value_0_00547_yard()
    {
      double value = 0.005;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Meter)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.M2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    //kilometer

    //kilometer to centimeter
    [TestMethod]
    public void For_Value_0_kilometer_we_should_get_value_0_centimeter()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_kilometer_we_should_get_value_100000_centimeter()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.Km2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_35_kilometer_we_should_get_value_3500000_centimeter()
    {
      double value = 35.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.Km2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_2_56_kilometer_we_should_get_value_256000_centimeter()
    {
      double value = 2.56;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.Km2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_33_kilometer_we_should_get_value_33000_centimeter()
    {
      double value = 0.33;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.Km2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_000001_kilometer_we_should_get_value_0_1_centimeter()
    {
      double value = 0.000001;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.Km2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    //kilometer 2 meter

    [TestMethod]
    public void For_Value_0_kilometer_we_should_get_value_0_meter()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_kilometer_we_should_get_value_1000_meter()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Km2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_11_kilometer_we_should_get_value_11000_meter()
    {
      double value = 11.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Km2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_2_78_kilometer_we_should_get_value_2780_meter()
    {
      double value = 2.78;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Km2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_3_5478_kilometer_we_should_get_value_3547_8_meter()
    {
      double value = 3.5478;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Km2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_52_kilometer_we_should_get_value_520_meter()
    {
      double value = 0.52;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Km2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_00084_kilometer_we_should_get_value_0_84_meter()
    {
      double value = 0.00084;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Km2M(value), 5), Math.Round(convertedAmount, 5));
    }

    //kilometer 2 kilometer

    [TestMethod]
    public void For_Value_0_kilometer_we_should_get_value_0_kilometer()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_kilometer_we_should_get_value_1_kilometer()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(value, convertedAmount);
    }

    //kilometer 2 inch

    [TestMethod]
    public void For_Value_0_kilometer_we_should_get_value_0_inch()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_kilometer_we_should_get_value_39370_07874_inch()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Km2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_5_kilometer_we_should_get_value_196850_3937_inch()
    {
      double value = 5.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Km2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_2_34_kilometer_we_should_get_value_92125_98425_inch()
    {
      double value = 2.34;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Km2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_0004_kilometer_we_should_get_value_15_74803_inch()
    {
      double value = 0.0004;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Km2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_00002_kilometer_we_should_get_value_0_7874_inch()
    {
      double value = 0.00002;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Km2In(value), 5), Math.Round(convertedAmount, 5));
    }

    //kilometer 2 foot

    [TestMethod]
    public void For_Value_0_kilometer_we_should_get_value_0_foot()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_kilometer_we_should_get_value_3280_8399_foot()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.Km2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_4_kilometer_we_should_get_value_13123_35958_foot()
    {
      double value = 4.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.Km2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_2_11_kilometer_we_should_get_value_6922_57218_foot()
    {
      double value = 2.11;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.Km2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_0023_kilometer_we_should_get_value_7_54593_foot()
    {
      double value = 0.0023;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.Km2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_00014_kilometer_we_should_get_value_0_45932_foot()
    {
      double value = 0.00014;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.Km2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    //kilometer 2 yard

    [TestMethod]
    public void For_Value_0_kilometer_we_should_get_value_0_yard()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_kilometer_we_should_get_value_1093_6133_yard()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.Km2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_5_kilometer_we_should_get_value_5468_06649_yard()
    {
      double value = 5.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.Km2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_1_2_kilometer_we_should_get_value_1312_33596_yard()
    {
      double value = 1.2;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.Km2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_3_kilometer_we_should_get_value_328_08399_yard()
    {
      double value = 0.3;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.Km2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_0002_kilometer_we_should_get_value_0_21872_yard()
    {
      double value = 0.0002;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Kilometer)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.Km2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    //inch

    //inch 2 centimeter

    [TestMethod]
    public void For_Value_0_inch_we_should_get_value_0_centimeter()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_inch_we_should_get_value_2_54_centimeter()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.In2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_3_inch_we_should_get_value_7_62_centimeter()
    {
      double value = 3.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.In2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_2_5_inch_we_should_get_value_6_35_centimeter()
    {
      double value = 2.5;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.In2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_4_inch_we_should_get_value_1_016_centimeter()
    {
      double value = 0.4;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.In2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_21_inch_we_should_get_value_0_5334_centimeter()
    {
      double value = 0.21;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.In2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    //inch 2 meter
    [TestMethod]
    public void For_Value_0_inch_we_should_get_value_0_meter()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_inch_we_should_get_value_0_0254_meter()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.In2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_6_inch_we_should_get_value_0_1524_meter()
    {
      double value = 6.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.In2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_3_4_inch_we_should_get_value_0_08636_meter()
    {
      double value = 3.4;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.In2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_9_inch_we_should_get_value_0_02286_meter()
    {
      double value = 0.9;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.In2M(value), 5), Math.Round(convertedAmount, 5));
    }

    //inch 2 kilometer
    [TestMethod]
    public void For_Value_0_inch_we_should_get_value_0_kilometer()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_inch_we_should_get_value_0_0000254_kilometer()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(Math.Round(LengthConversion.In2Km(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_158_inch_we_should_get_value_0_00401_kilometer()
    {
      double value = 158.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(Math.Round(LengthConversion.In2Km(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_1024_5_inch_we_should_get_value_0_02602_kilometer()
    {
      double value = 1024.5;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(Math.Round(LengthConversion.In2Km(value), 5), Math.Round(convertedAmount, 5));
    }

    //inch 2 inch
    [TestMethod]
    public void For_Value_0_inch_we_should_get_value_0_inch()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_5_inch_we_should_get_value_5_inch()
    {
      double value = 5.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(value, convertedAmount);
    }

    //inch 2 foot
    [TestMethod]
    public void For_Value_0_inch_we_should_get_value_0_foot()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_inch_we_should_get_value_0_08333_foot()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.In2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_13_inch_we_should_get_value_1_08333_foot()
    {
      double value = 13.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.In2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_100_8_inch_we_should_get_value_8_4_foot()
    {
      double value = 100.8;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.In2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_99_inch_we_should_get_value_0_0825_foot()
    {
      double value = 0.99;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.In2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    //inch 2 yard
    [TestMethod]
    public void For_Value_0_inch_we_should_get_value_0_yard()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_inch_we_should_get_value_0_02778_yard()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.In2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_12_inch_we_should_get_value_0_33333_yard()
    {
      double value = 12.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.In2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_2_inch_we_should_get_value_0_00556_yard()
    {
      double value = 0.2;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Inch)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.In2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    //foot to cm
    [TestMethod]
    public void For_Value_0_foot_we_should_get_value_0_centimeter()
    {
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(0).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(0, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_foot_we_should_get_value_30_48_centimeter()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_89_foot_we_should_get_value_2712_72_centimeter()
    {
      double value = 89.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_30_53_foot_we_should_get_value_930_5544_centimeter()
    {
      double value = 30.53;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    //foot 2 meter
    [TestMethod]
    public void For_Value_0_foot_we_should_get_value_0_meter()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_foot_we_should_get_value_0_3048_meter()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_29_foot_we_should_get_value_8_8392_meter()
    {
      double value = 29.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_53_5_foot_we_should_get_value_16_3068_meter()
    {
      double value = 53.5;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_8_foot_we_should_get_value_0_24384_meter()
    {
      double value = 0.8;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2M(value), 5), Math.Round(convertedAmount, 5));
    }

    //foot to kilometer
    [TestMethod]
    public void For_Value_0_foot_we_should_get_value_0_kilometer()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_foot_we_should_get_value_0_0003_kilometer()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2Km(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_1080_foot_we_should_get_value_0_32918_kilometer()
    {
      double value = 1080.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2Km(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_38574_7_foot_we_should_get_value_11_75757_kilometer()
    {
      double value = 38574.7;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2Km(value), 5), Math.Round(convertedAmount, 5));
    }

    //foot to inch
    [TestMethod]
    public void For_Value_0_foot_we_should_get_value_0_inch()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_foot_we_should_get_value_12_inch()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_50_foot_we_should_get_value_600_inch()
    {
      double value = 50.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_3_7_foot_we_should_get_value_44_4_inch()
    {
      double value = 3.7;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_5_foot_we_should_get_value_6_inch()
    {
      double value = 0.5;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_007_foot_we_should_get_value_0_084_inch()
    {
      double value = 0.007;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2In(value), 5), Math.Round(convertedAmount, 5));
    }

    //foot 2 foot
    [TestMethod]
    public void For_Value_0_foot_we_should_get_value_0_foot()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_4_foot_we_should_get_value_4_foot()
    {
      double value = 4.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(value, convertedAmount, 0.000001);
    }

    [TestMethod]
    public void For_Value_2_5_foot_we_should_get_value_2_5_foot()
    {
      double value = 2.5;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(value, convertedAmount, 0.00001);
    }

    //foot 2 yard
    [TestMethod]
    public void For_Value_0_foot_we_should_get_value_0_yard()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_foot_we_should_get_value_0_33333_yard()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_15_foot_we_should_get_value_5_yard()
    {
      double value = 15.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_20_4_foot_we_should_get_value_6_8_yard()
    {
      double value = 20.4;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_5_foot_we_should_get_value_0_16667_yard()
    {
      double value = 0.5;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Foot)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(Math.Round(LengthConversion.Ft2Yd(value), 5), Math.Round(convertedAmount, 5));
    }

    //yard
    //yard 2 centimeter
    [TestMethod]
    public void For_Value_0_yard_we_should_get_value_0_centimeter()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_yard_we_should_get_value_91_44_centimeter()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_3_yard_we_should_get_value_274_32_centimeter()
    {
      double value = 3.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_1_1_yard_we_should_get_value_100_584_centimeter()
    {
      double value = 1.1;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_008_yard_we_should_get_value_0_73152_centimeter()
    {
      double value = 0.008;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.CentiMeter);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2Cm(value), 5), Math.Round(convertedAmount, 5));
    }

    //yard 2 meter
    [TestMethod]
    public void For_Value_0_yard_we_should_get_value_0_meter()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_yard_we_should_get_value_0_9144_meter()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_48_yard_we_should_get_value_43_8912_meter()
    {
      double value = 48.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_10_5_yard_we_should_get_value_9_6012_meter()
    {
      double value = 10.5;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2M(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_8_yard_we_should_get_value_0_73152_meter()
    {
      double value = 0.8;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Meter);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2M(value), 5), Math.Round(convertedAmount, 5));
    }

    //yard 2 kilometer
    [TestMethod]
    public void For_Value_0_yard_we_should_get_value_0_kilometer()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_yard_we_should_get_value_0_00091_kilometer()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2Km(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_69_yard_we_should_get_value_0_06309_kilometer()
    {
      double value = 69.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2Km(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_127_5_yard_we_should_get_value_0_11659_kilometer()
    {
      double value = 127.5;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2Km(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_88_yard_we_should_get_value_0_0008_kilometer()
    {
      double value = 0.88;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Kilometer);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2Km(value), 5), Math.Round(convertedAmount, 5));
    }

    //yard 2 inch
    [TestMethod]
    public void For_Value_0_yard_we_should_get_value_0_inch()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_yard_we_should_get_value_36_inch()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_5_yard_we_should_get_value_180_inch()
    {
      double value = 5.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_2_4_yard_we_should_get_value_86_4_inch()
    {
      double value = 2.4;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2In(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_03_yard_we_should_get_value_1_08_inch()
    {
      double value = 0.03;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Inch);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2In(value), 5), Math.Round(convertedAmount, 5));
    }

    //yard 2 foot
    [TestMethod]
    public void For_Value_0_yard_we_should_get_value_0_foot()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_1_yard_we_should_get_value_3_foot()
    {
      double value = 1.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_15_yard_we_should_get_value_65_foot()
    {
      double value = 15.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_5_8_yard_we_should_get_value_17_4_foot()
    {
      double value = 5.8;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    [TestMethod]
    public void For_Value_0_1_yard_we_should_get_value_0_3_foot()
    {
      double value = 0.1;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Foot);
      Assert.AreEqual(Math.Round(LengthConversion.Yd2Ft(value), 5), Math.Round(convertedAmount, 5));
    }

    //yard 2 yard
    [TestMethod]
    public void For_Value_0_yard_we_should_get_value_0_yard()
    {
      double value = 0.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(value, convertedAmount);
    }

    [TestMethod]
    public void For_Value_4_yard_we_should_get_value_4_yard()
    {
      double value = 4.0;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(value, convertedAmount, 0.000001);
    }

    [TestMethod]
    public void For_Value_1_2_yard_we_should_get_value_1_2_yard()
    {
      double value = 1.2;
      Amount<ILength> amountToTest = new AmountBuilder<ILength>()
        .WithUnit(Units.Yard)
        .WithValue(value).Build();
      double convertedAmount = amountToTest.ValueAs(Units.Yard);
      Assert.AreEqual(value, convertedAmount, 0.000001);
    }
  }
}
