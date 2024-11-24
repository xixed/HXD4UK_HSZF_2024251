using HXD4UK_HSZF_20242501.Model;
using HXD4UK_HSZF_20242501.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public interface IKamino
    {
        List<Clones> KaminoBattle();
    }
    public class Kamino : IKamino
    {
        public IKlonokHaborujadbcontext klonokHaborujadbcontext;

        public Kamino(IKlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            this.klonokHaborujadbcontext=klonokHaborujadbcontext;
        }


        public List<Clones> KaminoBattle()
        {
            Battles battle = klonokHaborujadbcontext.Battles.FirstOrDefault(clone => clone.Name == "Battle of Kamino");
            if (battle == null)
            {
                
                return null;
            }
            else
            {
                var clones = klonokHaborujadbcontext.Battlestoclones.Where(x=>x.BattleId==battle.Id).Select(x=>x.Clone).ToList();

                return clones;
            }
            
            
        }
    }
}
