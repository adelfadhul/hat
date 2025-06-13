using Hat.Domain.Enums;
using Hat.Domain.Models;
using Hat.Mobile.ViewModels;

namespace Hat.DataViewModels
{
    public class ProductOptionViewModel : BaseViewModel
    {
        public ProductOptionViewModel(ProductOptionModel data)
        {
            Id = data.Id;
            Name = data.Name;
            ValueType = data.ValueType;
            Price = data.Price;
            if (data.ValueType == ProductOptionValueType.Selection)
            {
                data.Selections?.ForEach(x =>
                {
                    if (x is not null)
                    {
                        Selections.Add(new ProductOptionSelectionViewModel(x));
                    }
                });
                // Replace this line in the constructor:
                Price = Selections.SingleOrDefault(x => x.IsSelected)?.Price; // Set initial price based on the first selected option, or null if none selected
            }

        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProductOptionValueType ValueType { get; set; }

        private decimal? price;
        public decimal? Price
        {
            get => price;
            set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        private ProductOptionSelectionViewModel? selectedSelection;
        public ProductOptionSelectionViewModel? SelectedSelection
        {
            get => selectedSelection;
            set
            {
                if (selectedSelection != value)
                {
                    selectedSelection = value;
                    OnPropertyChanged(nameof(SelectedSelection));
                    UpdatePriceFromSelection();
                }
            }
        }

        private List<ProductOptionSelectionViewModel> selections = new();
        public List<ProductOptionSelectionViewModel> Selections
        {
            get => selections;
            set
            {
                if (selections != value)
                {
                    // Unsubscribe from previous selection events
                    foreach (var sel in selections)
                    {
                        sel.PropertyChanged -= Selection_PropertyChanged;
                    }

                    selections = value;

                    // Subscribe to new selection events
                    foreach (var sel in selections)
                    {
                        sel.PropertyChanged += Selection_PropertyChanged;
                    }

                    OnPropertyChanged(nameof(Selections));
                    UpdatePriceFromSelection();
                }
            }
        }

        private void Selection_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ProductOptionSelectionViewModel.IsSelected))
            {
                UpdatePriceFromSelection();
            }
        }

        private void UpdatePriceFromSelection()
        {
            if (ValueType == ProductOptionValueType.Selection)
            {
                var selected = Selections.SingleOrDefault(x => x.IsSelected);
                if (selected != null)
                {
                    Price = selected.Price;
                }
            }
        }
    }
}
