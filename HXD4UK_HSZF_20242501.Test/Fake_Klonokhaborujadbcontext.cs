using HXD4UK_HSZF_20242501.Model;
using HXD4UK_HSZF_20242501.Persistence.MsSql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Test
{
    internal class Fake_Klonokhaborujadbcontext : DbContext , IKlonokHaborujadbcontext
    {
        public DbSet<Battles> Battles { get; set; }
        public DbSet<Clones> Clones { get ; set; }
        public DbSet<Squads> Squads { get;set; }
        public DbSet<Battlestoclones> Battlestoclones { get; set; }

        public event EventHandler<Clones> cloneAdded;

        private KlonokHaborujadbcontext context;

        public Fake_Klonokhaborujadbcontext()
        {
            var options = new DbContextOptionsBuilder<KlonokHaborujadbcontext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context = new KlonokHaborujadbcontext(options);

            Battles = context.Set<Battles>();
            Clones = context.Set<Clones>();
            Squads = context.Set<Squads>();
            Battlestoclones = context.Set<Battlestoclones>();
        }
        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void OnCloneAdded(Clones clone)
        {
            cloneAdded?.Invoke(this, clone);
        }
    }
}
