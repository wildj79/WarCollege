// War College - Copyright (c) 2017 James Allred (wildj79@gmail.com)
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

using Eto.Drawing;
using Eto.Forms;

namespace WarCollege.Dialogs
{
    /// <summary>
    /// User preferences modal dialog
    /// </summary>
    public class Preferences : Dialog, IPreferencesDialog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:WarCollege.Dialogs.Preferences"/> class.
        /// </summary>
        public Preferences()
        {
            Title = Resources.Strings.HelloWorld;
            MinimumSize = new Size(300, 0);
            Resizable = false;

            var button = new Button
            {
                Text = Resources.Strings.CloseButton
            };

            button.Click += (sender, e) => Close();

            Content = new TableLayout
            {
                Padding = new Padding(10),
                Spacing = new Size(5, 5),
                Rows =
                {
                    new Label { Text = Resources.Strings.HelloWorld },
                    TableLayout.AutoSized(button, centered: true)
                }
            };

            AbortButton = DefaultButton = button;
        }
    }
}
