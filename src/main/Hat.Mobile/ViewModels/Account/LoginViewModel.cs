using Hat.Domain.Identity;
using Hat.Helpers;
using Hat.Mobile.Services;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;
namespace Hat.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;

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

        public LoginViewModel(
            NavigationService navigationService,
            DataService dataService,
            ILoginService loginService
        ) : base(navigationService, dataService)
        {
            _loginService = loginService;

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
            => await _navigationService.NavigateToRegister();

        private async void Login()
        {
            ICurrentUser currentUser =  _loginService.Login(Email, Password);
            var isSuccess = currentUser != null;
            if (isSuccess)
            {
                MauiApp.Current.MainPage = new AppShell();
                await ToastHelper.ShowToast("Welcome");
            }
            else
            {
                await ToastHelper.ShowToast("Invalid email or password");
            }
        }
    }
}
