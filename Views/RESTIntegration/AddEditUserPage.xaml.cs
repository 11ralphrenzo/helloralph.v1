using helloralph.ViewModels;

namespace helloralph.Views;

public partial class AddEditUserPage : ContentPage
{
	private readonly AddEditUserViewModel vm;

	public AddEditUserPage(AddEditUserViewModel vm)
	{
		InitializeComponent();
		BindingContext = this.vm = vm;
	}
}