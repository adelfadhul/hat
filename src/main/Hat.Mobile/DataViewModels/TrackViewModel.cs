using Hat.Domain.Models;
using Hat.ViewModels;
using static Hat.Model.TrackOrderModel;

namespace Hat.DataViewModels
{
    public class TrackViewModel : BaseViewModel
    {
        public TrackViewModel()
        {
            
        }
        public TrackViewModel(TrackModel domainModel)
        {
            OrderId = domainModel.OrderId;
            Price = domainModel.Price;
            Status = domainModel.Status;
            Images = domainModel.ImageUrlList;
        }
        private string _OrderId;
        public string OrderId
        {
            get => _OrderId;
            set => SetProperty(ref _OrderId, value);
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
       
    }
}