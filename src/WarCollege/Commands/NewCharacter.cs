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
using NLog;
using Eto.Drawing;
using Eto.Forms;
using NGettext;

namespace WarCollege.Commands
{
	/// <summary>
	/// New character command.
	/// </summary>
	public class NewCharacter : Command, INewCharacterCommand
    {
        private readonly ILogger _logger;
        private readonly ICatalog _catalog;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WarCollege.Commands.New"/> class.
        /// </summary>
        /// <param name="logger">General logging</param>
        /// <remarks>
        /// This class is the command used to start a new character. 
        /// </remarks>
        public NewCharacter(ILogger logger, ICatalog catalog)
        {
            _logger = logger;
            _catalog = catalog;

            MenuText = _catalog.GetParticularString("Menu|File|", "&New Character");
            ToolBarText = _catalog.GetString("New Character");
            Image = Icon.FromResource("WarCollege.Resources.page_white_add.png");
            Shortcut = Application.Instance.CommonModifier | Keys.N;
        }

        protected override void OnExecuted(EventArgs e)
        {
            _logger.Trace("Start NewCharacter.OnExecuted()");
            base.OnExecuted(e);

            _logger.Trace("End NewCharacter.OnExecuted()");
        }
    }
}
