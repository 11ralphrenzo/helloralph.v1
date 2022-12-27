using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using helloralph.Models;
using helloralph.Utilities;
using helloralph.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace helloralph.ViewModels
{
    public partial class RESTIntegrationViewModel : BaseViewModel
    {
        public RESTIntegrationViewModel()
        {
            Title = Constants.SAMPLE_REST;
            Setup();
        }

        [ObservableProperty]
        ObservableCollection<RESTApiModel> restApis = new ObservableCollection<RESTApiModel>();

        void Setup()
        {
            restApis.Add(new RESTApiModel { Name = "Tap to Check", Value = "USERS", Url = DummyAPI.GET_USERS });
        }

        [RelayCommand]
        async Task ExecuteRestAsync(RESTApiModel model)
        {
            if (model == null)
                return;
            await Shell.Current.GoToAsync(nameof(ExecuteRESTPage), true,
                new Dictionary<string, object>
                {
                    { "Model", model }
                });
        }
    }
}
