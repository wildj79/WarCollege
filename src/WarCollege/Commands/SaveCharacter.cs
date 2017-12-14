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
using System.IO;

namespace WarCollege.Commands
{
    public class SaveCharacter : Command, ISaveCharacterCommand
    {
        private readonly ILogger _logger;
        private readonly Config.IConfigSettings _configSettings;
        
        public SaveCharacter(ILogger logger, Config.IConfigSettings configSettings)
        {
            _logger = logger;
            _configSettings = configSettings;

            MenuText = Resources.Strings.SaveMenuText;
            ToolBarText = Resources.Strings.SaveToolBarText;
            Image = Icon.FromResource("WarCollege.Resources.disk.png");
            Shortcut = Application.Instance.CommonModifier | Keys.S;
        }

        protected override void OnExecuted(EventArgs e)
        {
            _logger.Trace("Start SaveCharacter.OnExecuted()");
            base.OnExecuted(e);

            _logger.Debug(_configSettings.UserPreferences.LastSaveLocation);

            using (var saveDialog = new SaveFileDialog())
            {
                if (!string.IsNullOrWhiteSpace(_configSettings.UserPreferences.LastSaveLocation))
                    saveDialog.Directory = new Uri(_configSettings.UserPreferences.LastSaveLocation);

                saveDialog.Filters.Add(new FileDialogFilter("Text Files", new string[] { "txt" }));
                
                var result = saveDialog.ShowDialog(Application.Instance.MainForm);

                if (result == DialogResult.Ok)
                {
                    //_logger.Debug(saveDialog.Directory.AbsolutePath);
                    //_configSettings.UserPreferences.LastSaveLocation = saveDialog.Directory.AbsolutePath;
                    _logger.Debug(Path.GetDirectoryName(saveDialog.FileName));
                    _configSettings.UserPreferences.LastSaveLocation = Path.GetDirectoryName(saveDialog.FileName);
                }
            }


            _logger.Trace("End SaveCharacter.OnExecuted()");
        }
    }
}
