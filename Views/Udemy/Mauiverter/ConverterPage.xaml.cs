namespace helloralph.Views;

public partial class ConverterPage : ContentPage
{
	public ConverterPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var vm = this.BindingContext as ViewModels.ConverterViewModel;
        if (!vm.IsPageLoaded)
        {
            vm.Setup();
            vm.IsPageLoaded = true;
        }
    }
}
