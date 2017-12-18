using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarCollege.Model;

namespace WarCollege.Services
{
    public class CharacterInitializationService : ICharacterInitializationService
    {
        public Character IntializeCharacter(int initialExperiencePoints = 5000)
        {
            var character = new Character(initialExperiencePoints)
            {
                Id = Guid.NewGuid(),
                Phenotype = Phenotype.NormalHuman
            };

            var strength = new CharacterAttribute()
            {
                Abbreviation = "STR",
                Description = "How physically strong a character is.",
                Experience = new ExperiencePoints(0),
                Id = Guid.NewGuid(),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 8,
                Name = "Strength",
                PhenotypeModifier = 0
            };

            var body = new CharacterAttribute
            {
                Abbreviation = "BOD",
                Description = "How durable and \"In shape\" a character is.",
                Experience = new ExperiencePoints(0),
                Id = Guid.NewGuid(),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 8,
                Name = "Body",
                PhenotypeModifier = 0
            };

            var reflexes = new CharacterAttribute
            {
                Abbreviation = "RFL",
                Description = "How quick a character can respond to situations.",
                Experience = new ExperiencePoints(0),
                Id = Guid.NewGuid(),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 8,
                Name = "Reflexes",
                PhenotypeModifier = 0
            };

            var dexterity = new CharacterAttribute
            {
                Abbreviation = "DEX",
                Description = "How well a character can manipulate and handle objects.",
                Experience = new ExperiencePoints(0),
                Id = Guid.NewGuid(),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 8,
                Name = "Dexterity",
                PhenotypeModifier = 0
            };

            var intelligence = new CharacterAttribute
            {
                Abbreviation = "INT",
                Description = "How intelligent a character is.",
                Experience = new ExperiencePoints(0),
                Id = Guid.NewGuid(),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 8,
                Name = "Intelligence",
                PhenotypeModifier = 0
            };

            var willpower = new CharacterAttribute
            {
                Abbreviation = "WIL",
                Description = "How decisive a characte is.",
                Experience = new ExperiencePoints(0),
                Id = Guid.NewGuid(),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 8,
                Name = "Willpower",
                PhenotypeModifier = 0
            };

            var charisma = new CharacterAttribute
            {
                Abbreviation = "CHA",
                Description = "How inspiring a character is.",
                Experience = new ExperiencePoints(0),
                Id = Guid.NewGuid(),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 9,
                Name = "Charisma",
                PhenotypeModifier = 0
            };

            var edge = new CharacterAttribute
            {
                Abbreviation = "EDG",
                Description = "How lucky a character is.",
                Experience = new ExperiencePoints(0),
                Id = Guid.NewGuid(),
                IsExceptionalAttribute = false,
                LinkModifier = 0,
                MaximumScoreAllowed = 9,
                Name = "Edge",
                PhenotypeModifier = 0
            };

            character.Attributes.Add(strength);
            character.Attributes.Add(body);
            character.Attributes.Add(reflexes);
            character.Attributes.Add(dexterity);
            character.Attributes.Add(intelligence);
            character.Attributes.Add(willpower);
            character.Attributes.Add(charisma);
            character.Attributes.Add(edge);

            var english = new Skill
            {
                Character = character,
                ComplexityRating = "SA",
                Description = "The language you speak.",
                Experience = new ExperiencePoints(20),
                Id = Guid.Parse("DAB4BCD0-8C78-409A-B128-E93AC344591F"),
                IsTiered = false,
                LinkedAttributes =
                {
                    intelligence,
                    charisma
                },
                Name = "Language",
                PageReference = "p. 148",
                Specialty = "",
                SubSkill = "English",
                TargetNumber = 8
            };

            var perception = new Skill
            {
                Character = character,
                ComplexityRating = "SB",
                Description = "What you can see.",
                Experience = new ExperiencePoints(10),
                Id = Guid.Parse("83C2C195-74ED-43D1-821F-E2985687B8FE"),
                IsTiered = false,
                LinkedAttributes =
                {
                    intelligence
                },
                Name = "Perception",
                PageReference = "p. 151",
                Specialty = "",
                SubSkill = "",
                TargetNumber = 7
            };

            character.Skills.Add(english);
            character.Skills.Add(perception);

            return character;
        }
    }
}
