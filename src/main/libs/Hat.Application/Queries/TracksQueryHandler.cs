using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class TracksQueryHandler : IRequestHandler<TracksQuery, List<TrackModel>>
    {
        private readonly ITrackRepository _trackRepository;

        public TracksQueryHandler(ITrackRepository categoryRepository)
        {
            _trackRepository = categoryRepository;
        }

        public async Task<List<TrackModel>> Handle(TracksQuery request, CancellationToken cancellationToken)
        {
            return await _trackRepository.GetTracks();
        }
    }
}
