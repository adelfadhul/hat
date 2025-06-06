using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class OrdersQueryHandler : IRequestHandler<OrdersQuery, List<OrderModel>>
    {
        private readonly ITrackRepository _trackRepository;

        public OrdersQueryHandler(ITrackRepository categoryRepository)
        {
            _trackRepository = categoryRepository;
        }

        public async Task<List<OrderModel>> Handle(OrdersQuery request, CancellationToken cancellationToken)
        {
            return await _trackRepository.GetTracks();
        }
    }
}
