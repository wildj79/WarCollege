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

using WarCollege.Model;
using Xunit;

namespace WarCollege.Tests
{
    public class ExperienceTests
    {
        const int Seed = 100;

        [Theory]
        [InlineData(20)]
        [InlineData(-20)]
        [InlineData(10)]
        [InlineData(-10)]
        [InlineData(100)]
        [InlineData(-100)]
        public void IsAmountAdded(int value)
        {
            var experience = new ExperiencePoints(Seed);
            experience.AddExperience(value);

            Assert.Equal(Seed + value, experience.TotalExperience);
            Assert.Equal(Seed + value, experience.CurrentExperience);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(-20)]
        [InlineData(10)]
        [InlineData(-10)]
        [InlineData(100)]
        [InlineData(-100)]
        public void IsPropertyChangedRaised(int value)
        {
            var experience = new ExperiencePoints(Seed);

            Assert.PropertyChanged(experience, nameof(ExperiencePoints.TotalExperience), () => experience.AddExperience(value));
            Assert.PropertyChanged(experience, nameof(ExperiencePoints.CurrentExperience), () => experience.AddExperience(value));
        }
    }
}
