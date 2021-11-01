using System.Collections.Generic;

namespace Promaster.Primitives.Collections
{
  public static class DictionaryExtensions
  {
    public static IReadOnlyDictionaryPortable<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(this IDictionary<TKey, TValue> dict)
    {
      return new SafeDictionary<TKey, TValue>(dict);
    }

    public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> other)
    {
      foreach (var keyValuePair in other)
        dict[keyValuePair.Key] = keyValuePair.Value;
    }

    public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue)
    {
      TValue val;
      if (dict.TryGetValue(key, out val))
        return val;
      return defaultValue;
    }
  }
}