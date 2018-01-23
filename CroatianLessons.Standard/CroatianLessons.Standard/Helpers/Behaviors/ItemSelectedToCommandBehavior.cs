using Xamarin.Forms;
using CroatianLessons.Standard.ViewModels;

namespace CroatianLessons.Standard.Helpers.Behaviors
{
    public class ItemSelectedToCommandBehavior : Behavior<ListView>
    {
        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var lv = sender as ListView;
            var vm = lv?.BindingContext as LecturePageViewModel;
            vm?.OpenLessonCommand.Execute(null);
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemSelected -= ListView_ItemSelected;
        }
    }
}
