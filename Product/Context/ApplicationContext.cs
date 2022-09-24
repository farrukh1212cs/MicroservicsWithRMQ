using Microsoft.EntityFrameworkCore;

namespace Product.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Product.Models.Product> Products { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
