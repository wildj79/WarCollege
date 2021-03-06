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

using Autofac;
using Eto;
using Eto.Drawing;
using Eto.Forms;
using NLog;
using System;
using WarCollege.Config;
using WarCollege.Dialogs;

namespace WarCollege.Commands
{
    /// <summary>
    /// User preferences command setup.
    /// </summary>
    public class Preferences : Command, IPreferencesCommand
    {
        #region Fields

        private readonly IConfigSettings _configSettings;
        private readonly IConfigManager _configManager;
        private readonly ILogger _logger;
        private readonly ILifetimeScope _unitOfWork;

        #endregion //Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WarCollege.Commands.Preferences"/> class.
        /// </summary>
        /// <param name="logger">General logging instance</param>
        /// <param name="configSettings">Application settings</param>
        /// <param name="configManager">Application configuration manager</param>
        /// <param name="unitOfWork"><see cref="ILifetimeScope"/> for the application.</param>
        public Preferences(ILogger logger, 
                           IConfigSettings configSettings, 
                           IConfigManager configManager,
                           ILifetimeScope unitOfWork
                          )
        {
            _logger = logger;
            _configSettings = configSettings;
            _configManager = configManager;
            _unitOfWork = unitOfWork;

            MenuText = Resources.Strings.PreferencesMenuText;
            ToolBarText = Resources.Strings.PreferencesToolBarText;
            if (Platform.Instance.IsMac)
                Shortcut = Application.Instance.CommonModifier | Keys.Comma;
            Image = Icon.FromResource("WarCollege.Resources.cog.png");
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Handler for the Command.Executed event.
        /// </summary>
        /// <param name="e">Generic event arguments</param>
        /// <remarks>
        /// When the user choses the preferences command in the menu, this
        /// is what controls that menu. This will open a modal dialog showing
        /// the user various settings that they can manipulate.
        /// </remarks>
        protected override void OnExecuted(EventArgs e)
        {
            _logger.Trace("Start Commands.Preferences.OnExecuted()");
            base.OnExecuted(e);

            using (var scope = _unitOfWork.BeginLifetimeScope())
            {
                var dialog = scope.Resolve<IPreferencesDialog>();
                dialog.ShowModal(Application.Instance.MainForm);
            }

            _logger.Trace("End Commands.Preferences.OnExecuted()");
        }

        #endregion // Methods
    }
}
