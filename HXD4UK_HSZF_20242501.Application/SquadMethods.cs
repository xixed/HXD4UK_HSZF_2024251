using HXD4UK_HSZF_20242501.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public class SquadMethods
    {
        KlonokHaborujadbcontext klonokHaborujadbcontext;

        public SquadMethods(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            this.klonokHaborujadbcontext = klonokHaborujadbcontext;
        }

        public void Data()
        {
            var squads = klonokHaborujadbcontext.Squads.ToList();
            Console.WriteLine("Names".PadLeft(30) + "Commanders".PadLeft(70));
            Console.WriteLine();
            foreach (var item in squads)
            {
                Console.WriteLine($"{item.Name.PadLeft(30)}{item.Commander.PadLeft(70)}");
            }
            Console.WriteLine();
        }


        public void Add()
        {

        }

        public void Remove()
        {

        }

        public void Update()
        {

        }
    }
}
