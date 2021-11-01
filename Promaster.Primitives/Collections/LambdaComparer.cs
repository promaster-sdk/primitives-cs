using System;
using System.Collections.Generic;

namespace Promaster.Primitives.Collections
{
  public class LambdaComparer<T> : IComparer<T>
  {
    private readonly Func<T, T, int> _compareFunction;

    public LambdaComparer(Func<T, T, int> compareFunction)
    {
      _compareFunction = compareFunction;
    }

    #region IComparer<T> Members

    public int Compare(T x, T y)
    {
      return _compareFunction(x, y);
    }

    #endregion

  }

}
