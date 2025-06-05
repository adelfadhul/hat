using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class CardsQuery : IRequest<List<CardModel>>
    {
    }
}
