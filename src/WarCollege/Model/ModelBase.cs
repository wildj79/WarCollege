// ModelBase.cs
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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WarCollege.Model
{
    /// <summary>
    /// Base class for all models.
    /// </summary>
    /// <remarks>
    /// Provides a base set of properties for the model as well as handling 
    /// all of the <see cref="INotifyPropertyChanged" /> events for the model.
    /// </remarks>
    public abstract class ModelBase : INotifyPropertyChanged
    {
        #region Fields

        private string _name;
        private Guid _id;

		#endregion

		#region Properties

		/// <summary>
		/// Unique Id for the model.
		/// </summary>
		/// <remarks>
		/// This will be used internally by the program to uniquely identify various 
		/// models (Equipment, weapons, vehicles, etc...) This should only be set once,
		/// when the model is created.
		/// </remarks>
		public virtual Guid Id { get; set; }

        /// <summary>
        /// A name that identifies the model.
        /// </summary>
        /// <value>The name.</value>
        public virtual string Name 
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

        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// See <see cref="INotifyPropertyChanged" />.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the <c>PropertyChanged</c> event for the model.
        /// </summary>
        /// <param name="memberName">The name of the property being changed.</param>
        protected virtual void RaisePropertyChanged([CallerMemberName] string memberName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        #endregion
    }
}
