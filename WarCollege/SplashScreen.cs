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
using System.Collections.Generic;
using System.Xml;
using Eto.Forms;
using Eto.Drawing;
using System.IO;

namespace WarCollege
{
    /// <summary>
    /// Application splash screen
    /// </summary>
    /// <remarks>
    /// I had played around with this, but at this time I don't think it is necessary.
    /// I will revisit this later if the need arises.
    /// </remarks>
    public class SplashScreen : Form
    {
        const int TIMER_INTERVAL = 50;
        double opacityIncrement = .05;
        double opacityDecrement = .08;
        string status;
        string timeRemaining;
        double completionFraction;

        double lastCompletionFraction;
        double PBIncrementPerTimerInterval = .015;

        int index = 1;
        int actualTicks;
        List<double> previousCompletionFraction;
        List<double> actualTimes = new List<double>();
        DateTime start;
        bool firstLaunch;
        bool DTSet;

        static SplashScreen splash;

        /// <summary>
        /// Gets or sets the update timer.
        /// </summary>
        /// <value>The update timer.</value>
        public UITimer UpdateTimer { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public Label Status { get; set; }

        /// <summary>
        /// Gets or sets the time remaining.
        /// </summary>
        /// <value>The time remaining.</value>
        public Label TimeRemaining { get; set; }

        /// <summary>
        /// Gets the progress bar.
        /// </summary>
        /// <value>The progress bar.</value>
        public ProgressBar ProgressBar { get; private set; }

        /// <summary>
        /// Gets the background.
        /// </summary>
        /// <value>The background.</value>
        public ImageView Background { get; private set; }

        static void ShowForm()
        {
            splash = new SplashScreen();
            splash.Show();
        }

        /// <summary>
        /// Closes the splash screen.
        /// </summary>
        public static void CloseForm()
        {
            if (splash != null)
            {
                // Make it start going away
                splash.opacityIncrement = -splash.opacityDecrement;
            }

            splash = null;
        }

        /// <summary>
        /// Shows the splash screen.
        /// </summary>
        public static void ShowSplashScreen()
        {
            if (splash != null)
                return;

            ShowForm();
        }

        /// <summary>
        /// Sets the load status.
        /// </summary>
        /// <param name="newStatus">New status.</param>
        public static void SetStatus(string newStatus)
        {
            SetStatus(newStatus, true);
        }

        /// <summary>
        /// Sets the status.
        /// </summary>
        /// <param name="newStatus">New status.</param>
        /// <param name="setReference">If set to <c>true</c> set reference.</param>
        public static void SetStatus(string newStatus, bool setReference)
        {
            if (splash == null)
                return;

            splash.status = newStatus;

            if (setReference)
                splash.SetReferenceInternal();
        }

        /// <summary>
        /// If there isn't any status to update, then call this to atleast 
        /// help set a reference point for the progress bar.
        /// </summary>
        public static void SetReferencePoint()
        {
            if (splash == null)
                return;

            splash.SetReferenceInternal();
        }

        void SetReferenceInternal()
        {
            if (DTSet == false)
            {
                DTSet = true;
                start = DateTime.Now;
                ReadIncrements();
            }

            double milliseconds = ElapsedMilliSeconds();
            actualTimes.Add(milliseconds);
            lastCompletionFraction = completionFraction;
            if (previousCompletionFraction != null && index < previousCompletionFraction.Count)
                completionFraction = previousCompletionFraction[index++];
            else
                completionFraction = (index > 0) ? 1 : 0;
        }

        double ElapsedMilliSeconds()
        {
            TimeSpan ts = DateTime.Now - start;
            return ts.TotalMilliseconds;
        }

        void ReadIncrements()
        {
            string sPBIncrementPerTimerInterval = SplashScreenXMLStorage.Interval;
            double result;

            if (double.TryParse(sPBIncrementPerTimerInterval, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out result) == true)
                PBIncrementPerTimerInterval = result;
            else
                PBIncrementPerTimerInterval = .0015;

            string sPBPreviousPctComplete = SplashScreenXMLStorage.Percents;

            if (sPBPreviousPctComplete != "")
            {
                string[] times = sPBPreviousPctComplete.Split(null);
                previousCompletionFraction = new List<double>();

                for (int i = 0; i < times.Length; i++)
                {
                    double val;
                    if (double.TryParse(times[i], System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out val) == true)
                        previousCompletionFraction.Add(val);
                    else
                        previousCompletionFraction.Add(1.0);
                }
            }
            else
            {
                firstLaunch = true;
                timeRemaining = "";
            }
        }

        void StoreIncrements()
        {
            string percent = "";
            double elapsedMilliseconds = ElapsedMilliSeconds();
            for (int i = 0; i < actualTimes.Count; i++)
                percent += (actualTimes[i] / elapsedMilliseconds).ToString("0.####", System.Globalization.NumberFormatInfo.InvariantInfo) + " ";

            SplashScreenXMLStorage.Percents = percent;

            PBIncrementPerTimerInterval = 1.0 / actualTicks;

            SplashScreenXMLStorage.Interval = PBIncrementPerTimerInterval.ToString("#.00000", System.Globalization.NumberFormatInfo.InvariantInfo);
        }

        /// <summary>
        /// Gets the splash screen.
        /// </summary>
        /// <returns>The splash screen.</returns>
        public static SplashScreen GetSplashScreen()
        {
            return splash;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WarCollege.SplashScreen"/> class.
        /// </summary>
        public SplashScreen()
        {
            TimeRemaining = new Label();
            Status = new Label();
            ProgressBar = new ProgressBar
            {
                MaxValue = 1000,
                Width = 800,
                Style = "ProgressBar"
            };

            Background = new ImageView();
            Background.Image = Bitmap.FromResource("WarCollege.Resources.splash.jpg");
            ClientSize = new Size(800, 675);
            WindowStyle = WindowStyle.None;
            Resizable = false;
            BackgroundColor = Colors.White;
            //Content = background;
            Opacity = .0;
            UpdateTimer = new UITimer();
            UpdateTimer.Interval = (double)TIMER_INTERVAL / 1000;
            UpdateTimer.Elapsed += UpdateTimer_Tick;
            UpdateTimer.Start();

            var top = (int)(Screen.WorkingArea.Height / 2) - (ClientSize.Height / 2);
            var left = (int)(Screen.WorkingArea.Width / 2) - (ClientSize.Width / 2);

            Location = new Point(left, top);

            var layout = new TableLayout
            {
                Rows = 
                {
                    new TableRow(Background),
                    new TableRow(ProgressBar),
                    new TableRow(Status),
                    new TableRow(TimeRemaining),
                    null
                }
            };

            Content = layout;
        }

        /// <summary>
        /// Closes the splash screen if the user double clicks on it.
        /// </summary>
        /// <param name="e">Mouse events</param>
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            CloseForm();
        }

        void UpdateTimer_Tick(object sender, EventArgs e)
        {
            Status.Text = status;

            if (opacityIncrement > 0)
            {
                actualTicks++;
                if (Opacity < 1)
                    Opacity += opacityIncrement;
            }
            else
            {
                if (Opacity > 0)
                    Opacity += opacityIncrement;
                else
                {
                    StoreIncrements();
                    UpdateTimer.Stop();
                    Close();
                }
            }

            if (!firstLaunch && lastCompletionFraction < completionFraction)
            {
                ProgressBar.Indeterminate = false;
                lastCompletionFraction += PBIncrementPerTimerInterval;

                ProgressBar.Value = (int)Math.Round(Math.Min(lastCompletionFraction, 1f) * 1000f);

                int secondsLeft = 1 + (int)(TIMER_INTERVAL * ((1.0 - lastCompletionFraction) / PBIncrementPerTimerInterval)) / 1000;
                timeRemaining = (secondsLeft == 1) ? string.Format("1 second remaining") : string.Format("{0} seconds remaining", secondsLeft);
            }
            else
            {
                ProgressBar.Indeterminate = true;
            }

            TimeRemaining.Text = timeRemaining;
        }

        static class SplashScreenXMLStorage
        {
            static string storedValues = "splashscreen.xml";
            static string defaultPercents = "";
            static string defaultIncrement = ".015";
            static readonly string appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WarCollege");

            public static string Percents
            {
                get { return GetValue("Percents", defaultPercents); }
                set { SetValue("Percents", value); }
            }

            public static string Interval
            {
                get { return GetValue("Interval", defaultIncrement); }
                set { SetValue("Interval", value); }
            }

            static string StoragePath
            {
                get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WarCollege", storedValues); }
            }

            static string GetValue(string name, string defaultValue)
            {
                if (!File.Exists(StoragePath))
                    return defaultValue;

                try
                {
                    XmlDocument docXML = new XmlDocument();
                    docXML.Load(StoragePath);
                    XmlElement elValue = docXML.DocumentElement.SelectSingleNode(name) as XmlElement;
                    return (elValue == null) ? defaultValue : elValue.InnerText;
                }
                catch
                {
                    return defaultValue;
                }
            }

            public static void SetValue(string name, string stringValue)
            {
                XmlDocument docXML = new XmlDocument();
                XmlElement elRoot = null;
                if (!File.Exists(StoragePath))
                {
                    elRoot = docXML.CreateElement("root");
                    docXML.AppendChild(elRoot);
                }
                else
                {
                    docXML.Load(StoragePath);
                    elRoot = docXML.DocumentElement;
                }

                XmlElement value = docXML.DocumentElement.SelectSingleNode(name) as XmlElement;
                if (value == null)
                {
                    value = docXML.CreateElement(name);
                    elRoot.AppendChild(value);
                }

                value.InnerText = stringValue;

                if (!Directory.Exists(appDataFolder))
                    Directory.CreateDirectory(appDataFolder);

                docXML.Save(StoragePath);
            }
        }
    }
}
