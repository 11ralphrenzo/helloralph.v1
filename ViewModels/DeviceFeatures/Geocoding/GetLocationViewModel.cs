using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using helloralph.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloralph.ViewModels
{
    public partial class GetLocationViewModel : BaseViewModel
    {
        [ObservableProperty]
        string address;

        [ObservableProperty]
        ObservableCollection<GeocodingLocationModel> locations = new ObservableCollection<GeocodingLocationModel>();

        [RelayCommand]
        async void Search(string s)
        {
            try
            {
                if (!IsBusy && !string.IsNullOrEmpty(s))
                {
                    IsBusy = true;
                    Locations.Clear();
                    var locs = await Geocoding.Default.GetLocationsAsync(s);

                    if (locs != null)
                    {
                        foreach (var loc in locs)
                        {
                            var rg = await Geocoding.Default.GetPlacemarksAsync(loc.Latitude, loc.Longitude);
                            var placemark = rg.FirstOrDefault();
                            Locations.Add(new GeocodingLocationModel { Placemark = placemark });
                        }
                    }                        
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        public GetLocationViewModel()
        {

        }
    }
}
