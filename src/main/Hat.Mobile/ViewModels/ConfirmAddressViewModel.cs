using Hat.DataViewModels;
using Hat.Domain.Models;
using Hat.Domain.Repositories;
using Hat.Views;
using MediatR;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hat.ViewModels
{
    public class ConfirmAddressViewModel : BaseViewModel
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
            set => SetProperty(ref _PrimaryAddress, value);
        }

        private ObservableCollection<ProductViewModel> _Products = [];
        public ObservableCollection<ProductViewModel> Products
        {
            get => _Products;
            set => SetProperty(ref _Products, value);
        }

        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand NextCommand { get; }
        public ICommand BackCommand { get; }
        private readonly IMediator _mediator;
        private readonly ConfirmPaymentView _confirmPaymentView;
        public ConfirmAddressViewModel(ObservableCollection<ProductViewModel> products, ConfirmPaymentView confirmPaymentView)
        {
           
            _confirmPaymentView = confirmPaymentView;
            Products = products;
            NextCommand = new Command(ConfirmAddress);
            BackCommand = new Command(GoBack);
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        async Task PopulateDataAsync()
        {
            await Task.Delay(500);
            //TODO: Remove Delay here and call API if needed
            PrimaryAddress = new AddressViewModel()
            {
                StreetOne = "21, Alex Davidson Avenue",
                StreetTwo = "Opposite Omegatron, Vicent Quarters",
                City = "Victoria Island",
                State = "Lagos State"
            };
             IsLoaded = true;
        }

        private async void ConfirmAddress()
        {
            await Microsoft.Maui.Controls.Application.Current.MainPage.Navigation.PushAsync(_confirmPaymentView);
        }

        private async void GoBack(object obj)
        {
            await Microsoft.Maui.Controls.Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
