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
    public interface I_501st_Legion
    {
        List<Clones> _501_Legion();
        List<Battles> _3_Atleast();

    }
    public class _501st_Legion : I_501st_Legion
    {
        IKlonokHaborujadbcontext klonokHaborujadbcontext { get; set; }


        public _501st_Legion(IKlonokHaborujadbcontext klonokHaborujadbcontext) 
        {
            this.klonokHaborujadbcontext=klonokHaborujadbcontext;
        }



        

        public List<Clones> _501_Legion()
        {
            var clones = klonokHaborujadbcontext.Clones.Where(clone=>clone.Squad.Name=="501st Legion").ToList();
            return clones;
            
        }

        public List<Battles> _3_Atleast()
        {

            var legion = klonokHaborujadbcontext.Squads.FirstOrDefault(b => b.Name == "501st Legion");

            if (legion == null)
            {
                return new List<Battles>();
            }
            else
            {
                var battlesWith501st = klonokHaborujadbcontext.Battles;
                List<Battles> battles = new List<Battles>();
                foreach (var item in battlesWith501st)
                {
                    int n = 0;
                    var clones = item.Clones;

                    foreach (var item1 in clones)
                    {
                        var squad = klonokHaborujadbcontext.Clones.Find(item1);

                        if (squad.Squad.Name == "501st Legion")
                        {
                            n++;
                        }
                    }

                    if (n >= 3)
                    {
                        battles.Add(item);
                    }


                }
                return battles;
            }
            
        }
    }
}
