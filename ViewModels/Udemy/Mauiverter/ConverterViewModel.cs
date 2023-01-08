using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UnitsNet;

namespace helloralph.ViewModels
{
	[QueryProperty("QuantityName", "Quantity")]
	public partial class ConverterViewModel : BaseViewModel
	{
		[ObservableProperty]
		string quantityName;

		[ObservableProperty]
		string currrentFromMeasure;

        [ObservableProperty]
        string currrentToMeasure;

        [ObservableProperty]
        double fromValue;

        [ObservableProperty]
        double toValue;

        [ObservableProperty]
		ObservableCollection<string> fromMeasures = new ObservableCollection<string>();

        [ObservableProperty]
        ObservableCollection<string> toMeasures = new ObservableCollection<string>();

        public ConverterViewModel()
		{
			Title = string.Empty;
		}

		public void Setup()
		{
			var m = LoadMeasures();
            FromMeasures = ToMeasures = m;
            FromValue = 1;
            CurrrentFromMeasure = m.FirstOrDefault();
            CurrrentToMeasure = m.Skip(1).FirstOrDefault();
        }

		[RelayCommand]
		void Convert()
		{
			if (!string.IsNullOrEmpty(CurrrentFromMeasure) && !string.IsNullOrEmpty(CurrrentToMeasure))
			{
				var v = UnitConverter
					.ConvertByName(FromValue, QuantityName, CurrrentFromMeasure, CurrrentToMeasure);
				ToValue = v;
			}
		}

		ObservableCollection<string> LoadMeasures()
		{
			var types = Quantity.Infos
				.FirstOrDefault(x => x.Name == QuantityName)
				.UnitInfos
				.Select(u => u.Name)
				.ToList();
			return new ObservableCollection<string>(types);
		}
    }
}

