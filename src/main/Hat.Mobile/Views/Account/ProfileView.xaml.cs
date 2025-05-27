using Hat.Mobile.ViewModels;

namespace Hat.Mobile.Views;

public partial class ProfileView : ContentPage
{
    public ProfileView(ProfileViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}