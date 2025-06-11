using MediatR;

namespace Hat.Domain.Commands
{
    public class CreateProductOptionSelectionCommand : IRequest<Guid>
    {
        public Guid ProductOptionId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
