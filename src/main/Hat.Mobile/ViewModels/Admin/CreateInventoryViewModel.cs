using Hat.Domain.Models;
using Hat.Helpers;
using Hat.Mobile.Services;
using System.Windows.Input;


namespace Hat.Mobile.ViewModels;

public class CreateInventoryViewModel : BaseViewModel
{

    public CreateInventoryViewModel(NavigationService navigationService, DataService dataService) : base(navigationService, dataService)
    {
        // Initialize any properties or commands specific to adding a product
        _ = PopulateDataAsync();


    }
    public CreateInventoryViewModel() { }

    public string Description { get; set; }
    public string Location { get; set; }
    public string ProductColor { get; set; }
    public string ProductSize { get; set; }
    public Guid ProductId { get; set; }


    private List<ProductModel> _Products;
    public List<ProductModel> Products { get => _Products; set => SetProperty(ref _Products, value); }


    private ProductModel SelectedProduct;
    public ProductModel SelectedProductModel
    {
        get => SelectedProduct;
        set
        {
            if (SetProperty(ref SelectedProduct, value))
            {
                // Update ProductId when a new product is selected
                ProductId = value?.Id ?? Guid.Empty;
            }
        }
    }

    public string SKU { get; set; }
    // Example command to add a product
    public ICommand CreateInventoryCommand => new Command(async () =>
    {


        var inventoryModel = new InventoryModel
        {
            Description = Description,
            Location = Location,
            ProductColor = ProductColor,
            ProductId = ProductId,
            ProductSize = ProductSize,
            SKU = SKU,
           
        };

        await _dataService.CreateUserInventory(inventoryModel).ContinueWith(async (result) =>
        {
            if (result.IsCompletedSuccessfully)
            {

                AlertHelper.ShowAlert("New Inventory", "Inventory added successfully", "cancel", FlowDirection.MatchParent);
                await _navigationService.NavigateToProfile();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Failed to add inventory. Please try again.", "OK");
            }
        });
    });
    // You can also add validation logic, error handling, etc. as needed.


    private async Task PopulateDataAsync()
    {

        Products = await _dataService.GetProducts();

    }

}
