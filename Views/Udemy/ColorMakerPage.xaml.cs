using System.Diagnostics;
using helloralph.ViewModels;

namespace helloralph.Views;

public partial class ColorMakerPage : ContentPage
{
    private ColorMakerViewModel vm;

    public ColorMakerPage()
	{
		InitializeComponent();
		this.vm = this.BindingContext as ViewModels.ColorMakerViewModel;
    }

    void Slider_DragCompleted(System.Object sender, System.EventArgs e)
    {
		this.vm.SliderDragged();
    }
}
