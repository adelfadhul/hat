using Hat.Mobile.ViewModels;
using Hat.Mobile.Views;

namespace Hat;
using MauiApp = Microsoft.Maui.Controls.Application;
public partial class App : MauiApp
{
    public App(LoginViewModel vm)
    {
        InitializeComponent();
        Current.UserAppTheme = AppTheme.Light;
        MainPage = new LoginView(vm);
    }
}
