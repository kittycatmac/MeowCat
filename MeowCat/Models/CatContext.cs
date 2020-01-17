using Microsoft.EntityFrameworkCore;

namespace MeowCat.Models
{
    public class CatContext : DbContext
    {
    public CatContext(DbContextOptions<CatContext> options)
        : base(options)
    {
    }

    public DbSet<MeowCat> MeowCats { get; set; }
        
    }
}