using helloralph.ViewModels;

namespace helloralph.Views;

public partial class AppInfoPage : ContentPage
{
	private readonly AppInfoViewModel vm;

	public AppInfoPage(AppInfoViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = this.vm = vm;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
        ThreadPool.QueueUserWorkItem(o =>
		{
            if (!vm.IsPageLoaded)
            {
				Thread.Sleep(TimeSpan.FromSeconds(1));
				vm.LoadList();
				vm.IsPageLoaded = true;
            }
        });
    }
}