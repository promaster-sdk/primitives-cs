using System.Collections.Generic;
using System.Linq;
using Promaster.Primitives.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Promaster.Primitives.Tests.Collections
{
  [TestClass]
  public class EnumerableTests
  {
    [TestMethod]
    public void Split1()
    {
      var list = new []{1, 2, 3, -1, 4, 5, 6};
      var split = list.SplitBy(-1).ToList();
      Assert.IsTrue(split.Count() == 2 && split.First().Count() == 3 && split.Last().Count() == 3);
    }

    [TestMethod]
    public void Split2()
    {
      var list = new[] { 1, 2, 3, -1, 4, 5, 6, -1 };
      var split = list.SplitBy(-1).ToList();
      Assert.IsTrue(split.Count() == 2 && split.First().Count() == 3 && split.Last().Count() == 3);
    }
  }
}