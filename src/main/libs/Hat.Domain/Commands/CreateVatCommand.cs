using MediatR;

namespace Hat.Domain.Commands
{
    public class CreateVatCommand : IRequest<Guid>
    {
        public string Code { get; set; }
        public double Rate { get; set; }
        public string Name { get; set; }
    }
}
