using MediatR;

namespace Hat.Domain.Commands
{
    public class CreateShippingAddressCommand: IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
       

    }


}
