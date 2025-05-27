using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;
using Hat.Model;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryProductRepository :UserRepository, IProductRepository
    {
        public static  Guid Product1 => PRODUCTS[0].Id;
        public static Guid Product2 => PRODUCTS[1].Id;
        public static Guid Product3 => PRODUCTS[2].Id;
        public static Guid Product4 => PRODUCTS[3].Id;

        private static readonly Lazy<List<ProductModel>> _products = new(() =>
        {
            var products = new List<ProductModel>
            {
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                    CategoryId= MemoryCategoryRepository.CATEGORY_ElectronicId,
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
                    CategoryId= MemoryCategoryRepository.CATEGORY_FashionId,
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
                    CategoryId= MemoryCategoryRepository.CATEGORY_ElectronicId,
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
                    CategoryId= MemoryCategoryRepository.CATEGORY_HomeId,
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
            
            
            return products;
        });

        public MemoryProductRepository(ICurrentUser currentUser) : base(currentUser)
        {
            foreach (var product in PRODUCTS)
            {
                product.UserId = _currentUser.Oid();
            }
        }

        private static List<ProductModel> PRODUCTS
       => _products.Value;

        public Task<List<ProductModel>> GetBestSettlingProducts()
        {

            var products= PRODUCTS;
            return Task.FromResult(products);
        }


        public Task<List<string>> GetBrands()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetFeaturedProducts()
        {
            var products = PRODUCTS;
            return Task.FromResult(products);
        }

        public Task<ProductModel?> GetProductById(Guid productId)
        {
            var products = PRODUCTS;
            var product = products.FirstOrDefault(p => p.Id == productId);
            return Task.FromResult(product);
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            return await Task.FromResult(PRODUCTS);
        }

        public Task<List<ProductModel>> GetProductsByCategory(Guid categoryId)
        {
           var products= PRODUCTS.Where(x => x.CategoryId == categoryId);
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
