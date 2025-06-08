using Hat.Domain.Models;
using Hat.Mobile.Services;
using System.Windows.Input;

namespace Hat.Mobile.ViewModels
{
    public class CreateProductViewModel : BaseViewModel
    {
       
        public CreateProductViewModel(NavigationService navigationService, DataService dataService) : base(navigationService, dataService)
        {
            // Initialize any properties or commands specific to adding a product
            _ = PopulateDataAsync();


        }
        public CreateProductViewModel() { }

        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Details { get; set; }
        // Example command to add a product
        public ICommand CreateProductCommand => new Command(async () =>
        {
           
            if (SelectedCategory == null || SelectedVat == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please select a category and VAT.", "OK");
                return;
            }
            var product = new ProductModel
            {
                Name = ProductName,
                Price = Price,
                Details = Details,
                CategoryId = SelectedCategory.Id,
                VatId = SelectedVat.Id,
                ImageUrl = "default_image_url" // Replace with actual image URL if needed
            };

             await _dataService.CreateProduct(product).ContinueWith(async (result) =>
             {
                 if (result.IsCompletedSuccessfully)
                 {
                     await App.Current.MainPage.DisplayAlert("Success", "Product added successfully.", "OK");
                     await _navigationService.NavigateToAllProducts();
                 }
                 else
                 {
                     await App.Current.MainPage.DisplayAlert("Error", "Failed to add product. Please try again.", "OK");
                 }
             });
        });
        // You can also add validation logic, error handling, etc. as needed.

        private List<CategoryModel> _Categories;
        public List<CategoryModel> Categories { get => _Categories; set => SetProperty(ref _Categories, value); }
        public CategoryModel SelectedCategory { get; set; }

        private List<VatModel> _Vats;
        public List<VatModel> Vats { get => _Vats; set => SetProperty(ref _Vats, value); }
        public VatModel SelectedVat { get; set; }
        private async Task PopulateDataAsync()
        {
           
            Categories = await _dataService.GetCategories();
            Vats = await _dataService.GetUserVats();

        }

      

    }
}