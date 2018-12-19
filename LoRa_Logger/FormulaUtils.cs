using System;
using System.Collections.Generic;

namespace LoRa_Logger
{
    /// <summary>
    /// A class of features that simplify basic operations for the formulas
    /// </summary>
    public static class FormulaUtils
    {
        /// <summary>
        /// Function that adds a list of values and makes a square root of the sum
        /// </summary>
        /// <returns>
        /// the square root of the sum of the values
        /// </returns>
        /// <param name="values">a list of values</param>
        public static double SumSqrt(List<double> values)
        {
            double sum = 0d;
            foreach (double value in values)
            {
                sum += value;
            }
            return Math.Sqrt(sum);
        }
    }
}
