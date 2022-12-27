using helloralph.ViewModels;

namespace helloralph.Views;

public partial class ExecuteRESTPage : ContentPage
{
	private readonly ExecuteRESTViewModel vm;

	public ExecuteRESTPage(ExecuteRESTViewModel vm)
	{
		InitializeComponent();
		BindingContext = this.vm = vm;
	}

    protected override void OnAppearing()
	{
		base.OnAppearing();
        vm.ExecuteApi();
    }
}