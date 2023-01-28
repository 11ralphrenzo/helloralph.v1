using System;
using helloralph.Interfaces;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace helloralph.Services
{
    public class BiometricsService : IBiometricsService
    {
        private IFingerprint fingerprint;
        private static BiometricsService _current;

        public static BiometricsService Current
        {
            get
            {
                if (_current == null)
                    _current = new BiometricsService();
                return _current;
            }
        }

        public BiometricsService()
        {
            this.fingerprint = CrossFingerprint.Current;
        }

        public async Task<AuthenticationType> GetAuthenticationType()
        {
            return await this.fingerprint.GetAuthenticationTypeAsync();
        }

        public async Task<bool> CheckIfEnabled()
        {
            return await this.fingerprint.IsAvailableAsync();
        }

        public async Task<FingerprintAvailability> GetAvailability()
        {
            return await this.fingerprint.GetAvailabilityAsync();
        }

        public async Task<FingerprintAuthenticationResult> Authenticate()
        {
            return await this.fingerprint.AuthenticateAsync(
                new AuthenticationRequestConfiguration("Authenticate", "For Testing")
                { AllowAlternativeAuthentication = true });
        }
    }
}

