using Hat.Helpers;
using Hat.Views;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;
namespace Hat.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Email;
        public string Email
        {
            get => _Email;
            set => SetProperty(ref _Email, value);
        }

        private string _Password;
        public string Password
        {
            get => _Password;
            set => SetProperty(ref _Password, value);
        }

        public ICommand LoginCommand { get; }
        public ICommand LoginFacebookCommand { get; }
        public ICommand LoginGoogleCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand ForgotPasswordCommand { get; }

       private readonly NavigationService _navigationService;
        public LoginViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
            LoginCommand = new Command(Login);
            LoginFacebookCommand = new Command(LoginWithFacebook);
            LoginGoogleCommand = new Command(LoginWithGoogle);
            RegisterCommand = new Command(SignUp);
            ForgotPasswordCommand = new Command(ForgotPassword);
          
        }

        private void LoginWithGoogle()
        {

        }

        private void LoginWithFacebook()
        {

        }

        private void ForgotPassword()
        {

        }

        private async void SignUp()
        {
           await _navigationService.NavigateToRegister();
            // var registerView = new RegisterView();
            // await MauiApp.Current.MainPage.Navigation.PushModalAsync(registerView);

            // await MauiApp.Current.MainPage.Navigation.PushModalAsync(registerView);
        }

        private async void Login()
        {
            MauiApp.Current.MainPage = new AppShell();
            await ToastHelper.ShowToast("Welcome");

        }
    }
}
