using Hat.Domain.Models;

namespace Hat.Domain.Repositories
{
    public interface ITrackRepository
    {
        Task<List<TrackModel>> GetTracks();
    }
}
