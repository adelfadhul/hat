using MediatR;

namespace Hat.Domain.Commands
{
    public class CreateCardCommand:IRequest<Guid>
    {
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string NameOnCard { get; set; }
        public string CardValidationCode { get; set; }
        public Guid UserId { get; set; }
    }
}
