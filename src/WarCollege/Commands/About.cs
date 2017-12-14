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

using Autofac;
using NLog;
using Eto.Drawing;
using Eto.Forms;
using System;
using WarCollege.Dialogs;

namespace WarCollege.Commands
{
    /// <summary>
    /// About menu item command.
    /// </summary>
    public class About : Command, IAboutCommand
    {
        private readonly ILogger _logger;
        private readonly ILifetimeScope _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WarCollege.Commands.About"/> class.
        /// </summary>
        /// <param name="logger">General logging</param>
        /// <param name="unitOfWork"><see cref="ILifetimeScope"/> for the application.</param>
        public About(ILogger logger,
            ILifetimeScope unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

            MenuText = Resources.Strings.AboutMenuText;
            ToolBarText = Resources.Strings.AboutToolBarText;
            Image = Icon.FromResource("WarCollege.Resources.information.png");
            Shortcut = Keys.F1;

        }

        /// <summary>
        /// Handler for the Command.OnExecuted evnet.
        /// </summary>
        /// <param name="e">Generic event args</param>
        /// <remarks>
        /// Brings up the about us modal dialog.
        /// </remarks>
        protected override void OnExecuted(EventArgs e)
        {
            _logger.Trace("Start Commands.About.OnExecuted()");
            base.OnExecuted(e);

            using (var scope = _unitOfWork.BeginLifetimeScope())
            {
                var about = scope.Resolve<IAboutDialog>();
                about.ShowModal(Application.Instance.MainForm);
            }

            _logger.Trace("End Commands.About.OnExecuted()");
        }
    }
}
