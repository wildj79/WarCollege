using Eto.Drawing;
using Eto.Forms;
using NLog;
using System;

namespace WarCollege.Commands
{
    public class SaveAllCharacters : Command, ISaveAllCharactersCommand
    {
        #region Fields

        private readonly ILogger _logger;

        #endregion

        #region Constructors

        public SaveAllCharacters(ILogger logger)
        {
            _logger = logger;

            MenuText = "Save All";
            ToolBarText = "Save All";
            Image = Icon.FromResource("WarCollege.Resources.disk_multiple.png");
            Shortcut = Application.Instance.CommonModifier | Keys.Shift | Keys.S;
        }

        #endregion

        #region Utilities
        #endregion

        #region Methods
        protected override void OnExecuted(EventArgs e)
        {
            base.OnExecuted(e);
            _logger.Trace("Start SaveAllCharacters.OnExecuted()");

            MessageBox.Show("Saved all characters!");

            _logger.Trace("End SaveAllCharacters.OnExecuted()");
        }
        #endregion

    }
}
