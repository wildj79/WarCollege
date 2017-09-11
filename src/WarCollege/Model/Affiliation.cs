//
// Affiliation.cs
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
using System.Collections.ObjectModel;
using WarCollege.Domain;

namespace WarCollege.Model
{
    public class Affiliation : ModelBase, IEquatable<Affiliation>, IComparable<Affiliation>
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


        #endregion

        #region IEquatable<Affiliation> implementation

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

		public int CompareTo(Affiliation other)
		{
            return string.Compare(Name, other.Name, StringComparison.CurrentCulture);
		}

        #endregion

        #region Methods

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

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion

        #region Operator overloads

        public static bool operator == (Affiliation aff1, Affiliation aff2)
        {
            if (aff1 == null || aff2 == null)
            {
                return false;
            }

            return aff1.Equals(aff2);
        }

        public static bool operator != (Affiliation aff1, Affiliation aff2)
        {
            if (aff1 == null || aff2 == null)
            {
                return false;
            }

            return !aff1.Equals(aff2);
        }

        #endregion
    }
}
