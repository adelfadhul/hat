using Hat.Domain.Models;
using Hat.Mobile.ViewModels;

namespace Hat.DataViewModels
{
    public class ProductOptionSelectionViewModel : BaseViewModel
    {
        public ProductOptionSelectionViewModel(ProductOptionSelectionModel data)
        {
            Id = data.Id;
            Value = data.Value;
           
        }
        public Guid Id { get; set; }
      
        public string Value { get; set; }
    }
}
