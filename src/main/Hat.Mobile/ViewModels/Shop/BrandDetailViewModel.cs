using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Hat.DataViewModels;
using Hat.Mobile.Services;
using Hat.Mobile.ViewModels;
namespace Hat.ViewModels
{
    public class BrandDetailViewModel : BaseViewModel
    {
        private ObservableCollection<TabPageModel> _TabPages = [];
        public ObservableCollection<TabPageModel> TabPages
        {
            get => _TabPages;
            set => SetProperty(ref _TabPages, value);
        }

        private ObservableCollection<ProductViewModel> _Products = [];
        public ObservableCollection<ProductViewModel> Products
        {
            get => _Products;
            set => SetProperty(ref _Products, value);
        }

        bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand SelectProductCommand { get; }
        public ICommand SelectMenuCommand { get; }


        public BrandDetailViewModel(NavigationService navigationService,DataService dataService) : base(navigationService,dataService)
        {
            TabPages = new ObservableCollection<TabPageModel>();



            SelectProductCommand = new Command<ProductViewModel>(SelectProduct);
            SelectMenuCommand = new Command<TabPageModel>(SelectMenu);
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        private async void SelectProduct(ProductViewModel obj)
        {
            await _navigationService.NavigateToProductDetails(obj.Id);
            // await MauiApp.Current.MainPage.Navigation.PushModalAsync(_productDetailsView);
        }

        private void SelectMenu(TabPageModel obj)
        {
            foreach (var item in TabPages)
            {
                if (item.Id == obj.Id)
                {
                    item.IsSelected = true;
                }
                else
                {
                    item.IsSelected = false;
                }
            }

        }
        async Task PopulateDataAsync()
        {
            var storedProducts = await _dataService.GetProducts(); 
           
            Products = storedProducts.Select(x => new ProductViewModel(x)).ToObservableCollection();

            var storedBrands = await _dataService.getBrands();
            TabPages.Add(new TabPageModel("All", 0, true));
            var index = 0;
            foreach (var item in storedBrands)
            {
                TabPages.Add(new TabPageModel(item, index, false));
                index++;
            }
            //TabPages.Add(new TabPageModel("All", 0, true));
            //TabPages.Add(new TabPageModel("Smart Bluetooth Speaker", 1, false));
            //TabPages.Add(new TabPageModel("Lamp", 2, false));
            //TabPages.Add(new TabPageModel("Airpods", 3, false));
            IsLoaded = true;
        }
    }
}
