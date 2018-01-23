using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CroatianLessons.Standard.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestingPage : ContentPage
	{
		public TestingPage (INotifyPropertyChanged vm)
        {
            BindingContext = vm;
            InitializeComponent ();
        }
	}
}