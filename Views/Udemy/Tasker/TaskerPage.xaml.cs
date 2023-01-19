using helloralph.ViewModels;

namespace helloralph.Views;

public partial class TaskerPage : ContentPage
{
	public TaskerPage()
	{
		InitializeComponent();
	}

    void checkBox_CheckedChanged(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
		(this.BindingContext as TaskerViewModel).UpdateData();
    }
}
