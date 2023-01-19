using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using helloralph.Models;

namespace helloralph.ViewModels
{
	public partial class WeatherViewModel : BaseViewModel
	{
		HttpClient client;

		[ObservableProperty]
		WeatherModel weather;

		[ObservableProperty]
		string placeName;

		[ObservableProperty]
		bool isVisible;

        [ObservableProperty]
        DateTime date = DateTime.Now;

        public WeatherViewModel()
		{
			client = new HttpClient();
		}

		private async Task GetWeather(Location location)
		{
			var url =
				$"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&daily=weathercode,temperature_2m_max,temperature_2m_min&current_weather=true&timezone=America%2FChicago";
			var response = await client.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				using (var responseStream = await response.Content.ReadAsStreamAsync())
				{
					var data = await JsonSerializer.DeserializeAsync<WeatherModel>(responseStream);
					Weather = data;

					if (Weather.daily.time.Any())
					{
						for (int i = 0; i < Weather.daily.time.Count(); i++)
						{
							var daily2 = new Daily2
							{
								time = Weather.daily.time[i],
								temperature_2m_max = Weather.daily.temperature_2m_max[i],
								temperature_2m_min = Weather.daily.temperature_2m_min[i],
								weathercode = Weather.daily.weathercode[i]
							};
							Weather.daily2.Add(daily2);
						}
					}

					IsVisible = true;
				}
			}
		}
		
		private async Task<Location> GetCoordinates(string address)
		{
			Location result = null;
			try
			{
                var locations = await Geocoding.Default.GetLocationsAsync(address);

                if (locations is not null && locations.Any())
                    result = locations.FirstOrDefault();
            }
			catch (Exception ex)
			{

			}
			return result;
		}

        [RelayCommand]
        private async void Search(string address)
		{
			IsLoading = true;
			PlaceName = address;
			var location = await GetCoordinates(address);
			if (location is not null)
				await GetWeather(location);
			IsLoading = false;
		}
	}
}

