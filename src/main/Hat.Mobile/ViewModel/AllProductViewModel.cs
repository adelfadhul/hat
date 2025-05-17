using EcommerceMAUI.Model;
using EcommerceMAUI.Views;
using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Repositories;
using Hat.Infrastructure.Persistance.Http.Features;
using MediatR;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EcommerceMAUI.ViewModel
{
    public class AllProductViewModel : BaseViewModel
    {
        private ObservableCollection<ProductListModel> _Products = [];

        public ObservableCollection<ProductListModel> Products
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

        private readonly IProductRepository _productRepository;
        public AllProductViewModel(IProductRepository productRepository)
        {
            _productRepository = productRepository; 
            SelectProductCommand = new Command<ProductListModel>(SelectProduct);
            _ = InitializeAsync();
        }
        public AllProductViewModel() { }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        async Task PopulateDataAsync()
        {
            await Task.Delay(500);
            //TODO: Remove Delay here and call API
            var storedProducts = await _productRepository.GetProducts();  
            Products.Clear();
            foreach (var x in storedProducts)
            {
                Products.Add(new ProductListModel(new ProductModel
                {
                    Name = x.Name,
                    IsAvailable
                     = x.IsAvailable,
                    BrandName = x.BrandName,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                }));


            }
            //Products.Add(new ProductListModel() { Name = "BeoPlay Speaker", BrandName = "Bang and Olufsen", Price = 755, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            //Products.Add(new ProductListModel() { Name = "Leather Wristwatch", BrandName = "Tag Heuer", Price = 450, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" });
            //Products.Add(new ProductListModel() { Name = "Smart Bluetooth Speaker", BrandName = "Google LLC", Price = 900, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" });
            //Products.Add(new ProductListModel() { Name = "Smart Luggage", BrandName = "Smart Inc", Price = 1200, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png" });
            //Products.Add(new ProductListModel() { Name = "Smart Bluetooth Speaker", BrandName = "Bang and Olufsen", Price = 90, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            //Products.Add(new ProductListModel() { Name = "B&o Desk Lamp", BrandName = "Bang and Olufsen", Price = 450, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image7.png" });
            //Products.Add(new ProductListModel() { Name = "BeoPlay Stand Speaker", BrandName = "Bang and Olufse", Price = 3000, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image8.png" });
            //Products.Add(new ProductListModel() { Name = "Airpods", BrandName = "B&o Phone Case", Price = 30, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image9.png" });
            IsLoaded = true;
        }

        private async void SelectProduct(ProductListModel product)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProductDetailsView());
        }
    }
}
