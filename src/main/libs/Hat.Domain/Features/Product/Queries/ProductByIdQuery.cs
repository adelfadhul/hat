using MediatR;

namespace Hat.Domain.Features.Product.Models.Queries
{
    public class ProductByIdQuery : IRequest<ProductModel>
    {
        public Guid Id { get; set; }
        public ProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
