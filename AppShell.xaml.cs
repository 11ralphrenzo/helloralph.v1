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

    }
}
