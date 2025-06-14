using Hat.Domain.Features.Product.Enums;
using MediatR;

namespace Hat.Domain.Features.Product.Commands
{
    public class ProductCreateCommand:IRequest<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public ProductType ProductType { get; set; }
    }
}
