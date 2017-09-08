// Phenotype.cs
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
    /// The chosen phenotype for a character.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Phenotype is technically a trait, but it is unique enough that it warrents its own
    /// class. Every character has a phenotype. But, unless your playing a clan character,
    /// it will more than likely be "Normal Human".
    /// </para>
    /// <para>
    /// In the core rules for A Time of War, there are four phenotypes: <em>Normal Human</em>,
    /// <em>Aerospace</em>, <em>Elemental</em>, and <em>MechWarrior</em>. The <em>Aerospace</em>,
    /// <em>Elemental</em>, and <em>MechWarrior</em> are only available to clan characters.
    /// </para>
    /// <para>
    /// Rules References:
    /// Phenotype Trait p.122, AToW
    /// </para>
    /// </remarks>
    public class Phenotype : ModelBase
    {
        #region Fields

        private string _name;
        private IDictionary<string, int> _attributeModifiers = new Dictionary<string, int>();
        private IDictionary<string, int> _attributeMaximums = new Dictionary<string, int>();
        private ObservableCollection<Trait> _bonusTraits;
        private string _fieldAptitude;

        #endregion

        #region Properties

        /// <summary>
        /// The name of the phenotype
        /// </summary>
        /// <remarks>
        /// Can be one of:
        /// <list type="bullet">
        /// <item><description>Normal Human</description></item>
        /// <item><description>Aerospace</description></item>
        /// <item><description>Elemental</description></item>
        /// <item><description>MechWarrior</description></item>
        /// </list>
        /// Other supplements could potentially add more.
        /// </remarks>
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

        /// <summary>
        /// Collection of key/value pairs used to map a modifier to a character attribute.
        /// </summary>
        public IDictionary<string, int> AttributeModifiers
        {
            get { return _attributeModifiers; }
            set
            {
                if (_attributeModifiers != value)
                {
                    _attributeModifiers = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Collection of key/value pairs used to map a maximum value to a character 
        /// attribute score.
        /// </summary>
        public IDictionary<string, int> AttributeMaximums
        {
            get { return _attributeMaximums; }
            set
            {
                if (_attributeMaximums != value)
                {
                    _attributeMaximums = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// List of bonus character traits assigned to a character with this
        /// phenotype.
        /// </summary>
        public ObservableCollection<Trait> BounusTraits
        {
            get { return _bonusTraits; }
            set
            {
                if (_bonusTraits != value)
                {
                    _bonusTraits = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Name of a skill field that characters with this phenotype have a
        /// strong aptitude in.
        /// </summary>
        /// <remarks>
        /// This applies a -1 TN modifier to all skills that are encompassed 
        /// by the skill field.
        /// </remarks>
        public string FieldAptitude
        {
            get { return _fieldAptitude; }
            set
            {
                if (!_fieldAptitude.Equals(value))
                {
                    _fieldAptitude = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion
    }
}
