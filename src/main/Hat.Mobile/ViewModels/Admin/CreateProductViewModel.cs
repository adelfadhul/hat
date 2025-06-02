using Hat.Mobile.Services;
using System.Windows.Input;

namespace Hat.Mobile.ViewModels
{
    public class CreateProductViewModel : BaseViewModel
    {
        public CreateProductViewModel(NavigationService navigationService, DataService dataService) : base(navigationService, dataService)
        {
            // Initialize any properties or commands specific to adding a product
        }
        public CreateProductViewModel() { }
        // Add properties and methods for adding a product
        // For example, you might have properties for ProductName, Price, Description, etc.
        // and methods to handle the logic of adding a product to the database or API.
        // Example properties:
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        // Example command to add a product
        public ICommand AddProductCommand => new Command(async () =>
        {
            // Logic to add the product
            // This could involve calling a service to save the product details
            // For example:
            // await _dataService.AddProduct(new Product { Name = ProductName, Price = Price, Description = Description });
            // After adding, you might want to navigate back or show a success message
        });
        // You can also add validation logic, error handling, etc. as needed.
        private async Task PopulateDataAsync()
        {
            // Implement logic to populate data if needed
            // For example, you might want to load categories or other related data
            // await _dataService.LoadCategories();
            // Or any other initialization logic specific to adding a product
        }
        private async Task InitializeAsync()
        {
            // Call PopulateDataAsync to load any necessary data when the view model is initialized
            await PopulateDataAsync();
        }


    }
}