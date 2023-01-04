using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloralph.Utilities
{
    public static class Enums
    {
        public enum BatteryFeatureType
        { 
            Status,
            LowPower,
            PowerSource
        }

        public enum GeocodingFeatures
        { 
            Geocoding,
            ReverseGeocoding
        }

        public enum GeolocationFeatures
        { 
            GetLastLocation,
            GetCurrentLocation
        }
        public enum MediaPickerFeatures
        {
            PickPhoto,
            CapturePhoto,
            PickVideo,
            CaptureVideo
        }

        public enum GameStatus
        {
            Start,
            Playing,
            Lost,
            Won
        }
    }
}
