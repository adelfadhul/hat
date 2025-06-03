using Hat.Domain.Commands;
using Hat.Domain.Models;
using Hat.Domain.Store;
using MediatR;

namespace Hat.Application.Commands
{
    internal class CreateVatCommandHandler : IRequestHandler<CreateVatCommand, Guid>
    {
        private readonly IVatRepository _vatRepository;
        public CreateVatCommandHandler(IVatRepository vatRepository)
        {
            _vatRepository = vatRepository;
        }
        public async Task<Guid> Handle(CreateVatCommand request, CancellationToken cancellationToken)
        {
            return await _vatRepository.CreateVat(new VatModel
            {
                Name = request.Name,
                Rate = request.Rate,
                Code = request.Code

            });
        }
    }
}
