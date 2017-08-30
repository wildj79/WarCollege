/* War College - Copyright(c) 2017 James Allred (wildj79@gmail.com)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this
 * software and associated documentation files (the "Software"), to deal in the Software
 * without restriction, including without limitation the rights to use, copy, modify, merge, 
 * publish, distribute, sublicense, and/or sell copies of the Software, and to permit
 * persons to whom the Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
 * OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
 * THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
 * OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using Eto.Forms;
using Eto.Drawing;
using Autofac.Extras.NLog;
using Autofac.Features.Indexed;
using System.ComponentModel;

namespace WarCollege
{
    /// <summary>
    /// The main GUI window for the application.
    /// </summary>
    /// <remarks>
    /// This is where the majority of the interaction with the user will
    /// take place.
    /// </remarks>
    public class MainForm : Form
    {
        #region Fields

        private readonly ILogger _logger;
        private readonly IIndex<string, Command> _commandFactory;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WarCollege.MainForm"/> class.
        /// </summary>
        /// <param name="logger">General logging aparatus</param>
        /// <param name="commandFactory">Factory method for creating menu commands</param>
        public MainForm(ILogger logger, IIndex<string, Command> commandFactory)
        {
            _logger = logger;
            _commandFactory = commandFactory;

            Title = Resources.Strings.AppTitle;
            ClientSize = new Size(800, 600);
            Content = new Label { Text = Resources.Strings.HelloWorld };
            Style = "MainWindow";

            GenerateMenu();
        }

        #endregion // Constructors

        #region Utilities

        /// <summary>
        /// Generates the main menu.
        /// </summary>
        private void GenerateMenu()
        {
            _logger.Trace("Starting MainForm.GenerateMenu()");

            _logger.Debug("Building menu bar and the tool bar.");

            var menu = new MenuBar
            {
                AboutItem = _commandFactory["aboutCommand"],
                QuitItem = _commandFactory["quitCommand"]
            };

            var file = menu.Items.GetSubmenu("&File");
            file.Items.Add(_commandFactory["newCharacterCommand"]);
            file.Items.Add(_commandFactory["openCharacterCommand"]);
            file.Items.Add(_commandFactory["saveCharacterCommand"]);
            file.Items.Add(_commandFactory["saveCharacterAsCommand"]);
            file.Items.Add(_commandFactory["saveAllCharactersCommand"]);

            menu.ApplicationItems.Add(_commandFactory["preferencesCommand"], 900);

            Menu = menu;

            _logger.Trace("End MainForm.GenerateMenu()");
        }

        #endregion // Utilities

        #region Methods

        /// <summary>
        /// Handler for the Form.Load event.
        /// </summary>
        /// <param name="e">Generic event arguments</param>
        /// <remarks>
        /// Don't remove the <code>base.OnLoad(e)</code> call. The resource strings 
        /// won't load correctly if you do.
        /// </remarks>
        protected override void OnLoad(EventArgs e)
        {
            _logger.Trace("Start MainForm.OnLoad()");
            // SplashScreen.CloseForm();
            base.OnLoad(e);

            _logger.Trace("End MainForm.OnLoad()");
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _logger.Trace("Start MainForm.OnClosing()");

            //if (!PromptSave())
                //e.Cancel = true;

            //_logger.Debug("Save Location: " + _settings.UserPreferences.LastSaveLocation);

            //_configManager.Save(_settings);

            _logger.Trace("End MainForm.OnClosing()");
            base.OnClosing(e);
        }

        /// <summary>
        /// Method used to determine if the user should be prompted before closing
        /// the application.
        /// </summary>
        /// <returns>
        /// <c>true</c>, if the user has any unsaved changes that will be lost
        /// when the application closes, <c>false</c> otherwise.
        /// </returns>
        public bool PromptSave()
        {
            _logger.Trace("Start MainForm.PromptSave()");

            var result = MessageBox.Show("You have unsaved changes, are you sure you want to quit?", "Are you sure...", MessageBoxButtons.YesNo, MessageBoxType.Question, MessageBoxDefaultButton.Yes);

            if (result == DialogResult.No || result == DialogResult.Cancel)
                return false;

            _logger.Trace("End MainForm.PromptSave()");

            return true;
        }

        #endregion // Methods
    }
}
