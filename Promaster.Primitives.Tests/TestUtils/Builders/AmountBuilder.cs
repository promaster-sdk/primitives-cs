using Promaster.Primitives.Measure;
using Promaster.Primitives.Measure.Quantity;
using Promaster.Primitives.Measure.Unit;

namespace Promaster.Primitives.Tests.TestUtils.Builders
{
  public class AmountBuilder<T> where T : IQuantity
  {

    private double _value = 20;
    private Unit<T> _unit;

    public AmountBuilder<T> WithValue(double value)
    {
      _value = value;
      return this;
    }

    public AmountBuilder<T> WithUnit(Unit<T> unit)
    {
      _unit = unit;
      return this;
    }

    public Amount<T> Build()
    {
      return Amount.Exact(_value, _unit);
    }

  }
}
