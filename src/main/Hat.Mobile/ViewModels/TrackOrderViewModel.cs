using Hat.DataViewModels;
using Hat.Domain.Models;
using Hat.Model;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
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
        public NavigationService _navigationService { get; set; }

        private readonly HttpClient _httpClient;
        public TrackOrderViewModel(NavigationService navigationService, IHttpClientFactory httpClientFactory, TrackViewModel data, bool emptyGroups = false)
        {
            _httpClient = httpClientFactory.CreateClient("Default");
            TrackOrderData = data;
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
            var storedDeliverySteps= await _httpClient.GetFromJsonAsync<List<DeliveryStepModel>>("/api/deliverysteps");    
            IsLoaded = true;
        }

        private async void GoBack(object obj)
        {
            await _navigationService.GoBack();
        }

    }
}
