using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface IVatRepository
    {

        Task<List<VatModel>> GetVats();
        Task<VatModel> GetVat(Guid vatId);
        Task AddVat(VatModel vat);
        Task DeleteVat(Guid vatId);
    }
}
