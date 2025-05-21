using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Domain.Models;
using Hat.Domain.Repositories;
using Hat.Model;
using Hat.Views;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;
namespace Hat.ViewModels
{
  
    public class OrderDetailsViewModel : BaseViewModel
    {
        private ObservableCollection<TrackOrderModel> _TrackData = [];
        public ObservableCollection<TrackOrderModel> TrackData
        {
            get => _TrackData;
            set => SetProperty(ref _TrackData, value);
        }

        private bool _IsLoaded;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand BackCommand { get; }
        public ICommand SelectOrderCommand { get; }

        private readonly HttpClient _httpClient;
        private readonly NavigationService _navigationService;
        public OrderDetailsViewModel(bool emptyGroups,NavigationService navigationService, IHttpClientFactory httpClientFactory)
        {
            BackCommand = new Command<object>(GoBack);
            _navigationService = navigationService;
            _httpClient = httpClientFactory.CreateClient("Default");
            SelectOrderCommand = new Command<object>(TrackCommand);
            _ = InitializeAsync();
           
        }
        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        private async void TrackCommand(object obj)
        {
            await _navigationService.NavigateToTrackOrder();
            // await MauiApp.Current.MainPage.Navigation.PushAsync(new TrackOrderView((TrackViewModel)obj));
        }
        private async void GoBack(object obj)
        {
           await _navigationService.GoBack();
        }
        private async Task PopulateDataAsync()
        {
            var storedTracks= await _httpClient.GetFromJsonAsync<List<TrackModel>>("/api/trakorders");
            var tracks= storedTracks.Select(x=> new TrackViewModel(x)).ToList();
            TrackData = storedTracks.Select(x => new TrackOrderModel("Sept 23", tracks)).ToObservableCollection();
            IsLoaded = true;
        }

    }
}
