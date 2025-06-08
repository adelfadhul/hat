namespace Hat.Domain.Models
{
    public class VatModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public double Rate { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }
    }
}
