using MediatR;

namespace Hat.Domain.Commands
{
    public class AddProductOptionSelectionCommand : IRequest<Guid>
    {
        public Guid ProductOptionId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public decimal ? Price { get; set; }
    }
}
