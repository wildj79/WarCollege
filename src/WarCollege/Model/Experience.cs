// Experience.cs
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

namespace WarCollege.Model
{
    /// <summary>
    /// Simple class for keeping track of experience points
    /// </summary>
    public class ExperiencePoints : Model
    {
        #region Fields

        private int _totalExperience;
        private int _currentExperience;

        #endregion

        #region Properties

        /// <summary>
        /// The total experience points allocated to this model.
        /// </summary>
        public int TotalExperience
        {
            get => _totalExperience;
            private set
            {
                if (_totalExperience != value)
                {
                    _totalExperience = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// The current number of experience points allocated to this model.
        /// </summary>
        public int CurrentExperience
        {
            get => _currentExperience;
            set
            {
                if (_currentExperience != value)
                {
                    _currentExperience = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Initialize a new instance of <see cref="ExperiencePoints"/>.
        /// </summary>
        public ExperiencePoints()
        {
            CurrentExperience = 0;
            TotalExperience = 0;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="ExperiencePoints"/> with an initial value.
        /// </summary>
        /// <param name="value">The initial number of experience points to set.</param>
        public ExperiencePoints(int value)
        {
            CurrentExperience = value;
            TotalExperience = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds experience points to this model.
        /// </summary>
        /// <param name="value">Amount of points to add</param>
        public void AddExperience(int value)
        {
            TotalExperience += value;
            CurrentExperience += value;
        }

        #endregion
    }
}
