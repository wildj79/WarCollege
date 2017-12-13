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
