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
using System.Collections.ObjectModel;

namespace WarCollege.Model
{
    /// <summary>
    /// Represents a skill that a character can posses.
    /// </summary>
    /// <remarks>
    /// Page References:
    /// Skills p. 140 - 159
    /// </remarks>
    public class Skill : Model<Guid>
    {
        #region Constants

        /// <summary>
        /// This is the maximum value a skill level can obtain.
        /// </summary>
        public const int MAX_LEVEL = 10;

        #endregion

        #region Fields
        
        private int _targetNumber;
        private string _complexityRating;
        private ExperiencePoints _experience;
        private ObservableCollection<CharacterAttribute> _linkedAttributes;
        private string _specialty;
        private string _subSkill;
        private bool _isTiered;
        private string _pageReference;
        private string _description;
        private Character _character;

        #endregion

        #region Properties

        /// <summary>
        /// The skills level.
        /// </summary>
        /// <remarks>
        /// This value is added to a roll made for a skill check. Higher
        /// values are better than lower. The calculation of the value seems
        /// to follow this equation: <c>y = 5x^2 + 5x + 20</c> where x is 
        /// the skill level and y is the experience points.
        /// </remarks>
        public int Level
        {
            get => GetCurrentLevel();
        }

        /// <summary>
        /// Target number the player is trying roll when making a skill check based on this 
        /// skill.
        /// </summary>
        /// <remarks>
        /// If the roll plus the skill's level equal or excede this number, then the 
        /// skill check succeeded.
        /// </remarks>
        public int TargetNumber
        {
            get { return _targetNumber; }
            set
            {
                if (_targetNumber != value)
                {
                    _targetNumber = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Two letter code that signifies how involved the skill is in terms
        /// of physical action or concentration and training.
        /// </summary>
        /// <remarks>
        /// The code is composed of two parts, the action rating and the training rating. The
        /// action rating is either <em>Simple</em> or <em>Complex</em>. The traing rating can
        /// be either <em>Basic</em> or <em>Advanced</em>. You use the first letter of these
        /// ratings and combine them to produce the code. The possible codes are:
        /// <list type="bullet">
        /// <item><description>SB (Simple-Basic)</description></item>
        /// <item><description>SA (Simple-Advanced)</description></item>
        /// <item><description>CB (Complex-Basic)</description></item>
        /// <item><description>CA (Complex-Advanced)</description></item>
        /// </list>
        /// </remarks>
        public string ComplexityRating
        {
            get { return _complexityRating; }
            set
            {
                if (_complexityRating != value)
                {
                    _complexityRating = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Experience allocated to this skill.
        /// </summary>
        public ExperiencePoints Experience
        {
            get => _experience;
            set
            {
                if (_experience != value)
                {
                    _experience = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// List of character attributes linked to this skill.
        /// </summary>
        /// <remarks>
        /// Simple skills <see cref="ComplexityRating"/> have one linked attribute, while
        /// Advanced skills have two. Linked attributes may potentially provide either a possitive
        /// or negative modifer to the skill check roll, depending on how exceptionally good or bad
        /// the attribute is.
        /// </remarks>
        public ObservableCollection<CharacterAttribute> LinkedAttributes
        {
            get { return _linkedAttributes; }
            set
            {
                if (_linkedAttributes != value)
                {
                    _linkedAttributes = value;
                    RaisePropertyChanged();
                }
            }
        }
        
        /// <summary>
        /// Represents an area of focus that a character has in a skill.
        /// </summary>
        /// <remarks>
        /// Specialties are open ended, meaing there are no predefined specialties for a given skill.
        /// When a specialty applies in a skill check, the character gets a bonus to the roll. On the 
        /// flip side, if the character uses a skill with a specialty where the specialty does not apply,
        /// then the character suffers a penalty to the roll.
        /// </remarks>
        public string Specialty
        {
            get { return _specialty; }
            set
            {
                if (_specialty != value)
                {
                    _specialty = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Indicates skills that are related, but are different enough to warrent a seperate skill.
        /// </summary>
        public string SubSkill
        {
            get { return _subSkill; }
            set
            {
                if (_subSkill != value)
                {
                    _subSkill = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Is this skill a tiered skill?
        /// </summary>
        /// <remarks>
        /// A tiered skill is both a Simple and a Complex skill. From skill levels 0 thru 3, a tiered skill
        /// is considered Simple. Skill levels 4 and up are considered Complex.
        /// </remarks>
        public bool IsTiered
        {
            get { return _isTiered; }
            set
            {
                if (_isTiered != value)
                {
                    _isTiered = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Book and page number where the rules for this skill can be found.
        /// </summary>
        public string PageReference
        {
            get { return _pageReference; }
            set
            {
                if (_pageReference != value)
                {
                    _pageReference = value;
                    RaisePropertyChanged();
                }
            }
        }

        // Note to contributors:
        // The intent of this property is to provide a quick synopsis of what a skill
        // is and what it does. It is *NOT* meant to supplant the rule book in anyway.
        // So, when creating the datafiles, I have intentionally tried to use my own
        // words as much as possible, and not copy descriptions verbatim from the rule
        // book. WarCollege is meant to suppliment the rule book, not replace it.
        /// <summary>
        /// Breif description for this skill.
        /// </summary>
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    RaisePropertyChanged();
                }
            }
        }

        public Character Character
        {
            get => _character;
            set
            {
                if (_character != value)
                {
                    _character = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Ctor

        public Skill()
        {
            Experience = new ExperiencePoints();
            LinkedAttributes = new ObservableCollection<CharacterAttribute>();
        }

        #endregion

        #region Methods

        private int GetCurrentLevel()
        {
            if (Character.HasTrait("Fast Learner"))
            {
                if (Experience.TotalExperience >= 16 && Experience.TotalExperience < 24)
                {
                    //Experience.CurrentExperience = Experience.CurrentExperience - (24 - 16);
                    Experience.CurrentExperience = Experience.TotalExperience - 16;
                    return 0;
                }
                else if (Experience.TotalExperience >= 24 && Experience.TotalExperience < 40)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 24;
                    return 1;
                }
                else if (Experience.TotalExperience >= 40 && Experience.TotalExperience < 64)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 40;
                    return 2;
                }
                else if (Experience.TotalExperience >= 64 && Experience.TotalExperience < 96)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 64;
                    return 3;
                }
                else if (Experience.TotalExperience >= 96 && Experience.TotalExperience < 136)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 96;
                    return 4;
                }
                else if (Experience.TotalExperience >= 136 && Experience.TotalExperience < 184)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 136;
                    return 5;
                }
                else if (Experience.TotalExperience >= 184 && Experience.TotalExperience < 240)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 184;
                    return 6;
                }
                else if (Experience.TotalExperience >= 240 && Experience.TotalExperience < 304)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 240;
                    return 7;
                }
                else if (Experience.TotalExperience >= 304 && Experience.TotalExperience < 376)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 304;
                    return 8;
                }
                else if (Experience.TotalExperience >= 376 && Experience.TotalExperience < 456)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 376;
                    return 9;
                }
                else if (Experience.TotalExperience >= 456)
                {
                    // Skill is maxed out.
                    Experience.CurrentExperience = 0;
                    return 10;
                }
                else
                {
                    return -1;
                }
            }
            else if (Character.HasTrait("Slow Learner"))
            {
                if (Experience.TotalExperience >= 24 && Experience.TotalExperience < 36)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 24;
                    return 0;
                }
                else if (Experience.TotalExperience >= 36 && Experience.TotalExperience < 60)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 36;
                    return 1;
                }
                else if (Experience.TotalExperience >= 60 && Experience.TotalExperience < 96)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 60;
                    return 2;
                }
                else if (Experience.TotalExperience >= 96 && Experience.TotalExperience < 144)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 96;
                    return 3;
                }
                else if (Experience.TotalExperience >= 144 && Experience.TotalExperience < 204)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 144;
                    return 4;
                }
                else if (Experience.TotalExperience >= 204 && Experience.TotalExperience < 276)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 204;
                    return 5;
                }
                else if (Experience.TotalExperience >= 276 && Experience.TotalExperience < 360)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 276;
                    return 6;
                }
                else if (Experience.TotalExperience >= 360 && Experience.TotalExperience < 456)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 360;
                    return 7;
                }
                else if (Experience.TotalExperience >= 456 && Experience.TotalExperience < 564)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 456;
                    return 8;
                }
                else if (Experience.TotalExperience >= 564 && Experience.TotalExperience < 684)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 564;
                    return 9;
                }
                else if (Experience.TotalExperience >= 684)
                {
                    // Skill is maxed out.
                    Experience.CurrentExperience = 0;
                    return 10;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (Experience.TotalExperience >= 20 && Experience.TotalExperience < 30)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 20;
                    return 0;
                }
                else if (Experience.TotalExperience >= 30 && Experience.TotalExperience < 50)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 30;
                    return 1;
                }
                else if (Experience.TotalExperience >= 50 && Experience.TotalExperience < 80)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 50;
                    return 2;
                }
                else if (Experience.TotalExperience >= 80 && Experience.TotalExperience < 120)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 80;
                    return 3;
                }
                else if (Experience.TotalExperience >= 120 && Experience.TotalExperience < 170)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 120;
                    return 4;
                }
                else if (Experience.TotalExperience >= 170 && Experience.TotalExperience < 230)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 170;
                    return 5;
                }
                else if (Experience.TotalExperience >= 230 && Experience.TotalExperience < 300)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 230;
                    return 6;
                }
                else if (Experience.TotalExperience >= 300 && Experience.TotalExperience < 380)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 300;
                    return 7;
                }
                else if (Experience.TotalExperience >= 380 && Experience.TotalExperience < 470)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 380;
                    return 8;
                }
                else if (Experience.TotalExperience >= 470 && Experience.TotalExperience < 570)
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 470;
                    return 9;
                }
                else if (Experience.TotalExperience >= 570)
                {
                    // Skil is maxed out.
                    Experience.CurrentExperience = 0;
                    return 10;
                }
                else
                {
                    return -1;
                }
            }
        }

        #endregion
    }
}
