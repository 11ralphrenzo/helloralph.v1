using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace helloralph.ViewModels
{
	public partial class CodeQuotesViewModel : BaseViewModel
	{
		Random r = new Random();
		List<string> quotes = new List<string>();

		[ObservableProperty]
		string quote;

		[ObservableProperty]
		LinearGradientBrush lgb = new LinearGradientBrush();

		public CodeQuotesViewModel()
		{
			Title = "Code Quotes";
			Setup();
		}

		async void Setup()
		{
            await LoadMauiAsset();
            ChangeQuote();
        }

		async Task LoadMauiAsset()
		{
			using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
			using var reader = new StreamReader(stream);

			while (reader.Peek() != -1)
			{
				quotes.Add(reader.ReadLine());
			}
		}

		[RelayCommand]
		void ChangeQuote()
		{
			Quote = quotes[r.Next(quotes.Count)];
			ChangeBackground();
		}

        [RelayCommand]
		void ChangeBackground()
		{
			var startColor = System.Drawing.Color
				.FromArgb(
					r.Next(0, 256),
                    r.Next(0, 256),
                    r.Next(0, 256));
            var endColor = System.Drawing.Color
                .FromArgb(
                    r.Next(0, 256),
                    r.Next(0, 256),
                    r.Next(0, 256));
			var colors = ColorUtility.ColorControls.GetColorGradient(startColor, endColor, 6);

			var stopOffset = .0f;
			var stops = new GradientStopCollection();

			foreach(var c in colors)
			{
				stops.Add(new GradientStop(Color.FromArgb(c.Name), stopOffset));
				stopOffset += .2f;
			}

			var gradient = new LinearGradientBrush(stops,
				new Point(0, 0),
				new Point(1, 1));
			this.Lgb = gradient;
        }
    }
}

