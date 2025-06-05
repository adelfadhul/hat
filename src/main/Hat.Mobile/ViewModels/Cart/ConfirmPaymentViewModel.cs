using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Mobile.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hat.Mobile.ViewModels
{
    public class ConfirmPaymentViewModel : BaseViewModel
    {
       readonly private ObservableCollection<ProductViewModel> _Products = [];
       
        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }

        private ObservableCollection<CardViewModel> _Cards = [];
        public ObservableCollection<CardViewModel> Cards
        {
            get => _Cards;
            set => SetProperty(ref _Cards, value);

        }
       
        public ICommand NextCommand { get; }
        public ICommand SelectPaymentCommand { get; }
        public ICommand BackCommand { get; }

        public ConfirmPaymentViewModel(ObservableCollection<ProductViewModel> products, NavigationService navigationService, DataService dataService):base(navigationService,dataService)
        {
         
            NextCommand = new Command(ConfirmPayment);
            SelectPaymentCommand = new Command<CardViewModel>(SelectPayment);
            BackCommand = new Command(GoBack);
            _ = InitializeAsync();
           
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }

        async Task PopulateDataAsync()
        {
            var storedCards = await _dataService.GetCards();
            Cards = storedCards.Select(x => new CardViewModel(x)).ToObservableCollection();
            IsLoaded = true;
        }
        private async void ConfirmPayment()
        {
            await _navigationService.NavigateToConfirmPyment();
            //await Microsoft.Maui.Controls.Application.Current.MainPage.Navigation.PushAsync(new FinishCartView(_Products, _DeliveryType, _PrimaryAddress, _SelectedCard));
        }
        private void SelectPayment(CardViewModel selectedCard)
        {
            foreach (var card in Cards)
            {
                if (card.CardNumber == selectedCard.CardNumber)
                {
                    card.IsSelected = true;
                }
                else
                {
                    card.IsSelected = false;
                }
            }
        }
        private async void GoBack(object obj)
        {
            await _navigationService.GoBack();
            await Microsoft.Maui.Controls.Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
