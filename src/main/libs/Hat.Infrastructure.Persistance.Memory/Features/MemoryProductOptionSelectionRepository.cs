using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryProductOptionSelectionRepository:IProductOptionSelectionRepository
    {
        private static Lazy<List<ProductOptionSelectionModel>> _selections = new(() =>
        {
            var selections = new List<ProductOptionSelectionModel>
            {
                new ProductOptionSelectionModel
                {
                    Id = Guid.NewGuid(),
                    ProductOptionId = MemoryProductOptionRepository.OPTION_BeoPlaySpeaker_SpeakerPower.Id,
                    Value = "Loud"
                },
                new ProductOptionSelectionModel
                {
                    Id = Guid.NewGuid(),
                    ProductOptionId = MemoryProductOptionRepository.OPTION_BeoPlaySpeaker_SpeakerPower.Id,
                    Value = "Quite"
                },
                new ProductOptionSelectionModel
                {
                    Id = Guid.NewGuid(),
                    ProductOptionId = MemoryProductOptionRepository.OPTION_BeoPlaySpeaker_SpeakerPower.Id,
                    Value = "Mutable"
                },
                new ProductOptionSelectionModel
                {
                    Id = Guid.NewGuid(),
                    ProductOptionId = MemoryProductOptionRepository.OPTION_SmartBluetoothSpeaker_CaseType.Id,
                    Value = "Alumimum"
                },
                new ProductOptionSelectionModel
                {
                    Id = Guid.NewGuid(),
                    ProductOptionId = MemoryProductOptionRepository.OPTION_SmartBluetoothSpeaker_CaseType.Id,
                    Value = "Iron"
                },
                new ProductOptionSelectionModel
                {
                    Id = Guid.NewGuid(),
                    ProductOptionId = MemoryProductOptionRepository.OPTION_SmartBluetoothSpeaker_CaseType.Id,
                    Value = "Plastic"
                }
            };
            return selections;
        });
     
    
        public static List<ProductOptionSelectionModel> SELECTIONS=> _selections.Value;

        public Task<Guid> Create(ProductOptionSelectionModel model)
        {
            SELECTIONS.Add(model);
            return Task.FromResult(model.Id);
        }

        public Task Delete(Guid productOptionSelectionId)
        {
           SELECTIONS.RemoveAll(s => s.Id == productOptionSelectionId);
            return Task.CompletedTask;
        }

        public Task<ProductOptionSelectionModel?> GetProductOptionSelectionById(Guid productOptionSelectionId)
        {
           return Task.FromResult(SELECTIONS.FirstOrDefault(s => s.Id == productOptionSelectionId));
        }

        public Task<List<ProductOptionSelectionModel>> GetProductOptionSelectionsByOption(Guid optionId)
        {
           return Task.FromResult(SELECTIONS
                .Where(s => s.ProductOptionId == optionId)
                .ToList());
        }

        public Task<List<ProductOptionSelectionModel>> GetProductOptionSelectionsByProductIds(List<Guid> productIds)
        {
           return Task.FromResult(SELECTIONS
                .Where(s => productIds.Contains(s.ProductOptionId))
                .ToList());
        }

        public Task Update(ProductOptionSelectionModel model)
        {
            var selectionToUpdate = SELECTIONS.FirstOrDefault(s => s.Id == model.Id);
            if (selectionToUpdate != null)
            {
                selectionToUpdate.Value = model.Value;
                selectionToUpdate.ProductOptionId = model.ProductOptionId;
            }
            return Task.CompletedTask;
        }
    }
}
