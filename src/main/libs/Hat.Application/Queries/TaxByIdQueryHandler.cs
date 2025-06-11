using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{

    public class VatsByUserQuery : IRequest<List<TaxModel>>
    {
        public VatsByUserQuery(Guid userId)
        {
            UserId = userId;
        }
        public Guid UserId { get; init; }
    }
    public class TaxByIdQueryHandler : IRequestHandler<TaxByIdQuery, TaxModel?>
    {
        private readonly ITaxRepository _vatRepository;
        public TaxByIdQueryHandler(ITaxRepository cardRepository)
        {
            _vatRepository = cardRepository;
        }
        public async Task<TaxModel?> Handle(TaxByIdQuery request, CancellationToken cancellationToken)
        {
            var vat = await _vatRepository.GetVat(request.Id);
            return await Task.FromResult(vat) ?? throw new KeyNotFoundException($"Vat with id {request.Id} not found.");
        }
    }

}
