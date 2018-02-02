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

namespace WarCollege.Model
{
    /// <summary>
    /// Represents a trait that a character can posses. These include traits associated
    /// with any combat vehicles the charater might posses.
    /// </summary>
    /// <remarks>
    /// Page Referneces:
    /// <list type="bullet">
    /// <item><description>Traits p. 106-135 AToW</description></item>
    /// </list>
    /// </remarks>
    public class Trait : Model<Guid>
    {
        #region Fields

        private string _pageReference;
        private ExperiencePoints _experience;
        private string _description;
        private CharacterTraitType _traitType;
        private bool _isVariable;
        private IList<int> _allowedTraitPoints;
        private int _minimumLevel;
        private int _maximumLevel;

        #endregion

        #region Properties

        public int MinimumLevel
        {
            get => _minimumLevel;
            set
            {
                if (_minimumLevel != value)
                {
                    _minimumLevel = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int MaximumLevel
        {
            get => _maximumLevel;
            set
            {
                if (_maximumLevel != value)
                {
                    _maximumLevel = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Is this trait a variable-level trait?
        /// </summary>
        public bool IsVariable
        {
            get => _isVariable;
            set
            {
                if (_isVariable != value)
                {
                    _isVariable = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// The value of the trait.
        /// </summary>
        /// <remarks>
        /// This value is derived form the total alloted experinece points.
        /// </remarks>
        /// <value>The trait points.</value>
        public int Level
        {
            get => CalcualteCurrentTraitPoints();
        }

        public IList<int> AllowedTriatPoints
        {
            get => _allowedTraitPoints;
            set
            {
                if (_allowedTraitPoints != value)
                {
                    _allowedTraitPoints = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// The book and page number reference where the trait is listed.
        /// </summary>
        /// <value>The page reference.</value>
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

        /// <summary>
        /// Experience points allocated to this trait.
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
        /// Brief description of the trait and what it does.
        /// </summary>
        /// <value>The description.</value>
        /// <remarks>
        /// Used mostly in tooltips and other informational screens. Not to interested in
        /// all of the game rules, mostly just a quick sysnopsis of what the trait is
        /// and what it does.
        /// </remarks>
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

		/// <summary>
		/// The type of trait this is.
		/// </summary>
		/// <value>The type of the trait.</value>
		/// <remarks>
		/// <para>
		/// A trait can be of multiple types. The possible types are:
		/// <list type="bullet">
		/// <item><description>Nuetral</description></item>
		/// <item><description>Positive</description></item>
		/// <item><description>Negative</description></item>
		/// <item><description>Flexible</description></item>
		/// <item><description>Character</description></item>
		/// <item><description>Vehicle</description></item>
		/// <item><description>Identity</description></item>
		/// </list>
		/// </para>
        /// <para>
        /// It is possible for a trait to be up to 3 of those at once. For instance,
        /// a trait can be of type Positive, Character, and Identity. It is possible to
        /// do this by ORing the values together, like this:
        /// <code>
        /// Trait myTrait = new Trait();
        /// myTrait.TraitType = CharacterTraitType.Positive | CharacterTraitType.Character | CharacterTraitType.Identity;
        /// </code>
        /// You can then tell if a variable is of a trait type by using the <see cref="Enum.HasFlag(Enum)"/> method on the variable.
        /// <code>
        /// if (myTrait.TraitType.HasFlag(CharacterTraitType.Positive))
        /// {
        ///     // Do something if it has this flag.
        /// }
        /// </code>
        /// <seealso cref="CharacterTraitType"/>
        /// </para>
		/// </remarks>
		public CharacterTraitType TraitType
        {
            get { return _traitType; }
            set
            {
                if (_traitType != value)
                {
                    _traitType = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Ctor

        public Trait()
        {
            Experience = new ExperiencePoints();
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{Name} -> Level: {CalcualteCurrentTraitPoints()}";
        }

        /// <summary>
        /// Calculates the current trait point total.
        /// </summary>
        /// <returns>The current trait point value as an integer.</returns>
        private int CalcualteCurrentTraitPoints()
        {
            int retval = 0;

            if (Experience.TotalExperience.IsNegative())
            {
                if (Experience.TotalExperience.IsMultipleOf(100))
                {
                    Experience.CurrentExperience = Experience.TotalExperience + 100;
                }

                retval = (int)Math.Ceiling(Experience.TotalExperience / 100D);
            }
            else
            {
                if (Experience.TotalExperience.IsMultipleOf(100))
                {
                    Experience.CurrentExperience = Experience.TotalExperience - 100;
                }

                retval = (int)Math.Floor(Experience.TotalExperience / 100D);
            }

            if (retval < MinimumLevel)
                return 0;
            if (retval > MaximumLevel)
                return MaximumLevel;

            return retval;
        }

        #endregion
    }
}
