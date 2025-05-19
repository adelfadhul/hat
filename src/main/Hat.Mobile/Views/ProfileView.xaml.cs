using Hat.ViewModels;

namespace Hat.Views;

public partial class ProfileView : ContentPage
{
    public ProfileView()
    {
        InitializeComponent();
        BindingContext = new ProfileViewModel();
    }
}