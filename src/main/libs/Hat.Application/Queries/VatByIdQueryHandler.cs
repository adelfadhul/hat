using Hat.Domain.Models;
using Hat.Domain.Queries;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Queries
{

    public class VatsByUserQuery : IRequest<List<VatModel>>
    {
        public VatsByUserQuery(Guid userId)
        {
            UserId = userId;
        }
        public Guid UserId { get; init; }
    }
    public class VatByIdQueryHandler : IRequestHandler<VatByIdQuery, VatModel?>
    {
        private readonly IVatRepository _vatRepository;
        public VatByIdQueryHandler(IVatRepository cardRepository)
        {
            _vatRepository = cardRepository;
        }
        public async Task<VatModel?> Handle(VatByIdQuery request, CancellationToken cancellationToken)
        {
            var vat = await _vatRepository.GetVat(request.Id);
            return await Task.FromResult(vat) ?? throw new KeyNotFoundException($"Vat with id {request.Id} not found.");
        }
    }

}
