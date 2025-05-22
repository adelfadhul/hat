using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class CardInfosQuery : IRequest<List<CardInfoModel>>
    {
    }
}
