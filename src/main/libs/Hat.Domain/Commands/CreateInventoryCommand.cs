using MediatR;

namespace Hat.Domain.Commands
{
    public class CreateInventoryCommand : IRequest<Guid>
    {
       
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string SKU { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Location { get; set; }
    }
}
