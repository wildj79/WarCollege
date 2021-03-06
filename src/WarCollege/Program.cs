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

using System;
using System.ComponentModel;
using System.IO;
// using System.Threading;
// using System.Threading.Tasks;
using NLog;
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
        private readonly Func<Form> _formFactory;

        #endregion // Fields

        #region Constructors

        //public Program() { }
        //public Program(string platform) : base(platform) { }
        //public Program(Platform platform) : base(platform) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WarCollege.Program"/> class.
        /// </summary>
        /// <param name="logger">Logging instance</param>
        /// <param name="formFactory">Factory delagate for creating the Main Form</param>
        public Program(ILogger logger, Func<Form> formFactory)
        {
            _logger = logger;
            _formFactory = formFactory;
        }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Handler for the Application.Terminating event
        /// </summary>
        /// <param name="e">Cancel Event arguments</param>
        protected override void OnTerminating(CancelEventArgs e)
        {
            _logger.Trace("Start Application.OnTerminating()");
            base.OnTerminating(e);


            //var form = MainForm as MainForm;
            //if (!form.PromptSave())
                //e.Cancel = true;

            //_logger.Debug("Save Location: " + _settings.UserPreferences.LastSaveLocation);

            //_configManager.Save(_settings);
            _logger.Trace("End Application.OnTerminating()");            
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
                if (LogManager.Configuration == null)
                    LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(Path.Combine(EtoEnvironment.GetFolderPath(EtoSpecialFolder.ApplicationResources), "NLog.config"));

                LogManager.Configuration.Variables["logRootDir"] = Path.Combine(EtoEnvironment.GetFolderPath(EtoSpecialFolder.ApplicationSettings), "WarCollege");
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

            Name = "War College";

            MainForm = _formFactory();
            MainForm.Show();

            _logger.Info("Application started");

            _logger.Trace("End Program.OnInitialized()");
        }

        #endregion // Methods
    }
}
