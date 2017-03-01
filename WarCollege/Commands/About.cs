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

using System;
using Autofac.Extras.NLog;
using Autofac.Features.OwnedInstances;
using Eto.Forms;
using Autofac.Features.AttributeFilters;

namespace WarCollege.Commands
{
    /// <summary>
    /// About menu item command.
    /// </summary>
    public class About : Command
    {
        private readonly ILogger _logger;
        private readonly Func<Owned<Dialog>> _dialogFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WarCollege.Commands.About"/> class.
        /// </summary>
        /// <param name="logger">General logging</param>
        /// <param name="dialogFactory">Factory method for creating the about dailog</param>
        public About(ILogger logger, 
                     [KeyFilter("aboutDialog")] Func<Owned<Dialog>> dialogFactory)
        {
            _logger = logger;
            _dialogFactory = dialogFactory;
            
            MenuText = Resources.Strings.AboutMenuText;
            ToolBarText = Resources.Strings.AboutToolBarText;
            // Image = Icon.FromResource("");
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

            using (var about = _dialogFactory().Value)
                about.ShowModal(Application.Instance.MainForm);

            _logger.Trace("End Commands.About.OnExecuted()");
        }
    }
}
