using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WarCollege.Model
{
    public class ExperiencePoints : INotifyPropertyChanged
    {
        private int _totalExperience;
        private int _currentExperience;

        public int TotalExperience
        {
            get => _totalExperience;
            private set
            {
                if (_totalExperience != value)
                {
                    _totalExperience = value;
                    RaisePropertyChagned();
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
                    RaisePropertyChagned();
                }
            }
        }

        public void AddExperience(int value)
        {
            TotalExperience += value;
            CurrentExperience += value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChagned([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
