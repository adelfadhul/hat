using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{
    public class TaxesQueryHandler : IRequestHandler<TaxesQuery, List<TaxModel>>
    {
        private readonly ITaxRepository _vatRepository;
        public TaxesQueryHandler(ITaxRepository vatRepository)
        {
            _vatRepository = vatRepository;
        }
        public async Task<List<TaxModel>> Handle(TaxesQuery request, CancellationToken cancellationToken)
        {
            return await _vatRepository.GetVats();
        }
    }

}
