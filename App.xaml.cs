using helloralph.Utilities;

namespace helloralph;

public partial class App : Application
{
	public App()
	{
		Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Constants.SYNCFUSION_LICENSE_KEY);
		InitializeComponent();
		MainPage = new AppShell();
	}
}
