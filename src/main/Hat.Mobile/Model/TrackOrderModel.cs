using Hat.ViewModels;
using static Hat.Model.TrackOrderModel;

namespace Hat.Model
{
    public class TrackOrderModel : List<TrackViewModel>
    {
        public string Date { get; private set; }

        public TrackOrderModel(string date, List<TrackViewModel> tracks) : base(tracks)
        {
            Date = date;
        }

        public override string ToString()
        {
            return Date;
        }

       

        public class ImageList
        {
            public string ImageUrl { get; set; }
        }
    }
}