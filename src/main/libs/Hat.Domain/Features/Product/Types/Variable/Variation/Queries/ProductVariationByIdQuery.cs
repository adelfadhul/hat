using MediatR;

namespace Hat.Domain.Features.Product.Types.Variable.Variation.Queries
{
    internal class ProductVariationByIdQuery : IRequest<ProductVariationModel>
    {
        public Guid Id { get; set; }
        public ProductVariationByIdQuery(Guid id)
        {
            Id = id;
        }
    }


}
