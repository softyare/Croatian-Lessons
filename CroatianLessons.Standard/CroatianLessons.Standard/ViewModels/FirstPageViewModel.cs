using CroatianLessons.Standard.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;

namespace CroatianLessons.Standard.ViewModels
{
    public class FirstPageViewModel : IViewModel
    {
        private string selectedLanguageCode;

        public FirstPageViewModel()
        {
            StartCommand = new Command(StartLearning);
            if (SupportedLangCodes.Contains(CurrentLanguageShortCode))
                selectedLanguageCode = CurrentLanguageShortCode;
            else
                selectedLanguageCode = "en";
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string SelectedLangCode
        {
            get { return selectedLanguageCode; }
            set
            {
                selectedLanguageCode = value;
                Settings.Settings.AppLanguageCode = selectedLanguageCode.ToLower();
                Settings.Settings.CurrentCultureInfo = new CultureInfo(selectedLanguageCode);
                DependencyService.Get<ILocalize>().SetLocale(Settings.Settings.CurrentCultureInfo);
                Resources.AppResources.Culture = Settings.Settings.CurrentCultureInfo;
                OnPropertyChanged(nameof(SelectedLangCode));
                OnPropertyChanged(nameof(CurrentLanguage));
                OnPropertyChanged(nameof(LanguageInfoMessage));
            }
        }

        public string CurrentLanguage {
            get
            {
                return Settings.Settings.CurrentCultureInfo.NativeName;
            }
        }

        public string CurrentLanguageShortCode
        {
            get
            {
                return Settings.Settings.CurrentCultureInfo.TwoLetterISOLanguageName;
            }
        }

        public List<string> SupportedLangCodes
        {
            get
            {
                return Settings.Settings.SupportedLanguageShortCodes;
            }
        }

        public string LanguageInfoMessage
        {
            get
            {
                if (Settings.Settings.IsNativeLanguageSupported)
                {
                    return Resources.AppResources.LanguageFoundInfo;
                }
                else
                {
                    return Resources.AppResources.LanguageNotFoundInfo;
                }
            }
        }

        public Command StartCommand { get; set; }

        public void StartLearning()
        {
            App.Current.MainPage = new Views.StartPage();
        }

    }
}
