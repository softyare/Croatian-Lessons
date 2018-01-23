using Xamarin.Forms;
using CroatianLessons.Standard.ViewModels;
using System.Windows.Input;

namespace CroatianLessons.Standard.Helpers.Behaviors
{
    public class ItemTappedToCommandBehavior : Behavior<ListView>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                propertyName: "Command",
                returnType: typeof(ICommand),
                declaringType: typeof(ItemTappedToCommandBehavior));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.ItemTapped += Bindable_ItemTapped;
            bindable.BindingContextChanged += Bindable_BindingContextChanged;
        }

        private void Bindable_BindingContextChanged(object sender, System.EventArgs e)
        {
            var lv = sender as ListView;
            BindingContext = lv?.BindingContext;
        }

        private void Bindable_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Command.Execute(null);
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemTapped -= Bindable_ItemTapped;
            bindable.BindingContextChanged -= Bindable_BindingContextChanged;
        }
    }
}
