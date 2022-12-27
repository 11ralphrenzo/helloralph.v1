using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using helloralph.Models.DummyApi;
using helloralph.Utilities;
using helloralph.Utilities.DefaultHttpClient;
using helloralph.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace helloralph.ViewModels
{
    [QueryProperty("User", "Model")]
    public partial class UserDetailsViewModel : BaseViewModel
    {
        private readonly AppHttpClient client;
        [ObservableProperty]
        UserModel user;

        public UserDetailsViewModel(AppHttpClient client)
        {
            this.client = client;
        }
        public async void GetUserDetails()
        {
            try
            {
                if (User != null && !IsBusy)
                {
                    IsBusy = IsLoading = true;
                    if (HelperMethods.HasConnection())
                    {
                        var response = await this.client.DummyApi.GetAsync(new Uri(DummyAPI.GET_USER_BY_ID + User.Id));
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            var user = JsonSerializer.Deserialize<UserModel>(content, client.DefaultSerializerOptions);
                            this.User = user;
                        }
                    }
                }
            }
            finally
            {
                IsBusy = IsLoading = false;
            }
        }

        [RelayCommand]
        async void DeleteUser(UserModel model)
        {
            try
            {
                if (!IsBusy)
                {
                    IsBusy = true;
                    if (HelperMethods.HasConnection())
                    {
                        var answer = await Application.Current.MainPage.DisplayAlert("Delete User", "Are you sure you want to remove this user?", "Yes", "No");
                        if (answer)
                        {
                            var response = await this.client.DummyApi.DeleteAsync(new Uri(DummyAPI.GET_USER_BY_ID + User.Id));
                            if (response.IsSuccessStatusCode)
                            {
                                HelperMethods.DisplayAlert("Success", "User Deleted", "OK");
                                await Shell.Current.GoToAsync("..");
                            }
                        }
                    }
                }

            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async void GoToEditUser(UserModel model)
        {
            try
            {
                if (!IsBusy)
                {
                    IsBusy = true;
                    await Shell.Current.GoToAsync(nameof(AddEditUserPage), true,
                    new Dictionary<string, object>
                    {
                        { "Model", model },
                        { "IsCreating", false }
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
