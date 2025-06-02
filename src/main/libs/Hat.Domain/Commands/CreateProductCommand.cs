using MediatR;

namespace Hat.Domain.Commands
{

    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string Details { get; set; }
        public double Qty { get; set; } = 1;
      
        public double VatRate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public Guid VatId { get; set; }
    }
}
