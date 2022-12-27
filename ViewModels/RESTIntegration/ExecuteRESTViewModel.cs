using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using helloralph.Models;
using helloralph.Models.DummyApi;
using helloralph.Utilities;
using helloralph.Utilities.DefaultHttpClient;
using helloralph.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace helloralph.ViewModels
{
    [QueryProperty("Model", "Model")]
    public partial class ExecuteRESTViewModel : BaseViewModel
    {
        private readonly AppHttpClient client;
        [ObservableProperty]
        RESTApiModel model;

        [ObservableProperty]
        ObservableCollection<UserModel> users;

        public ExecuteRESTViewModel(AppHttpClient client)
        {
            this.client = client;
        }

        public async void ExecuteApi()
        {
            try
            {
                IsBusy = IsLoading = true;
                if (HelperMethods.HasConnection())
                {
                    var response = await client.DummyApi.GetAsync(new Uri(model.Url));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var result = JsonSerializer.Deserialize<ListModel>(content, client.DefaultSerializerOptions);
                        Users = new ObservableCollection<UserModel>(result.Data);
                    }
                }
            }
            finally
            {
                IsBusy = IsLoading = false;
            }
        }

        [RelayCommand]
        public async void GoToUserDetails(UserModel model)
        {
            try
            {
                if (!IsBusy && model != null)
                {
                    IsBusy = true;
                    await Shell.Current.GoToAsync(nameof(UserDetailsPage), true,
                        new Dictionary<string, object>
                        {
                        { "Model", model }
                        });
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async void GoToAddUser()
        {
            try
            {
                if (!IsBusy)
                {
                    IsBusy = true;
                    await Shell.Current.GoToAsync(nameof(AddEditUserPage), true,
                        new Dictionary<string, object>
                        {
                        { "IsCreating", true }
                        });
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
