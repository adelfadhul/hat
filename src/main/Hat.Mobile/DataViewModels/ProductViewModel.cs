using Hat.Domain.Models;
using Hat.Mobile.ViewModels;

namespace Hat.DataViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public ProductViewModel()
        {
        }
        public ProductViewModel(ProductModel domainModel)
        {
            Id = domainModel.Id;
            Name = domainModel.Name;
            ImageUrl = domainModel.ImageUrl;
            BrandName = domainModel.BrandName;
            Price = domainModel.Price;
            Details = domainModel.Details; Qty = domainModel.Qty;
            IsAvailable = domainModel.IsAvailable;
            Sizes = domainModel.Sizes;
        }

        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public double Price { get; set; }
        public string Details { get; set; }
        public double Qty { get; set; } = 1;

        private List<string> _sizes = new();
        public List<string> Sizes
        {
            get => _sizes;
            set
            {
                if (_sizes != value)
                {
                    _sizes = value;
                    OnPropertyChanged(nameof(Sizes));
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
