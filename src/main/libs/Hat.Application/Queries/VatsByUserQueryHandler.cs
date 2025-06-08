using Hat.Domain.Models;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class VatsByUserQueryHandler : IRequestHandler<VatsByUserQuery,List<VatModel>>
    {
        private readonly IVatRepository _vatRepository;
        public VatsByUserQueryHandler(IVatRepository vatRepository)
        {
            _vatRepository = vatRepository ?? throw new ArgumentNullException(nameof(vatRepository), "VatRepository must implement IVatRepository");
        }
        public async Task<List<VatModel>> Handle(VatsByUserQuery request, CancellationToken cancellationToken)
        {
            return await _vatRepository.GetVatsByUser(request.UserId);
        }
    }

}
