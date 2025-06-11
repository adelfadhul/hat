using MediatR;

namespace Hat.Domain.Commands
{
    public class CreateProductOptionCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
