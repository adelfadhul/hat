using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;
using Hat.Infrastructure.Identity.Memory;
using Hat.Model;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryProductRepository :  IProductRepository
    {
        public static Guid PRODUCT_BeoPlaySpeaker => PRODUCTS[0].Id;
        public static Guid PRODUCT_LeatherWristwatch => PRODUCTS[1].Id;
        public static Guid PRODUCT_SmartBluetoothSpeaker => PRODUCTS[2].Id;
        public static Guid PRODUCT_SmartLuggage => PRODUCTS[3].Id;

        private static readonly Lazy<List<ProductModel>> _products = new(() =>
        {
            var products = new List<ProductModel>
            {
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                    UserId= MemoryLoginService.USER_Alice,
                    VatId = MemoryVatRepository.VATS_ZeroVAT,
                    CategoryId= MemoryCategoryRepository.CATEGORY_ElectronicId,
                    Name = "BeoPlay Speaker",
                    BrandName = "Bang and Olufsen",
                    Price = 755,
                    ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png",
                    Details = "High-quality wireless speaker with immersive sound.",
                    Reviews = new List<ReviewModel>()
                },
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                     UserId= MemoryLoginService.USER_Bob,
                    CategoryId= MemoryCategoryRepository.CATEGORY_FashionId,
                    VatId = MemoryVatRepository.VATS_ReducedVAT,
                    Name = "Leather Wristwatch",
                    BrandName = "Tag Heuer",
                    Price = 450,
                    ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png",
                    Details = "Elegant leather wristwatch for all occasions.",
                    Reviews = new List<ReviewModel>()
                },
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                     UserId= MemoryLoginService.USER_Lina,
                    CategoryId= MemoryCategoryRepository.CATEGORY_ElectronicId,
                    VatId = MemoryVatRepository.VAT_StandardVAT,
                    Name = "Smart Bluetooth Speaker",
                    BrandName = "Google LLC",
                    Price = 900,
                    ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png",
                    Details = "Smart speaker with voice assistant integration.",

                    Reviews = new List<ReviewModel>()
                },
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                     UserId= MemoryLoginService.USER_Alice,
                    CategoryId= MemoryCategoryRepository.CATEGORY_HomeId,
                    VatId = MemoryVatRepository.VAT_StandardVAT,
                    Name = "Smart Luggage",
                    BrandName = "Smart Inc",
                    Price = 1200,
                    ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png",
                    Details = "Luggage with built-in GPS and charging ports.",

                    Reviews = new List<ReviewModel>()
                }
            };


            return products;
        });

        public MemoryProductRepository() 
        {
           
        }

        private static List<ProductModel> PRODUCTS
       => _products.Value;

        public Task<List<ProductModel>> GetBestSettlingProducts()
        {

            var products = PRODUCTS;
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
            var products = PRODUCTS.Where(x => x.CategoryId == categoryId);
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
                 new ProductModel { UserId= MemoryLoginService.USER_Alice, Name = "BeoPlay Speaker", BrandName = "Bang and Olufsen", Price = 755, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" },
                new ProductModel {UserId= MemoryLoginService.USER_Bob, Name = "Leather Wristwatch", BrandName = "Tag Heuer", Price = 450, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" },
                new ProductModel {UserId= MemoryLoginService.USER_Lina, Name = "Smart Bluetooth Speaker", BrandName = "Google LLC", Price = 900, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" },
                new ProductModel {UserId= MemoryLoginService.USER_Alice, Name = "Smart Luggage", BrandName = "Smart Inc", Price = 1200, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png"},
                new ProductModel { UserId= MemoryLoginService.USER_Bob,Name = "Smart Bluetooth Speaker", BrandName = "Bang and Olufsen", Price = 90, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" },
                new ProductModel { UserId= MemoryLoginService.USER_Lina,Name = "B&o Desk Lamp", BrandName = "Bang and Olufsen", Price = 450, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image7.png"},
                new ProductModel {UserId= MemoryLoginService.USER_Alice, Name = "BeoPlay Stand Speaker", BrandName = "Bang and Olufse", Price = 3000, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image8.png"  },
                new ProductModel {UserId= MemoryLoginService.USER_Bob, Name = "Airpods", BrandName = "B&o Phone Case", Price = 30, ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image9.png" },
             };
            return Task.FromResult(products);
        }

        public async Task<Guid> Create(ProductModel model)
        {
            model.Id = Guid.NewGuid();
            PRODUCTS.Add(model);
            return await Task.FromResult(model.Id);
        }

        public Task<List<ProductModel>> GetProductsByIds(List<Guid> guids)
        {
            var products = PRODUCTS.Where(p => guids.Contains(p.Id)).ToList();
            if (products.Count == 0)
            {
                return Task.FromResult(new List<ProductModel>());
            }
            return Task.FromResult(products);
        }

       
    }
}
