using System;
using System.Collections.ObjectModel;

namespace helloralph.Models
{
    public class CurrentWeather
    {
        public double temperature { get; set; }
        public double windspeed { get; set; }
        public double winddirection { get; set; }
        public int weathercode { get; set; }
        public string time { get; set; }
    }

    public class Daily
    {
        public List<string> time { get; set; }
        public List<int> weathercode { get; set; }
        public List<double> temperature_2m_max { get; set; }
        public List<double> temperature_2m_min { get; set; }
    }

    public class Daily2
    {
        public string time { get; set; }
        public int weathercode { get; set; }
        public double temperature_2m_max { get; set; }
        public double temperature_2m_min { get; set; }
    }

    public class DailyUnits
    {
        public string time { get; set; }
        public string weathercode { get; set; }
        public string temperature_2m_max { get; set; }
        public string temperature_2m_min { get; set; }
    }

    public class WeatherModel
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public double elevation { get; set; }
        public CurrentWeather current_weather { get; set; }
        public DailyUnits daily_units { get; set; }
        public Daily daily { get; set; }
        public ObservableCollection<Daily2> daily2 { get; set; }
            = new ObservableCollection<Daily2>();
    }
}
