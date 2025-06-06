namespace Hat.Domain.Models
{
    public class DeliveryStepModel 
    {
        #region data
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public DateTime DeliveryStatusDate { get; set; }


        public bool IsComplete { get; set; }

      
        public bool IsLineVisible { get; set; }
        #endregion
    }
}
