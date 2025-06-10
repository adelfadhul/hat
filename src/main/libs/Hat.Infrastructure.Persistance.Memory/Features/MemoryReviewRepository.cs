using Hat.Domain.Identity;
using Hat.Domain.Store;
using Hat.Model;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryReviewRepository : IReviewRepository
    {
        private static readonly Lazy<List<ReviewModel>> _reviews = new(() =>
        {
            var Review1 = new List<ReviewModel>
            {
                new ReviewModel
                {
                    Id = Guid.NewGuid(),
                    ProductId =MemoryProductRepository.Product1,
                    ImageUrl = "https://randomuser.me/api/portraits/men/1.jpg",
                    Name = "John Doe",
                    Review = "Amazing sound quality!",
                    Rating = 4.8f
                },
                new ReviewModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = MemoryProductRepository.Product1,
                    ImageUrl = "https://randomuser.me/api/portraits/men/5.jpg",
                    Name = "Michael Brown",
                    Review = "Great bass and clarity.",
                    Rating = 4.6f
                }
            };

            var Reviews2 = new List<ReviewModel>
            {
                new ReviewModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = MemoryProductRepository.Product2,
                    ImageUrl = "https://randomuser.me/api/portraits/women/2.jpg",
                    Name = "Jane Smith",
                    Review = "Stylish and comfortable.",
                    Rating = 4.5f
                },
                new ReviewModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = MemoryProductRepository.Product2,
                    ImageUrl = "https://randomuser.me/api/portraits/men/6.jpg",
                    Name = "David Lee",
                    Review = "Looks premium and feels durable.",
                    Rating = 4.7f
                }
            };

            var Reviews3 = new List<ReviewModel>
            {
                new ReviewModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = MemoryProductRepository.Product3,
                    ImageUrl = "https://randomuser.me/api/portraits/men/3.jpg",
                    Name = "Alex Johnson",
                    Review = "Very convenient for my smart home.",
                    Rating = 4.7f
                }
            };

            var Reviews4 = new List<ReviewModel>
            {
                new ReviewModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = MemoryProductRepository.Product4,
                    ImageUrl = "https://randomuser.me/api/portraits/women/4.jpg",
                    Name = "Emily Davis",
                    Review = "Perfect for frequent travelers.",
                    Rating = 4.9f
                },
                new ReviewModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = MemoryProductRepository.Product4,
                    ImageUrl = "https://randomuser.me/api/portraits/men/7.jpg",
                    Name = "Chris Evans",
                    Review = "Love the GPS feature!",
                    Rating = 4.8f
                }
            };

            var L = new List<ReviewModel>();
            L.AddRange(Review1);
            L.AddRange(Reviews2);
            L.AddRange(Reviews3);
            L.AddRange(Reviews4);
            return L;
        });

        public MemoryReviewRepository() 
        {
        }

        private static List<ReviewModel> REVIEWS
       => _reviews.Value;
        public async Task<List<ReviewModel>> GetReviewsByProduct(Guid productId)
        {
           return await Task.Run(() =>
            {
                return REVIEWS.Where(r => r.ProductId == productId).ToList();
            });
        }
    }
}
