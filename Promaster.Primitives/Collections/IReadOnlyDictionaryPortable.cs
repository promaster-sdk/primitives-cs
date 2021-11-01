using System.Collections.Generic;

namespace Promaster.Primitives.Collections
{

  /// <summary>
  /// ReadOnly interface for dictionary semantics. Provided here since this is not included in .NET BCL.
  /// </summary>
  public interface IReadOnlyDictionaryPortable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
  {
    TValue this[TKey index] { get; }
    int Count { get; }
    bool ContainsKey(TKey key);
    bool TryGetValue(TKey key, out TValue value);
    Dictionary<TKey, TValue>.KeyCollection Keys { get; }
    Dictionary<TKey, TValue>.ValueCollection Values { get; }
    IEqualityComparer<TKey> Comparer { get; }
  }

}
