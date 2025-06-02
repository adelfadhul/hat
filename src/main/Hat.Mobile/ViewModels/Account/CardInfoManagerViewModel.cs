using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Mobile.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace Hat.Mobile.ViewModels
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

       
        public CardInfoManagerViewModel( NavigationService navigationService,DataService dataService):base(navigationService, dataService)
        {
            AddNewCommand = new Command(AddNewCard);
            _ = PopulateDataAsync();


        }

      
        async Task PopulateDataAsync()
        { 
            var storedCards= await _dataService.GetCardInfos();
            Cards = storedCards.Select(x => new CardInfoViewModel(x)).ToObservableCollection();
            IsLoaded = true;
        }
        private async void AddNewCard()
        {
            await _navigationService.NavigateToAddNewCard();
        }

    }
}
