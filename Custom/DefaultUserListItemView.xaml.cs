using helloralph.Models.DummyApi;

namespace helloralph.Custom;

public partial class DefaultUserListItemView : Frame
{
    // User
    public static readonly BindableProperty UserProperty = BindableProperty.Create(nameof(User),
    typeof(UserModel),
    typeof(DefaultUserListItemView),
    null,
    BindingMode.TwoWay,
    propertyChanged: UserPropertyChanged);

    private static void UserPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (DefaultUserListItemView)bindable;
        view.User = (UserModel)newValue;
    }

    public UserModel User
    {
        get { return (UserModel)GetValue(UserProperty); }
        private set { SetValue(UserProperty, value); }
    }
    public DefaultUserListItemView()
	{
		InitializeComponent();
	}
}