// Skill.cs
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private int _totalExperience;
        private int _currentExperience;
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
                if (!_complexityRating.Equals(value))
                {
                    _complexityRating = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Total experience allocated to this skill.
        /// </summary>
        public int TotalExperience
        {
            get => _totalExperience;
            private set
            {
                if (_totalExperience != value)
                {
                    _totalExperience = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(Level));
                }
            }
        }

        /// <summary>
        /// This is the current experience points allocated to this skill 
        /// after determining the current level.
        /// </summary>
        public int CurrentExperience
        {
            get => _currentExperience;
            private set
            {
                if (_currentExperience != value)
                {
                    _currentExperience = value;
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
                if (!_specialty.Equals(value))
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
                if (!_subSkill.Equals(value))
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
                if (!_pageReference.Equals(value))
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
                if (!_description.Equals(value))
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

        #region Methods

        private int GetCurrentLevel()
        {
            if (Character.HasTrait("Fast Learner"))
            {
                if (TotalExperience >= 16 && TotalExperience < 24)
                {
                    CurrentExperience = CurrentExperience - (24 - 16);
                    CurrentExperience = TotalExperience - 16;
                    return 0;
                }
                else if (TotalExperience >= 24 && TotalExperience < 40)
                {
                    CurrentExperience = TotalExperience - 24;
                    return 1;
                }
                else if (TotalExperience >= 40 && TotalExperience < 64)
                {
                    CurrentExperience = TotalExperience - 40;
                    return 2;
                }
                else if (TotalExperience >= 64 && TotalExperience < 96)
                {
                    CurrentExperience = TotalExperience - 64;
                    return 3;
                }
                else if (TotalExperience >= 96 && TotalExperience < 136)
                {
                    CurrentExperience = TotalExperience - 96;
                    return 4;
                }
                else if (TotalExperience >= 136 && TotalExperience < 184)
                {
                    CurrentExperience = TotalExperience - 136;
                    return 5;
                }
                else if (TotalExperience >= 184 && TotalExperience < 240)
                {
                    CurrentExperience = TotalExperience - 184;
                    return 6;
                }
                else if (TotalExperience >= 240 && TotalExperience < 304)
                {
                    CurrentExperience = TotalExperience - 240;
                    return 7;
                }
                else if (TotalExperience >= 304 && TotalExperience < 376)
                {
                    CurrentExperience = TotalExperience - 304;
                    return 8;
                }
                else if (TotalExperience >= 376 && TotalExperience < 456)
                {
                    CurrentExperience = TotalExperience - 376;
                    return 9;
                }
                else if (TotalExperience >= 456)
                {
                    // Skill is maxed out.
                    CurrentExperience = 0;
                    return 10;
                }
                else
                {
                    return -1;
                }
            }
            else if (Character.HasTrait("Slow Learner"))
            {
                if (TotalExperience >= 24 && TotalExperience < 36)
                {
                    CurrentExperience = TotalExperience - 24;
                    return 0;
                }
                else if (TotalExperience >= 36 && TotalExperience < 60)
                {
                    CurrentExperience = TotalExperience - 36;
                    return 1;
                }
                else if (TotalExperience >= 60 && TotalExperience < 96)
                {
                    CurrentExperience = TotalExperience - 60;
                    return 2;
                }
                else if (TotalExperience >= 96 && TotalExperience < 144)
                {
                    CurrentExperience = TotalExperience - 96;
                    return 3;
                }
                else if (TotalExperience >= 144 && TotalExperience < 204)
                {
                    CurrentExperience = TotalExperience - 144;
                    return 4;
                }
                else if (TotalExperience >= 204 && TotalExperience < 276)
                {
                    CurrentExperience = TotalExperience - 204;
                    return 5;
                }
                else if (TotalExperience >= 276 && TotalExperience < 360)
                {
                    CurrentExperience = TotalExperience - 276;
                    return 6;
                }
                else if (TotalExperience >= 360 && TotalExperience < 456)
                {
                    CurrentExperience = TotalExperience - 360;
                    return 7;
                }
                else if (TotalExperience >= 456 && TotalExperience < 564)
                {
                    CurrentExperience = TotalExperience - 456;
                    return 8;
                }
                else if (TotalExperience >= 564 && TotalExperience < 684)
                {
                    CurrentExperience = TotalExperience - 564;
                    return 9;
                }
                else if (TotalExperience >= 684)
                {
                    // Skill is maxed out.
                    CurrentExperience = 0;
                    return 10;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (TotalExperience >= 20 && TotalExperience < 30)
                {
                    CurrentExperience = TotalExperience - 20;
                    return 0;
                }
                else if (TotalExperience >= 30 && TotalExperience < 50)
                {
                    CurrentExperience = TotalExperience - 30;
                    return 1;
                }
                else if (TotalExperience >= 50 && TotalExperience < 80)
                {
                    CurrentExperience = TotalExperience - 50;
                    return 2;
                }
                else if (TotalExperience >= 80 && TotalExperience < 120)
                {
                    CurrentExperience = TotalExperience - 80;
                    return 3;
                }
                else if (TotalExperience >= 120 && TotalExperience < 170)
                {
                    CurrentExperience = TotalExperience - 120;
                    return 4;
                }
                else if (TotalExperience >= 170 && TotalExperience < 230)
                {
                    CurrentExperience = TotalExperience - 170;
                    return 5;
                }
                else if (TotalExperience >= 230 && TotalExperience < 300)
                {
                    CurrentExperience = TotalExperience - 230;
                    return 6;
                }
                else if (TotalExperience >= 300 && TotalExperience < 380)
                {
                    CurrentExperience = TotalExperience - 300;
                    return 7;
                }
                else if (TotalExperience >= 380 && TotalExperience < 470)
                {
                    CurrentExperience = TotalExperience - 380;
                    return 8;
                }
                else if (TotalExperience >= 470 && TotalExperience < 570)
                {
                    CurrentExperience = TotalExperience - 470;
                    return 9;
                }
                else if (TotalExperience >= 570)
                {
                    // Skil is maxed out.
                    CurrentExperience = 0;
                    return 10;
                }
                else
                {
                    return -1;
                }
            }
        }

        public void AddExperience(int experience)
        {
            TotalExperience += experience;
            CurrentExperience += experience;
        }

        #endregion
    }
}
