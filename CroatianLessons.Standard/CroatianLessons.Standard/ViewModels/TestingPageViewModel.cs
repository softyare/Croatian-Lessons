using System.ComponentModel;

namespace CroatianLessons.Standard.ViewModels
{
    class TestingPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string pName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(pName)));
        }

        public bool IsFirst
        {
            get
            {
                return Settings.Settings.IsFirstTime; 
            }
            set
            {
                Settings.Settings.IsFirstTime = value;
                OnPropertyChanged(nameof(IsFirst));
                OnPropertyChanged(nameof(IsFirstTimeText));
            }
        }

        public string IsFirstTimeText
        {
            get
            {
                OnPropertyChanged(nameof(IsFirstTimeText));
                return IsFirst ? "It's first time" : "Already visited";
            }
        }
    }
}
