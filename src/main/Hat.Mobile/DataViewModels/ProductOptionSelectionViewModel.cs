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
            Price= isSelected ? data.Price : null; // Set price only if selected
        }
        public Guid Id { get; set; }
      
        public decimal? Price { get; set; } // Optional price for the selection
        public string Value { get; set; }

        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                    // Update price when selection changes
                    if (isSelected)
                    {
                        Price = Price; // Keep the price if selected
                    }
                    else
                    {
                        Price = null; // Clear price if not selected
                    }
                    OnPropertyChanged(nameof(Price));
                }
            }
        }
    }
}
