using System;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace helloralph.ViewModels
{
	public partial class BiometricsViewModel : BaseViewModel
	{
        private readonly IFingerprint fingerprint;

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

        public BiometricsViewModel()
		{
            this.fingerprint = CrossFingerprint.Current;
        }

        async Task<bool> GetAuthenticationType()
        {
            Toast.Make("Getting Authentication Type", CommunityToolkit.Maui.Core.ToastDuration.Short);
            var result = await this.fingerprint.GetAuthenticationTypeAsync();
            AuthenticationTypeMessage = result.ToString();
            return result != AuthenticationType.None;
        }

        async Task<bool> CheckIsAvailable()
        {
            Toast.Make("Preparing", CommunityToolkit.Maui.Core.ToastDuration.Short);
            var result = await this.fingerprint.IsAvailableAsync();
            PluginAvailabilityMessage = result.ToString(); 
            return result;
        }

        async Task<bool> GetAvailability()
        {
            Toast.Make("Getting Availability", CommunityToolkit.Maui.Core.ToastDuration.Short);
            var result = await this.fingerprint.GetAvailabilityAsync();
            AvailabilityMessage = result.ToString();
            return result == FingerprintAvailability.Available;
        }

        async Task<bool> Authenticate()
        {
            Toast.Make("Authenticating...", CommunityToolkit.Maui.Core.ToastDuration.Short);
            var result = await this.fingerprint.AuthenticateAsync(
                new AuthenticationRequestConfiguration("Authenticate", "For Testing")
                { AllowAlternativeAuthentication = true });
            IsAuthenticatedMessage = result.Authenticated.ToString();
            AuthenticationStatusMessage = result.Status.ToString();
            authenticationErrorMessage = result.ErrorMessage;
            return result.Authenticated;
        }

        [RelayCommand]
        async void StartAuthentication()
        {
            if (await GetAuthenticationType())
                if (await CheckIsAvailable())
                    if (await GetAvailability())
                    {
                        IsAuthenticated = await Authenticate();
                    }
        }
	}
}

