using helloralph.ViewModels;

namespace helloralph.Views;

public partial class MediaPickerPage : ContentPage
{
	private readonly MediaPickerViewModel vm;

	public MediaPickerPage(MediaPickerViewModel vm)
	{
        InitializeComponent();
        BindingContext = this.vm = vm;
    }

    protected async override void OnAppearing()
	{
		base.OnAppearing();

        if (!vm.IsPageLoaded)
        {
			vm.LoadList();
			vm.IsPageLoaded = true;
		}
    }
}