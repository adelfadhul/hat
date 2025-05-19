using Hat.DataViewModels;
using Hat.Domain.Models;
using Hat.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;
namespace Hat.ViewModels
{
    public class FinishCartViewModel : BaseViewModel
    {
        private DeliveryTypeViewModel _DeliveryType;
        public DeliveryTypeViewModel DeliveryType
        {
            get => _DeliveryType;
            set => SetProperty(ref _DeliveryType, value);
        }

        private AddressViewModel _PrimaryAddress;
        public AddressViewModel PrimaryAddress
        {
            get => _PrimaryAddress;
            set
            {
                if (_PrimaryAddress != value)
                {
                    _PrimaryAddress = value;
                    OnPropertyChanged(nameof(PrimaryAddress));
                    OnPropertyChanged(nameof(FullAddress));
                }
            }
        }

        private ObservableCollection<ProductViewModel> _Products = [];
        public ObservableCollection<ProductViewModel> Products
        {
            get => _Products;
            set => SetProperty(ref _Products, value);
        }

        private CardInfoViewModel _SelectedCard;
        public CardInfoViewModel SelectedCard
        {
            get => _SelectedCard;
            set => SetProperty(ref _SelectedCard, value);
        }

        public string FullAddress
        {
            get
            {
                return $"{PrimaryAddress.StreetOne}, {PrimaryAddress.StreetTwo}, {PrimaryAddress.City}, {PrimaryAddress.State}";
            }
        }

        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand FinishCommand { get; }
        public ICommand BackCommand { get; }

        public FinishCartViewModel(ObservableCollection<ProductViewModel> products, DeliveryTypeViewModel deliveryType, AddressViewModel address, CardInfoViewModel card)
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
            await MauiApp.Current.MainPage.Navigation.PopToRootAsync();
            await Shell.Current.GoToAsync("///HomePageView");
            await ToastHelper.ShowToast("Order Complete");
        }
        private async void GoBack(object obj)
        {
            await MauiApp.Current.MainPage.Navigation.PopAsync();
        }
    }
}
