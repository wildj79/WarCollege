// War College - Copyright (c) 2017 James Allred (wildj79 at gmail dot com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this 
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge, 
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit 
// persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or 
// substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS 
// OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
// OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR 
// OTHER DEALINGS IN THE SOFTWARE.

using System;
using Xunit;
using WarCollege;

namespace WarCollege.Tests
{
    public class NumberTests
    {
        private void IsNearlyEqual(float a, float b)
        {
            Assert.True(a.NearlyEqual(b));
        }

        private void IsNearlyEqual(float a, float b, float epsilon)
        {
            Assert.True(a.NearlyEqual(b, epsilon));
        }

        private void IsNotNearlyEqual(float a, float b)
        {
            Assert.False(a.NearlyEqual(b));
        }

        private void IsNotNearlyEqual(float a, float b, float epsilon)
        {
            Assert.False(a.NearlyEqual(b, epsilon));
        }

        [Theory]
        [InlineData(1000000f, 1000001f)]
        [InlineData(1000001f, 1000000f)]
        public void AreBigFloatsNearlyEqual(float a, float b)
        {
            IsNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(10000f, 10001f)]
        [InlineData(10001f, 10000f)]
        public void AreBigFloatsNotNearlyEqual(float a, float b)
        {
            IsNotNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(-1000000f, -1000001f)]
        [InlineData(-1000001f, -1000000f)]
        public void AreBigNegativeFloatsNearlyEqual(float a, float b)
        {
            IsNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(-10000f, -10001f)]
        [InlineData(-10001f, -10000f)]
        public void AreBigNegativeFloatsNotNearlyEqual(float a, float b)
        {
            IsNotNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(1.0000001f, 1.0000002f)]
        [InlineData(1.0000002f, 1.0000001f)]
        public void AreNumbersAroundOneNearlyEqual(float a, float b)
        {
            IsNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(1.0002f, 1.0001f)]
        [InlineData(1.0001f, 1.0002f)]
        public void AreNumbersAroundOneNotNearlyEqual(float a, float b)
        {
            IsNotNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(-1.0000001f, -1.0000002f)]
        [InlineData(-1.0000002f, -1.0000001f)]
        public void AreNumbersAroundNegativeOneNearlyEqual(float a, float b)
        {
            IsNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(-1.0002f, -1.0001f)]
        [InlineData(-1.0001f, -1.0002f)]
        public void AreNumbersAroundNegativeOneNotNearlyEqual(float a, float b)
        {
            IsNotNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(0.000000001000001f, 0.000000001000002f)]
        [InlineData(0.000000001000002f, 0.000000001000001f)]
        public void AreSmallNumbersNearlyEqual(float a, float b)
        {
            IsNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(0.000000000001002f, 0.000000000001001f)]
        [InlineData(0.000000000001001f, 0.000000000001002f)]
        public void AreSmallNumbersNotNearlyEqual(float a, float b)
        {
            IsNotNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(-0.000000001000001f, -0.000000001000002f)]
        [InlineData(-0.000000001000002f, -0.000000001000001f)]
        public void AreNegativeSmallNumbersNearlyEqual(float a, float b)
        {
            IsNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(-0.000000000001002f, -0.000000000001001f)]
        [InlineData(-0.000000000001001f, -0.000000000001002f)]
        public void AreNegativeSmallNumbersNotNearlyEqual(float a, float b)
        {
            IsNotNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(0.3f, 0.30000003f)]
        [InlineData(-0.3f, -0.30000003f)]
        public void AreSmallDifferencesNearlyEqual(float a, float b)
        {
            IsNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(0.0f, 0.0f)]
        [InlineData(0.0f, -0.0f)]
        [InlineData(-0.0f, -0.0f)]
        public void AreZerosNearlyEqual(float a, float b)
        {
            IsNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(0.00000001f, 0.0f)]
        [InlineData(0.0f, 0.00000001f)]
        [InlineData(-0.00000001f, 0.0f)]
        [InlineData(0.0f, -0.00000001f)]
        public void AreZerosNotNearlyEqual(float a, float b)
        {
            IsNotNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(0.0f, 1e-40f, 0.01f)]
        [InlineData(1e-40f, 0.0f, 0.01f)]
        [InlineData(0.0f, -1e-40f, 0.1f)]
        [InlineData(-1e-40f, 0.0f, 0.1f)]
        public void AreZerosNearlyEqualWithEpsilon(float a, float b, float epsilon)
        {
            IsNearlyEqual(a, b, epsilon);
        }

        [Theory]
        [InlineData(1e-40f, 0.0f, 0.000001f)]
        [InlineData(0.0f, 1e-40f, 0.000001f)]
        [InlineData(-1e-40f, 0.0f, 0.00000001f)]
        [InlineData(0.0f, -1e-40f, 0.00000001f)]
        public void AreZerosNotNearlyEqualWithEpsilon(float a, float b, float epsilon)
        {
            IsNotNearlyEqual(a, b, epsilon);
        }

        [Fact]
        public void AreExtreameMaxValuesNearlyEqual()
        {
            IsNearlyEqual(float.MaxValue, float.MaxValue);
        }

        [Theory]
        [InlineData(float.MaxValue, -float.MaxValue)]
        [InlineData(-float.MaxValue, float.MaxValue)]
        [InlineData(float.MaxValue, float.MaxValue / 2)]
        [InlineData(float.MaxValue, -float.MaxValue / 2)]
        [InlineData(-float.MaxValue, float.MaxValue / 2)]
        public void AreExtremeMaxValuesNotNearlyEqual(float a, float b)
        {
            IsNotNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
        [InlineData(float.NegativeInfinity, float.NegativeInfinity)]
        public void AreInfinitiesNearlyEqual(float a, float b)
        {
            IsNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(float.NegativeInfinity, float.PositiveInfinity)]
        [InlineData(float.PositiveInfinity, float.MaxValue)]
        [InlineData(float.NegativeInfinity, -float.MaxValue)]
        public void AreInfinitiesNotNearlyEqual(float a, float b)
        {
            IsNotNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(float.NaN, float.NaN)]
        [InlineData(float.NaN, 0.0f)]
        [InlineData(-0.0f, float.NaN)]
        [InlineData(float.NaN, -0.0f)]
        [InlineData(0.0f, float.NaN)]
        [InlineData(float.NaN, float.PositiveInfinity)]
        [InlineData(float.PositiveInfinity, float.NaN)]
        [InlineData(float.NaN, float.NegativeInfinity)]
        [InlineData(float.NegativeInfinity, float.NaN)]
        [InlineData(float.NaN, float.MaxValue)]
        [InlineData(float.MaxValue, float.NaN)]
        [InlineData(float.NaN, -float.MaxValue)]
        [InlineData(-float.MaxValue, float.NaN)]
        [InlineData(float.NaN, float.MinValue)]
        [InlineData(float.MinValue, float.NaN)]
        [InlineData(float.NaN, -float.MinValue)]
        [InlineData(-float.MinValue, float.NaN)]
        [InlineData(float.NaN, float.Epsilon)]
        [InlineData(float.Epsilon, float.NaN)]
        [InlineData(float.NaN, -float.Epsilon)]
        [InlineData(-float.Epsilon, float.NaN)]
        public void AreNansNotNearlyEqual(float a, float b)
        {
            IsNotNearlyEqual(a, b);
        }

        [Fact]
        public void AreOppisitesNearlyEqual()
        {
            IsNearlyEqual(10 * float.Epsilon, 10 * -float.Epsilon);
        }

        [Theory]
        [InlineData(1.000000001f, -1.0f)]
        [InlineData(-1.0f, 1.000000001f)]
        [InlineData(-1.000000001f, 1.0f)]
        [InlineData(1.0f, -1.000000001f)]
        [InlineData(10000 * float.Epsilon, 10000 * -float.Epsilon)]
        public void AreOppisitesNotNearlyEqual(float a, float b)
        {
            IsNotNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(float.Epsilon, float.Epsilon)]
        [InlineData(float.Epsilon, -float.Epsilon)]
        [InlineData(-float.Epsilon, float.Epsilon)]
        [InlineData(float.Epsilon, 0)]
        [InlineData(0, float.Epsilon)]
        [InlineData(-float.Epsilon, 0)]
        [InlineData(0, -float.Epsilon)]
        public void AreNumbersVeryCloseToZeroNearlyEqual(float a, float b)
        {
            IsNearlyEqual(a, b);
        }

        [Theory]
        [InlineData(0.000000001f, -float.Epsilon)]
        [InlineData(0.000000001f,float.Epsilon)]
        [InlineData(float.Epsilon, 0.000000001f)]
        [InlineData(-float.Epsilon, 0.000000001f)]
        public void AreNumbersVeryCloseToZeroNotNearlyEqual(float a, float b)
        {
            IsNotNearlyEqual(a, b);
        }

        [Fact]
        public void IsIntegerNegative()
        {
            int number = -20;

            Assert.True(number.IsNegative());
        }

        [Fact]
        public void IsIntegerNotNegative()
        {
            int number = 20;

            Assert.False(number.IsNegative());
        }

        [Fact]
        public void IsFloatNegative()
        {
            float number = -20f;

            Assert.True(number.IsNegative());
        }

        [Fact]
        public void IsFloatNotNegative()
        {
            float number = 20f;

            Assert.False(number.IsNegative());
        }

        [Fact]
        public void IsShortNegative()
        {
            short number = -20;

            Assert.True(number.IsNegative());
        }

        [Fact]
        public void IsShortNotNegative()
        {
            short number = 20;

            Assert.False(number.IsNegative());
        }

        [Fact]
        public void IsLongNegative()
        {
            long number = -20L;

            Assert.True(number.IsNegative());
        }

        [Fact]
        public void IsLongNotNegative()
        {
            long number = 20L;

            Assert.False(number.IsNegative());
        }

        [Fact]
        public void IsDoubleNegative()
        {
            double number = -20D;

            Assert.True(number.IsNegative());
        }

        [Fact]
        public void IsDoubleNotNegative()
        {
            double number = 20D;

            Assert.False(number.IsNegative());
        }

        [Fact]
        public void IsDecimalNegative()
        {
            decimal number = -20m;

            Assert.True(number.IsNegative());
        }

        [Fact]
        public void IsDecimalNotNegative()
        {
            decimal number = 20m;

            Assert.False(number.IsNegative());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(100)]
        public void IsIntegerMultipleOf(int value)
        {
            int number = 500;

            Assert.True(number.IsMultipleOf(value));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(100)]
        public void IsShortMultipleOf(short value)
        {
            short number = 200;

            Assert.True(number.IsMultipleOf(value));
        }

        [Theory]
        [InlineData(5L)]
        [InlineData(10L)]
        [InlineData(100L)]
        public void IsLongMultipleOf(long value)
        {
            long number = 500L;

            Assert.True(number.IsMultipleOf(value));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void IsIntegerOdd(int value)
        {
            Assert.True(value.IsOdd());
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void IsShortOdd(short value)
        {
            Assert.True(value.IsOdd());
        }

        [Theory]
        [InlineData(3L)]
        [InlineData(5L)]
        [InlineData(7L)]
        public void IsLongOdd(long value)
        {
            Assert.True(value.IsOdd());
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(6)]
        public void IsInetegerEven(int value)
        {
            Assert.True(value.IsEven());
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(6)]
        public void IsShortEven(short value)
        {
            Assert.True(value.IsEven());
        }

        [Theory]
        [InlineData(2L)]
        [InlineData(4L)]
        [InlineData(6L)]
        public void IsLongEven(long value)
        {
            Assert.True(value.IsEven());
        }
    }
}
