using MediatR;
using System.Collections.Generic;

namespace Hat.Domain.Queries
{
    public class BrandsQuery : IRequest<List<string>>
    {
    }
}
