using System;
using CommunityToolkit.Mvvm.ComponentModel;
using helloralph.Models;

namespace helloralph.ViewModels
{
	public partial class BMICalculatorViewModel : BaseViewModel
	{
		[ObservableProperty]
		BMIModel bmi;

		public BMICalculatorViewModel()
		{
			Bmi = new BMIModel() { Height = 180, Weight = 73 };
		}
	}
}

