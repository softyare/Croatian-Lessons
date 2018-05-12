using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CroatianLessons.Standard.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccessoriesPage : ContentPage
	{
		public AccessoriesPage ()
		{
            var vm = new ViewModels.AccessoriesPageViewModel() { Navigation = this.Navigation };
            BindingContext = vm;
            InitializeComponent();
        }
	}
}