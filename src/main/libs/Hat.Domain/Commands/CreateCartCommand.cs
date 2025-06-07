using MediatR;

namespace Hat.Domain.Commands
{
    public class CreateCartCommand: IRequest
    {
        public Guid UserId { get; set; }
        public string Address { get; set; }
        public CreateCartCommand(Guid userId, string address)
        {
            UserId = userId;
            Address = address;

        }
    }


}
