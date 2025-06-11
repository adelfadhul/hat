using Hat.Domain.Models;

namespace Hat.Domain.Store
{
    public interface ITaxRepository
    {

        Task<List<TaxModel>> GetVats();
        Task<TaxModel> GetVat(Guid vatId);
        Task<Guid> CreateVat(TaxModel vat);
        Task DeleteVat(Guid vatId);
        Task<List<TaxModel>> GetVatsByUser(Guid userId);
    }
}
