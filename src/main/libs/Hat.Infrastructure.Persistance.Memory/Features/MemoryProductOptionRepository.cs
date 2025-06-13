using Hat.Domain.Enums;
using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryProductOptionRepository : IProductOptionRepository
    {
        public static ProductOptionModel OPTION_BeoPlaySpeaker_Label => PRODUCT_OPTIONS[0];
        public static ProductOptionModel OPTION_BeoPlaySpeaker_SpeakerPower => PRODUCT_OPTIONS[1];
        public static ProductOptionModel OPTION_LeatherWristwatch_HeadphoneSize => PRODUCT_OPTIONS[2];
        public static ProductOptionModel OPTION__LeatherWristwatch_HeadphoneMaterial => PRODUCT_OPTIONS[3];
        public static ProductOptionModel OPTION_SmartBluetoothSpeaker_CaseType => PRODUCT_OPTIONS[4];

        private static readonly Lazy<List<ProductOptionModel>> _productOptions = new(() =>
        {
            var LabelOptionId = Guid.NewGuid();
            var SpeakerPowerOptionId = Guid.NewGuid();
            var HeadphoneOptionId = Guid.NewGuid();
            var HeadphoneMaterialOptionId = Guid.NewGuid();
            var CaseTypeId = Guid.NewGuid();

            var productOptions = new List<ProductOptionModel>
            {
                new ProductOptionModel
                {
                    Id = LabelOptionId,
                    Name = "Label",
                    ValueType = ProductOptionValueType.Text,
                    ProductId = MemoryProductRepository.PRODUCT_BeoPlaySpeaker,
                    Selections = new List<ProductOptionSelectionModel>(),
                    Price=null,
                },
                new ProductOptionModel
                {
    Id = SpeakerPowerOptionId,
    Name = "Speaker Power",
    ValueType = ProductOptionValueType.Selection,
    ProductId = MemoryProductRepository.PRODUCT_BeoPlaySpeaker,
    //Selections = new List<ProductOptionSelectionModel>
    //{
    //    new ProductOptionSelectionModel { Id = Guid.NewGuid(), ProductOptionId = SpeakerPowerOptionId, Value = "High", Price=10 },
    //    new ProductOptionSelectionModel { Id = Guid.NewGuid(), ProductOptionId = SpeakerPowerOptionId, Value = "Low", Price=5 }
    //}
},
                new ProductOptionModel
                {
                    Id = HeadphoneOptionId,
                    Name = "Headphone Size",
                    ValueType = ProductOptionValueType.Number,
                    ProductId = MemoryProductRepository.PRODUCT_LeatherWristwatch,
                    Price=null,
                    //Selections = new List<ProductOptionSelectionModel>(){ 
                    //new ProductOptionSelectionModel{Id=Guid.NewGuid(), ProductOptionId=HeadphoneOptionId, Value="M", Price=15},
                    //new ProductOptionSelectionModel{Id=Guid.NewGuid(), ProductOptionId=HeadphoneOptionId, Value="S", Price=5},
                    //}
                },
                new ProductOptionModel
                {
                    Id = HeadphoneMaterialOptionId,
                    Name = "Headphone Material",
                    ValueType = ProductOptionValueType.Text,
                    Price = 25,
                    ProductId = MemoryProductRepository.PRODUCT_LeatherWristwatch,
                    Selections = null
                },
                new ProductOptionModel
                {
                    Id = CaseTypeId,
                    Name = "Case Type",
                    ValueType = ProductOptionValueType.Selection,
                    Price = 30,
                    ProductId = MemoryProductRepository.PRODUCT_SmartBluetoothSpeaker,
                    //Selections = new List<ProductOptionSelectionModel>
                    //{
                    //    new ProductOptionSelectionModel { Id = Guid.NewGuid(), ProductOptionId = CaseTypeId, Value = "Leather",Price=1 },
                    //    new ProductOptionSelectionModel { Id = Guid.NewGuid(), ProductOptionId =CaseTypeId, Value = "Fabric" , Price = 5}
                    //}
                }
            };


            return productOptions;
        });

        public static List<ProductOptionModel> PRODUCT_OPTIONS => _productOptions.Value;
        public async Task<Guid> Create(ProductOptionModel model)
        {
            PRODUCT_OPTIONS.Add(model);
            return await Task.FromResult(model.Id);
        }

        public Task Delete(Guid productOptionId)
        {
            var productOptionToRemove = PRODUCT_OPTIONS.SingleOrDefault(x => x.Id == productOptionId);
            if (productOptionToRemove is null)
            {

            }
            else
            {
                PRODUCT_OPTIONS.Remove(productOptionToRemove);
            }

            return Task.CompletedTask;
        }

        public async Task<ProductOptionModel?> GetProductOptionById(Guid productOptionId)
        {
            var x = PRODUCT_OPTIONS.SingleOrDefault(x => x.Id == productOptionId);
            return await Task.FromResult(x);
        }

        public Task<List<ProductOptionModel>> GetProductOptionsByProduct(Guid productId)
        {
            return Task.FromResult(PRODUCT_OPTIONS.Where(x => x.ProductId == productId).ToList());
        }

        public Task<List<ProductOptionModel>> GetProductOptionsByProducts(List<Guid> productIds)
        {
            return Task.FromResult(PRODUCT_OPTIONS.Where(x => productIds.Contains(x.ProductId)).ToList());
        }

        public Task Update(ProductOptionModel model)
        {
            // throw new NotImplementedException();
            return Task.CompletedTask;
        }
    }
}
