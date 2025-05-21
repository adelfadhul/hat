using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Views;
using MediatR;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;
namespace Hat.ViewModels
{
    public class DeliveryTypeSelectorViewModel : BaseViewModel
    {
        private ObservableCollection<DeliveryTypeViewModel> _DeliveryTypes = [];
        public ObservableCollection<DeliveryTypeViewModel> DeliveryTypes
        {
            get => _DeliveryTypes;
            set => SetProperty(ref _DeliveryTypes, value);

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
        private DeliveryTypeViewModel deliveryType;

        public ICommand SelectDeliveryTypeCommand { get; }
        public ICommand NextCommand { get; }
        public ICommand BackCommand { get; }

        private readonly IMediator _mediator;
        private readonly ConfirmAddressView _confirmAddressView;
        private readonly NavigationService _navigationService;
        public DeliveryTypeSelectorViewModel(ObservableCollection<ProductViewModel> products,NavigationService navigationService, ConfirmAddressView confirmAddressView)
        {
            SelectDeliveryTypeCommand = new Command<DeliveryTypeViewModel>(SelectDeliveryType);
            NextCommand = new Command(ConfirmDeliverType);
            BackCommand = new Command(GoBack);
            Products = products;
            _confirmAddressView = confirmAddressView;
            _navigationService = navigationService; 
            _ = InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }

        async Task PopulateDataAsync()
        {
            
            
            var storedDeliveryTypes = await _mediator.Send(new DeliveryTypesQuery());
            DeliveryTypes= storedDeliveryTypes.Select(x => new DeliveryTypeViewModel(x)).ToObservableCollection();
            deliveryType = DeliveryTypes[0];
            IsLoaded = true;
        }
        private void SelectDeliveryType(DeliveryTypeViewModel type)
        {
            foreach (var delType in DeliveryTypes)
            {
                if (delType.Name == type.Name)
                {
                    delType.IsSelected = true;
                    deliveryType = type;
                }
                else
                {
                    delType.IsSelected = false;
                }
            }
        }
        private async void ConfirmDeliverType()
        {
            await _navigationService.NavigateToConfirmAddress();
          //  await MauiApp.Current.MainPage.Navigation.PushAsync(_confirmAddressView);
        }
        private async void GoBack(object obj)
        {
            await _navigationService.GoBack();
            // await MauiApp.Current.MainPage.Navigation.PopAsync();
        }

    }
}
