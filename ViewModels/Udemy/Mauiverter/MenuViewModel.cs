using System;
using CommunityToolkit.Mvvm.Input;

namespace helloralph.ViewModels
{
	public partial class MenuViewModel : BaseViewModel
	{
		public MenuViewModel()
		{
		}

		[RelayCommand]
		async void GoTo(string choice)
		{
			await Shell.Current
				.GoToAsync($"{nameof(Views.ConverterPage)}?Quantity={choice}");
		}
	}
}

