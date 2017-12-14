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
using WarCollege.Model;
using Xunit;

namespace WarCollege.Tests
{
    public class CharacterAttributeTests
    {
        [Theory(DisplayName = "Calculate Score Correctly")]
        [InlineData(20)]
        [InlineData(100)]
        [InlineData(-125)]
        [InlineData(1000)]
        public void CalculatesScoreCorrectly(int experience)
        {
            var att = new CharacterAttribute()
            {
                Abbreviation = "STR",
                Description = "",
                Experience = new ExperiencePoints(100),
                Id = Guid.NewGuid(),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 8,
                Name = "Stength",
                PhenotypeModifier = 0
            };

            int initialScore = att.Score;
            att.Experience.AddExperience(experience);

            int testScore = Math.Min(att.MaximumScoreAllowed, (int)Math.Floor((100 + experience) / 100D));

            Assert.Equal(1, initialScore);
            Assert.Equal(testScore, att.Score);
        }

        [Theory(DisplayName = "Calculate Experience Correctly")]
        [InlineData(20)]
        [InlineData(100)]
        [InlineData(-125)]
        public void CalculateExperienceCorrectly(int experince)
        {
            var att = new CharacterAttribute()
            {
                Abbreviation = "STR",
                Description = "",
                Experience = new ExperiencePoints(100),
                Id = Guid.NewGuid(),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 8,
                Name = "Stength",
                PhenotypeModifier = 0
            };

            int score = att.Score;
            Assert.Equal(1, score);
            Assert.Equal(0, att.Experience.CurrentExperience);

            att.Experience.AddExperience(experince);
            score = att.Score;

            int expectedCurrentExperience = experince.IsMultipleOf(100) ? att.Experience.TotalExperience - 100 : experince;

            Assert.Equal(100 + experince, att.Experience.TotalExperience);
            Assert.Equal(expectedCurrentExperience, att.Experience.CurrentExperience);
        }
    }
}
