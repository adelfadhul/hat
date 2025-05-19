using System.Collections.Generic;
using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class BestSettlingProductsQuery : IRequest<List<ProductModel>>
    {
    }
}
