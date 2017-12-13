// CharacterTests.cs
//
// Author:
//       James Allred <wildj79@gmail.com>
//
// Copyright (c) 2017 James Allred
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using WarCollege.Model;
using Xunit;

namespace WarCollege.Tests
{
    public class CharacterTests
    {
        Character character;

        public CharacterTests()
        {
            character = new Character()
            {
                PlayerName = "James",
                HairColor = "Blond",
                EyeColor = "Hazel",
                Weight = 104.3f,
                Height = 170.688f,
                Age = 37,
                Experience = new ExperiencePoints(5000),
                Description = "It's me",
                Notes = "Random random random",
                CBills = 1000f,
                Id = Guid.NewGuid(),
                Name = "Some Dude"
            };

            var aff = new Affiliation()
            {
                Description = "",
                ExperienceCost = 150,
                Id = Guid.NewGuid(),
                Name = "Marik Commonwealth",
                Parent = new Affiliation()
                {
                    Description = "",
                    Id = Guid.NewGuid(),
                    Name = "Free Worlds League",
                    PrimaryLanguage = "English",
                    SecondaryLanguages = new System.Collections.ObjectModel.ObservableCollection<string>()
                    {
                        "Greek",
                        "Hindi",
                        "Itailian",
                        "Mandarin",
                        "Mongolian",
                        "Romanian",
                        "Slovak",
                        "Spanish",
                        "Urdu"
                    },
                    ExperienceCost = 0,
                    FixedExperiencePoints = new System.Collections.ObjectModel.ObservableCollection<Domain.ExperienceAllotment>()
                    {
                        new Domain.ExperienceAllotment("Skill", "Language/Any Secondary", 15),
                        new Domain.ExperienceAllotment("Skill", "Art/Any", 10)
                    }
                },
                FixedExperiencePoints = new System.Collections.ObjectModel.ObservableCollection<Domain.ExperienceAllotment>()
                {
                    new Domain.ExperienceAllotment("Trait", "Wealth", 100),
                    new Domain.ExperienceAllotment("Trait", "Equipped", 100),
                    new Domain.ExperienceAllotment("Trait", "Reputation", -100),
                    new Domain.ExperienceAllotment("Skill", "Appraisal", 5),
                    new Domain.ExperienceAllotment("Skill", "Negotiation", 10),
                    new Domain.ExperienceAllotment("Skill", "Protocol/Free Worlds", 10)
                }
            };

            character.Affiliation = aff;

            var str = new CharacterAttribute()
            {
                Id = Guid.NewGuid(),
                Abbreviation = "STR",
                Description = "",
                Experience = new ExperiencePoints(425),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 8,
                Name = "Streangth",
                PhenotypeModifier = 0
            };

            var bod = new CharacterAttribute()
            {
                Id = Guid.NewGuid(),
                Abbreviation = "BOD",
                Description = "",
                Experience = new ExperiencePoints(300),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 8,
                Name = "Body",
                PhenotypeModifier = 0
            };

            var dex = new CharacterAttribute()
            {
                Id = Guid.NewGuid(),
                Abbreviation = "DEX",
                Description = "",
                Experience = new ExperiencePoints(515),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 8,
                Name = "Dexterity",
                PhenotypeModifier = 0
            };

            var rfl = new CharacterAttribute()
            {
                Id = Guid.NewGuid(),
                Abbreviation = "RFL",
                Description = "",
                Experience = new ExperiencePoints(450),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 8,
                Name = "Reflexes",
                PhenotypeModifier = 0
            };


            var @int = new CharacterAttribute()
            {
                Id = Guid.NewGuid(),
                Abbreviation = "INT",
                Description = "",
                Experience = new ExperiencePoints(325),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 8,
                Name = "Inteligence",
                PhenotypeModifier = 0
            };

            var wil = new CharacterAttribute()
            {
                Id = Guid.NewGuid(),
                Abbreviation = "WIL",
                Description = "",
                Experience = new ExperiencePoints(430),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 8,
                Name = "Willpower",
                PhenotypeModifier = 0
            };
            
            var cha = new CharacterAttribute()
            {
                Id = Guid.NewGuid(),
                Abbreviation = "CHA",
                Description = "",
                Experience = new ExperiencePoints(260),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 8,
                Name = "Charisma",
                PhenotypeModifier = 0
            };

            var edg = new CharacterAttribute()
            {
                Id = Guid.NewGuid(),
                Abbreviation = "EDG",
                Description = "",
                Experience = new ExperiencePoints(125),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 8,
                Name = "Edge",
                PhenotypeModifier = 0
            };

            character.Attributes.Add(str);
            character.Attributes.Add(bod);
            character.Attributes.Add(dex);
            character.Attributes.Add(rfl);
            character.Attributes.Add(@int);
            character.Attributes.Add(wil);
            character.Attributes.Add(cha);
            character.Attributes.Add(edg);

            var trait = new Trait()
            {
                Id = Guid.NewGuid(),
                Description = "",
                Name = "Fit",
                PageReference = "AToW p. 117",
                TraitType = CharacterTraitType.Character,
                Experience = new ExperiencePoints(200)
            };

            character.Traits.Add(trait);

            var skill = new Skill()
            {
                Character = character,
                ComplexityRating = "SB",
                Description = "",
                Experience = new ExperiencePoints(30),
                Id = Guid.NewGuid(),
                IsTiered = false,
                Name = "Archery",
                PageReference = "AToW p.143",
                Specialty = "",
                SubSkill = "",
                TargetNumber = 7,
            };

            skill.LinkedAttributes.Add(dex);

            character.Skills.Add(skill);

            character.Phenotype = new Phenotype()
            {
                Id = Guid.NewGuid(),
                Name = "Normal Human",
                FieldAptitude = ""
            };

            character.Phenotype.AttributeMaximums.Add("STR", 8);
            character.Phenotype.AttributeMaximums.Add("BOD", 8);
            character.Phenotype.AttributeMaximums.Add("DEX", 8);
            character.Phenotype.AttributeMaximums.Add("RFL", 8);
            character.Phenotype.AttributeMaximums.Add("INT", 8);
            character.Phenotype.AttributeMaximums.Add("WIL", 8);
            character.Phenotype.AttributeMaximums.Add("CHA", 9);
            character.Phenotype.AttributeMaximums.Add("EDG", 9);

            character.Phenotype.AttributeModifiers.Add("STR", 0);
            character.Phenotype.AttributeModifiers.Add("BOD", 0);
            character.Phenotype.AttributeModifiers.Add("DEX", 0);
            character.Phenotype.AttributeModifiers.Add("RFL", 0);
            character.Phenotype.AttributeModifiers.Add("INT", 0);
            character.Phenotype.AttributeModifiers.Add("WIL", 0);
            character.Phenotype.AttributeModifiers.Add("CHA", 0);
            character.Phenotype.AttributeModifiers.Add("EDG", 0);
        }

        [Fact(DisplayName = "Does Have Trait")]
        public void DoesHaveTrait()
        {
            Assert.True(character.HasTrait("Fit"));
        }

        [Fact(DisplayName = "Does Not Have Trait")]
        public void DoesNotHaveTrait()
        {
            Assert.False(character.HasTrait("Poor Vision"));
        }

        [Fact(DisplayName = "Does Have Skill")]
        public void DoesHaveSkill()
        {
            Assert.True(character.HasSkill("Archery"));
        }

        [Fact(DisplayName = "Does Not Have Skill")]
        public void DoesNotHaveSkill()
        {
            Assert.False(character.HasSkill("Running"));
        }

        [Fact(DisplayName = "Is In Affiliation")]
        public void IsInAffiliation()
        {
            Assert.True(character.IsInAffiliation("Free Worlds League"));
            Assert.True(character.IsInAffiliation("Marik Commonwealth"));
        }

        [Fact(DisplayName = "Is Not In Affiliation")]
        public void IsNotInAffiliation()
        {
            Assert.False(character.IsInAffiliation("Lyran Alliance"));
        }

        [Fact(DisplayName = "Is RaisePropertyChagned Called")]
        public void IsPropertyChagnedRaised()
        {
            Assert.PropertyChanged(character, nameof(Character.Age), () => character.Age = 22);
            Assert.PropertyChanged(character, nameof(Character.CBills), () => character.CBills = 100000f);
            Assert.PropertyChanged(character, nameof(Character.Description), () => character.Description = "This is a description");
            Assert.PropertyChanged(character, nameof(Character.EyeColor), () => character.EyeColor = "Blue");
            Assert.PropertyChanged(character, nameof(Character.HairColor), () => character.HairColor = "White");
            Assert.PropertyChanged(character, nameof(Character.Height), () => character.Height = 4f);
            Assert.PropertyChanged(character, nameof(Character.Name), () => character.Name = "Jim");
            Assert.PropertyChanged(character, nameof(Character.Notes), () => character.Notes = "Some notes that should be different");
            Assert.PropertyChanged(character, nameof(Character.PlayerName), () => character.PlayerName = "Jim");
            Assert.PropertyChanged(character, nameof(Character.Weight), () => character.Weight = 185f);
        }
    }
}
