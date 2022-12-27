namespace helloralph.Custom;

public partial class DefaultPageTitleView : ContentView
{
	public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(DefaultPageTitleView), string.Empty, BindingMode.TwoWay, propertyChanged: TitlePropertyChanged);

	private static void TitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var view = (DefaultPageTitleView)bindable;
		view.Title = (string)newValue;
	}

    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        private set { SetValue(TitleProperty, value); }
    }

    public DefaultPageTitleView()
	{
		InitializeComponent();
	}
}