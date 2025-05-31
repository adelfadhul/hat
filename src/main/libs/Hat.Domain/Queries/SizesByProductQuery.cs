using MediatR;

namespace Hat.Domain.Queries
{
    public class SizesByProductQuery : IRequest<List<string>>
    {
        public string ProductId { get; set; }
    }
}
