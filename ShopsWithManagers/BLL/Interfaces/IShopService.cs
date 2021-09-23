using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IShopService
    {
        IEnumerable<ShopModel> GetShops();
    }
}
