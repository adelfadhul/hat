using Hat.Domain.Models;
using Hat.Helpers;
using Hat.Mobile.Services;
using System.Windows.Input;


namespace Hat.Mobile.ViewModels;

public class CreateVatViewModel : BaseViewModel
{

    public CreateVatViewModel(NavigationService navigationService, DataService dataService) : base(navigationService, dataService)
    {
        // Initialize any properties or commands specific to adding a product
        _ = PopulateDataAsync();


    }
    public CreateVatViewModel() { }

    public string Code { get; set; }
    public double Rate { get; set; }
    public string VatName { get; set; }

    // Example command to add a product
    public ICommand CreateVatCommand => new Command(async () =>
    {

       
        var vat = new TaxModel
        {
            Code = Code,
            Rate = Rate,
            Name = VatName
        };

        await _dataService.CreateVat(vat).ContinueWith(async (result) =>
        {
            if (result.IsCompletedSuccessfully)
            {
              
                AlertHelper.ShowAlert("New Vat", "Vat added successfully", "cancel", FlowDirection.MatchParent);
                await _navigationService.NavigateToProfile();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Failed to add vat. Please try again.", "OK");
            }
        });
    });
    // You can also add validation logic, error handling, etc. as needed.


    private async Task PopulateDataAsync()
    {

       

    }

}
