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
    public class CharacterTrait : ModelBase
    {
        #region Fields

        private string _name;
        private int _traitPoints;
        private string _pageReference;
        private int _experience;
        private string _description;
        private CharacterTraitType _traitType;

        #endregion

        #region Properties

        public override string Name
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
