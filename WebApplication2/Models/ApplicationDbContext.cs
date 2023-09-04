using Microsoft.EntityFrameworkCore;

namespace CmsShoppingCart.Models
{
    public class ApplicationDbContext : DbContext
    {
       /* public DbSet<Product> Products { get; set; }
        public DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Offer>()
                .HasOne(o => o.Product)
                .WithMany(p => p.Offer)
                .HasForeignKey(o => o.ProductId);*/
//        }
    }
}
