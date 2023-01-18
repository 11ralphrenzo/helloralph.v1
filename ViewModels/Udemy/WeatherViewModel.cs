using System;
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
			var location = await GetCoordinates(address);
			if (location is not null)
				await GetWeather(location);
		}
	}
}

