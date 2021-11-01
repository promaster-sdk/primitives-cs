using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Promaster.Primitives.Collections
{
  /// <summary>
  /// A generic keyed collection that supports read only interface.
  /// </summary>
  public class SafeKeyedCollection<TKey, TItem> : KeyedCollection<TKey, TItem>, IReadOnlyKeyedCollection<TKey, TItem>
  {
    private readonly Func<TItem, TKey> getKeyFunc;

    public SafeKeyedCollection(Func<TItem, TKey> getKeyFunc)
    {
      this.getKeyFunc = getKeyFunc;
    }

    public SafeKeyedCollection(Func<TItem, TKey> getKeyFunc, IEnumerable<TItem> collection) : this(getKeyFunc)
    {
      foreach (var item in collection)
      {
        this.Add(item);
      }
    }

    protected override TKey GetKeyForItem(TItem item)
    {
      return getKeyFunc(item);
    }

  }

}
