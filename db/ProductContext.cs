using Microsoft.EntityFrameworkCore;
using back.models;

namespace back.db
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions <ProductContext> options) : base(options)
        {
        }
        public DbSet<Products> Produtos {get; set; }
    }
}