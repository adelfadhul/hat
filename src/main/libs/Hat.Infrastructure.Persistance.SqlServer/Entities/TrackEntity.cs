namespace Hat.Infrastructure.Persistance.SqlServer.Entities
{

    public class TrackEntity
    {
       
        #region data

        public Guid Id { get; set; }
        public string OrderId { get; set; }

        public string Price { get; set; }

        public string Status { get; set; }

        public string ImageUrls { get; set; }

        #endregion

        
    }
}
