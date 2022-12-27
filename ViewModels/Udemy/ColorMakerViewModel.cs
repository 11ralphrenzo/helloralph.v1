using System;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace helloralph.ViewModels
{
	public partial class ColorMakerViewModel : BaseViewModel
	{
		Random rdm = new Random();

		[ObservableProperty]
		Color selectedColor;

		[ObservableProperty]
		string selectedColorStr;

		[ObservableProperty]
		int redVal = 128;

        [ObservableProperty]
        int greenVal = 128;

        [ObservableProperty]
        int blueVal = 128;

        public ColorMakerViewModel()
		{
            this.GenerateRandomColor();
        }

        public void SliderDragged()
		{
			this.ChangeColor(RedVal, GreenVal, BlueVal);
		}

		void ChangeColor(int r, int g, int b)
		{
            SelectedColor = Color.FromRgb(r, g, b);
			SelectedColorStr = SelectedColor.ToHex();
			Toast.Make($"Color Hex: {SelectedColorStr}", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }

		[RelayCommand]
		void GenerateRandomColor()
		{
            this.ChangeColor(
				RedVal = rdm.Next(0, 255),
				GreenVal = rdm.Next(0, 255),
				BlueVal = rdm.Next(0, 255));
        }

		[RelayCommand]
		async void CopyColorHex()
		{
			await Clipboard.SetTextAsync(SelectedColorStr);
            await Toast.Make($"Copied to Clipboard: {SelectedColorStr}", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }
}

