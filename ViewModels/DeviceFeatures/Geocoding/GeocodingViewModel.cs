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

namespace helloralph.ViewModels
{
    public partial class GeocodingViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<GeocodingModel> items;

        public GeocodingViewModel()
        {
            Title = Utilities.Constants.GEOCODING;
            Setup();
        }

        private void Setup()
        {
            Items = new ObservableCollection<GeocodingModel>()
            {
                new GeocodingModel { Name = "Tap to Check", Value = "Location Search", Tag = Enums.GeocodingFeatures.Geocoding },
            };
        }

        [RelayCommand]
        async void GoTo(GeocodingModel model)
        {
            try
            {
                if (!IsBusy && model != null)
                { 
                    IsBusy = true;
                    string page = string.Empty;
                    switch(model.Tag)
                    {
                        case Enums.GeocodingFeatures.Geocoding:
                            page = nameof(GetLocationPage);
                            break;
                        case Enums.GeocodingFeatures.ReverseGeocoding:
                            page = nameof(GetLocationPage);
                            break;
                    }
                    await Shell.Current.GoToAsync(page, true);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
