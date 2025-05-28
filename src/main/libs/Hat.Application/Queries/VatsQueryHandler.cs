using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class VatsQueryHandler : IRequestHandler<VatsQuery, List<VatModel>>
    {
        private readonly IVatRepository _vatRepository;
        public VatsQueryHandler(IVatRepository vatRepository)
        {
            _vatRepository = vatRepository;
        }
        public async Task<List<VatModel>> Handle(VatsQuery request, CancellationToken cancellationToken)
        {
            return await _vatRepository.GetVats();
        }
    }

}
