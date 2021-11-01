using System.Collections.Generic;

namespace Promaster.Primitives.Collections
{

  /// <summary>
  /// List that is possible to fill but then return as IReadOnlyList.
  /// </summary>
  public class SafeList<T> : List<T>, IReadOnlyListPortable<T>
  {
    public SafeList()
    {
    }

    public SafeList(IEnumerable<T> collection) : base(collection)
    {
    }
  }

}
