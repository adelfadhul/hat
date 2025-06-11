using Hat.Domain.Models;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class TaxesByUserQueryHandler : IRequestHandler<VatsByUserQuery,List<TaxModel>>
    {
        private readonly ITaxRepository _vatRepository;
        public TaxesByUserQueryHandler(ITaxRepository vatRepository)
        {
            _vatRepository = vatRepository ?? throw new ArgumentNullException(nameof(vatRepository), "VatRepository must implement IVatRepository");
        }
        public async Task<List<TaxModel>> Handle(VatsByUserQuery request, CancellationToken cancellationToken)
        {
            return await _vatRepository.GetVatsByUser(request.UserId);
        }
    }

}
