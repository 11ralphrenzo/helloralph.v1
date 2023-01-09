using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dangl.Calculator;

namespace helloralph.ViewModels
{
    public partial class CalculatorViewModel : BaseViewModel
    {
        [ObservableProperty]
        string formula;

        [ObservableProperty]
        string result = "0";

        public CalculatorViewModel()
        {
        }

        [RelayCommand]
        void Operation(string number)
        {
            Formula += number;
        }

        [RelayCommand]
        void Reset()
        {
            Formula = string.Empty;
            Result = "0";
        }

        [RelayCommand]
        void Backspace()
        {
            if (!string.IsNullOrEmpty(Formula))
            {
                Formula = Formula.Substring(0, Formula.Length - 1);
            }
        }

        [RelayCommand]
        void Calculate()
        {
            if (!string.IsNullOrEmpty(Formula))
            {
                var calculation = Calculator.Calculate(Formula);
                Result = calculation.Result.ToString();
            }
        }
    }
}

