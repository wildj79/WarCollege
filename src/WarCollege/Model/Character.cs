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

        private string _name;
        private string _playerName;
        private string _hairColor;
        private string _eyeColor;
        private float _weight;
        private float _height;
        private IList<CharacterAttribute> _attributes;

        #endregion

        #region Properties

        // The following properties represent character fluff more than hard data about the character

        /// <summary>
        /// The characters name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (!_name.Equals(value))
                {
                    _name = value;
                    RaisePropertyChanged();
                }
            }
        }

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
                if (_weight != value)
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
                if (_height != value)
                {
                    _height = value;
                    RaisePropertyChanged();
                }
            }
        }

        // These properites represent actuall game data for a character

        public IList<CharacterAttribute> Attributes
        {
            get { return _attributes; }
            private set { _attributes = value; }
        }

        #endregion

        #region Events

        #endregion

        #region Ctor
        #endregion

        #region Methods
        #endregion

        #region Utilities

        #endregion
    }
}
