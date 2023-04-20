using BDDELP.Database.EntityModels;
using Microsoft.EntityFrameworkCore;


namespace BDDELP.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { 
        }

        public DbSet<Utilisateur> Utilisateur { get; set; }
    }
}
