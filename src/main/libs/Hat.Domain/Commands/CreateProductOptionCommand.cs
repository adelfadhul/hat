using Hat.Domain.Enums;
using MediatR;

namespace Hat.Domain.Commands
{
    public class AddProductOptionCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }

        public ProductOptionValueType ValueType { get; set; }
        public string Description { get; set; }

        public decimal ? Price { get; set; }
    }
}
