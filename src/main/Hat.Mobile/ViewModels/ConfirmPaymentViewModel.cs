using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Domain.Models;
using MediatR;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Windows.Input;

namespace Hat.ViewModels
{
    public class ConfirmPaymentViewModel : BaseViewModel
    {
        readonly private DeliveryTypeViewModel _DeliveryType;
        readonly private ShippingAddressViewModel _PrimaryAddress;
        readonly private ObservableCollection<ProductViewModel> _Products = [];
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

        private readonly IMediator _mediator;
        private readonly HttpClient _httpClient;
        private readonly NavigationService _navigationService;
        public ConfirmPaymentViewModel(ObservableCollection<ProductViewModel> products, NavigationService navigationService, DeliveryTypeViewModel deliveryType, DataViewModels.ShippingAddressViewModel address, IMediator mediator, HttpClient httpClient)
        {
            _DeliveryType = deliveryType;
            _Products = products;
            _navigationService = navigationService;
            _PrimaryAddress = address;
            NextCommand = new Command(ConfirmPayment);
            SelectPaymentCommand = new Command<CardInfoViewModel>(SelectPayment);
            BackCommand = new Command(GoBack);
            _ = InitializeAsync();
            _mediator = mediator;
            _httpClient = httpClient;
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }

        async Task PopulateDataAsync()
        {

            var storedCards = await _httpClient.GetFromJsonAsync<List<CardInfoModel>>("api/cards");
            Cards = storedCards.Select(x => new CardInfoViewModel(x)).ToObservableCollection();
            _SelectedCard = Cards[0];
            IsLoaded = true;
        }
        private async void ConfirmPayment()
        {
            await _navigationService.NavigateToConfirmPyment();
            //await Microsoft.Maui.Controls.Application.Current.MainPage.Navigation.PushAsync(new FinishCartView(_Products, _DeliveryType, _PrimaryAddress, _SelectedCard));
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
            await _navigationService.GoBack();
            await Microsoft.Maui.Controls.Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
