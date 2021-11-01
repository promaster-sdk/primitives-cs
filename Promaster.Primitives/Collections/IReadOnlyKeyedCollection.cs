using System.Collections;
using System.Collections.Generic;

namespace Promaster.Primitives.Collections
{
  public interface IReadOnlyKeyedCollection<TKey, TItem> : IEnumerable<TItem>, IEnumerable
  {

    TItem this[TKey key] { get; }
    int IndexOf(TItem item);
    int Count { get; }

  }

}
