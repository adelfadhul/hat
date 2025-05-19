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
        private ObservableCollection<DeliveryTypeModel> _DeliveryTypes = [];
        public ObservableCollection<DeliveryTypeModel> DeliveryTypes
        {
            get => _DeliveryTypes;
            set => SetProperty(ref _DeliveryTypes, value);

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
        private DeliveryTypeModel deliveryType;

        public ICommand SelectDeliveryTypeCommand { get; }
        public ICommand NextCommand { get; }
        public ICommand BackCommand { get; }

        private readonly IMediator _mediator;
        public DeliveryTypeSelectorViewModel(ObservableCollection<ProductListViewModel> products,IMediator mediator)
        {
            SelectDeliveryTypeCommand = new Command<DeliveryTypeModel>(SelectDeliveryType);
            NextCommand = new Command(ConfirmDeliverType);
            BackCommand = new Command(GoBack);
            Products = products;
            _mediator = mediator;
            _ = InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }

        async Task PopulateDataAsync()
        {
            //await Task.Delay(500);
            //TODO: Remove Delay here and call API
            DeliveryTypes.Clear();
            var storedDeliveryTypes = await _mediator.Send(new DeliveryTypesQuery());
            //DeliveryTypes.Add(new DeliveryTypeViewModel() { Name = "Standard Delivery", Description = "Order will be delivered between 3 - 5 business days", IsSelected = true });
            //DeliveryTypes.Add(new DeliveryTypeViewModel() { Name = "Next Day Delivery", Description= "Place your order before 6pm and your items will be delivered the next day" });
            // DeliveryTypes.Add(new DeliveryTypeViewModel() { Name = "Nominated Delivery", Description= "Pick a particular date from the calendar and order will be delivered on selected date" });
            deliveryType = DeliveryTypes[0];
            IsLoaded = true;
        }
        private void SelectDeliveryType(DeliveryTypeModel type)
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
            await MauiApp.Current.MainPage.Navigation.PushAsync(new ConfirmAddressView(new ConfirmAddressViewModel(_Products, deliveryType, _mediator)));
        }
        private async void GoBack(object obj)
        {
            await MauiApp.Current.MainPage.Navigation.PopAsync();
        }

    }
}
