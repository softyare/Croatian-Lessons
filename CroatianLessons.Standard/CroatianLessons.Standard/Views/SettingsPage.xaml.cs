using CroatianLessons.Standard.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CroatianLessons.Standard.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
        {
            BindingContext = new SettingsPageViewModel(this);
            InitializeComponent ();
		}
    }
}