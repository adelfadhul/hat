using Hat.Domain.Commands;
using Hat.Domain.Store;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hat.Application.Commands
{
    public class AddShoppingCartItemCommandHandler : IRequestHandler<AddShoppingCartItemCommand>
    {
        private readonly IShoppingCartRepository _repository;
        public AddShoppingCartItemCommandHandler(IShoppingCartRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(AddShoppingCartItemCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddCartItem(request.Item);

        }
    }
}
