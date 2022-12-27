using helloralph.ViewModels;

namespace helloralph.Views;

public partial class PickOrCapturePhotoPage : ContentPage
{
	public PickOrCapturePhotoPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		var vm = BindingContext as PickOrCapturePhotoViewModel;
		if (!vm.IsPageLoaded)
		{
			vm.IsPageLoaded = true;
			vm.HandleQueryProperty();

        }

    }
}