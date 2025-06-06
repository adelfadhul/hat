namespace Hat.Domain.Models
{

    public class OrderModel
    {
       
        #region data

        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Price { get; set; }

        public string Status { get; set; }

        public string ImageUrls { get; set; }

        public DateTime OrderDate { get; set; }

        #endregion

        #region rich
       
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
