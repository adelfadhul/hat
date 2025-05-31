using MediatR;

namespace Hat.Domain.Queries
{
    public class ColorsByProductQuery : IRequest<List<string>>
    {
        public string ProductId { get; set; }
    }
}
