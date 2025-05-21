using Hat.Domain.Models;
using Hat.Domain.Repositories;
using Hat.Model;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryProductRepository : IProductRepository
    {
        private static readonly Lazy<List<ProductModel>> _products = new(() =>
        {
            var products = new List<ProductModel>
            {
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                    Name = "BeoPlay Speaker",
                    BrandName = "Bang and Olufsen",
                    Price = 755,
                    ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png",
                    Details = "High-quality wireless speaker with immersive sound.",
                    Qty = 10,
                    IsAvailable = true,
                    ColorText = "#000000",
                    SizesText = "Standard,Large",
                    Reviews = new List<ReviewModel>()
                },
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Leather Wristwatch",
                    BrandName = "Tag Heuer",
                    Price = 450,
                    ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png",
                    Details = "Elegant leather wristwatch for all occasions.",
                    Qty = 5,
                    IsAvailable = true,
                    ColorText = "#A52A2A",
                    SizesText = "One Size",
                    Reviews = new List<ReviewModel>()
                },
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Smart Bluetooth Speaker",
                    BrandName = "Google LLC",
                    Price = 900,
                    ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png",
                    Details = "Smart speaker with voice assistant integration.",
                    Qty = 8,
                    IsAvailable = true,
                    ColorText = "#FFFFFF",
                    SizesText = "Small,Medium,Large",
                    Reviews = new List<ReviewModel>()
                },
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Smart Luggage",
                    BrandName = "Smart Inc",
                    Price = 1200,
                    ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png",
                    Details = "Luggage with built-in GPS and charging ports.",
                    Qty = 3,
                    IsAvailable = false,
                    ColorText = "#808080,#FFFFFF",
                    SizesText = "Medium,Large",
                    Reviews = new List<ReviewModel>()
                }
            };

            products[0].Reviews = new List<ReviewModel>
            {
                new ReviewModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = products[0].Id,
                    ImageUrl = "https://randomuser.me/api/portraits/men/1.jpg",
                    Name = "John Doe",
                    Review = "Amazing sound quality!",
                    Rating = 4.8f
                },
                new ReviewModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = products[0].Id,
                    ImageUrl = "https://randomuser.me/api/portraits/men/5.jpg",
                    Name = "Michael Brown",
                    Review = "Great bass and clarity.",
                    Rating = 4.6f
                }
            };

            products[1].Reviews = new List<ReviewModel>
            {
                new ReviewModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = products[1].Id,
                    ImageUrl = "https://randomuser.me/api/portraits/women/2.jpg",
                    Name = "Jane Smith",
                    Review = "Stylish and comfortable.",
                    Rating = 4.5f
                },
                new ReviewModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = products[1].Id,
                    ImageUrl = "https://randomuser.me/api/portraits/men/6.jpg",
                    Name = "David Lee",
                    Review = "Looks premium and feels durable.",
                    Rating = 4.7f
                }
            };

            products[2].Reviews = new List<ReviewModel>
            {
                new ReviewModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = products[2].Id,
                    ImageUrl = "https://randomuser.me/api/portraits/men/3.jpg",
                    Name = "Alex Johnson",
                    Review = "Very convenient for my smart home.",
                    Rating = 4.7f
                }
            };

            products[3].Reviews = new List<ReviewModel>
            {
                new ReviewModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = products[3].Id,
                    ImageUrl = "https://randomuser.me/api/portraits/women/4.jpg",
                    Name = "Emily Davis",
                    Review = "Perfect for frequent travelers.",
                    Rating = 4.9f
                },
                new ReviewModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = products[3].Id,
                    ImageUrl = "https://randomuser.me/api/portraits/men/7.jpg",
                    Name = "Chris Evans",
                    Review = "Love the GPS feature!",
                    Rating = 4.8f
                }
            };

            return products;
        });

        private static List<ProductModel> PRODUCTS()
        {
            
            return _products.Value;
        }
       
        public Task<List<ProductModel>> GetBestSettlingProducts()
        {

            var products= PRODUCTS();
            return Task.FromResult(products);
        }


        public Task<List<string>> GetBrands()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetFeaturedProducts()
        {
            var products = PRODUCTS();
            return Task.FromResult(products);
        }

        public Task<ProductModel?> GetProductById(Guid productId)
        {
            var products = PRODUCTS();
            var product = products.FirstOrDefault(p => p.Id == productId);
            return Task.FromResult(product);
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            return await Task.FromResult(PRODUCTS());
        }

        public Task<List<ProductModel>> GetProductsByCategory(Guid categoryId)
        {
           var products= PRODUCTS().Where(x => x.CategoryId == categoryId);
            return Task.FromResult(products.ToList());
        }

      

        public Task GetTabPages()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetWhishListProducts(string brandId)
        {
            var products = new List<ProductModel>
             {
                 new ProductModel { Name = "BeoPlay Speaker", BrandName = "Bang and Olufsen", Price = 755, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" },
                new ProductModel { Name = "Leather Wristwatch", BrandName = "Tag Heuer", Price = 450, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" },
                new ProductModel { Name = "Smart Bluetooth Speaker", BrandName = "Google LLC", Price = 900, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" },
                new ProductModel { Name = "Smart Luggage", BrandName = "Smart Inc", Price = 1200, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png"},
                new ProductModel { Name = "Smart Bluetooth Speaker", BrandName = "Bang and Olufsen", Price = 90, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" },
                new ProductModel { Name = "B&o Desk Lamp", BrandName = "Bang and Olufsen", Price = 450, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image7.png"},
                new ProductModel { Name = "BeoPlay Stand Speaker", BrandName = "Bang and Olufse", Price = 3000, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image8.png"  },
                new ProductModel { Name = "Airpods", BrandName = "B&o Phone Case", Price = 30, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image9.png" },
             };
            return Task.FromResult(products);
        }
    }
}
