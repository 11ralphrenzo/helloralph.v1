using System;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using helloralph.Utilities;
using helloralph.Services;

namespace helloralph.ViewModels
{
	public partial class BiometricsViewModel : BaseViewModel
	{
        [ObservableProperty]
        bool isAvailable;

        [ObservableProperty]
        bool isAuthenticated;

        [ObservableProperty]
        string pluginAvailabilityMessage;

        [ObservableProperty]
        string authenticationTypeMessage;

        [ObservableProperty]
        string availabilityMessage;

        [ObservableProperty]
        string isAuthenticatedMessage;

        [ObservableProperty]
        string authenticationStatusMessage;

        [ObservableProperty]
        string authenticationErrorMessage;
        private BiometricsService biometrics;

        public BiometricsViewModel()
		{
            this.biometrics = new BiometricsService();
        }

        [RelayCommand]
        async void StartAuthentication()
        {
            HelperMethods.Toast("Getting Authentication Type...");
            var type = await biometrics.GetAuthenticationType();
            AuthenticationTypeMessage = type.ToString();
            if (type == AuthenticationType.None)
            {
                AuthenticationErrorMessage = "Face/Fingerprint not available";
                return;
            }

            HelperMethods.Toast("Checking if enabled...");
            var isEnabled = await biometrics.CheckIfEnabled();
            PluginAvailabilityMessage = isEnabled.ToString();
            if (!isEnabled)
            {
                AuthenticationErrorMessage = "Face/Fingerprint not enabled or registered.";
                return;
            }

            HelperMethods.Toast("Checking availability...", false);
            var availability = await biometrics.GetAvailability();
            if (availability != FingerprintAvailability.Available)
            {
                AvailabilityMessage = availability.ToString();
                return;
            }

            HelperMethods.Toast("Authenticating...", false);
            var authresult = await biometrics.Authenticate();
            IsAuthenticatedMessage = authresult.Authenticated.ToString();
            AuthenticationStatusMessage = authresult.Status.ToString();
            AuthenticationErrorMessage = authresult.ErrorMessage;
        }
	}
}

