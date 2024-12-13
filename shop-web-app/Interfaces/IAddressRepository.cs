using shop_web_app.Models;

namespace shop_web_app.Interfaces
{
    public interface IAddressRepository
    {
        bool Add(Address address);
        bool Update(Address address);
        bool Delete(Address address);
        bool Save();
    }
}
