using Hat.DataViewModels;
using Hat.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hat.ViewModels
{
    public class DeliveryTypeViewModel : BaseViewModel
    {
        private ObservableCollection<DataViewModels.DeliveryTypeDataViewModel> _DeliveryTypes = [];
        public ObservableCollection<DataViewModels.DeliveryTypeDataViewModel> DeliveryTypes
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
        private DataViewModels.DeliveryTypeDataViewModel deliveryType;

        public ICommand SelectDeliveryTypeCommand { get; }
        public ICommand NextCommand { get; }
        public ICommand BackCommand { get; }
        public DeliveryTypeViewModel(ObservableCollection<ProductListViewModel> products)
        {
            SelectDeliveryTypeCommand = new Command<DataViewModels.DeliveryTypeDataViewModel>(SelectDeliveryType);
            NextCommand = new Command(ConfirmDeliverType);
            BackCommand = new Command(GoBack);
            Products = products;
            _ = InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }

        async Task PopulateDataAsync()
        {
            await Task.Delay(500);
            //TODO: Remove Delay here and call API
            DeliveryTypes.Clear();
            DeliveryTypes.Add(new DeliveryTypeDataViewModel() { Name = "Standard Delivery", Description = "Order will be delivered between 3 - 5 business days", IsSelected = true });
            DeliveryTypes.Add(new DeliveryTypeDataViewModel() { Name = "Next Day Delivery", Description= "Place your order before 6pm and your items will be delivered the next day" });
            DeliveryTypes.Add(new DeliveryTypeViewModel() { Name = "Nominated Delivery", Description= "Pick a particular date from the calendar and order will be delivered on selected date" });
            deliveryType = DeliveryTypes[0];
            IsLoaded = true;
        }
        private void SelectDeliveryType(DataViewModels.DeliveryTypeDataViewModel type)
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
            await Application.Current.MainPage.Navigation.PushAsync(new ConfirmAddressView(Products, deliveryType));
        }
        private async void GoBack(object obj)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}
