using HXD4UK_HSZF_20242501.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace HXD4UK_HSZF_20242501.Persistence.MsSql
{
    public interface IKlonokHaborujadbcontext
    {
        public DbSet<Battles> Battles { get; set; }
        public DbSet<Clones> Clones { get; set; }
        public DbSet<Squads> Squads { get; set; }
        public DbSet<Battlestoclones> Battlestoclones { get; set; }

        public event EventHandler<Clones> cloneAdded;

        public int SaveChanges();

        public void OnCloneAdded(Clones clone);
        

    }

    public class KlonokHaborujadbcontext : DbContext, IKlonokHaborujadbcontext
    {
        public DbSet<Battles> Battles { get; set; }
        public DbSet<Clones> Clones { get; set; }
        public DbSet<Squads> Squads { get; set; }

        public DbSet<Battlestoclones> Battlestoclones { get; set; }

        string connStr;

        
        public event EventHandler<Clones> cloneAdded;

        public KlonokHaborujadbcontext(DbContextOptions<KlonokHaborujadbcontext> options) : base(options)
        {
            
            Database.EnsureDeleted();
            Database.EnsureCreated();
            
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            modelBuilder.Entity<Clones>().HasOne(clone => clone.Squad).WithMany(squad => squad.Clones).HasForeignKey(clone => clone.Squad_id);

            modelBuilder.Entity<Battlestoclones>().HasKey(bc => new {  bc.BattleId, bc.CloneId }); 

            modelBuilder.Entity<Battlestoclones>()
                .HasOne(bc => bc.Battle)
                .WithMany(bc=>bc.Battlestoclones) 
                .HasForeignKey(bc => bc.BattleId);

            
        }
        public void OnCloneAdded(Clones clone)
        {
            cloneAdded?.Invoke(this, clone);
        }

        
    }
    
}
