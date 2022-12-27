using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using helloralph.Models;
using helloralph.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloralph.ViewModels
{
    public partial class GeolocationViewModel : BaseViewModel
    {
        [ObservableProperty]
        List<BaseInfoModel> items;

        CancellationTokenSource _cancelTokenSource;

        [RelayCommand]
        public async void Tap(BaseInfoModel item)
        { 
            if (item == null)
                return;

            switch (item.Tag)
            {
                case Enums.GeolocationFeatures.GetLastLocation:
                    {
                        var result = "No Result";
                        try
                        {
                            Location location = await Geolocation.Default.GetLastKnownLocationAsync();

                            if (location != null)
                                result = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                        }
                        catch (FeatureNotSupportedException fnsEx)
                        {
                            // Handle not supported on device exception
                            result = "Location service is not supported.";
                        }
                        catch (FeatureNotEnabledException fneEx)
                        {
                            // Handle not enabled on device exception
                            result = "Location service is not enabled.";
                        }
                        catch (PermissionException pEx)
                        {
                            // Handle permission exception
                            result = "Location service permission denied.";
                        }
                        catch (Exception ex)
                        {
                            // Unable to get location
                            result = ex.Message;
                        }
                        HelperMethods.DisplayAlert("Last Known Location", result, "OK");
                    }
                    break;
                case Enums.GeolocationFeatures.GetCurrentLocation:
                    {
                        if (!IsBusy)
                        {
                            var result = "No Result";
                            try
                            {
                                IsBusy = true;

                                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                                _cancelTokenSource = new CancellationTokenSource();

                                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                                if (location != null)
                                    result = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                            }
                            catch (FeatureNotSupportedException fnsEx)
                            {
                                // Handle not supported on device exception
                                result = "Location service is not supported.";
                            }
                            catch (FeatureNotEnabledException fneEx)
                            {
                                // Handle not enabled on device exception
                                result = "Location service is not enabled.";
                            }
                            catch (PermissionException pEx)
                            {
                                // Handle permission exception
                                result = "Location service permission denied.";
                            }
                            catch (Exception ex)
                            {
                                // Unable to get location
                                result = ex.Message;
                            }
                            finally
                            {
                                IsBusy = false;
                            }
                            HelperMethods.DisplayAlert("Current Location", result, "OK");
                        }
                    }
                    break;
            }
        }

        public GeolocationViewModel()
        {
            Title = Utilities.Constants.GEOLOCATION;
            Setup();
        }

        private void Setup()
        {
            Items = new List<BaseInfoModel>
                {
                    new BaseInfoModel { Value = "Get the last known location.", Name = "Tap to Check", Tag = Enums.GeolocationFeatures.GetLastLocation, Definition = "The device may have cached the most recent location of the device. Use the GetLastKnownLocationAsync method to access the cached location, if available. This is often faster than doing a full location query, but can be less accurate. If no cached location exists, this method returns null." },
                    new BaseInfoModel { Value = "Get current location.", Name = "Tap to Check", Tag = Enums.GeolocationFeatures.GetCurrentLocation, Definition = "While checking for the last known location of the device may be quicker, it can be inaccurate. Use the GetLocationAsync method to query the device for the current location. You can configure the accuracy and timeout of the query. It's best to the method overload that uses the GeolocationRequest and CancellationToken parameters, since it may take some time to get the device's location." }
                };
        }
    }
}
