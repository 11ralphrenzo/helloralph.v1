using helloralph.ViewModels;

namespace helloralph.Views;

public partial class GetLocationPage : ContentPage
{
	private readonly GetLocationViewModel vm;

	public GetLocationPage(GetLocationViewModel vm)
	{
		InitializeComponent();
		BindingContext = this.vm = vm;
	}
}