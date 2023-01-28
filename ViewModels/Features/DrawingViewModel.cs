using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace helloralph.ViewModels
{
    public partial class DrawingViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<Color> drawColors = new ObservableCollection<Color>();

        [ObservableProperty]
        ObservableCollection<double> lineSizes = new ObservableCollection<double>();

        [ObservableProperty]
        Color selectedColor = Colors.Black;

        [ObservableProperty]
        double selectedLineSize = 3;

        public DrawingViewModel()
        {
            DrawColors.Add(Colors.Black);
            DrawColors.Add(Colors.Red);
            DrawColors.Add(Colors.Blue);
            DrawColors.Add(Colors.Green);
            DrawColors.Add(Colors.Brown);
            DrawColors.Add(Colors.Violet);
            DrawColors.Add(Colors.Yellow);
            DrawColors.Add(Colors.Pink);
            DrawColors.Add(Colors.SpringGreen);

            for (int x = 1; x <= 10; x++)
                LineSizes.Add(x);
        }

        [RelayCommand]
        void ColorSelected()
        {
            var s = 1;
        }
    }
}
