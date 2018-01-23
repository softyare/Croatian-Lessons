using CroatianLessons.Standard.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CroatianLessons.Standard.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LecturePage : ContentPage
    {
		public LecturePage(LecturePageViewModel vm)
		{
            BindingContext = vm;
			InitializeComponent ();
		}
	}
}