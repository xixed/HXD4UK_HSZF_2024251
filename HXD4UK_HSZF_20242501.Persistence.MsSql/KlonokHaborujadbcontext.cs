using HXD4UK_HSZF_20242501.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace HXD4UK_HSZF_20242501.Persistence.MsSql
{
    public class KlonokHaborujadbcontext : DbContext
    {
        public DbSet<Battles> Battles { get; set; }
        public DbSet<Clones> Clones { get; set; }
        public DbSet<Squads> Squads { get; set; }

        public DbSet<Battlestoclones> Battlestoclones { get; set; }

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            


            modelBuilder.Entity<Clones>()
                .HasOne(s => s.Squad).WithMany(c => c.Clones).HasForeignKey(c => c.Squad_id);



            modelBuilder.Entity<Battlestoclones>()
                .HasKey(bc => new { bc.CloneId, bc.BattleId });
            modelBuilder.Entity<Battlestoclones>()
                .HasOne(bc => bc.clones)
                .WithMany(b => b.Battles)
                .HasForeignKey(bc => bc.CloneId);
            modelBuilder.Entity<Battlestoclones>()
                .HasOne(bc => bc.battles)
                .WithMany(c => c.Clones1)
                .HasForeignKey(bc => bc.BattleId);





        }

        

    }
}
