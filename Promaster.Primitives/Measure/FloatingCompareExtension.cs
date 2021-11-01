//using System;

//namespace Promaster.Primitives.Measure
//{
//    /// <summary>
//    /// Extension class with floating point comparison methods using given tolerance
//    /// </summary>
//    public static class FloatingCompareExtension
//    {
//        /// <summary>
//        /// Float value type comparison using a tolerance for equality
//        /// </summary>
//        /// <param name="a"></param>
//        /// <param name="b"></param>
//        /// <param name="tolerance"></param>
//        /// <returns></returns>
//        public static int CompareTo(this float a, float b, float tolerance)
//        {
//            return CloseAtTolerance(a, b, tolerance) ? 0 : a.CompareTo(b);
//        }

//        /// <summary>
//        /// Double value type comparison using a tolerance for equality
//        /// </summary>
//        /// <param name="a"></param>
//        /// <param name="b"></param>
//        /// <param name="tolerance"></param>
//        /// <returns></returns>
//        public static int CompareTo(this double a, double b, double tolerance)
//        {
//            return CloseAtTolerance(a, b, tolerance) ? 0 : a.CompareTo(b);
//        }

//        /// <summary>
//        /// Return whether two double values are close at a given tolerance
//        /// </summary>
//        /// <param name="a"></param>
//        /// <param name="b"></param>
//        /// <param name="tolerance"></param>
//        /// <returns></returns>
//        internal static bool CloseAtTolerance(this double a, double b, double tolerance)
//        {
//            double absTolerance = Math.Abs(tolerance);
//            double diff = Math.Abs(a - b);            
//            return diff <= absTolerance;
//        }
//    }
//}
