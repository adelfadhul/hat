using Camera.MAUI.ZXingHelper;
using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Domain.Repositories;
using Hat.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hat.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private ObservableCollection<CategoryViewModel> _Categories = [];
        public ObservableCollection<CategoryViewModel> Categories
        {
            get => _Categories;
            set => SetProperty(ref _Categories, value);

        }

        private ObservableCollection<ProductListViewModel> _BestSellingProducts = [];
        public ObservableCollection<ProductListViewModel> BestSellingProducts
        {
            get => _BestSellingProducts;
            set => SetProperty(ref _BestSellingProducts, value);
        }

        private ObservableCollection<ProductListViewModel> _FeaturedBrands = [];
        public ObservableCollection<ProductListViewModel> FeaturedBrands
        {
            get => _FeaturedBrands;
            set => SetProperty(ref _FeaturedBrands, value);
        }

        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand SelectProductCommand { get; }
        public ICommand BrandTapCommand { get; }
        public ICommand RecommendedTapCommand { get; }
        public ICommand CategoryTapCommand { get; }
        public ICommand OpenCameraCommand { get; }

        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public HomePageViewModel(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            SelectProductCommand = new Command<ProductListViewModel>(SelectProduct);
            RecommendedTapCommand = new Command<object>(SelectRecommend);
            CategoryTapCommand = new Command<CategoryViewModel>(SelectCategory);
            BrandTapCommand = new Command<ProductListViewModel>(SelectBrand);
            OpenCameraCommand = new Command(OpenCamera);
            _ = InitializeAsync();

        }
        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        async Task PopulateDataAsync()
        {
            // Delay added to display loading, remove during api call
            //await Task.Delay(500);
            //TODO: Remove Delay here and call API
            var storedCategories = await _categoryRepository.GetCategories();
            Categories = storedCategories.Select(x => new CategoryViewModel(x)).ToObservableCollection();
            //Categories.Add(new CategoryViewModel() { CategoryID = 1, CategoryName = "Men", Icon = "\ufb22" });
            //Categories.Add(new CategoryViewModel() { CategoryID = 2, CategoryName = "Women", Icon = "\ufb23" });
            //Categories.Add(new CategoryViewModel() { CategoryID = 2, CategoryName = "Devices", Icon = "\uf322" });
            //Categories.Add(new CategoryViewModel() { CategoryID = 2, CategoryName = "Gadgets", Icon = "\uf2cb" });
            //Categories.Add(new CategoryViewModel() { CategoryID = 2, CategoryName = "Games", Icon = "\uf5ba" });

            var bestSellingProducts = await _productRepository.GetBestSettlingProducts();
            BestSellingProducts = BestSellingProducts = bestSellingProducts
                .Select(x => new ProductListViewModel(x)).ToObservableCollection();
            //BestSellingProducts.Add(new ProductListModel() { Name = "BeoPlay Speaker", BrandName = "Bang and Olufsen", Price = 755, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            //BestSellingProducts.Add(new ProductListModel() { Name = "Leather Wristwatch", BrandName = "Tag Heuer", Price = 450, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" });
            //BestSellingProducts.Add(new ProductListModel() { Name = "Smart Bluetooth Speaker", BrandName = "Google LLC", Price = 900, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" });
            //BestSellingProducts.Add(new ProductListModel() { Name = "Smart Luggage", BrandName = "Smart Inc", Price = 1200, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png" });

            var storedFeaturedBrandsProducts = await _productRepository.GetFeaturedProducts();
            FeaturedBrands = storedFeaturedBrandsProducts.Select(x => new ProductListViewModel(x)).ToObservableCollection();
            //FeaturedBrands.Add(new ProductListModel() { BrandName = "B&o", Details = "5693 Products", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Bo.png" });
            //FeaturedBrands.Add(new ProductListModel() { BrandName = "Beats", Details = "1124 Products", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/beats.png" });
            //FeaturedBrands.Add(new ProductListModel() { BrandName = "Apple Inc", Details = "5693 Products", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Icon_Apple.png" });

            IsLoaded = true;
        }

        private async void SelectBrand(ProductListViewModel product)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new BrandDetailView());
        }
        private async void SelectProduct(ProductListViewModel product)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProductDetailsView());
        }

        private async void SelectCategory(CategoryViewModel category)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CategoryDetailView(category));
        }
        private async void SelectRecommend(object product)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AllProductView());
        }
        private async void OpenCamera()
        {
            var response = await Application.Current.MainPage.DisplayAlert("Scan QR", "Do you want to open camera?", "Yes", "No");
            if (response)
            {
                PermissionStatus status = await Permissions.RequestAsync<Permissions.Camera>();
                if (status == PermissionStatus.Granted)
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ScanCameraView());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Permission Denied", "Camera access is required but not granted. Please enable camera permissions in your device settings.", "OK");

                }

            }
        }

        private void CameraViewBarcodeDetected(object sender, BarcodeEventArgs args)
        {

        }

        private void CameraViewCamerasLoaded(object sender, EventArgs e)
        {

        }
    }
}
