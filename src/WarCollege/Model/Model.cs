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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WarCollege.Model
{
    /// <summary>
    /// Base class for all models.
    /// </summary>
    /// <remarks>
    /// Simple abstract class that defines an implementation for the 
    /// <c>INotifyPropertyChanged</c> interface.
    /// </remarks>
    public abstract class Model : INotifyPropertyChanged
    {
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

    /// <summary>
    /// Base class for models that use an unique id.
    /// </summary>
    /// <typeparam name="TKey"><c>Type</c> used to uniquly identify the model.</typeparam>
    /// <remarks>
    /// Provides a base set of properties for the model.
    /// </remarks>
    public abstract class Model<TKey> : Model
    {
        #region Fields

        private string _name;
        private TKey _id;

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
		public virtual TKey Id
        {
            get => _id;
            set
            {
                if (!_id.Equals(value))
                {
                    _id = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// A name that identifies the model.
        /// </summary>
        /// <value>The name.</value>
        public virtual string Name 
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion
    }
}
