using Hat.DataViewModels;
using Hat.Domain.Models;
using Hat.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;
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

        private ObservableCollection<ProductViewModel> _Products = [];
        public ObservableCollection<ProductViewModel> Products
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

        public FinishCartViewModel(ObservableCollection<ProductViewModel> products, DeliveryTypeViewModel deliveryType, ShippingAddressViewModel address, CardViewModel card)
        {
            DeliveryType = deliveryType;
            Products = products;
            PrimaryAddress = address;
            SelectedCard = card;          
            FinishCommand = new Command(FinishOrder);
            BackCommand = new Command(GoBack);
            IsLoaded = true;

        }
        private async void FinishOrder()
        {            
            //await MauiApp.Current.MainPage.Navigation.PopToRootAsync();
            //await Shell.Current.GoToAsync("///HomePageView");
            await _navigationService.NavigateToHome();
            await ToastHelper.ShowToast("Order Complete");
        }
        private async void GoBack(object obj)
        => await _navigationService.GoBack();
    }
}
