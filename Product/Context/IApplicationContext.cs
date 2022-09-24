using Microsoft.EntityFrameworkCore;

namespace Product.Context
{
    public interface IApplicationContext
    {
        DbSet<Models.Product> Products { get; set; }

        Task<int> SaveChanges();
    }
}
