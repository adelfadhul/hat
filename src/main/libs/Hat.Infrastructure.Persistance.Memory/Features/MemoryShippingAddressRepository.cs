using Hat.Domain.Identity;
using Hat.Domain.Models;
using Hat.Domain.Store;

namespace Hat.Infrastructure.Persistance.Memory.Features
{
    public class MemoryShippingAddressRepository : UserRepository, IShippingAddressRepository
    {
        private static Lazy<List<ShippingAddressModel>> _addresses = new(() =>
        {
            return new List<ShippingAddressModel>
            {
                new ShippingAddressModel
                {
                     Id = Guid.NewGuid(),
                      UserId = Guid.NewGuid(),
                      IsPrimary = true, 
                    Name = "Home Address",
                    Address = "21, Alex Davidson Avenue, Opposite Omegatron, Vicent Smith Quarters, Victoria Island, Lagos, Nigeria",

                },
                new ShippingAddressModel
                {
                        Id = Guid.NewGuid(),
                        UserId = Guid.NewGuid(),
                        IsPrimary = false,
                    Name = "Work Address",
                    Address = "9, Martins Crescent, Bank of Nigeria, Abuja, Nigeria",

                }
            };
        });

        public MemoryShippingAddressRepository(ILoginService loginService) : base(loginService)
        {
        }

        private static List<ShippingAddressModel> ADDRESSES => _addresses.Value;
        public Task<List<ShippingAddressModel>> GetShippingAddresses()
        {
            // Simulate async operation
            return Task.FromResult(ADDRESSES);
        }

        public Task<ShippingAddressModel?> GetPrimaryShippingAddress()
        {
            return Task.FromResult(ADDRESSES.FirstOrDefault(a => a.IsPrimary) ?? null);
        }

        public Task<Guid> CreateShippingAddress(ShippingAddressModel model)
        {
            var newAddress = new ShippingAddressModel
            {
                Id = Guid.NewGuid(),
                UserId = model.UserId,
                IsPrimary = model.IsPrimary,
                Address = model.Address,
                Name = model.Name
            };
            ADDRESSES.Add(newAddress);
            return Task.FromResult(newAddress.Id);
        }

        public Task DeleteShippingAddress(Guid id)
        {
            ADDRESSES.RemoveAll(a => a.Id == id);
            return Task.CompletedTask;
        }

        public Task InactivateShippingAddress(Guid id)
        {
            ADDRESSES.Single(a => a.Id == id).IsInactive = true;
            return Task.CompletedTask;
        }

        public Task ActivateShippingAddress(Guid id)
        {
            ADDRESSES.Single(a => a.Id == id).IsInactive = false;
            return Task.CompletedTask;
        }

        public Task<List<ShippingAddressModel>> GetShippingAddressesByUser(Guid userId)
        {
            return Task.FromResult(ADDRESSES.Where(a => a.UserId == userId && !a.IsInactive).ToList());
        }
    }
}
