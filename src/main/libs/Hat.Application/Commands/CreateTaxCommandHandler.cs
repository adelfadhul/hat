using Hat.Domain.Commands;
using Hat.Domain.Models;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    internal class CreateTaxCommandHandler : IRequestHandler<CreateTaxCommand, Guid>
    {
        private readonly ITaxRepository _vatRepository;
        public CreateTaxCommandHandler(ITaxRepository vatRepository)
        {
            _vatRepository = vatRepository;
        }
        public async Task<Guid> Handle(CreateTaxCommand request, CancellationToken cancellationToken)
        {
            return await _vatRepository.CreateVat(new TaxModel
            {
                Name = request.Name,
                Rate = request.Rate,
                Code = request.Code

            });
        }
    }
}
