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
using NGettext;
using NLog;
using System;
using System.ComponentModel;
using WarCollege.Commands;
using WarCollege.Model;
using WarCollege.Services;

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
        private readonly Config.IConfigSettings _configSettings;
        private readonly Config.IConfigManager _configManager;
        private readonly IAboutCommand _aboutComand;
        private readonly IQuitCommand _quitCommand;
        private readonly INewCharacterCommand _newCharacterCommand;
        private readonly IOpenCharacterCommand _openCharacterCommand;
        private readonly ISaveCharacterCommand _saveCharacterCommand;
        private readonly ISaveCharacterAsCommand _saveCharacterAsCommand;
        private readonly ISaveAllCharactersCommand _saveAllCharactersCommand;
        private readonly IPreferencesCommand _preferencesCommand;
        private readonly ICharacterInitializationService _characterInitializationService;
        private readonly ICatalog _catalog;

        #endregion // Fields

        #region Properties

        public Character Character { get; set; }

        #endregion // Properties


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        /// <param name="logger">Application logger instacne</param>
        /// <param name="configSettings">Configuration settings for the application.</param>
        /// <param name="configManager">The configuration manager for the application.</param>
        /// <param name="aboutCommand">Command that controls the "About" dialog box.</param>
        /// <param name="quitCommand">Command that exit's the application.</param>
        /// <param name="newCharacterCommand">Command the creates a new character.</param>
        /// <param name="openCharacterCommand">Command that opens a character.</param>
        /// <param name="saveCharacterCommand">Command that save's the current character.</param>
        /// <param name="saveCharacterAsCommand">Command that save's the current character with a specific name.</param>
        /// <param name="saveAllCharactersCommand">Command that save's all open characters.(I might remove this.)</param>
        /// <param name="preferencesCommand">Command that handles the preferneces dialog.</param>
        public MainForm(ILogger logger,
                        Config.IConfigSettings configSettings,
                        Config.IConfigManager configManager,
                        IAboutCommand aboutCommand,
                        IQuitCommand quitCommand,
                        INewCharacterCommand newCharacterCommand,
                        IOpenCharacterCommand openCharacterCommand,
                        ISaveCharacterCommand saveCharacterCommand,
                        ISaveCharacterAsCommand saveCharacterAsCommand,
                        ISaveAllCharactersCommand saveAllCharactersCommand,
                        IPreferencesCommand preferencesCommand,
                        ICharacterInitializationService characterInitializationService,
                        ICatalog catalog)
        {
            _logger = logger;
            _configSettings = configSettings;
            _configManager = configManager;
            _aboutComand = aboutCommand;
            _quitCommand = quitCommand;
            _newCharacterCommand = newCharacterCommand;
            _openCharacterCommand = openCharacterCommand;
            _saveCharacterCommand = saveCharacterCommand;
            _saveCharacterAsCommand = saveCharacterAsCommand;
            _saveAllCharactersCommand = saveAllCharactersCommand;
            _preferencesCommand = preferencesCommand;
            _characterInitializationService = characterInitializationService;
            _catalog = catalog;

            Character = _characterInitializationService.IntializeCharacter();

            Character.Experience.AddExperience(-100);

            Title = $"{_catalog.GetString("War College")}: {Character}";
            ClientSize = new Size(800, 600);
            Content = new Label { Text = _catalog.GetString("Hello World!") };
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
            _logger.Trace($"Starting {nameof(GenerateMenu)}");

            _logger.Debug("Building menu bar and the tool bar.");

            var menu = new MenuBar
            {
                AboutItem = _aboutComand as Command,
                QuitItem = _quitCommand as Command
            };

            var file = menu.Items.GetSubmenu(_catalog.GetParticularString("Menu|", "&File"));
            file.Items.Add(_newCharacterCommand as Command);
            file.Items.Add(_openCharacterCommand as Command);
            file.Items.Add(_saveCharacterCommand as Command);
            file.Items.Add(_saveCharacterAsCommand as Command);
            file.Items.Add(_saveAllCharactersCommand as Command);

            menu.ApplicationItems.Add(_preferencesCommand as Command, 900);

            Menu = menu;

            _logger.Trace($"End {nameof(GenerateMenu)}");
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

            _logger.Debug("Save Location: " + _configSettings.UserPreferences.LastSaveLocation);

            _configManager.Save(_configSettings);

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

            var result = MessageBox.Show(_catalog.GetString("You have unsaved changes, are you sure you want to quit?"), _catalog.GetString("Are you sure..."), MessageBoxButtons.YesNo, MessageBoxType.Question, MessageBoxDefaultButton.Yes);

            if (result == DialogResult.No || result == DialogResult.Cancel)
                return false;

            _logger.Trace("End MainForm.PromptSave()");

            return true;
        }

        #endregion // Methods
    }
}
