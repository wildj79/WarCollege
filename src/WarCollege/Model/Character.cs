// Character.cs
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
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WarCollege.Model
{
    /// <summary>
    /// Represents an A Time of War character.
    /// </summary>
    /// <remarks>
    /// This is the main model for the program.
    /// </remarks>
    public class Character : ModelBase
    {
        #region Fields

        private string _playerName;
        private string _hairColor;
        private string _eyeColor;
        private float _weight;
        private float _height;
        private int _age;
        private int _currentExperience;
        private int _initialExperience;
        private string _description;
        private string _notes;
        private float _cbills;
        private Affiliation _affiliation;

        private ObservableCollection<CharacterAttribute> _attributes;
        private ObservableCollection<Trait> _traits;
        private ObservableCollection<Skill> _skills;


        #endregion

        #region Properties

        // The following properties represent character fluff more than hard data about the character

        /// <summary>
        /// The name of the player who is playing the character
        /// </summary>
        public string PlayerName
        {
            get { return _playerName; }
            set
            {
                if (!_playerName.Equals(value))
                {
                    _playerName = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// The characters hair color
        /// </summary>
        public string HairColor
        {
            get { return _hairColor; }
            set
            {
                if (!_hairColor.Equals(value))
                {
                    _hairColor = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// The characters eye color
        /// </summary>
        public string EyeColor
        {
            get { return _eyeColor; }
            set
            {
                if (!_eyeColor.Equals(value))
                {
                    _eyeColor = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// The weight of the character in kilograms
        /// </summary>
        public float Weight
        {
            get { return _weight; }
            set
            {
                if (!_weight.NearlyEqual(value))
                {
                    _weight = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// The height of the character in centimeters
        /// </summary>
        public float Height
        {
            get { return _height; }
            set
            {
                if (!_height.NearlyEqual(value))
                {
                    _height = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// The age of the character.
        /// </summary>
        public int Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// A description of the character.
        /// </summary>
        /// <value>The description.</value>
        /// <remarks>
        /// The player can put any biographical notes, physical description, etc, here.
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
        /// Any notes or comments about the character.
        /// </summary>
        /// <value>The notes.</value>
        /// <remarks>
        /// This is more of a general catch all for notation about the character.
        /// Use this to describe design choices or just make general notes about
        /// the process used to create the character.
        /// </remarks>
        public string Notes
        {
            get { return _notes; }
            set
            {
                if(!_notes.Equals(value))
                {
                    _notes = value;
                    RaisePropertyChanged();
                }
            }
        }

        // These properites represent actuall game data for a character

        /// <summary>
        /// The characters faction affiliation.
        /// </summary>
        /// <value>The affiliation.</value>
        /// <remarks>
        /// This is the faction that the player begins play with. 
        /// See a list of affiliations starting on p. 53 of AToW.
        /// </remarks>
        public Affiliation Affiliation
        {
            get { return _affiliation; }
            set
            {
                if (_affiliation != value)
                {
                    _affiliation = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// A characters currently available experience pool.
        /// </summary>
        /// <value>The current experience.</value>
        public int CurrentExperience
        {
            get { return _currentExperience; }
            set
            {
                if (_currentExperience != value)
                {
                    _currentExperience = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// The initial amount of experience points allocated to the character.
        /// </summary>
        /// <value>The initial experience.</value>
        public int InitialExperience
        {
            get { return _initialExperience; }
            set
            {
                if (_initialExperience != value)
                {
                    _initialExperience = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Amount of money the character possesses (in Comstar Bills)
        /// </summary>
        /// <value>The CBills.</value>
        /// <remarks>
        /// The various factions all have the own monetary systems, but for simplicity,
        /// War College uses the Comstar bill as kind of a global currency.
        /// </remarks>
        public float CBills
        {
            get { return _cbills; }
            set
            {
                if (!_cbills.NearlyEqual(value))
                {
                    _cbills = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// List of the characters attributes.
        /// </summary>
        /// <value>The attributes.</value>
        /// <remarks>
        /// A character has exactaly eight attributes.
        /// </remarks>
        public ObservableCollection<CharacterAttribute> Attributes
        {
            get { return _attributes; }
            set
            {
                if (_attributes != value)
                {
                    _attributes = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// List of the characters traits.
        /// </summary>
        /// <value>The traits.</value>
        public ObservableCollection<Trait> Traits
        {
            get { return _traits; }
            set
            {
                if (_traits != value)
                {
                    _traits = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// List of the characters skills.
        /// </summary>
        /// <value>The skills.</value>
        public ObservableCollection<Skill> Skills
        {
            get { return _skills; }
            set
            {
                if (_skills != value)
                {
                    _skills = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Events

        #endregion

        #region Ctor
        #endregion

        #region Methods

        /// <summary>
        /// Determines if a character has a particular trait.
        /// </summary>
        /// <param name="name">Name of the trait to test.</param>
        /// <returns><c>True</c> if the character has the named trait.</returns>
        public bool HasTrait(string name) => Traits.Any(x => x.Name == name);

        /// <summary>
        /// Determines if a character has a particular skill.
        /// </summary>
        /// <param name="name">Name of the skill to test.</param>
        /// <returns><c>True</c> if the character has the named skill.</returns>
        public bool HasSkill(string name) => Skills.Any(x => x.Name == name);

        #endregion

        #region Utilities

        #endregion
    }
}
