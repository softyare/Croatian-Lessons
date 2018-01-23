using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using CroatianLessons.Standard.Helpers;
using Xamarin.Forms;
using System.Diagnostics;
using CroatianLessons.Standard.ViewModels;

namespace CroatianLessons.Settings
{
    public static class Settings
    {
        public static CultureInfo CurrentCultureInfo
        {
            get
            {
                try
                {
                    return DependencyService.Get<ILocalize>().GetCultureInfo();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return new CultureInfo("en");
                }
            }
            set
            {
                DependencyService.Get<ILocalize>().SetLocale(value);
            }
        }

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static List<string> SupportedLanguageShortCodes
        {
            get
            {
                return new List<string>()
                {
                    "en", "de", "fr", "it", "ru"
                };
            }
        }

        public static bool IsFirstTime
        {
            get => AppSettings.GetValueOrDefault(nameof(IsFirstTime), true, "clSettings");
            set => AppSettings.AddOrUpdateValue(nameof(IsFirstTime), value, "clSettings");
        }
        
        public static string AppLanguageCode
        {
            get => AppSettings.GetValueOrDefault(nameof(AppLanguageCode), String.Empty, "clSettings");
            set => AppSettings.AddOrUpdateValue(nameof(AppLanguageCode), value, "clSettings");
        }

        public static bool IsLanguageSet
        {
            get => AppSettings.Contains(nameof(AppLanguageCode));
        }

        public static bool IsNativeLanguageSupported
        {
            get => AppSettings.GetValueOrDefault(nameof(IsNativeLanguageSupported), false, "clSettings");
            set => AppSettings.AddOrUpdateValue(nameof(IsNativeLanguageSupported), value, "clSettings");
        }
    }
}
