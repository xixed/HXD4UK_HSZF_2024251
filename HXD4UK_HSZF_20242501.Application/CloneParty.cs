using HXD4UK_HSZF_20242501.Model;
using HXD4UK_HSZF_20242501.Persistence.MsSql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public interface ICloneParty
    {
        List<Clones> Party();
    }
    public class CloneParty : ICloneParty
    {
        public IKlonokHaborujadbcontext KlonokHaborujadbcontext;

        public CloneParty(IKlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            KlonokHaborujadbcontext = klonokHaborujadbcontext;
        }
        public List<Clones> Party()
        {

            var cloneBattles = KlonokHaborujadbcontext.Clones
                .Include(clone => clone.Battlestoclones)
                .ThenInclude(bc => bc.Battle)
                    .ToList();

            int maxSharedBattles = 0;
            Clones? clone1 = null;
            Clones? clone2 = null;

            for (int i = 0; i < cloneBattles.Count; i++)
            {
                for (int j = i + 1; j < cloneBattles.Count; j++)
                {
                    var sharedBattles = cloneBattles[i].Battlestoclones
                        .Select(bc => bc.BattleId)
                        .Intersect(cloneBattles[j].Battlestoclones.Select(bc => bc.BattleId))
                        .Count();

                    if (sharedBattles > maxSharedBattles)
                    {
                        maxSharedBattles = sharedBattles;
                        clone1 = cloneBattles[i];
                        clone2 = cloneBattles[j];
                    }
                }
            }
            List<Clones> clones = new List<Clones>();
            clones.Add(clone1);
            clones.Add(clone2);
            return clones;
            
            

        }
    }
    
}
