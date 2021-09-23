using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IShopRepository
    {
        IEnumerable<Shop> GetShops();
    }
}
