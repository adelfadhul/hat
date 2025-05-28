using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryVatRepository : IVatRepository
    {
        private static readonly Lazy<List<VatModel>> _vats = new(() =>
        {
            var vats = new List<VatModel>
            {
                new VatModel { Id = Guid.NewGuid(), Name = "Standard VAT", Rate = 0.2 },
                new VatModel { Id = Guid.NewGuid(), Name = "Reduced VAT", Rate = 0.05 },
                new VatModel { Id = Guid.NewGuid(), Name = "Zero VAT", Rate = 0.00 }
            };
            return vats;
        });
        public static List<VatModel> VATS => _vats.Value;
        public async Task AddVat(VatModel vat)
        {
            VATS.Add(vat);
            await Task.FromResult(Task.CompletedTask);
        }

        public async Task DeleteVat(Guid vatId)
        {
           VATS.RemoveAll(v => v.Id == vatId);
            await Task.FromResult(Task.CompletedTask);
        }

        public Task<VatModel> GetVat(Guid vatId)
        {
            return Task.FromResult(VATS.FirstOrDefault(v => v.Id == vatId) ?? new VatModel());
        }

        public Task<List<VatModel>> GetVats()
        {
          return Task.FromResult(VATS);
        }
    }
}
