using HXD4UK_HSZF_20242501.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public class Kamino
    {
        public KlonokHaborujadbcontext klonokHaborujadbcontext;

        public Kamino(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            this.klonokHaborujadbcontext=klonokHaborujadbcontext;
        }


        public void KaminoBattle()
        {
            var battle = klonokHaborujadbcontext.Battles.Where(clone => clone.Location == "Battle of Kamino");
            if (battle == null)
            {
                Console.WriteLine("There are no 'Battle of Kamino' in the database");
            }
            else
            {
                var clones = klonokHaborujadbcontext.Clones;

                foreach (var clone in clones)
                {
                    Console.WriteLine($"Name: {clone.Name}, Rank: {clone.Rank}");
                }
            }
            
        }
    }
}
