using Hat.Views;
using System.Windows.Input;
namespace Hat.ViewModels
{
    public class RegisterViewModel : BaseViewModel
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
        public RegisterViewModel(LoginView loginView)
        {
            LoginCommand = new Command(Login);
            RegisterCommand = new Command(SignUp);
        }

        private async void SignUp(object obj)
        => await _navigationService.NavigateToVerification();



        private async void Login(object obj)
        =>await _navigationService.NavigateToLogin();
        
    }
}
