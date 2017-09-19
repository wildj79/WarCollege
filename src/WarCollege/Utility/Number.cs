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
        /// Tests wheater an integer is negative.
        /// </summary>
        /// <param name="number">The integer to test.</param>
        /// <returns>True, if the integer is negative.</returns>
        public static bool IsNegative(this int number) => number < 0;

        /// <summary>
        /// Tests wheater a double floating point number is negative.
        /// </summary>
        /// <param name="number">The number to test.</param>
        /// <returns>True, if the number is negative.</returns>
        public static bool IsNegative(this double number) => number < 0D;

        /// <summary>
        /// Tests wheater a short integer is negative.
        /// </summary>
        /// <param name="number">The number to test.</param>
        /// <returns>True, if the number is negative.</returns>
        public static bool IsNegative(this short number) => number < 0;

        /// <summary>
        /// Tests wheater a long integer is negative.
        /// </summary>
        /// <param name="number">The number to test.</param>
        /// <returns>True, if the number is negative.</returns>
        public static bool IsNegative(this long number) => number < 0L;

        /// <summary>
        /// Tests wheater a floating point number is negative.
        /// </summary>
        /// <param name="number">The number to test.</param>
        /// <returns>True, if the number is negative.</returns>
        public static bool IsNegative(this float number) => number < 0f;

        /// <summary>
        /// Tests wheater a decimal number is negative.
        /// </summary>
        /// <param name="number">The number to test.</param>
        /// <returns>True, if the number is negative.</returns>
        public static bool IsNegative(this decimal number) => number < 0m;

        /// <summary>
        /// Checks to see if an integer is a multiple of another number.
        /// </summary>
        /// <param name="number">Integer to check.</param>
        /// <param name="value">Value to check against.</param>
        /// <returns><c>True</c> if the integer is a multiple of value.</returns>
        public static bool IsMultipleOf(this int number, int value) => number % value == 0;
        public static bool IsMultipleOf(this short number, short value) => number % value == 0;
        public static bool IsMultipleOf(this long number, long value) => number % value == 0L;
    }
}
