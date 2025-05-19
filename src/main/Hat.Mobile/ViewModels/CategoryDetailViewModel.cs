using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Views;
using MediatR;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Input;
using MauiApp = Microsoft.Maui.Controls.Application;
namespace Hat.ViewModels
{
    public class CategoryDetailViewModel : BaseViewModel
    {
        private ObservableCollection<ProductViewModel> _Products = [];
        public ObservableCollection<ProductViewModel> Products
        {
            get => _Products;
            set => SetProperty(ref _Products, value);
        }

        private ObservableCollection<ProductViewModel> _FeaturedBrandsDataList = [];
        public ObservableCollection<ProductViewModel> FeaturedBrandsDataList
        {
            get => _FeaturedBrandsDataList;
            set => SetProperty(ref _FeaturedBrandsDataList, value);
        }
        public string PageTitle
        {
            get
            {
                return CategoryModel.CategoryName;
            }
        }
        CategoryViewModel CategoryModel { get; set; }

        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand BackCommand { get; }
        public ICommand SelectProductCommand { get; }

      
        private readonly HttpClient _httpClient;
       
        public CategoryDetailViewModel(CategoryViewModel data,  HttpClient httpClient) 
        {
        
            _httpClient = httpClient;
            BackCommand = new Command(GoBack);
            SelectProductCommand = new Command<ProductViewModel>(SelectProduct);
            CategoryModel = new CategoryViewModel();
            CategoryModel = data;
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        async Task PopulateDataAsync()
        {

            var storedProducts= await _httpClient.GetFromJsonAsync<List<ProductModel>>("api/products");
            Products = storedProducts.Select(x=> new ProductViewModel(x)).ToObservableCollection();

            var storedFeaturedBrands = await _httpClient.GetFromJsonAsync<List<ProductModel>>("api/products/featured-brand");
            FeaturedBrandsDataList= storedFeaturedBrands.Select(x => new ProductViewModel(x)).ToObservableCollection(); 
            IsLoaded = true;
        }

        private async void GoBack()
        {
            await MauiApp.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void SelectProduct(ProductViewModel product)
        {
            await MauiApp.Current.MainPage.Navigation.PushModalAsync(new ProductDetailsView());
        }

    }
}
