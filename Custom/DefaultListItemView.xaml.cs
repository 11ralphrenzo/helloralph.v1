using System.Windows.Input;

namespace helloralph.Custom;

public partial class DefaultListItemView : Frame
{
    // Toggled
    public static readonly BindableProperty ToggledProperty = BindableProperty.Create(nameof(Toggled),
    typeof(ICommand),
    typeof(DefaultListItemView),
    null,
    BindingMode.TwoWay,
    propertyChanged: ToggledPropertyChanged);

    private static void ToggledPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (DefaultListItemView)bindable;
        view.Toggled = (ICommand)newValue;
    }

    public ICommand Toggled
    {
        get { return (ICommand)GetValue(ToggledProperty); }
        private set { SetValue(ToggledProperty, value); }
    }

    // Tag
    public static readonly BindableProperty TagProperty = BindableProperty.Create(nameof(Tag),
        typeof(object),
        typeof(DefaultListItemView),
        null,
        BindingMode.TwoWay,
        propertyChanged: TagPropertyChanged);

    private static void TagPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (DefaultListItemView)bindable;
        view.Tag = (object)newValue;
    }

    public object Tag
    {
        get { return (object)GetValue(TagProperty); }
        private set { SetValue(TagProperty, value); }
    }

    // DetailsFormattedText
    public static readonly BindableProperty DetailsFormattedStringProperty = BindableProperty.Create(nameof(DetailsFormattedString),
        typeof(FormattedString),
        typeof(DefaultListItemView),
        null,
        BindingMode.TwoWay,
        propertyChanged: DetailsFormattedStringPropertyChanged);

    private static void DetailsFormattedStringPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (DefaultListItemView)bindable;
        view.labelDetail.FormattedText = view.DetailsFormattedString = (FormattedString)newValue;
    }

    public FormattedString DetailsFormattedString
    {
        get { return (FormattedString)GetValue(DetailsFormattedStringProperty); }
        private set { SetValue(DetailsFormattedStringProperty, value); }
    }

    // IsToggled
    public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(nameof(IsToggled),
        typeof(bool),
        typeof(DefaultListItemView),
        false,
        BindingMode.TwoWay,
        propertyChanged: IsToggledPropertyChanged);

    private static void IsToggledPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (DefaultListItemView)bindable;
        view.labelDetail.IsVisible = view.IsToggled = (bool)newValue;
    }

    public bool IsToggled
    {
        get { return (bool)GetValue(IsToggledProperty); }
        private set { SetValue(IsToggledProperty, value); }
    }

    public DefaultListItemView()
	{
		InitializeComponent();
	}

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        try
        {
            IsToggled = (sender as Switch).IsToggled;
            Toggled.Execute(this.Tag);
        }
        catch
        {
            throw;
        }
    }
}