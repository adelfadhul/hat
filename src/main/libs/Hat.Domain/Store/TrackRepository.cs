using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface ITrackRepository
    {
        Task<List<TrackModel>> GetTracks();
    }
}
