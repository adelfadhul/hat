using Hat.Domain.Models;
using MediatR;

namespace Hat.Domain.Commands
{
    public class CreateCartCommand: IRequest<CartModel>
    {
       public Guid UserId { get; set; }

       public List<CartItemModel> CartItems { get; set; } 
        
        public Dictionary<Guid,KeyValuePair<string, string>> Options { get; set; } = new Dictionary<Guid, KeyValuePair<string, string>>(); // Optional, if you want to track options for each item
    }


}
