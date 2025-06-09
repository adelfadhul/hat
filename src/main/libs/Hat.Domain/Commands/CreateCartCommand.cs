using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Commands
{
    public class CreateCartCommand: IRequest<CartModel>
    {
       public Guid UserId { get; set; }

       
    }


}
