using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApi.Models;

namespace WebApi.Data
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }

        public static ProdutoContext Instancia()
        {
            var contextOptions = new DbContextOptionsBuilder<ProdutoContext>().UseMySQL(@"Server=localhost;Database=ecommerce;Uid=root;Pwd=ROOT;").Options;

            return new ProdutoContext(contextOptions);
        }
    }
}
