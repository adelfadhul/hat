using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Domain.Models;
using Hat.Views;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;
namespace Hat.ViewModels
{
    public class CardInfoManagerViewModel : BaseViewModel
    {
        private ObservableCollection<CardInfoViewModel> _Cards = [];
        public ObservableCollection<CardInfoViewModel> Cards
        {
            get => _Cards;
            set => SetProperty(ref _Cards, value);

        }
        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }

        public ICommand AddNewCommand { get; }

        private readonly HttpClient _httpClient;
        private readonly NavigationService _navigationService;
        public CardInfoManagerViewModel(IHttpClientFactory httpClientFactory, NavigationService navigationService)
        {
            AddNewCommand = new Command(AddNewCard);
            _httpClient = httpClientFactory.CreateClient("Default");
            _navigationService = navigationService;
            _ = InitializeAsync();
          
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        async Task PopulateDataAsync()
        {
           
            var storedCards= await _httpClient.GetFromJsonAsync<List<CardInfoModel>>("/api/card-infos");
            Cards = storedCards.Select(x => new CardInfoViewModel(x)).ToObservableCollection();
            IsLoaded = true;
        }
        private async void AddNewCard()
        {
            await _navigationService.NavigateToAddNewCard();
          //  await MauiApp.Current.MainPage.Navigation.PushAsync(new AddNewCardView(new AddNewCardViewModel()));
        }

    }
}
