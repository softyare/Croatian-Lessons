using CroatianLessons.Standard.Helpers;
using CroatianLessons.Standard.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;

namespace CroatianLessons.Standard.ViewModels
{
    public class SettingsPageViewModel : IViewModel
    {
        public SettingsPageViewModel(Page p)
        {
            page = p;
            selectedLangCode = Settings.Settings.AppLanguageCode;
        }

        private Page page;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string selectedLangCode;
        public string SelectedLangCode
        {
            get
            {
                return selectedLangCode;
            }
            set
            {
                selectedLangCode = value;
                OnPropertyChanged(nameof(SelectedLangCode));
                ChangeLanguage(selectedLangCode);
            }
        }

        private async void ChangeLanguage(string value)
        {
            string title = Resources.AppResources.LanguageChangeDialogTitle;
            string question = Resources.AppResources.LanguageChangeDialogText.Replace("xxxx", CultureInfo.GetCultureInfoByIetfLanguageTag(value).DisplayName);
            string yes = Resources.AppResources.AnswerYes;
            string no = Resources.AppResources.AnswerNo;
            var answer = await page.DisplayAlert(title, question, yes, no);
            if (answer == true)
            {
                Settings.Settings.AppLanguageCode = value.ToLower();
                Settings.Settings.CurrentCultureInfo = new CultureInfo(value.ToLower());
                DependencyService.Get<ILocalize>().SetLocale(Settings.Settings.CurrentCultureInfo);
                Resources.AppResources.Culture = Settings.Settings.CurrentCultureInfo;

                App.Current.MainPage = new StartPage();
            }
        }

        public string CurrentLanguage
        {
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
                    return Resources.AppResources.LanguageFoundInfoSettings;
                }
                else
                {
                    return Resources.AppResources.LanguageNotFoundInfoSettings;
                }
            }
        }
        
    }
}
