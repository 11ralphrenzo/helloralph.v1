using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace helloralph.ViewModels
{
	public partial class PerfectPayViewModel : BaseViewModel
	{
		[ObservableProperty]
		int numPerson = 1;

		[ObservableProperty]
		int bill;

		[ObservableProperty]
		int tip = 0;

		[ObservableProperty]
		int tipByPerson;

        [ObservableProperty]
        int subTotal;

        [ObservableProperty]
        int totalByPerson;

        public PerfectPayViewModel()
		{
		}

		void UpdateComputationDisplay()
		{
			try
			{
				var totalTip = (Bill * Tip) / 100;

				TipByPerson = (totalTip / NumPerson);

				SubTotal = Bill / NumPerson;

				TotalByPerson = (Bill + totalTip) / NumPerson;
			}
			catch
			{

			}
		}

		[RelayCommand]
		void ChangeTip(string choice = null)
		{
			Tip = int.Parse(choice);
		}

		[RelayCommand]
		void ChangeNumPerson(string choice)
		{
			bool isAdd = bool.Parse(choice);
			if (isAdd)
				NumPerson++;
			else
			{
				if (NumPerson > 1)
					NumPerson--;
			}	
		}

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

			switch (e.PropertyName)
			{
                //case nameof(Bill):
                case nameof(Tip):
                case nameof(NumPerson):
                    UpdateComputationDisplay();
					break;
			}
        }
    }
}

