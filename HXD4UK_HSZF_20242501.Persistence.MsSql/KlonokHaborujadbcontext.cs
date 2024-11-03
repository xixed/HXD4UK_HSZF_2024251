using HXD4UK_HSZF_20242501.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace HXD4UK_HSZF_20242501.Persistence.MsSql
{
    public class KlonokHaborujadbcontext : DbContext
    {
        public DbSet<Battles> Battles { get; set; }
        public DbSet<clones> Clones { get; set; }
        public DbSet<squads> Squads { get; set; }

        public DbSet<battlestoclones> Battlestoclones { get; set; }

        public KlonokHaborujadbcontext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=KlonokHaborujadbcontext;Integrated Security=True;MultipleActiveResultSets=true";

            optionsBuilder.UseSqlServer(connStr);
            base.OnConfiguring(optionsBuilder);
        }
        
    }
}
