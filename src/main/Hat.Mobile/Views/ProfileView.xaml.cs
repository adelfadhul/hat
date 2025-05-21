using Hat.ViewModels;

namespace Hat.Views;

public partial class ProfileView : ContentPage
{
    public ProfileView(ProfileViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}