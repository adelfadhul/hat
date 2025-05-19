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
        private DeliveryTypeModel _DeliveryType;
        public DeliveryTypeModel DeliveryType
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

        private ObservableCollection<ProductListViewModel> _Products = [];
        public ObservableCollection<ProductListViewModel> Products
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
        public ConfirmAddressViewModel(ObservableCollection<ProductListViewModel> products, DeliveryTypeModel deliveryType, IMediator mediator)
        {
            _mediator = mediator;
            DeliveryType = deliveryType;
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
            await Microsoft.Maui.Controls.Application.Current.MainPage.Navigation.PushAsync(new ConfirmPaymentView(Products, DeliveryType, PrimaryAddress, _mediator));
        }

        private async void GoBack(object obj)
        {
            await Microsoft.Maui.Controls.Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
