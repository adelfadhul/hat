using Hat.Domain.Models;
using Hat.Mobile.ViewModels;

namespace Hat.DataViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public OrderViewModel()
        {
            
        }
        public OrderViewModel(OrderModel domainModel)
        {
            Name = domainModel.Name;
            Price = domainModel.Price;
            Status = domainModel.Status;
            Images = domainModel.ImageUrls.Split(',').ToList();
            OrderDate = domainModel.OrderDate;

            NumberOfItems= Images.Count;
            ImageOneVisibility = NumberOfItems >= 1;
            ImageOneUrl= Images[0];
            ImageTwoVisibility = NumberOfItems >= 2;
            ImageTwoUrl= Images[1];
            ImageThreeUrl= Images[2];
            ImageThreeVisibility= NumberOfItems >= 3;

            ImageMoreVisibility = NumberOfItems >= 4;
            RemainingImages = NumberOfItems - 3;

        }
        private string _Name;
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }
        private string _Price;
        public string Price
        {
            get => _Price;
            set => SetProperty(ref _Price, value);
        }
        private string _Status;
        public string Status
        {
            get => _Status;
            set => SetProperty(ref _Status, value);
        }
        private List<string> _Images = [];
        public List<string> Images
        {
            get => _Images;
            set => SetProperty(ref _Images, value);
        }

        private DateTime _OrderDate;
        public DateTime OrderDate
        {
            get => _OrderDate;
            set => SetProperty(ref _OrderDate, value);
        }


       
        public int NumberOfItems { get; init; }
        public bool ImageOneVisibility { get; init; }
        public string ImageOneUrl { get;init; }
        public bool ImageTwoVisibility { get;init; }
        public string ImageTwoUrl { get;init; } 
        public bool ImageThreeVisibility { get; init; }
        public string ImageThreeUrl { get; init; }
        public bool ImageMoreVisibility { get; init; }
        public int RemainingImages { get; set; }
    }
}