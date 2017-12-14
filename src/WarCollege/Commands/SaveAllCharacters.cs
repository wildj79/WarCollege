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

using Eto.Drawing;
using Eto.Forms;
using NLog;
using System;

namespace WarCollege.Commands
{
    public class SaveAllCharacters : Command, ISaveAllCharactersCommand
    {
        #region Fields

        private readonly ILogger _logger;

        #endregion

        #region Constructors

        public SaveAllCharacters(ILogger logger)
        {
            _logger = logger;

            MenuText = "Save All";
            ToolBarText = "Save All";
            Image = Icon.FromResource("WarCollege.Resources.disk_multiple.png");
            Shortcut = Application.Instance.CommonModifier | Keys.Shift | Keys.S;
        }

        #endregion

        #region Utilities
        #endregion

        #region Methods
        protected override void OnExecuted(EventArgs e)
        {
            base.OnExecuted(e);
            _logger.Trace("Start SaveAllCharacters.OnExecuted()");

            MessageBox.Show("Saved all characters!");

            _logger.Trace("End SaveAllCharacters.OnExecuted()");
        }
        #endregion

    }
}
