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
        public ProductViewModel(ProductModel domainModel)
        {
            Id = domainModel.Id;
            Name = domainModel.Name;
            ImageUrl = domainModel.ImageUrl;
            BrandName = domainModel.BrandName;
            Price = domainModel.Price;
            Details = domainModel.Details; Qty = domainModel.Qty;
            IsAvailable = domainModel.IsAvailable;
            ProductSizes = domainModel.ProductSizes;
            Reviews = new ReadOnlyObservableCollection<ReviewModel>(new ObservableCollection<ReviewModel>(domainModel.Reviews));
            VatRate = domainModel.VatRate;
            ProductSize = domainModel.ProductSize;
            ProductColor = Color.FromArgb(domainModel.ProductColor);
            ProductColors = domainModel.ProductColors;


        }

        public Guid Id { get; set; }
        public ReadOnlyObservableCollection<ReviewModel> Reviews { get; set; } = new ReadOnlyObservableCollection<ReviewModel>(new ObservableCollection<ReviewModel>());
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public double Price { get; set; }
        public string Details { get; set; }
        public double Qty { get; set; } = 1;

        private string _size;
        public string ProductSize
        {
            get => _size; set
            {
                _size = value;
                OnPropertyChanged(nameof(ProductSize));
            }
        }

       
        public Color ProductColor { get; private set; }
        public double VatRate { get; private set; }

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

        private List<string> _colors = new();
        public List<string> ProductColors
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
