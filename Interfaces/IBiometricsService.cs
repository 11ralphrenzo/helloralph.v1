using System;
using Plugin.Fingerprint.Abstractions;

namespace helloralph.Interfaces
{
	public interface IBiometricsService
	{
        Task<AuthenticationType> GetAuthenticationType();
        Task<bool> CheckIfEnabled();
        Task<FingerprintAvailability> GetAvailability();
        Task<FingerprintAuthenticationResult> Authenticate();
    }
}

