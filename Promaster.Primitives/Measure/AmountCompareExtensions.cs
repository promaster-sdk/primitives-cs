//using Promaster.Primitives.Measure.Quantity;
//using Promaster.Primitives.Measure.Unit;

//namespace Promaster.Primitives.Measure
//{
//  public static class AmountCompareExtensions
//  {

//    /// <summary>
//    /// Amount<> comparison using a tolerance for equality
//    /// </summary>
//    /// <typeparam name="T"></typeparam>
//    /// <param name="a"></param>
//    /// <param name="b"></param>
//    /// <param name="tolerance"></param>
//    /// <returns></returns>
//    public static int CompareTo<T>(this Amount<T> a, Amount<T> b, Amount<T> tolerance) where T : IQuantity
//    {
//      return CloseAtTolerance(a, b, tolerance) ? 0 : a.CompareTo(b);
//    }


//    /// <summary>
//    /// Return whether two Amount<> are close at a given tolerance
//    /// </summary>
//    /// <typeparam name="T"></typeparam>
//    /// <param name="a"></param>
//    /// <param name="b"></param>
//    /// <param name="tolerance"></param>
//    /// <returns></returns>
//    private static bool CloseAtTolerance<T>(this Amount<T> a, Amount<T> b, Amount<T> tolerance) where T : IQuantity
//    {
//      if (a == null)
//        return b == null;
//      if (b == null)
//        return false;
//      if (ReferenceEquals(a, b))
//        return true;
//      var bValue = b.ValueAs(a.Unit as Unit<T>);
//      var toleranceValue = tolerance.ValueAs(a.Unit as Unit<T>);
//      return a.Value.CloseAtTolerance(bValue, toleranceValue);
//    }
//  }
//}