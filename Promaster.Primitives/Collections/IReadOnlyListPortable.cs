using System.Collections;
using System.Collections.Generic;

namespace Promaster.Primitives.Collections
{

  /// <summary>
  /// ReadOnly interface for list semantics. Provided here since this is not included in .NET BCL.
  /// </summary>
  public interface IReadOnlyListPortable<T> : IEnumerable<T>, IEnumerable
  {

    int IndexOf(T item);
    T this[int index] { get; }
    int Count { get; }

  }
}
