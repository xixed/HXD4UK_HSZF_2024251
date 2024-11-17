using HXD4UK_HSZF_20242501.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public class AllDataQuerie
    {
        public IKlonokHaborujadbcontext klonokHaborujadbcontext;
        public BattleMethods battleMethods;
        public CloneMethods cloneMethods;
        public SquadMethods squadMethods;



        public AllDataQuerie(IKlonokHaborujadbcontext klonokHaborujadbcontext, SquadMethods squadMethods, CloneMethods cloneMethods, BattleMethods battleMethods)
        {
            this.klonokHaborujadbcontext = klonokHaborujadbcontext;
            this.squadMethods = squadMethods;
            this.cloneMethods = cloneMethods;
            this.battleMethods = battleMethods;
        }

        public void AllData()
        {
            Console.WriteLine("Squads:");
            squadMethods.Data();
            Console.WriteLine("Clones:");
            cloneMethods.Data();
            Console.WriteLine("Battles:");
            battleMethods.Data();

        }

    }
}
