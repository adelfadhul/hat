using Hat.Domain.Models;
using Hat.Mobile.ViewModels;
using Hat.Model;
using System.Collections.ObjectModel;

namespace Hat.DataViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public ProductViewModel()
        {
        }
        public ProductViewModel(ProductModel data)
        {
            Id = data.Id;
            Name = data.Name;
            ImageUrl = data.ImageUrl;
            BrandName = data.BrandName;
            Price = data.Price;
            Details = data.Details;
            Qty = data.Qty;
            IsAvailable = data.IsAvailable;
            Reviews = new ReadOnlyObservableCollection<ReviewModel>(new ObservableCollection<ReviewModel>(data.Reviews));
            TaxRate = data.VatRate;
            ProductColors = data.ProductColors?.Select(x => Color.FromArgb(x)).ToList();
            ProductSizes = data.ProductSizes;
            //Options = data.Options.Select;
            options = data.Options.Select(x => new ProductOptionViewModel(x)).ToList();
            Id = data.Id;
            // Set default values for selected size and color

        }

        public Guid Id { get; set; }
        public ReadOnlyObservableCollection<ReviewModel> Reviews { get; set; } = new ReadOnlyObservableCollection<ReviewModel>(new ObservableCollection<ReviewModel>());
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string Details { get; set; }
        public double Qty { get; set; } = 1;

        private List<ProductOptionViewModel> options;
        public List<ProductOptionViewModel> Options
        {
            get => options;
            set
            {
                if (options != value)
                {
                    options = value;
                    OnPropertyChanged(nameof(Options));
                }
            }
        }



        public double TaxRate { get; private set; }

        private List<string> _sizes = new();
        public List<string> ProductSizes
        {
            get => _sizes;
            set
            {
                if (_sizes != value)
                {
                    _sizes = value;
                    OnPropertyChanged(nameof(ProductSizes));
                }
            }
        }

        private List<Color> _colors = new();
        public List<Color> ProductColors
        {
            get => _colors;
            set
            {
                if (_colors != value)
                {
                    _colors = value;
                    OnPropertyChanged(nameof(ProductColors));
                }
            }
        }

        private bool _IsAvailable;

        public bool IsAvailable
        {
            get => _IsAvailable;
            set
            {
                if (_IsAvailable != value)
                {
                    _IsAvailable = value;
                    OnPropertyChanged(nameof(IsAvailable));
                    OnPropertyChanged(nameof(AvailableColor));
                }
            }
        }
        public Color AvailableColor
        {
            get
            {
                if (IsAvailable)
                {
                    return Color.FromArgb("#00C569");
                }
                return Color.FromArgb("#FFB900");
            }
        }

        public string AvailableText
        {
            get
            {
                if (IsAvailable)
                {
                    return "In Stock";
                }
                return "Out of Stock";
            }
        }


    }
}
