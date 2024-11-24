using HXD4UK_HSZF_20242501.Model;
using HXD4UK_HSZF_20242501.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public interface IGeonosis
    {
        List<Clones> Geo();
    }
    public class Geonosis : IGeonosis
    {

        public IKlonokHaborujadbcontext klonokHaborujadbcontext;

        public Geonosis(IKlonokHaborujadbcontext klonokHaborujadbcontext) { this.klonokHaborujadbcontext = klonokHaborujadbcontext; }

        public List<Clones> Geo()
        {

            var geonosisClones = klonokHaborujadbcontext.Clones.Where(clone => clone.Squad.Name == "212th Attack Battalion");
            if (geonosisClones ==null)
            {
                Console.WriteLine("There are no clone in the '212th Attack Battalion' squad");
                return new List<Clones>();
            }

            var battleG = klonokHaborujadbcontext.Battles.FirstOrDefault(battle => battle.Name == "Battle of Geonosis");
            if (battleG == null)
            {
                Console.WriteLine("There are no 'Battle of Geonosis' battle in the database");
                return new List<Clones>();
            }

            var clonesInBattle = geonosisClones.Where(clone => clone.Battlestoclones.Any(bc => bc.BattleId == battleG.Id)).ToList();

            return clonesInBattle;
            
            
            

        }

    }
}
