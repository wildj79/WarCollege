//
// Open.cs
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
using Autofac.Extras.NLog;
using Eto.Drawing;
using Eto.Forms;

namespace WarCollege.Commands
{
    /// <summary>
    /// Open character command.
    /// </summary>
    public class OpenCharacter : Command
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WarCollege.Commands.Open"/> class.
        /// </summary>
        /// <param name="logger">General logging</param>
        /// <remarks>
        /// This is the command used to open a previously created character.
        /// </remarks>
        public OpenCharacter(ILogger logger)
        {
            _logger = logger;

            MenuText = Resources.Strings.OpenMenuText;
            ToolBarText = Resources.Strings.OpenToolBarText;
            Image = Icon.FromResource("WarCollege.Resources.folder.png");
            Shortcut = Application.Instance.CommonModifier | Keys.O;
        }

        protected override void OnExecuted(EventArgs e)
        {
            _logger.Trace("Start OpenCharacter.OnExecuted()");
            base.OnExecuted(e);

            _logger.Trace("End OpenCharacter.OnExecuted()");
        }
    }
}
