using System;
using System.ComponentModel;

namespace ToastAppStudio.MVVM
{
    public interface IViewModel
    {
        bool IsInBackground
        {
            get; set;
        }

        object Parameters
        {
            get; set;
        }

        void SetParameters<T>(T parameters);
    }
}