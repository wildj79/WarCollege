using System;
using WarCollege.Model;
using Xunit;

namespace WarCollege.Tests
{
    public class AffiliationTests
    {
        private Affiliation SetupParent()
        {
            string parentIdString = "15C198F9-7EA0-4C80-93C7-13B1896FF946";
            var parent = new Affiliation()
            {
                Name = "Free Worlds League",
                Description = "",
                ExperienceCost = 150,
                Parent = null,
                PrimaryLanguage = "English"
            };

            parent.SecondaryLanguages.Add("Greek");
            parent.SecondaryLanguages.Add("Hindi");
            parent.SecondaryLanguages.Add("Italian");
            parent.SecondaryLanguages.Add("Mandarin");
            parent.SecondaryLanguages.Add("Mongolian");
            parent.SecondaryLanguages.Add("Romanian");
            parent.SecondaryLanguages.Add("Slovak");
            parent.SecondaryLanguages.Add("Spanish");
            parent.SecondaryLanguages.Add("Urdu");

            parent.FixedExperiencePoints.Add(new Domain.ExperienceAllotment("Skills", "Language/Any Secondary", 15));
            parent.FixedExperiencePoints.Add(new Domain.ExperienceAllotment("Skills", "Art/Any", 10));

            Guid.TryParse(parentIdString, out Guid parentId);
            parent.Id = parentId;

            return parent;
        }

        [Theory(DisplayName = "Are Affilations Equal")]
        [InlineData("96261710-C26B-444D-81AB-ABF0C44A0F46")]
        [InlineData("C527F3B1-8328-48D3-B657-5C6629720741")]
        public void AreAffiliationsEqual(string id)
        {
            var aff1 = new Affiliation();
            var aff2 = new Affiliation();

            aff1.Parent = aff2.Parent = SetupParent();


            Guid.TryParse(id, out Guid aff1Id);
            Guid.TryParse(id, out Guid aff2Id);

            aff1.Id = aff1Id;
            aff2.Id = aff2Id;

            Assert.Equal(aff1, aff2);
            Assert.Equal(aff2, aff1);
        }

        [Theory(DisplayName = "Compare Affiliations")]
        [InlineData("Marik Commonwealth")]
        [InlineData("Principality of Regulus")]
        [InlineData("Duchy of Oriente")]
        [InlineData("Duchy of Andurien")]
        [InlineData("Other FWL Worlds")]
        public void ComapreAffiliations(string name)
        {
            var aff1 = new Affiliation()
            {
                Id = Guid.NewGuid(),
                Description = "",
                ExperienceCost = 150,
                Name = "Marik Commonwealth",
                Parent = SetupParent(),
                PrimaryLanguage = "English"
            };

            var aff2 = new Affiliation()
            {
                Id = Guid.NewGuid(),
                Description = "",
                ExperienceCost = 150,
                Name = name,
                Parent = SetupParent(),
                PrimaryLanguage = "English"
            };

            Assert.Equal(string.Compare(aff1.Name, name, StringComparison.CurrentCulture), aff1.CompareTo(aff2));
        }

        [Theory(DisplayName = "Is RaisePropertyChagned Called")]
        [InlineData("This is a test", 125, "Spanish")]
        public void IsRaisePropertyChanged(string description, 
            int experienceCost, 
            string primaryLanguage)
        {
            var aff = new Affiliation()
            {
                Id = Guid.NewGuid(),
                Description = "",
                ExperienceCost = 150,
                Name = "Marik Commonwealth",
                Parent = SetupParent(),
                PrimaryLanguage = "English"
            };

            Assert.PropertyChanged(aff, "Description", () => aff.Description = description);
            Assert.PropertyChanged(aff, "ExperienceCost", () => aff.ExperienceCost = experienceCost);
            Assert.PropertyChanged(aff, "PrimaryLanguage", () => aff.PrimaryLanguage = primaryLanguage);
        }
    }
}
