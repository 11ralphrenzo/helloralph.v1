using helloralph.ViewModels;

namespace helloralph.Views;

public partial class GeocodingPage : ContentPage
{
	private readonly GeocodingViewModel vm;

	public GeocodingPage(GeocodingViewModel vm)
	{
		InitializeComponent();
		BindingContext = this.vm = vm;
	}
}