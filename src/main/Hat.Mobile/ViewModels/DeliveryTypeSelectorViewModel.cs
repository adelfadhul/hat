using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Domain.Queries;
using Hat.Services;
using MediatR;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace Hat.ViewModels
{
    public class DeliveryTypeSelectorViewModel : BaseViewModel
    {
        private ObservableCollection<DeliveryTypeViewModel> _DeliveryTypes = [];
        public ObservableCollection<DeliveryTypeViewModel> DeliveryTypes
        {
            get => _DeliveryTypes;
            set => SetProperty(ref _DeliveryTypes, value);

        }

        private ObservableCollection<ProductViewModel> _Products = [];
        public ObservableCollection<ProductViewModel> Products
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
      

        public ICommand SelectDeliveryTypeCommand { get; }
        public ICommand NextCommand { get; }
        public ICommand BackCommand { get; }

        public DeliveryTypeSelectorViewModel(NavigationService navigationService,DataService dataService):base(navigationService,dataService)
        {
            SelectDeliveryTypeCommand = new Command<DeliveryTypeViewModel>(SelectDeliveryType);
            NextCommand = new Command(ConfirmDeliverType);
            BackCommand = new Command(GoBack);
            Products = new();
            _ = InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }

        async Task PopulateDataAsync()
        {
            var storedDeliveryTypes = await _dataService.GetDeliveryTypes();
            DeliveryTypes= storedDeliveryTypes.Select(x => new DeliveryTypeViewModel(x)).ToObservableCollection();
            IsLoaded = true;
        }
        private void SelectDeliveryType(DeliveryTypeViewModel type)
        {
            foreach (var delType in DeliveryTypes)
            {
                if (delType.Name == type.Name)
                {
                    delType.IsSelected = true;
                }
                else
                {
                    delType.IsSelected = false;
                }
            }
        }
        private async void ConfirmDeliverType()
        => await _navigationService.NavigateToConfirmAddress();
        private async void GoBack(object obj)
        => await _navigationService.GoBack();

    }
}
