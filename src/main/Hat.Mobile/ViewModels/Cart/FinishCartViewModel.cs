using Hat.DataViewModels;
using Hat.Helpers;
using Hat.Mobile.Services;
using System.Windows.Input;
namespace Hat.Mobile.ViewModels
{
    public class FinishCartViewModel : BaseViewModel
    {

        private CartManagerViewModel _CartViewModel;
        public CartManagerViewModel CartViewModel
        {
            get => _CartViewModel;
            set => SetProperty(ref _CartViewModel, value);
        }


        private OrderViewModel _OrderViewModel;
        public OrderViewModel OrderViewModel
        {
            get => _OrderViewModel;
            set => SetProperty(ref _OrderViewModel, value);
        }


        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand FinishCommand { get; }
        public ICommand BackCommand { get; }

        public FinishCartViewModel(NavigationService navigationService, DataService dataService):base(navigationService, dataService)
        {
                 
            FinishCommand = new Command(FinishOrder);
            BackCommand = new Command(GoBack);
            IsLoaded = true;
            _ = Initialize();

        }
        private async Task Initialize()
        {
            await PopulateData();
        }
        async Task PopulateData()
        {
            var storedCart = await _dataService.GetCart();


            IsLoaded = true;
        }
        private async void FinishOrder()
        {            
            await _navigationService.NavigateToHome();
            await ToastHelper.ShowToast("Order Complete");
        }
        private async void GoBack(object obj)
        => await _navigationService.GoBack();
    }
}
