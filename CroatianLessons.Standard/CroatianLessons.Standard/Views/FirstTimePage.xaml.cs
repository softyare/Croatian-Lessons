using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CroatianLessons.Standard.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FirstTimePage : ContentPage
	{
		public FirstTimePage ()
		{
            BindingContext = new ViewModels.FirstPageViewModel();
			InitializeComponent ();
		}
	}
}