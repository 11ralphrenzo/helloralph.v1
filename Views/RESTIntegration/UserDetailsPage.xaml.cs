using helloralph.ViewModels;

namespace helloralph.Views;

public partial class UserDetailsPage : ContentPage
{
	private readonly UserDetailsViewModel vm;

	public UserDetailsPage(UserDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = this.vm = vm;
	}

    protected override void OnAppearing()
	{
		base.OnAppearing();
        vm.GetUserDetails();
    }
}