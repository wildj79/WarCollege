// CharacterAttribute.cs
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
using System.ComponentModel;

namespace WarCollege.Model
{
    /// <summary>
    /// Represents one character attribute.
    /// </summary>
    /// <remarks>
    /// <para>
    /// An attribute describes a charater's raw physical and mental capabilities.
    /// Each character has eight attributes.
    /// </para>
    /// <para>
    /// Possible values:
    /// <list type="bullet">
    /// <item><description>STR (Strength)</description></item>
    /// <item><description>BOD (Body)</description></item>
    /// <item><description>RFL (Reflexes)</description></item>
    /// <item><description>DEX (Dexterity)</description></item>
    /// <item><description>INT (Intelligence)</description></item>
    /// <item><description>WIL (Willpower)</description></item>
    /// <item><description>CHA (Charisma)</description></item>
    /// <item><description>EDG (Edge)</description></item>
    /// </list>
    /// </para>
    /// <para>
    /// Rules references:
    /// <list type="bullet">
    /// <item><description>Attributes p.34, AToW</description></item>
    /// <item><description>Character Advancement p.330, AToW</description></item>
    /// <item><description>Exceptional Attribute Trait p. 116, AToW</description></item>
    /// <item><description>Phenotype p.121, AToW</description></item>
    /// </list>
    /// </para>
    /// <para>
    /// This is not what I would prefer calling the class. I would prefer just <c>Attribute</c>,
    /// but the .NET framework includes an <c>Attribute</c> abstract class in the <c>System</c> namespace.
    /// So, to preclude any namespace conflicts, I've decieded to name this <c>CharacterAttribute</c>
    /// instead.
    /// </para>
    /// </remarks>
    public class CharacterAttribute : Model<Guid>
    {
        #region Fields

        private int _linkModifier;
        private ExperiencePoints _experience;
        private string _description;
        private string _abbreviation;
        private int _maximumScoreAllowed;
        private int _phenotypeModifier;
        private bool _isExceptionalAttribute;

        #endregion

        #region Properties

        /// <summary>
        /// The value used in gameplay for this attribute.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Derived from the XP alloted to the attribute. Can also be modified by character
        /// phenotype and aging affects.
        /// </para>
        /// <para>
        /// This is a calculated field, based on the amount of experiance allocated to the attribute.
        /// The calculation is: <c>Math.Min(MaximumScoreAllowed, (int)Math.Floor(Experience / 100.0D));</c>
        /// </para>
        /// </remarks>
        public int Score => CalculateScore();

        /// <summary>
        /// Modifier added to skills linked to this attribute.
        /// </summary>
        /// <remarks>
        /// Acts as a bonus to skill checks for skills linked to the attribute.
        /// </remarks>
        public int LinkModifier
        {
            get => _linkModifier;
            set
            {
                if (_linkModifier != value)
                {
                    _linkModifier = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Experience points allocated to this attribute.
        /// </summary>
        /// <remarks>
        /// Experience points are spent to increase the attributes score.
        /// 100 xp increases an attributes score by 1.
        /// </remarks>
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
        /// A description of what the attribute is.
        /// </summary>
        /// <remarks>
        /// Used in tooltips and whatnot for informational purposes.
        /// </remarks>
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Three letter abbreviation used to identify the attribute.
        /// </summary>
        public string Abbreviation
        {
            get => _abbreviation;
            set
            {
                if (_abbreviation != value)
                {
                    _abbreviation = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// The highest score that this attribute is allowed to obtain.
        /// </summary>
        /// <remarks>
        /// This is set depending on the characters phenotype and can be modified
        /// by and Exceptional Attribute Trait (p. 116, AToW)
        /// </remarks>
        public int MaximumScoreAllowed
        {
            get => _maximumScoreAllowed;
            set
            {
                if (_maximumScoreAllowed != value)
                {
                    _maximumScoreAllowed = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Modifier applied to the attribute score <em>after</em> character creation is finialized.
        /// </summary>
        /// <remarks>
        /// This represents a value that is added to the attribute score after characeter creation. 
        /// The value is derived from the characters phenotype.
        /// </remarks>
        public int PhenotypeModifier
        {
            get => _phenotypeModifier;
            set
            {
                if (_phenotypeModifier != value)
                {
                    _phenotypeModifier = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Determines if this trait is affected by an Exeptional Attribute Trait (p. 116, AToW).
        /// </summary>
        /// <value>Returns true if this attribute is linked to an Exceptional Attribute Trait.</value>
        public bool IsExceptionalAttribute
        {
            get => _isExceptionalAttribute;
            set
            {
                if (_isExceptionalAttribute != value)
                {
                    _isExceptionalAttribute = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of <see cref="CharacterAttribute"/>.
        /// </summary>
        public CharacterAttribute()
        {
            Experience = new ExperiencePoints();

            Experience.PropertyChanged += OnExperienceChanged;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calculates the current score for this attribute.
        /// </summary>
        /// <returns>The current attribute score as an <c>integer</c></returns>
        private int CalculateScore()
        {
            if (Experience.TotalExperience.IsMultipleOf(100))
            {
                Experience.CurrentExperience = Experience.TotalExperience - 100;
            }

            return Math.Min(MaximumScoreAllowed, (int)Math.Floor(Experience.TotalExperience / 100D));
        }

        private void OnExperienceChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(Score));
        }

        #endregion
    }
}
