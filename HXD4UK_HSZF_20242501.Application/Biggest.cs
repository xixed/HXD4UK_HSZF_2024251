using HXD4UK_HSZF_20242501.Model;
using HXD4UK_HSZF_20242501.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public interface IBiggest
    {
        Battles Big();
    }
    public class Biggest : IBiggest
    {
        public IKlonokHaborujadbcontext klonokHaborujadbcontext;


        public Biggest(IKlonokHaborujadbcontext klonokHaborujadbcontext) 
        {
            this.klonokHaborujadbcontext=klonokHaborujadbcontext;
        }

        public Battles Big()
        {

            var battle = klonokHaborujadbcontext.Battles.Select(battle => new { Battle = battle, CloneCount = battle.Clones.Count() }).ToList().OrderByDescending(b => b.CloneCount).FirstOrDefault();
            if (battle == null)
            {
                
                return null;
            }
            else
            {
                
                return battle.Battle;
                
            }
            
        }


    }
}
