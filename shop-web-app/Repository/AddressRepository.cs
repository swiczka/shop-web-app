using shop_web_app.Data;
using shop_web_app.Interfaces;
using shop_web_app.Models;

namespace shop_web_app.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Address address)
        {
            _context.Addresses.Add(address);
            return Save();
        }

        public bool Delete(Address address)
        {
            _context.Addresses.Remove(address);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(Address address)
        {
            _context.Addresses.Update(address);
            return Save();
        }
    }
}
