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
        string connStr;

        public DbSet<Battlestoclones> Battlestoclones { get; set; }

        public KlonokHaborujadbcontext(string connStr)
        {
            this.connStr = connStr;
            Database.EnsureDeleted();
            Database.EnsureCreated();
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

            optionsBuilder.UseSqlServer(connStr);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {




            
            modelBuilder.Entity<Clones>()
                .HasOne(clone => clone.Squad)
                .WithMany(squad => squad.Clones)
                .HasForeignKey(clone => clone.Squad_id);

            
            modelBuilder.Entity<Battlestoclones>()
                .HasKey(bc => new { bc.CloneId, bc.BattleId });

            
            modelBuilder.Entity<Battlestoclones>()
                .HasOne(bc => bc.clones)  
                .WithMany(clone => clone.Battles)
                .HasForeignKey(bc => bc.CloneId);

            
            modelBuilder.Entity<Battlestoclones>()
                .HasOne(bc => bc.battles)  
                .WithMany(battle => battle.Clones1) 
                .HasForeignKey(bc => bc.BattleId);

        }

        

    }
}
