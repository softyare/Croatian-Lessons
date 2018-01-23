using CroatianLessons.Standard.Views;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace CroatianLessons.Standard
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (Settings.Settings.IsFirstTime)
            {
                Settings.Settings.IsFirstTime = false;
                InitializeApp();
                MainPage = new FirstTimePage();
            }
            else
            {
                MainPage = new StartPage();
            }

        }

        public static void InitializeApp()
        {
            string langcode;
            if (!Settings.Settings.IsLanguageSet)
            {
                langcode = Settings.Settings.CurrentCultureInfo.TwoLetterISOLanguageName;

                if (Settings.Settings.SupportedLanguageShortCodes.Contains(langcode))
                {
                    Settings.Settings.AppLanguageCode = langcode;
                    Settings.Settings.IsNativeLanguageSupported = true;
                }
                else
                {
                    Settings.Settings.AppLanguageCode = "en";
                    Settings.Settings.IsNativeLanguageSupported = false;
                }
            }
        }

        protected override void OnStart ()
		{
            AppCenter.Start("ios=bffba8bc-9a29-4f93-8d32-ab4d3dfff244;" +
                   "android=5aa588fc-4e12-4db4-b543-de5b99bf6ca3;",
                   typeof(Analytics), typeof(Crashes));
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
