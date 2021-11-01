using System.Collections.Generic;

namespace Promaster.Primitives.Collections
{

  /// <summary>
  /// Supports list and dictionary sementics at the same time.
  /// </summary>
  public class PairList<TKey, TValue> : List<KeyValuePair<TKey, TValue>>
  {
    public void Add(TKey key, TValue value)
    {
      Add(new KeyValuePair<TKey, TValue>(key, value));
    }

    /// <summary>
    /// Returns values in list-order.
    /// </summary>
    public IEnumerable<TValue> Values
    {
      get
      {
        foreach (var kvp in this)
        {
          yield return kvp.Value;
        }
      }
    }

    /// <summary>
    /// Returns keys in list-order.
    /// </summary>
    public IEnumerable<TKey> Keys
    {
      get
      {
        foreach (var kvp in this)
        {
          yield return kvp.Key;
        }
      }
    }

  }

}
