using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace helloralph.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;

        [ObservableProperty]
        string message;

        [ObservableProperty]
        bool isBusy;

        [ObservableProperty]
        bool isLoading;

        [ObservableProperty]
        bool isPageLoaded;

        bool isNotBusy => !isBusy;
    }
}
