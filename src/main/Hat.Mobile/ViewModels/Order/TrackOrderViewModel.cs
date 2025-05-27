using Hat.DataViewModels;
using Hat.Mobile.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace Hat.Mobile.ViewModels
{
    public class TrackOrderViewModel : BaseViewModel
    {
        private ObservableCollection<DeliveryStepViewModel> _TrackStatus = [];
        public ObservableCollection<DeliveryStepViewModel> TrackStatus
        {
            get => _TrackStatus;
            set => SetProperty(ref _TrackStatus, value);

        }  
        public TrackViewModel TrackOrderData { get; set; }
        public string PageTitle
        {
            get
            {
                return TrackOrderData.OrderId;
            }
        }
        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand BackCommand { get; set; }
       
        public TrackOrderViewModel(NavigationService navigationService, DataService dataService):base(navigationService,dataService)
        {
           
            TrackOrderData = new();
            _navigationService = navigationService;
            BackCommand = new Command<object>(GoBack);
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        async Task PopulateDataAsync()
        {
           
            var deliverySteps = _dataService.GetDeliverySteps();
            IsLoaded = true;
        }

        private async void GoBack(object obj)
        {
            await _navigationService.GoBack();
        }

    }
}
