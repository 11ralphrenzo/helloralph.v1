using helloralph.Views;

namespace helloralph;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		// Register Pages
		Routing.RegisterRoute(nameof(ExecuteRESTPage), typeof(ExecuteRESTPage));
        Routing.RegisterRoute(nameof(UserDetailsPage), typeof(UserDetailsPage));
        Routing.RegisterRoute(nameof(AddEditUserPage), typeof(AddEditUserPage));
        Routing.RegisterRoute(nameof(GetLocationPage), typeof(GetLocationPage));
        Routing.RegisterRoute(nameof(PickOrCapturePhotoPage), typeof(PickOrCapturePhotoPage));
        Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));
        Routing.RegisterRoute(nameof(ConverterPage), typeof(ConverterPage));
        Routing.RegisterRoute(nameof(AddNewTaskPage), typeof(AddNewTaskPage));
        Routing.RegisterRoute(nameof(TransactionsPage), typeof(TransactionsPage));

    }
}
