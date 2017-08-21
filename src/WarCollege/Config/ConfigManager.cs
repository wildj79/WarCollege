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

using System.IO;
using System.Xml.Serialization;

namespace WarCollege.Config
{
    /// <summary>
    /// Responsible for loading and saving the applications settings file.
    /// </summary>
    public class ConfigManager : IConfigManager
    {
        private const string settingsFileName = "settings.xml";
        private string appDataFolder = ""; //EtoEnvironment.GetFolderPath(EtoSpecialFolder.ApplicationSettings);

        /// <summary>
        /// Gets the config file path.
        /// </summary>
        /// <value>The path to the application file.</value>
        public string ConfigFilePath 
        { 
            get { return Path.Combine(appDataFolder, settingsFileName); } 
            set { appDataFolder = value; }
        }

        /// <summary>
        /// Opens the config file for both reading and writing.
        /// </summary>
        /// <returns>A <c>FileStream</c> object</returns>
        /// <param name="isWrite">
        /// If set to <c>true</c> the open the file for writing.
        /// </param>
        protected FileStream OpenConfigFile(bool isWrite = false)
        {
            FileStream fs;

            if (isWrite)
                fs = new FileStream(ConfigFilePath, FileMode.Create, FileAccess.Write, FileShare.Write);
            else
                fs = new FileStream(ConfigFilePath, FileMode.Open, FileAccess.Read, FileShare.None);

            return fs;
        }

        /// <summary>
        /// Loads the config file
        /// </summary>
        /// <returns>The deserialized <c>ConfigSettings</c></returns>
        /// <remarks>
        /// Responsible for deserializing the configurations xml file and returning
        /// a <c>ConfigSettings</c> object.
        /// </remarks>
        public IConfigSettings LoadConfig()
        {
            var settings = null as IConfigSettings;

            using (var fs = OpenConfigFile())
            {
                var xml = new XmlSerializer(typeof(ConfigSettings));

                settings = xml.Deserialize(fs) as ConfigSettings;
            }

            return settings;
        }

        /// <summary>
        /// Save the specified settings.
        /// </summary>
        /// <param name="settings">The <c>ConfigSettings</c> object to save</param>
        /// <remarks>
        /// Responsible for serializing the <c>ConfigSettings</c> object and saving
        /// it to the applications configuration xml file.
        /// </remarks>
        public void Save(IConfigSettings settings)
        {
            using (var fs = OpenConfigFile(true))
            {
                var xml = new XmlSerializer(typeof(ConfigSettings));

                xml.Serialize(fs, settings);
            }
        }
    }
}
