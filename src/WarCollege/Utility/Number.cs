using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCollege
{
    /// <summary>
    /// Collection of constants and extension methods dealing with numbers.
    /// </summary>
    public static class Number
    {
        /// <summary>
        /// Really tiny number. Used mostly for comparing floating point numbers.
        /// </summary>
        public const float EPSILON = 0.000000001f;

        /// <summary>
        /// Tests wheater a number is negative.
        /// </summary>
        /// <param name="number">The number to test.</param>
        /// <returns>True, if the number is negative.</returns>
        public static bool IsNegative(this int number) => number < 0;

        /// <summary>
        /// Tests wheater a number is negative.
        /// </summary>
        /// <param name="number">The number to test.</param>
        /// <returns>True, if the number is negative.</returns>
        public static bool IsNegative(this double number) => number < 0D;

        /// <summary>
        /// Tests wheater a number is negative.
        /// </summary>
        /// <param name="number">The number to test.</param>
        /// <returns>True, if the number is negative.</returns>
        public static bool IsNegative(this short number) => number < 0;

        /// <summary>
        /// Tests wheater a number is negative.
        /// </summary>
        /// <param name="number">The number to test.</param>
        /// <returns>True, if the number is negative.</returns>
        public static bool IsNegative(this long number) => number < 0L;

        /// <summary>
        /// Tests wheater a number is negative.
        /// </summary>
        /// <param name="number">The number to test.</param>
        /// <returns>True, if the number is negative.</returns>
        public static bool IsNegative(this float number) => number < 0f;

        /// <summary>
        /// Tests wheater a number is negative.
        /// </summary>
        /// <param name="number">The number to test.</param>
        /// <returns>True, if the number is negative.</returns>
        public static bool IsNegative(this decimal number) => number < 0m;
    }
}
