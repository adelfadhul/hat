using Hat.DataViewModels;

namespace Hat.Model
{
    public partial class OrderModel : List<OrderViewModel>
    {
        public string Date { get; private set; }

        public OrderModel(string date, List<OrderViewModel> tracks) : base(tracks)
        {
            Date = date;
        }

        public override string ToString()
        {
            return Date;
        }
    }
}