using MediatR;

namespace Hat.Domain.Features.Product.Types.Variable.Variation.Queries
{
    internal class ProductVariationByProductIdQuery : IRequest<List<ProductVariationModel>>
    {
        public Guid ProductId { get; set; }
        public ProductVariationByProductIdQuery(Guid productId)
        {
            ProductId = productId;
        }
    }


}
