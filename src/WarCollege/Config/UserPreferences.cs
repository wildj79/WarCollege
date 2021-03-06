﻿// War College - Copyright (c) 2017 James Allred (wildj79 at gmail dot com)
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
using System.Xml.Serialization;
using System.ComponentModel;

namespace WarCollege.Config
{
    /// <summary>
    /// User preferences.
    /// </summary>
    public class UserPreferences
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:WarCollege.Config.UserPreferences"/> class.
        /// </summary>
        public UserPreferences() 
        {
            Locale = "en-US";
            LastSaveLocation = string.Empty;
        }

        /// <summary>
        /// Gets or sets the locale.
        /// </summary>
        /// <value>The locale.</value>
        [XmlAttribute("locale")]
        [DefaultValue("en-US")]
        public string Locale { get; set; }

        [XmlElement("lastsavelocation")]
        [DefaultValue("")]
        public string LastSaveLocation { get; set; }
    }
}
