using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CroatianLessons.Standard.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LecturesPage : ContentPage
	{
		public LecturesPage ()
		{
            var vm = new ViewModels.LecturesPageViewModel() { Navigation = this.Navigation };
            BindingContext = vm;
			InitializeComponent ();
		}
	}
}