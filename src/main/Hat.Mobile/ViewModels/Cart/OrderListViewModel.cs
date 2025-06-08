using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Mobile.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace Hat.Mobile.ViewModels
{

    public class OrderListViewModel : BaseViewModel
    {
        private ObservableCollection<OrderViewModel> _Orders = [];
        public ObservableCollection<OrderViewModel> Orders
        {
            get => _Orders;
            set => SetProperty(ref _Orders, value);
        }

        private bool _IsLoaded;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand BackCommand { get; }
        public ICommand SelectOrderCommand { get; }

        public OrderListViewModel(NavigationService navigationService, DataService dataService):base(navigationService,dataService)
        {
            BackCommand = new Command<object>(GoBack);
            SelectOrderCommand = new Command<object>(TrackCommand);
            _ = InitializeAsync();
           
        }
        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        private async void TrackCommand(object obj)
        {
            var test = obj;
            var id = ((OrderViewModel)obj).Id;
            await _navigationService.NavigateToTrackOrder(id);
        }
        private async void GoBack(object obj)
        => await _navigationService.GoBack();
        private async Task PopulateDataAsync()
        {
            var storedOrders = await _dataService.GetUserOrders();
            Orders= storedOrders.Select(x=> new OrderViewModel(x)).ToObservableCollection();
           
            IsLoaded = true;
        }

    }
}
