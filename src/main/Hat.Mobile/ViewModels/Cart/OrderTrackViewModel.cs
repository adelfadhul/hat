using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Mobile.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace Hat.Mobile.ViewModels
{
    [QueryProperty(nameof(OrderId), "orderId")]
    public class OrderTrackViewModel : BaseViewModel
    {

        private ObservableCollection<DeliveryStepViewModel> _DeliverySteps = [];
        public ObservableCollection<DeliveryStepViewModel> DeliverySteps
        {
            get => _DeliverySteps;
            set => SetProperty(ref _DeliverySteps, value);

        }  
        public OrderViewModel TrackOrderData { get; set; }
        public string PageTitle
        {
            get
            {
                return TrackOrderData.Name;
            }
        }
        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand BackCommand { get; set; }
       
        public OrderTrackViewModel(NavigationService navigationService, DataService dataService):base(navigationService,dataService)
        {
           
            TrackOrderData = new();
            BackCommand = new Command<object>(GoBack);
            _ = InitializeAsync();
        }

        private string _OrderId;
        public string OrderId
        {
            get => _OrderId;
            set=> SetProperty(ref _OrderId, value);
        }
        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        async Task PopulateDataAsync()
        {
           
            var storedDeliverySteps = await _dataService.GetDeliverySteps(Guid.Parse(OrderId));
            DeliverySteps= storedDeliverySteps.Select(x=>new DeliveryStepViewModel(x)).ToObservableCollection();    
            IsLoaded = true;
        }

        private async void GoBack(object obj)
        {
            await _navigationService.GoBack();
        }

    }
}
