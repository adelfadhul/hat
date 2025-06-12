using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class ProductOptionByIdQuery : IRequest<ProductOptionModel?>
    {
        public Guid Id { get; }

        public ProductOptionByIdQuery(Guid id)
        {
            Id = id;
          
        }
    }
}
