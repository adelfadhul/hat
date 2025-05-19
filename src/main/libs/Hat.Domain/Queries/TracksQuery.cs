using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Queries
{
    public class TracksQuery : IRequest<List<TrackModel>>
    {
    }
}
