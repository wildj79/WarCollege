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

namespace WarCollege.Domain
{
    /// <summary>
    /// A number of experience points that are allocated to a <see cref="WarCollege.Model.Skill"/> , 
    /// <see cref="WarCollege.Model.Trait"/>, or <see cref="WarCollege.Model.CharacterAttribute"/> during character creation.
    /// </summary>
    /// <remarks>
    /// These represent a strait allotment of points. These points can be 
    /// negative or positive.
    /// </remarks>
    public class ExperienceAllotment
    {
        #region Properties

        /// <summary>
        /// Whether these points are allocated to a <c>Skill</c>, <c>Trait</c>,
        /// or <c>CharacterAttribute</c>.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        /// The name of the <c>Skill</c>, <c>Trait</c>, or <c>CharacterAttribute</c> these points are allocated to.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// The number of points to allocate.
        /// </summary>
        /// <value>The experience points.</value>
        /// <remarks>
        /// Can be negative or positive
        /// </remarks>
        public int ExperiencePoints { get; set; }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="WarCollege.Domain.ExperienceAllotment"/> class.
        /// </summary>
        /// <param name="type">
        /// Whether these points are for a <c>Skill</c>, <c>Trait</c>, or <c>CharacterAttribute</c>.
        /// </param>
        /// <param name="name">
        /// Name of the <c>Skill</c>, <c>Trait</c>, or <c>CharacterAttribute</c> to allocate the points to.
        /// </param>
        /// <param name="experiencePoints">The number of points to allocate</param>
        public ExperienceAllotment(string type = "", string name = "", int experiencePoints = 0)
        {
            Type = type;
            Name = name;
            ExperiencePoints = experiencePoints;
        }

        #endregion
    }
}
