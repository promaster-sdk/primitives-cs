using System.Collections.Generic;

namespace Promaster.Primitives.Collections
{
  /// <summary>
  /// Dictionary that is possible to fill but then return as IReadOnlyList.
  /// </summary>
  public class SafeDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IReadOnlyDictionaryPortable<TKey, TValue>
  {

    public SafeDictionary()
    { }

    public SafeDictionary(IEqualityComparer<TKey> comparer)
      : base(comparer)
    {
    }

    public SafeDictionary(IDictionary<TKey, TValue> input)
    {
      if (input == null)
        return;
      foreach (var item in input)
        Add(item.Key, item.Value);
    }

    public SafeDictionary(IEnumerable<KeyValuePair<TKey, TValue>> input)
    {
      if (input == null)
        return;
      foreach (var item in input)
        Add(item.Key, item.Value);
    }

    public SafeDictionary(IReadOnlyDictionaryPortable<TKey, TValue> input)
    {
      if (input == null)
        return;
      foreach (var item in input)
        Add(item.Key, item.Value);
    }
  }

}
