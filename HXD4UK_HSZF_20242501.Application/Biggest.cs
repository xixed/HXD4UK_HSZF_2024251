using HXD4UK_HSZF_20242501.Model;
using HXD4UK_HSZF_20242501.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public class Biggest
    {
        public IKlonokHaborujadbcontext klonokHaborujadbcontext;


        public Biggest(IKlonokHaborujadbcontext klonokHaborujadbcontext) 
        {
            this.klonokHaborujadbcontext=klonokHaborujadbcontext;
        }

        public void Big()
        {

            var battle = klonokHaborujadbcontext.Battles.Select(battle => new { Battle = battle, CloneCount = battle.Clones.Count() }).OrderByDescending(b => b.CloneCount).FirstOrDefault();
            if (battle == null)
            {
                Console.WriteLine("There are no battle in the database");
            }
            else
            {
                Console.WriteLine($"{battle.Battle.Name}");
            }
        }


    }
}
