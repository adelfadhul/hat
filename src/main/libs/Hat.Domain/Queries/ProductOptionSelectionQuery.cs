using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class ProductOptionSelectionQuery : IRequest<List<ProductModel>>
    {

        public Guid OptionId { get; }
        public ProductOptionSelectionQuery(Guid optionId)
        {

            OptionId = optionId;
        }
    }
}
