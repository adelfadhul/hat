using Hat.Domain.Models;
using Hat.ViewModels;

namespace Hat.DataViewModels
{
    public class ProductListViewModel : BaseViewModel
    {
        public ProductListViewModel(ProductModel domainModel)
        {

            Name = domainModel.Name;
            ImageUrl = domainModel.ImageUrl;
            BrandName = domainModel.BrandName;
            Price = domainModel.Price;
            Details = domainModel.Details; Qty = domainModel.Qty;
            IsAvailable = domainModel.IsAvailable;  
        }

        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public double Price { get; set; }
        public string Details { get; set; }
        public double Qty { get; set; } = 1;


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
