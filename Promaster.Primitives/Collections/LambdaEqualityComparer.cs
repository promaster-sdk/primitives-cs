using System;
using System.Collections.Generic;

namespace Promaster.Primitives.Collections
{
  public class LambdaEqualityComparer<T> : IEqualityComparer<T>
  {
    private readonly Func<T, T, bool> _equalsFunction;
    private readonly Func<T, int> _getHashCodeFunction;

    public LambdaEqualityComparer(Func<T, T, bool> equalsFunction, Func<T, int> getHashCodeFunction)
    {
      _equalsFunction = equalsFunction;
      _getHashCodeFunction = getHashCodeFunction;
    }

    #region IEqualityComparer<T> Members

    public bool Equals(T x, T y)
    {
      return _equalsFunction(x, y);
    }

    public int GetHashCode(T obj)
    {
      return _getHashCodeFunction(obj);
    }

    #endregion
  }

}
