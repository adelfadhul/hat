using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Domain.Repositories;
using Hat.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hat.ViewModels
{
    public class ConfirmPaymentViewModel : BaseViewModel
    {
        readonly private DeliveryTypeViewModel _DeliveryType;
        readonly private AddressViewModel _PrimaryAddress;
        readonly private ObservableCollection<ProductListViewModel> _Products = [];
        private CardInfoViewModel _SelectedCard;
        
        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }

        private ObservableCollection<CardInfoViewModel> _Cards = [];
        public ObservableCollection<CardInfoViewModel> Cards
        {
            get => _Cards;
            set => SetProperty(ref _Cards, value);

        }
        public ICommand NextCommand { get; }
        public ICommand SelectPaymentCommand { get; }
        public ICommand BackCommand { get; }

        private readonly ICardRepository _cardReposiotory;
        public ConfirmPaymentViewModel(ObservableCollection<ProductListViewModel> products, DeliveryTypeViewModel deliveryType, AddressViewModel address, ICardRepository cardReposiotory)
        {
            _DeliveryType = deliveryType;
            _Products = products;
            _PrimaryAddress = address;
            NextCommand = new Command(ConfirmPayment);
            SelectPaymentCommand = new Command<CardInfoViewModel>(SelectPayment);
            BackCommand = new Command(GoBack);
            _ = InitializeAsync();
            _cardReposiotory = cardReposiotory;
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }

        async Task PopulateDataAsync()
        {
            // Delay added to display loading, remove during api call
            //await Task.Delay(500);
            //TODO: Remove Delay here and call API
            var storedCards = await _cardReposiotory.GetCards();
            Cards= storedCards.Select(x => new CardInfoViewModel(x)).ToObservableCollection();
            //Cards.Add(new CardInfoViewModel() { CardNumber = "371449635398431", CardValidationCode = "123", ExpirationDate = "2024-12-01",IsSelected = true });
            //Cards.Add(new CardInfoViewModel() { CardNumber = "38520000023237", CardValidationCode = "456", ExpirationDate = "2025-12-01" });
            //Cards.Add(new CardInfoViewModel() { CardNumber = "6011000990139424", CardValidationCode = "789", ExpirationDate = "2026-12-01" });
            //Cards.Add(new CardInfoViewModel() { CardNumber = "3566002020360505", CardValidationCode = "321", ExpirationDate = "2027-12-01" });
            //Cards.Add(new CardInfoViewModel() { CardNumber = "5555555555554444", CardValidationCode = "654", ExpirationDate = "2028-12-01" });
            //Cards.Add(new CardInfoViewModel() { CardNumber = "4012888888881881", CardValidationCode = "987", ExpirationDate = "2028-12-01" });
            _SelectedCard = Cards[0];
            IsLoaded = true;
        }
        private async void ConfirmPayment()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new FinishCartView(_Products, _DeliveryType, _PrimaryAddress, _SelectedCard));
        }
        private void SelectPayment(CardInfoViewModel selectedCard)
        {
            foreach (var card in Cards)
            {
                if (card.CardNumber == selectedCard.CardNumber)
                {
                    card.IsSelected = true;
                    _SelectedCard = selectedCard;
                }
                else
                {
                    card.IsSelected = false;
                }
            }
        }
        private async void GoBack(object obj)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
