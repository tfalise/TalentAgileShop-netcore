using Microsoft.EntityFrameworkCore;
using TalentAgileShop.Model;

namespace TalentAgileShop.Data
{
    public class TalentAgileShopDataContext : DbContext, IDataContext
    {

        public TalentAgileShopDataContext(DbContextOptions<TalentAgileShopDataContext> options) : base(options)
        {


        }


        public DbSet<Country> Countries { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

#if false
        public DbSet<DBCartItem> CartItems { get; set; }
#endif
 
    }
}

