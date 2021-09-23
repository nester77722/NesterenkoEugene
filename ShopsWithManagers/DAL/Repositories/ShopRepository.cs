using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly ShopsDBContext _dbContext;

        public ShopRepository(ShopsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Shop> GetShops()
        {
           return _dbContext.Shops.AsNoTracking().ToList();
        }
    }
}
