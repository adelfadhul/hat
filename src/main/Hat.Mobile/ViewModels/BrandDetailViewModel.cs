using CommunityToolkit.Maui.Core.Extensions;
using Hat.Views;
using Hat.Domain.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Hat.DataViewModels;

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

        private ObservableCollection<ProductListViewModel> _Products = [];
        public ObservableCollection<ProductListViewModel> Products
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

        private readonly IProductRepository _ProductRepository;
        public BrandDetailViewModel(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
            SelectProductCommand = new Command<ProductListViewModel>(SelectProduct);
            SelectMenuCommand = new Command<TabPageModel>(SelectMenu);
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        private async void SelectProduct(ProductListViewModel obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProductDetailsView());
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
            //await Task.Delay(500);
            //TODO: Remove Delay here and call API
            var storedProducts = await _ProductRepository.GetProducts();
            Products = storedProducts.Select(x => new ProductListViewModel(x)).ToObservableCollection();
            //Products.Add(new ProductListModel() { Name = "BeoPlay Speaker", BrandName = "Bang and Olufsen", Price = 755, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            //Products.Add(new ProductListModel() { Name = "Leather Wristwatch", BrandName = "Tag Heuer", Price = 450, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" });
            //Products.Add(new ProductListModel() { Name = "Smart Bluetooth Speaker", BrandName = "Google LLC", Price = 900, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" });
            //Products.Add(new ProductListModel() { Name = "Smart Luggage", BrandName = "Smart Inc", Price = 1200, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png" });
            //Products.Add(new ProductListModel() { Name = "Smart Bluetooth Speaker", BrandName = "Bang and Olufsen", Price = 90, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            //Products.Add(new ProductListModel() { Name = "B&o Desk Lamp", BrandName = "Bang and Olufsen", Price = 450, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image7.png" });
            //Products.Add(new ProductListModel() { Name = "BeoPlay Stand Speaker", BrandName = "Bang and Olufse", Price = 3000, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image8.png" });
            //Products.Add(new ProductListModel() { Name = "Airpods", BrandName = "B&o Phone Case", Price = 30, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image9.png" });


            var storedBrands = await _ProductRepository.GetBrands();
            TabPages.Add(new TabPageModel("All", 0, true));
            var index = 0;
            foreach(var item in storedBrands)
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
