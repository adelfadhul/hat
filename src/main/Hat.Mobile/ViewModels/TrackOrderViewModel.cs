using Hat.DataViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;
namespace Hat.ViewModels
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

        public TrackOrderViewModel(TrackViewModel data, bool emptyGroups = false)
        {
            TrackOrderData = data;
            BackCommand = new Command<object>(GoBack);
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
            TrackStatus.Add(new DeliveryStepViewModel() { Id = 1, DeliveryStatusDate = DateTime.Now.AddDays(-4), IsComplete = true, Name = "Order Placed", Location = "Lagos State, Nigeria" });
            TrackStatus.Add(new DeliveryStepViewModel() { Id = 2, DeliveryStatusDate = DateTime.Now.AddDays(-3), IsComplete = true, Name = "Order Confirmed", Location = "Lagos State, Nigeria" });
            TrackStatus.Add(new DeliveryStepViewModel() { Id = 3, DeliveryStatusDate = DateTime.Now.AddDays(-2), IsComplete = true, Name = "Order Dispatched", Location = "Lagos State, Nigeria" });
            TrackStatus.Add(new DeliveryStepViewModel() { Id = 4, DeliveryStatusDate = DateTime.Now.AddDays(-1), IsComplete = false, Name = "Out for Delivery", Location = "Lagos State, Nigeria" });
            TrackStatus.Add(new DeliveryStepViewModel() { Id = 5, DeliveryStatusDate = DateTime.Now, IsComplete = false, Name = "Order Delivered", Location = "Lagos State, Nigeria" , IsLineVisible  = false});
            IsLoaded = true;
        }

        private async void GoBack(object obj)
        {
            await MauiApp.Current.MainPage.Navigation.PopModalAsync();
        }

    }
}
