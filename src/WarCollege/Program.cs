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
using System.ComponentModel;
using System.IO;
// using System.Threading;
// using System.Threading.Tasks;
using Autofac.Extras.NLog;
using Eto;
using Eto.Forms;

namespace WarCollege
{
    /// <summary>
    /// Derived class that handles initiating the applicaion.
    /// </summary>
    /// <remarks>
    /// We initialize most of the configuration for the application in this
    /// class. The Eto.Forms GUI toolkit has some very usefull methods
    /// for standarizing where configuration files and other user files
    /// are stored, but the EtoEnvironment isn't constructed until the 
    /// Application.Run() method is called. To ensure consistency across platforms
    /// I choose to handle some of of the initialzation here instead of when
    /// the IoC container is built.
    /// </remarks>
    public class Program : Application
    {
        #region Fields

        private readonly ILogger _logger;
        private readonly Config.IConfigSettings _settings;
        private readonly Func<Form> _formFactory;
        private readonly Config.IConfigManager _configManager;

        #endregion // Fields

        #region Constructors

        //public Program() { }
        //public Program(string platform) : base(platform) { }
        //public Program(Platform platform) : base(platform) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WarCollege.Program"/> class.
        /// </summary>
        /// <param name="logger">Logging instance</param>
        /// <param name="settings">Application Settings</param>
        /// <param name="formFactory">Factory method to create the application forms</param>
        /// <param name="configManager">The applications configuration manager</param>
        public Program(ILogger logger,
                       Config.IConfigSettings settings,
                       Func<Form> formFactory,
                       Config.IConfigManager configManager)
        {
            _logger = logger;
            _settings = settings;
            _formFactory = formFactory;
            _configManager = configManager;
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Handler for the Application.Terminating event
        /// </summary>
        /// <param name="e">Cancel Event arguments</param>
        protected override void OnTerminating(CancelEventArgs e)
        {
            base.OnTerminating(e);

            var form = MainForm as MainForm;
            if (!form.PromptSave())
                e.Cancel = true;
        }

        /// <summary>
        /// Handler for the Application.Initialized evnet
        /// </summary>
        /// <param name="e">Generic event arguments</param>
        /// <remarks>
        /// Most of the application initialization happens here.
        /// </remarks>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // Configuring NLog here is not prefered, but
            // the EtoEnvironment isn't setup until the 
            // Eto.Forms.Application is up and running.
            // The prefered method would be to run this as
            // an Autofac IStartable, but then I couldn't use
            // the EtoEnvironment values :(
            try
            {
                // When using NLog with the Xamarin.Mac target, the config
                // file isn't being read from the Resource folder in the application
                // bundle.  NLog is looking for the configuration in the executables
                // folder, but this file doesn't get coppied into the MonoBundle 
                // folder with the executable.  On Windows and Linux, this should 
                // already be configured.  This is a hack that ensures that
                // NLog loads the config from the right location, if NLog is not
                // already configured. (On Windows and Linux, the 
                // EtoSpecialFolder.ApplicationResources enum will point to the 
                // executables folder, where the NLog.config file should already be present.)
                if (NLog.LogManager.Configuration == null)
                    NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(Path.Combine(EtoEnvironment.GetFolderPath(EtoSpecialFolder.ApplicationResources), "NLog.config"));

                NLog.LogManager.Configuration.Variables["logRootDir"] = Path.Combine(EtoEnvironment.GetFolderPath(EtoSpecialFolder.ApplicationSettings), "WarCollege");
            }
            catch (Exception ex)
            {
                // Can't log the exception here, because NLog isn't configured correctly.
                // This at least lets me know if there is an issue during development.
                // 
                // TODO: Remove this before publishing WarCollege
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            _logger.Trace("Start Program.OnInitialized()");

            _logger.Info("Starting the application");

            _logger.Debug("Config file location: {0}", _configManager.ConfigFilePath);

            _logger.Debug("Config Settings:");
            _logger.Debug("Locale: {0}", _settings.UserPreferences.Locale);

            Name = "War College";
            MainForm = _formFactory(); // new MainForm();
            MainForm.Show();

            _logger.Info("Application started");

            _logger.Trace("End Program.OnInitialized()");
        }

        #endregion // Methods
    }
}
