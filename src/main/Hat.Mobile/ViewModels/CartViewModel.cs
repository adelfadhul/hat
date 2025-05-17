using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Domain.Repositories;
using Hat.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hat.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        private ObservableCollection<ProductListViewModel> _Products = [];
        public ObservableCollection<ProductListViewModel> Products
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
        private double _SubTotal = 0;
        public double SubTotal
        {
            get => _SubTotal;
            set => SetProperty(ref _SubTotal, value);
        }

        public ICommand DeleteCommand { get; }
        public ICommand FavoriteCommand { get; }
        public ICommand QtyChangeCommand { get; }
        public ICommand CheckoutCommand { get; }

        private readonly IProductRepository _productRepository;
        public CartViewModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            DeleteCommand = new Command<ProductListViewModel>(DeleteProduct);
            FavoriteCommand = new Command<ProductListViewModel>(FavoriteProduct);
            QtyChangeCommand = new Command<ProductListViewModel>(ChangeProductQty);
            CheckoutCommand = new Command(Checkout);
            _ = InitializeAsync();
        }      

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        async Task PopulateDataAsync()
        {
            //await Task.Delay(500);
            //TODO: Remove Delay here and call API
            var storedProducts = await _productRepository.GetProducts();
            Products= storedProducts.Select(x=> new ProductListViewModel(x)).ToObservableCollection();
            //Products.Add(new ProductListModel() { Name = "BeoPlay Speaker", BrandName = "Bang and Olufsen", Qty = 1, Price = 755, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            //Products.Add(new ProductListModel() { Name = "Leather Wristwatch", BrandName = "Tag Heuer", Qty = 1, Price = 450, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" });
            //Products.Add(new ProductListModel() { Name = "Smart Bluetooth Speaker", BrandName = "Google LLC", Qty = 1, Price = 900, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" });
            //Products.Add(new ProductListModel() { Name = "Smart Luggage", BrandName = "Smart Inc", Price = 1200, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png" });
            //Products.Add(new ProductListModel() { Name = "Smart Bluetooth Speaker", BrandName = "Bang and Olufsen", Qty = 1, Price = 90, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            //Products.Add(new ProductListModel() { Name = "B&o Desk Lamp", BrandName = "Bang and Olufsen", Qty = 1, Price = 450, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image7.png" });
            //Products.Add(new ProductListModel() { Name = "BeoPlay Stand Speaker", BrandName = "Bang and Olufse", Qty = 1, Price = 3000, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image8.png" });
            //Products.Add(new ProductListModel() { Name = "Airpods", BrandName = "B&o Phone Case", Qty = 1, Price = 30, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image9.png" });
            SubTotal = Products.Sum(item => item.Qty * item.Price);
            IsLoaded = true;
        }
        private async void DeleteProduct(ProductListViewModel product)
        {
            
        }
        private async void FavoriteProduct(ProductListViewModel product)
        {

        }
        private void ChangeProductQty(ProductListViewModel product)
        {
            SubTotal = Products.Sum(item => item.Qty * item.Price);
        }
        private async void Checkout()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CartCalculation(Products));
        }
    }
}
