using Hat.DataViewModels;
using Hat.Helpers;
using Hat.Services;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;
namespace Hat.ViewModels
{
    public class AddNewCardViewModel : BaseViewModel
    {
        private CardInfoViewModel _Card = new();

        public CardInfoViewModel Card
        {
            get => _Card;
            set => SetProperty(ref _Card, value);

        }

        private string _CardNumber;
        public string CardNumber
        {
            get => _CardNumber;
            set => SetProperty(ref _CardNumber, value);

        }
        private DateTime _ExpireDate = DateTime.Now;
        public DateTime ExpireDate
        {
            get => _ExpireDate;
            set
            {
                if (_ExpireDate != value)
                {
                    _ExpireDate = value;
                    OnPropertyChanged(nameof(ExpireDate));
                    OnPropertyChanged(nameof(ExpireDateString));
                }
            }

        }

        public string ExpireDateString
        {
            get
            {
                return ExpireDate.ToString("MM / dd");
            }
        }


        private string _NameOnCard;
        public string NameOnCard
        {
            get => _NameOnCard;
            set => SetProperty(ref _NameOnCard, value);

        }
        private string _CVV;
        public string CVV
        {
            get => _CVV;
            set => SetProperty(ref _CVV, value);

        }

        public ICommand SaveCommand { get; }
        public ICommand BackCommand { get; }
      
        public AddNewCardViewModel(DataService dataService, NavigationService navigationService):base(navigationService, dataService)
        {
            SaveCommand = new Command(SaveCard);
            BackCommand = new Command(GoBack);
            _navigationService = navigationService;
            _dataService = dataService;
        }

        private async void SaveCard()
        {
           // await MauiApp.Current.MainPage.Navigation.PopAsync();
            await _navigationService.GoBack();
            await ToastHelper.ShowToast("Add card added.");
        }
        private async void GoBack()
        {
          //  await MauiApp.Current.MainPage.Navigation.PopAsync();
            await _navigationService.GoBack();
        }

    }
}
