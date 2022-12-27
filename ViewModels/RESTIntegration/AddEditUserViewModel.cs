using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using helloralph.Models.DummyApi;
using helloralph.Utilities;
using helloralph.Utilities.DefaultHttpClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace helloralph.ViewModels
{
    [QueryProperty("User", "Model")]
    [QueryProperty("IsCreating", "IsCreating")]
    public partial class AddEditUserViewModel : BaseViewModel
    {
        private readonly AppHttpClient client;

        [ObservableProperty]
        UserModel user;

        [ObservableProperty]
        bool isCreating = true;

        [ObservableProperty]
        string title;

        public AddEditUserViewModel(AppHttpClient client)
        {
            this.client = client;                
        }

        [RelayCommand]
        async void SelectTitle()
        {
            var answer = await Application.Current.MainPage.DisplayActionSheet("Select", "Cancel", null, new string[] { "Mr", "Mrs", "Ms" });
            if (string.IsNullOrEmpty(answer))
                return;
            User.Title = answer;
            OnPropertyChanged(nameof(User));
        }

        [RelayCommand]
        async void UpdateUser()
        {
            try
            {
                if (!IsBusy && User != null)
                {
                    IsBusy = true;
                    var json = JsonSerializer.Serialize(User, this.client.DefaultSerializerOptions);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response;
                    if (IsCreating)
                        response = await this.client.DummyApi.PostAsync(DummyAPI.CREATE_USER, content);
                    else
                        response = await this.client.DummyApi.PutAsync(DummyAPI.GET_USER_BY_ID + User.Id, content);
                    if (response.IsSuccessStatusCode)
                    {
                        HelperMethods.DisplayAlert("Success", "User details has been updated.", "OK");
                        await Shell.Current.GoToAsync("..");
                    }
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
