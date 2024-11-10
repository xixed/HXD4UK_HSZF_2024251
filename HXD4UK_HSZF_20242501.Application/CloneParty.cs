using HXD4UK_HSZF_20242501.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public class CloneParty
    {
        public KlonokHaborujadbcontext KlonokHaborujadbcontext;

        public CloneParty(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            KlonokHaborujadbcontext = klonokHaborujadbcontext;
        }

        public void Party()
        {
            var clonePairs = KlonokHaborujadbcontext.Clones
                    .SelectMany(clone => clone.Battles, (clone, battle) => new { clone, battle })
                    .GroupBy(x => x.battle)
                    .SelectMany(group =>
                     group.SelectMany(c1 => group.Select(c2 => new { Clone1 = c1.clone, Clone2 = c2.clone }))
                    .Where(pair => pair.Clone1 != pair.Clone2))
                    .GroupBy(pair => new { pair.Clone1.Name, pair.Clone2.Name })
                    .Select(pairGroup => new
                                        {
                                            ClonePair = pairGroup.Key,
                                            BattleCount = pairGroup.Count()
                                        })
                                            .OrderByDescending(x => x.BattleCount)
                                            .FirstOrDefault();

            if (clonePairs != null)
            {
                Console.WriteLine($"Clones with the most battles together: {clonePairs.ClonePair.Name1} and {clonePairs.ClonePair.Name2} (Battles: {clonePairs.BattleCount})");
            }
        }
    }
}
