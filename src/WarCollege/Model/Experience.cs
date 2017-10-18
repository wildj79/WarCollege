namespace WarCollege.Model
{
    public class ExperiencePoints : Model
    {
        #region Fields

        private int _totalExperience;
        private int _currentExperience;

        #endregion

        #region Properties

        public int TotalExperience
        {
            get => _totalExperience;
            private set
            {
                if (_totalExperience != value)
                {
                    _totalExperience = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int CurrentExperience
        {
            get => _currentExperience;
            set
            {
                if (_currentExperience != value)
                {
                    _currentExperience = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Methods

        public void AddExperience(int value)
        {
            TotalExperience += value;
            CurrentExperience += value;
        }

        #endregion
    }
}
