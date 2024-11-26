using Microsoft.EntityFrameworkCore;
using productlib;

namespace ProductAPI
{
    public class SqlDbContext : DbContext, IDbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Product>(new ProductEntityTypeConfig());

            var products = ProductService.InitRequest.Select(req => req.ToEntity()).ToList();
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
