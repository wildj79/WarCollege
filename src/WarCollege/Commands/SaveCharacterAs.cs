//
// SaveCharacterAs.cs
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

using Eto.Forms;
using NLog;
using System;

namespace WarCollege.Commands
{
    public class SaveCharacterAs : Command, ISaveCharacterAsCommand
    {
        private readonly ILogger _logger;
        private readonly Config.IConfigSettings _configSettings;
        
        public SaveCharacterAs(ILogger logger, Config.IConfigSettings configSettings)
        {
            _logger = logger;
            _configSettings = configSettings;

            MenuText = Resources.Strings.SaveAsMenuText;
            ToolBarText = Resources.Strings.SaveAsToolBarText;
        }

        protected override void OnExecuted(EventArgs e)
        {
            _logger.Trace("Start SaveCharacterAs.OnExecuted()");
            base.OnExecuted(e);

            if (string.IsNullOrWhiteSpace(_configSettings.UserPreferences.LastSaveLocation))
            {
                _configSettings.UserPreferences.LastSaveLocation = Eto.EtoEnvironment.GetFolderPath(Eto.EtoSpecialFolder.Documents);
            }

			var dialog = new SaveFileDialog();
            dialog.Directory = new Uri(_configSettings.UserPreferences.LastSaveLocation);
			var result = dialog.ShowDialog(null);

			if (result == DialogResult.Ok)
			{
				_logger.Debug(dialog.FileName);
                _configSettings.UserPreferences.LastSaveLocation = System.IO.Path.GetDirectoryName(dialog.FileName);
			}

            _logger.Trace("End SaveCharacterAs.OnExecuted()");
        }
    }
}
