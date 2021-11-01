using System;
using System.Collections.Generic;
using System.Linq;

namespace Promaster.Primitives.Collections
{

  public static class EnumerableExtensions
  {
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable, Random random)
    {
      return enumerable.OrderBy(k => random.NextDouble());
    }

    public static IEnumerable<T> Backwards<T>(this IEnumerable<T> enumerable)
    {
      return enumerable.Reverse();
    }

    public static IEnumerable<T> RemoveNulls<T>(this IEnumerable<T> enumerable) where T : class
    {
      return enumerable.Where(e => e != null);
    }

    // Creates an IEnumerable with this single item 
    public static IEnumerable<T> ToEnumerable<T>(this T item)
    {
      yield return item;
    }

    public static T AtPositionOrNull<T>(this IEnumerable<T> enumerable, int i)
    {
      var list = enumerable.ToList();
      if (i < 0 || i >= list.Count)
        return default(T);
      return list[i];
    }

    public static IReadOnlyListPortable<T> ToReadOnlyList<T>(this IEnumerable<T> enumerable)
    {
      return new SafeList<T>(enumerable);
    }

    public static SafeList<T> ToSafeList<T>(this IEnumerable<T> enumerable)
    {
      return new SafeList<T>(enumerable);
    }

    public static SafeDictionary<TKey, TValue> ToSafeDictionary<TItem, TKey, TValue>(this IEnumerable<TItem> enumerable, Func<TItem, TKey> keySelector, Func<TItem, TValue> valueSelector, IEqualityComparer<TKey> comparer)
    {
      var dict = new SafeDictionary<TKey, TValue>(comparer);
      foreach (var item in enumerable)
        dict[keySelector(item)] = valueSelector(item);
      return dict;
    }


    public static SafeDictionary<TKey, TValue> ToSafeDictionary<TItem, TKey, TValue>(this IEnumerable<TItem> enumerable, Func<TItem, TKey> keySelector, Func<TItem, TValue> valueSelector)
    {
      var dict = new SafeDictionary<TKey, TValue>();
      foreach (var item in enumerable)
        dict[keySelector(item)] = valueSelector(item);
      return dict;
    }

    public static SafeDictionary<TKey, TValue> ToSafeDictionary<TKey, TValue>(this IEnumerable<TKey> enumerable, Func<TKey, TValue> valueSelector)
    {
      var dict = new SafeDictionary<TKey, TValue>();
      foreach (var item in enumerable)
        dict[item] = valueSelector(item);
      return dict;
    }

    public static IEnumerable<IEnumerable<T>> Page<T>(this IEnumerable<T> source, int pageSize)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (pageSize < 1)
        throw new ArgumentOutOfRangeException("pageSize");
      using (var enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          var currentPage = enumerator.Current.ToEnumerable().ToList();
          while (currentPage.Count < pageSize && enumerator.MoveNext())
            currentPage.Add(enumerator.Current);
          yield return currentPage;
        }
      }
    }

    public static IEnumerable<TResult> SafeZip<T, TSecond, TResult>(this IEnumerable<T> first,
      IEnumerable<TSecond> second, Func<T, TSecond, TResult> resultSelector)
    {

      if (first == null || second == null)
        throw new ArgumentNullException();
      var firstList = first.ToList();
      var secondList = second.ToList();
      if (firstList.Count() != secondList.Count())
        throw new Exception("Can't zip two enumerables with different length.");
      return firstList.Zip(secondList, resultSelector);
    }

    public static IEnumerable<IEnumerable<T>> SplitBy<T>(this IEnumerable<T> source, T separator)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      using (var enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          yield break;
        var list = new List<T>();
        do
        {
          if (Equals(enumerator.Current, separator))
          {
            if (list.Any())
              yield return list;
            list = new List<T>();
          }
          else
          {
            list.Add(enumerator.Current);
          }

        } while (enumerator.MoveNext());
        if (list.Any())
          yield return list;
      }
    }

    public static IEnumerable<IEnumerable<T>> SplitBy<T>(this IEnumerable<T> source, Func<T, bool> separator)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      using (var enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          yield break;
        var list = new List<T>();
        do
        {
          if (separator(enumerator.Current))
          {
            if (list.Any())
              yield return list;
            list = new List<T>();
          }
          else
          {
            list.Add(enumerator.Current);
          }

        } while (enumerator.MoveNext());
        if (list.Any())
          yield return list;
      }
    }

    public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
    {
      return source.MinBy(selector, Comparer<TKey>.Default);
    }

    public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      using (var sourceIterator = source.GetEnumerator())
      {
        if (!sourceIterator.MoveNext())
          throw new InvalidOperationException("Sequence was empty");

        var min = sourceIterator.Current;
        var minKey = selector(min);
        while (sourceIterator.MoveNext())
        {
          var candidate = sourceIterator.Current;
          var candidateProjected = selector(candidate);
          if (comparer.Compare(candidateProjected, minKey) >= 0)
            continue;
          min = candidate;
          minKey = candidateProjected;
        }
        return min;
      }
    }

    public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
    {
      return source.MaxBy(selector, Comparer<TKey>.Default);
    }

    public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");
      if (comparer == null)
        throw new ArgumentNullException("comparer");
      using (var sourceIterator = source.GetEnumerator())
      {
        if (!sourceIterator.MoveNext())
          throw new InvalidOperationException("Sequence was empty");

        var max = sourceIterator.Current;
        var maxKey = selector(max);
        while (sourceIterator.MoveNext())
        {
          var candidate = sourceIterator.Current;
          var candidateProjected = selector(candidate);
          if (comparer.Compare(candidateProjected, maxKey) <= 0)
            continue;
          max = candidate;
          maxKey = candidateProjected;
        }
        return max;
      }
    }

    public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source)
    {
      return new HashSet<TSource>(source);
    }

    public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
    {
      return new HashSet<TSource>(source, comparer);
    }

    public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
      var knownKeys = new HashSet<TKey>();
      foreach (TSource element in source)
        if (knownKeys.Add(keySelector(element)))
          yield return element;
    }
  }

}
