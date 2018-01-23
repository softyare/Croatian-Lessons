using System.ComponentModel;

namespace CroatianLessons.Standard.ViewModels
{
    public interface IViewModel : INotifyPropertyChanged
    {
        void OnPropertyChanged(string propertyName);
    }
}
