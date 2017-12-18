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
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WarCollege.Model
{
    /// <summary>
    /// The chosen phenotype for a character.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Phenotype is technically a trait, but it is unique enough that it warrents its own
    /// class. Every character has a phenotype. But, unless your playing a clan character,
    /// it will more than likely be "Normal Human".
    /// </para>
    /// <para>
    /// In the core rules for A Time of War, there are four phenotypes: <em>Normal Human</em>,
    /// <em>Aerospace</em>, <em>Elemental</em>, and <em>MechWarrior</em>. The <em>Aerospace</em>,
    /// <em>Elemental</em>, and <em>MechWarrior</em> are only available to clan characters.
    /// </para>
    /// <para>
    /// Rules References:
    /// Phenotype Trait p.122, AToW
    /// </para>
    /// </remarks>
    public class Phenotype : Model<Guid>
    {
        #region Fields

        private IDictionary<string, int> _attributeModifiers = new Dictionary<string, int>();
        private IDictionary<string, int> _attributeMaximums = new Dictionary<string, int>();
        private ObservableCollection<Trait> _bonusTraits;
        private string _fieldAptitude;

        private static Phenotype _normalHuman;
        private static Phenotype _aerospace;
        private static Phenotype _elemental;
        private static Phenotype _mechWarrior;

		#endregion

		#region Properties

        /// <summary>
        /// Collection of key/value pairs used to map a modifier to a character attribute.
        /// </summary>
        public IDictionary<string, int> AttributeModifiers
        {
            get { return _attributeModifiers; }
            set
            {
                if (_attributeModifiers != value)
                {
                    _attributeModifiers = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Collection of key/value pairs used to map a maximum value to a character 
        /// attribute score.
        /// </summary>
        public IDictionary<string, int> AttributeMaximums
        {
            get { return _attributeMaximums; }
            set
            {
                if (_attributeMaximums != value)
                {
                    _attributeMaximums = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// List of bonus character traits assigned to a character with this
        /// phenotype.
        /// </summary>
        public ObservableCollection<Trait> BounusTraits
        {
            get { return _bonusTraits; }
            set
            {
                if (_bonusTraits != value)
                {
                    _bonusTraits = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Name of a skill field that characters with this phenotype have a
        /// strong aptitude in.
        /// </summary>
        /// <remarks>
        /// This applies a -1 TN modifier to all skills that are encompassed 
        /// by the skill field.
        /// </remarks>
        public string FieldAptitude
        {
            get { return _fieldAptitude; }
            set
            {
                if (_fieldAptitude != value)
                {
                    _fieldAptitude = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Represents a normal human character.
        /// </summary>
        /// <remarks>
        /// All Inner Sphere characters and free born Clan characters will have this Phenotype.
        /// </remarks>
        public static Phenotype NormalHuman
        {
            get
            {
                if (_normalHuman == null)
                {
                    _normalHuman = new Phenotype
                    {
                        Id = Guid.Parse("D1E98D1B-EDC7-4CB7-8E98-7D9270DC9934"),
                        Name = "Normal Human",
                        FieldAptitude = "",
                        AttributeMaximums =
                        {
                            { "STR", 8 },
                            { "BOD", 8 },
                            { "DEX", 8 },
                            { "RFL", 8 },
                            { "INT", 8 },
                            { "WIL", 8 },
                            { "CHA", 9 },
                            { "EDG", 9 }
                        },
                        AttributeModifiers =
                        {
                            { "STR", 0 },
                            { "BOD", 0 },
                            { "DEX", 0 },
                            { "RFL", 0 },
                            { "INT", 0 },
                            { "WIL", 0 },
                            { "CHA", 0 },
                            { "EDG", 0 }
                        }
                    };
                }

                return _normalHuman;
            }
        }

        /// <summary>
        /// Represents a True born warrior who was engineered to be an 
        /// aerospace pilot.
        /// </summary>
        /// <remarks>
        /// Only clan characters with the True born trait are allowed to take this Phenotype.
        /// </remarks>
        public static Phenotype Aerospace
        {
            get
            {
                if (_aerospace == null)
                {
                    _aerospace = new Phenotype
                    {
                        Id = Guid.Parse("366F5902-FFE2-4301-9D11-1AF920138C61"),
                        Name = "Aerospace",
                        FieldAptitude = "Clan Fighter Pilot",
                        AttributeMaximums =
                        {
                            { "STR", 7 },
                            { "BOD", 7 },
                            { "DEX", 9 },
                            { "RFL", 9 },
                            { "INT", 9 },
                            { "WIL", 8 },
                            { "CHA", 8 },
                            { "EDG", 8 }
                        },
                        AttributeModifiers =
                        {
                            { "STR", -1 },
                            { "BOD", -1 },
                            { "DEX", 2 },
                            { "RFL", 2 },
                            { "INT", 0 },
                            { "WIL", 0 },
                            { "CHA", 0 },
                            { "EDG", 0 }
                        },
                        BounusTraits =
                        {
                            new Trait
                            {
                                Name = "G-Tolernace",
                                Description = "Less affected by the stress of variable gravity conditions.",
                                Experience = new ExperiencePoints(100),
                                Id = Guid.Parse("DDB007A7-6F78-4651-B179-C76D42064652"),
                                PageReference = "p. 118",
                                TraitType = CharacterTraitType.Character | CharacterTraitType.Positive
                            },
                            new Trait
                            {
                                Name = "Glass Jaw",
                                Description = "More susceptible to personal injury.",
                                Experience = new ExperiencePoints(-300),
                                Id = Guid.Parse(""),
                                PageReference = "p. 118",
                                TraitType = CharacterTraitType.Negative | CharacterTraitType.Character | CharacterTraitType.Opposed
                            }
                        }
                    };
                }

                return _aerospace;
            }
        }

        /// <summary>
        /// Represents a True born warrior who was engineered to be an elemental.
        /// </summary>
        /// <remarks>
        /// Only clan characters with the True born trait are allowed to take this Phenotype.
        /// </remarks>
        public static Phenotype Elemental
        {
            get
            {
                if (_elemental == null)
                {
                    _elemental = new Phenotype
                    {
                        Id = Guid.Parse("61C817E5-1365-4955-B5A4-70576D3362CF"),
                        Name = "Elemental",
                        FieldAptitude = "Elemental",
                        AttributeMaximums =
                        {
                            { "STR", 9 },
                            { "BOD", 9 },
                            { "DEX", 7 },
                            { "RFL", 8 },
                            { "INT", 8 },
                            { "WIL", 9 },
                            { "CHA", 8 },
                            { "EDG", 8 }
                        },
                        AttributeModifiers =
                        {
                            { "STR", 2 },
                            { "BOD", 1 },
                            { "DEX", -1 },
                            { "RFL", 0 },
                            { "INT", 0 },
                            { "WIL", 0 },
                            { "CHA", 0 },
                            { "EDG", 0 }
                        },
                        BounusTraits =
                        {
                            new Trait
                            {
                                Name = "Toughness",
                                Description = "Less susceptible to personal injury",
                                Experience = new ExperiencePoints(300),
                                Id = Guid.Parse("76F55838-EF03-4ACF-9C0A-1B2272499BED"),
                                PageReference = "p. 127",
                                TraitType = CharacterTraitType.Character | CharacterTraitType.Positive | CharacterTraitType.Opposed
                            }
                        }
                    };
                }

                return _elemental;
            }
        }

        /// <summary>
        /// Represents a True born warrior who was engineered to be a MechWarrior.
        /// </summary>
        /// <remarks>
        /// Only clan characters with the True born trait are allowed to take this Phenotype.
        /// </remarks>
        public static Phenotype MechWarrior
        {
            get
            {
                if (_mechWarrior == null)
                {
                    _mechWarrior = new Phenotype
                    {
                        Id = Guid.Parse("B0644599-1FFC-4427-A24B-A8F806D3ABEC"),
                        Name = "MechWarrior",
                        FieldAptitude = "Clan MechWarrior",
                        AttributeMaximums =
                        {
                            { "STR", 8 },
                            { "BOD", 8 },
                            { "DEX", 9 },
                            { "RFL", 9 },
                            { "INT", 8 },
                            { "WIL", 8 },
                            { "CHA", 9 },
                            { "EDG", 8 }
                        },
                        AttributeModifiers =
                        {
                            { "STR", 0 },
                            { "BOD", 0 },
                            { "DEX", 1 },
                            { "RFL", 1 },
                            { "INT", 0 },
                            { "WIL", 0 },
                            { "CHA", 0 },
                            { "EDG", 0 }
                        }
                    };
                }

                return _mechWarrior;
            }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of <see cref="Phenotype"/>
        /// </summary>
        public Phenotype()
        {
            BounusTraits = new ObservableCollection<Trait>();
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion // Methods
    }
}
