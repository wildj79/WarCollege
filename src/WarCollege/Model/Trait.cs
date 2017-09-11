// CharacterTrait.cs
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class Trait : ModelBase
    {
        #region Fields

        private int _traitPoints;
        private string _pageReference;
        private int _experience;
        private string _description;
        private CharacterTraitType _traitType;

        #endregion

        #region Properties

        /// <summary>
        /// The value of the trait.
        /// </summary>
        /// <value>The trait points.</value>
        public int TraitPoints
        {
            get { return _traitPoints; }
            set
            {
                if (_traitPoints != value)
                {
                    _traitPoints = value;
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
                if (!_pageReference.Equals(value))
                {
                    _pageReference = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// The number of experience points allocated to the trait.
        /// </summary>
        /// <value>The experience.</value>
        public int Experience
        {
            get { return _experience; }
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
                if (!_description.Equals(value))
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
        /// CharacterTrait myTrait = new CharacterTrait();
        /// myTrait.TraitType = CharacterTraitType.Positive | CharacterTraitType.Character | CharacterTraitType.Identity;
        /// </code>
        /// You can then tell if a variable is of a trait type by using the <see cref="Enum.HasFlag(Enum)"/> method on the variable.
        /// <code>
        /// if (myTrait.TraitType.HasFlag(CharacterTraitType.Positive))
        /// {
        ///     // Do something if it has this flag.
        /// }
        /// </code>
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
    }
}
