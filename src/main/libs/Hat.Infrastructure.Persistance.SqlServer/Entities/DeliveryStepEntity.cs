using System.Drawing;

namespace Hat.Infrastructure.Persistance.SqlServer.Entities
{
    public class DeliveryStepEntity 
    {
        #region data
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public DateTime DeliveryStatusDate { get; set; }


        public bool IsComplete { get; set; }

      
        public bool IsLineVisible { get; set; }
        #endregion
    }
}
