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

        /// <summary>
        /// Checks to see if a short integer is a multiple of another number.
        /// </summary>
        /// <param name="number">Short to check.</param>
        /// <param name="value">Value to check against.</param>
        /// <returns><c>True</c> if the short integer is a multiple of value.</returns>
        public static bool IsMultipleOf(this short number, short value) => number % value == 0;

        /// <summary>
        /// Checks to see if a long integer is a multiple of another number.
        /// </summary>
        /// <param name="number">Long to check.</param>
        /// <param name="value">Value to check against.</param>
        /// <returns><c>True</c> if the long integer is a multiple of value.</returns>
        public static bool IsMultipleOf(this long number, long value) => number % value == 0L;

        /// <summary>
        /// Checks to see if a number is odd or not.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns><c>True</c> if the number is odd.</returns>
        public static bool IsOdd(this int number) => number % 2 == 1;

        /// <summary>
        /// Checks to see if a number is odd or not.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns><c>True</c> if the number is odd.</returns>
        public static bool IsOdd(this short number) => number % 2 == 1;

        /// <summary>
        /// Checks to see if a number is odd or not.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns><c>True</c> if the number is odd.</returns>
        public static bool IsOdd(this long number) => number % 2L == 1L;

        /// <summary>
        /// Checks to see if a number is even or not.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns><c>True</c> if the number is even.</returns>
        public static bool IsEven(this int number) => number % 2 == 0;

        /// <summary>
        /// Checks to see if a number is even or not.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns><c>True</c> if the number is even.</returns>
        public static bool IsEven(this short number) => number % 2 == 0;

        /// <summary>
        /// Checks to see if a number is even or not.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns><c>True</c> if the number is even.</returns>
        public static bool IsEven(this long number) => number % 2L == 0L;

        /// <summary>
        /// Compares two floating point values and determines if they are equal.
        /// </summary>
        /// <remarks>
        /// This method was derivied from this stackoverflow answer:
        /// <a href="https://stackoverflow.com/questions/3874627/floating-point-comparison-functions-for-c-sharp">
        /// Floating point comparison functions for C#
        /// </a>
        /// </remarks>
        /// <param name="a">Value we are testing</param>
        /// <param name="b">Value we are testing against</param>
        /// <param name="epsilon">A small floating point number used to determine the percision of the comparison.</param>
        /// <returns><c>True</c> if the two numbers are close enough to be considered equal</returns>
        public static bool NearlyEqual(this float a, float b, float epsilon)
        {
            const float normal = (1 << 23) * float.Epsilon;
            float absA = Math.Abs(a);
            float absB = Math.Abs(b);
            float diff = Math.Abs(a - b);

            if (a == b)
            {
                // Shortcut, handles infinities
                return true;
            }

            if (a == 0.0f || b == 0.0f || diff < normal)
            {
                // a or b is zero, or both are extremely close to it.
                // relative error is less meaningful here
                return diff < (epsilon * normal);
            }

            // use relative error
            return diff / Math.Min((absA + absB), float.MaxValue) < epsilon;
        }

        /// <summary>
        /// Compares two floating point values and determines if they are equal.
        /// </summary>
        /// <remarks>
        /// This method was derivied from this stackoverflow answer:
        /// <a href="https://stackoverflow.com/questions/3874627/floating-point-comparison-functions-for-c-sharp">
        /// Floating point comparison functions for C#
        /// </a>
        /// </remarks>
        /// <param name="a">Value we are testing</param>
        /// <param name="b">Value we are testing against</param>
        /// <returns><c>True</c> if the two numbers are close enough to be considered equal</returns>
        public static bool NearlyEqual(this float a, float b) => NearlyEqual(a, b, 0.00001f);

        public static bool NearlyEqual(this double a, double b, double epsilon)
        {
            const double normal = (1L << 52) * double.Epsilon;
            double absA = Math.Abs(a);
            double absB = Math.Abs(b);
            double diff = Math.Abs(a - b);

            if (a == b)
            {
                // Shortcut, handles infinities
                return true;
            }

            if (a == 0.0D || b == 0.0D || diff < normal)
            {
                // a or b is zero, or both are extremely close to it.
                // relative error is less meaningful here
                return diff < (epsilon * normal);
            }

            return diff / Math.Min((absA + absB), double.MaxValue) < epsilon;
        }

        public static bool NearlyEqual(this double a, double b) => NearlyEqual(a, b, EPSILON);
    }
}
