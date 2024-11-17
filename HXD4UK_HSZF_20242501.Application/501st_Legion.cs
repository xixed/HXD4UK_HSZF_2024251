using HXD4UK_HSZF_20242501.Persistence.MsSql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public class _501st_Legion
    {
        IKlonokHaborujadbcontext klonokHaborujadbcontext;

        public _501st_Legion(IKlonokHaborujadbcontext klonokHaborujadbcontext) 
        {
            this.klonokHaborujadbcontext=klonokHaborujadbcontext;
        }



        

        public void _501_Legion()
        {
            var clones = klonokHaborujadbcontext.Clones.Where(clone=>clone.Squad.Name=="501st Legion").ToList();

            if (clones.Count == 0)
            {
                Console.WriteLine("There are no '501st Legion' squad in the database");
            }
            else { foreach (var clone in clones) { Console.WriteLine(clone.Name); } }
        }

        public void _3_Atleast()
        {

            var legion = klonokHaborujadbcontext.Squads.FirstOrDefault(b => b.Name == "501st Legion");

            if (legion == null)
            {
                Console.WriteLine("There are no '501st Legion' squad in the database");
            }
            else
            {
                var battlesWith501st = klonokHaborujadbcontext.Battles;
                
                foreach (var item in battlesWith501st)
                {
                    int n = 0;
                    var clones = item.Clones;

                    foreach (var item1 in clones)
                    {
                        var squad=klonokHaborujadbcontext.Clones.Find(item1);
                        
                        if(squad.Squad.Name=="501st Legion")
                        {
                            n++;
                        }
                    }

                    if (n >= 3)
                    {
                        Console.WriteLine(item.Name);
                    }
                    
                }
            } 
        }
    }
}
