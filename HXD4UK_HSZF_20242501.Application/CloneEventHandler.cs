using HXD4UK_HSZF_20242501.Model;
using HXD4UK_HSZF_20242501.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public interface ICloneEventHandler
    { 
        public void CreateFile(object sender, Clones clones);
    }
    public class CloneEventHandler : ICloneEventHandler
    {
        IKlonokHaborujadbcontext KlonokHaborujadbcontext;
        public CloneEventHandler(IKlonokHaborujadbcontext klonokHaborujadbcontext) 
        {
            KlonokHaborujadbcontext = klonokHaborujadbcontext;
        }
        
        public void CreateFile(object sender,Clones clones)
        {
            var squadname = KlonokHaborujadbcontext.Squads.FirstOrDefault(squad => squad.Id == clones.Squad_id);
            string folder = Path.Combine("Squad", squadname.Name);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string clonePath = Path.Combine(folder, $"{clones.Name}.txt");

            File.WriteAllText(clonePath,$"Name: {clones.Name}, Designation: {clones.Designation}, Rank: {clones.Rank}, Squad_Id: {clones.Squad_id}");
        }
    }
    
}
