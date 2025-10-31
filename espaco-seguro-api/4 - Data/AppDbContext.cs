using Microsoft.EntityFrameworkCore;

namespace espaco_seguro_api._4___Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        // Defina os DbSets para suas entidades aqui
    }
}
