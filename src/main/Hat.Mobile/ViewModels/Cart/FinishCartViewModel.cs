using CommunityToolkit.Maui.Core.Extensions;
using Foundation;
using Hat.DataViewModels;
using Hat.Domain.Models;
using Hat.Helpers;
using Hat.Mobile.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace Hat.Mobile.ViewModels
{
    public class FinishCartViewModel : BaseViewModel
    {
        private DeliveryTypeViewModel _DeliveryType;
        public DeliveryTypeViewModel DeliveryType
        {
            get => _DeliveryType;
            set => SetProperty(ref _DeliveryType, value);
        }

        private ShippingAddressViewModel _PrimaryAddress;
        public ShippingAddressViewModel PrimaryAddress
        {
            get => _PrimaryAddress;
            set
            {
                if (_PrimaryAddress != value)
                {
                    _PrimaryAddress = value;
                    OnPropertyChanged(nameof(PrimaryAddress));
                   
                }
            }
        }

        private ObservableCollection<CartItemModel> _Products = [];
        public ObservableCollection<CartItemModel> Products
        {
            get => _Products;
            set => SetProperty(ref _Products, value);
        }

        private CardViewModel _SelectedCard;
        public CardViewModel SelectedCard
        {
            get => _SelectedCard;
            set => SetProperty(ref _SelectedCard, value);
        }

      
        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand FinishCommand { get; }
        public ICommand BackCommand { get; }

        public FinishCartViewModel(NavigationService navigationService, DataService dataService):base(navigationService, dataService)
        {
            DeliveryType = deliveryType;
            PrimaryAddress = address;
            SelectedCard = card;          
            FinishCommand = new Command(FinishOrder);
            BackCommand = new Command(GoBack);
            IsLoaded = true;

        }
        private async Task Initialize()
        {
            await PopulateData();
        }
        async Task PopulateData()
        {
            var storedDeliveryType= _dataService.AddShoppingCartItem
            IsLoaded = true;
        }
        private async void FinishOrder()
        {            
            await _navigationService.NavigateToHome();
            await ToastHelper.ShowToast("Order Complete");
        }
        private async void GoBack(object obj)
        => await _navigationService.GoBack();
    }
}
