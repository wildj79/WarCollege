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
using WarCollege.Domain;

namespace WarCollege.Model
{
    /// <summary>
    /// Represents a Battletech affiliation.
    /// </summary>
    public class Affiliation : Model<Guid>, IEquatable<Affiliation>, IComparable<Affiliation>
    {
        #region Fields

        private string _description;
        private int _experienceCost;
        private string _primaryLanguage;
        private Affiliation _parent;
        private ObservableCollection<string> _secondaryLanguages;
        private ObservableCollection<ExperienceAllotment> _fixedExperiencePoints;
        private ObservableCollection<ExperienceAllotment> _flexibleExperiencePoints;

        #endregion

        #region Properties

        /// <summary>
        /// A brief description of the affilialtion.
        /// </summary>
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
        /// The amount of experience it costs to join this affiliation.
        /// </summary>
        public int ExperienceCost
        {
            get => _experienceCost;
            set
            {
                if (_experienceCost != value)
                {
                    _experienceCost = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// This affiliations main faction. Pertains to sub affiliations.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Every main faction has as series of sub factions within it. Instead of keeping
        /// a list of every possible sub affiliation, I think it is easier to have a seperate
        /// instance for each, and then just store the parent of this sub affiliation here.
        /// </para>
        /// <para>
        /// This will be <c>null</c> if this is a main affiliation.
        /// </para>
        /// </remarks>
        public Affiliation Parent
        {
            get => _parent;
            set
            {
                if (_parent != value)
                {
                    _parent = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// The primary languge spoken in this affiliation.
        /// </summary>
        /// <remarks>
        /// Every faction seems to only have one primary language.
        /// </remarks>
        public string PrimaryLanguage
        {
            get => _primaryLanguage;
            set
            {
                if (_primaryLanguage != value)
                {
                    _primaryLanguage = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// A collection of secondary languages that are spoken in this affilitaion.
        /// </summary>
        public ObservableCollection<string> SecondaryLanguages
        {
            get => _secondaryLanguages;
            set
            {
                if (_secondaryLanguages != value)
                {
                    _secondaryLanguages = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// A collection of fixed experience points that are alloted when a character
        /// joins this affiliation.
        /// </summary>
        /// <remarks>
        /// This is subject to change. I haven't finalized how I'm going to handle these yet.
        /// </remarks>
        public ObservableCollection<ExperienceAllotment> FixedExperiencePoints
        {
            get => _fixedExperiencePoints;
            set
            {
                if (_fixedExperiencePoints != value)
                {
                    _fixedExperiencePoints = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// A collection of flexible experience points that are alloted when a character
        /// joins this faction.
        /// </summary>
        /// <remarks>
        /// This will most likely change. I haven't finalized how I'm going to handle this yet.
        /// </remarks>
        public ObservableCollection<ExperienceAllotment> FlexibleExperiencePoints
        {
            get => _flexibleExperiencePoints;
            set
            {
                if (_flexibleExperiencePoints != value)
                {
                    _flexibleExperiencePoints = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Ctor

        public Affiliation()
        {
            SecondaryLanguages = new ObservableCollection<string>();
            FixedExperiencePoints = new ObservableCollection<ExperienceAllotment>();
            FlexibleExperiencePoints = new ObservableCollection<ExperienceAllotment>();
        }

        #endregion

        #region IEquatable<Affiliation> implementation

        /// <summary>
        /// Checks equallity of two affiliations.
        /// </summary>
        /// <param name="other">The other affiliation to check.</param>
        /// <returns>Returns <c>true</c> if the two affiliations are the same.</returns>
        public bool Equals(Affiliation other)
        {
            if (other == null)
            {
                return false;
            }

            return other.Id == Id;
        }

		#endregion

		#region IComparable<Affiliation> implementation

        /// <summary>
        /// Compares two affiliations.
        /// </summary>
        /// <param name="other">The other affiliation to compare.</param>
        /// <returns>
        /// Returns 1, -1, or 0 depending if the other affilations name comes before, after, or is the same 
        /// as this affiliation.
        /// </returns>
		public int CompareTo(Affiliation other)
		{
            return string.Compare(Name, other.Name, StringComparison.CurrentCulture);
		}

        #endregion

        #region Methods

        /// <summary>
        /// Override for <see cref="Object.Equals(object)"/>.
        /// </summary>
        /// <param name="obj">The other object to check.</param>
        /// <returns>Returns <c>true</c> if the other obejct is equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Affiliation)
            {
                return Equals((Affiliation)obj);
            }

            return false;
        }

        /// <summary>
        /// Override for <see cref="Object.GetHashCode"/>
        /// </summary>
        /// <returns>Returns the hash code for this affiliation.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name} -> {Parent?.Name}";
        }

        #endregion

        #region Operator overloads

        /// <summary>
        /// Checks if two affiliations are equal.
        /// </summary>
        /// <param name="aff1">First affiliation to test.</param>
        /// <param name="aff2">Second affiliation to test.</param>
        /// <returns>Returns <c>true</c> if both affiliations are equal.</returns>
        /// <remarks>Operator override.</remarks>
        public static bool operator == (Affiliation aff1, Affiliation aff2)
        {
            if (ReferenceEquals(aff1, null) || ReferenceEquals(aff2, null))
                return false;

            return aff1.Equals(aff2);
        }

        /// <summary>
        /// Checks if two affiliations are not equal.
        /// </summary>
        /// <param name="aff1">First affiliation to test.</param>
        /// <param name="aff2">Second affiliation to test.</param>
        /// <returns>Returns <c>true</c> if the two affiliations are not equal.</returns>
        /// <remarks>Operator override.</remarks>
        public static bool operator != (Affiliation aff1, Affiliation aff2)
        {
            return !(aff1 == aff2);
        }

        #endregion
    }
}
