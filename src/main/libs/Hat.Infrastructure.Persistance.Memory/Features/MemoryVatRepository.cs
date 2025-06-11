using Hat.Domain.Models;
using Hat.Domain.Store;
using Hat.Infrastructure.Identity.Memory;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryVatRepository : ITaxRepository
    {
        public static Guid VAT_StandardVAT => VATS.Single(c => c.Name == "Standard VAT").Id;
        public static Guid VATS_ReducedVAT => VATS.Single(c => c.Name == "Reduced VAT").Id;
        public static Guid VATS_ZeroVAT => VATS.Single(c => c.Name == "Zero VAT").Id;
        private static readonly Lazy<List<TaxModel>> _vats = new(() =>
        {
            var vats = new List<TaxModel>
            {
                new TaxModel { Id = Guid.NewGuid(), UserId= MemoryLoginService.UserId1, Name = "Standard VAT", Rate = 0.2 },
                new TaxModel { Id = Guid.NewGuid(),UserId= MemoryLoginService.UserId2, Name = "Reduced VAT", Rate = 0.05 },
                new TaxModel { Id = Guid.NewGuid(),UserId= MemoryLoginService.UserId3, Name = "Zero VAT", Rate = 0.00 }
            };
            return vats;
        });
        public static List<TaxModel> VATS => _vats.Value;
        public async Task<Guid> CreateVat(TaxModel vat)
        {
            vat.Id = Guid.NewGuid();
            VATS.Add(vat);
            return await Task.FromResult(vat.Id);
        }

        public async Task DeleteVat(Guid vatId)
        {
            VATS.RemoveAll(v => v.Id == vatId);
            await Task.FromResult(Task.CompletedTask);
        }

        public Task<TaxModel> GetVat(Guid vatId)
        {
            return Task.FromResult(VATS.FirstOrDefault(v => v.Id == vatId) ?? new TaxModel());
        }

        public Task<List<TaxModel>> GetVats()
        {
            return Task.FromResult(VATS);
        }
        public Task<List<TaxModel>> GetVatsByUser(Guid userId)
        {
            // In a real application, you would filter by userId
            return Task.FromResult(VATS.Where(x => x.UserId == userId).ToList());
        }
    }

}
