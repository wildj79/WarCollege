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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCollege.Model
{
    /// <summary>
    /// Represents a character attribute.
    /// </summary>
    /// <remarks>
    /// This is not what I would prefer calling the class. I would prefer just <c>Attribute</c>,
    /// but the .NET framework includes an <c>Attribute</c> abstract class in the <c>System</c> namespace.
    /// So, to preclude any namespace conflicts, I've decieded to name this <c>CharacterAttribute</c>
    /// instead.
    /// </remarks>
    public class CharacterAttribute : ModelBase
    {
        #region Fields

        private int _score;
        private int _linkModifier;
        private int _experience;
        private string _name;
        private string _description;
        private string _abbreviation;

        #endregion

        #region Properties

        public int Score
        {
            get { return _score; }
            set
            {
                if (_score != value)
                {
                    _score = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int LinkModifier
        {
            get { return _linkModifier; }
            set
            {
                if (_linkModifier != value)
                {
                    _linkModifier = value;
                    RaisePropertyChanged();
                }
            }
        }

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

        public string Abbreviation
        {
            get { return _abbreviation; }
            set
            {
                if (!_abbreviation.Equals(value))
                {
                    _abbreviation = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion
    }
}
