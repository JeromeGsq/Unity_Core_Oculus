using System.ComponentModel;

namespace ToastAppStudio.MVVM
{
    public interface IView
    {
        void OnPropertyChanged(object sender, PropertyChangedEventArgs property);
    }
}