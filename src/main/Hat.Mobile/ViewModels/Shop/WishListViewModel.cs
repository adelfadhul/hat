using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Mobile.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hat.Mobile.ViewModels
{
    public class WishListViewModel : BaseViewModel
    {
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

        public ICommand SelectProductCommand { get; }

        public WishListViewModel(NavigationService navigationService, DataService dataService):base(navigationService,dataService)
        {
          
            SelectProductCommand = new Command<ProductViewModel>(SelectProduct);
            _ = InitializeAsync();
        }

        private async void SelectProduct(ProductViewModel model)
        {
            if (model.IsAvailable)
            {
                await _navigationService.NavigateToProductDetails(model.Id);
                
            }
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }

        async Task PopulateDataAsync()
        {
         
            Products.Clear();
            var storedProducts = await _dataService.GetProducts();
            Products = storedProducts.Select(x => new ProductViewModel(x)).ToObservableCollection();
               IsLoaded = true;
        }

    }
}
