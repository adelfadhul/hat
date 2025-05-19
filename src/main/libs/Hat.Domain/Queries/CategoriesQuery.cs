using System.Collections.Generic;
using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class CategoriesQuery : IRequest<List<CategoryModel>>
    {
    }
}
