using Hat.Views;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;
namespace Hat.ViewModels
{
    public class RegisterViewModel: BaseViewModel
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

        private string _Name;
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        private readonly VerificationView _verificationView;
        private readonly LoginView _loginView;
        public RegisterViewModel(VerificationView verificationView, LoginView loginView)
        {
            LoginCommand = new Command(Login);
            RegisterCommand = new Command(SignUp);
            _verificationView = verificationView;
            _loginView = loginView;
        }

        private async void SignUp(object obj)
        {
            await MauiApp.Current.MainPage.Navigation.PushModalAsync(_verificationView);
        }

        private void Login(object obj)
        {
            MauiApp.Current.MainPage =_loginView;
        }
    }
}
