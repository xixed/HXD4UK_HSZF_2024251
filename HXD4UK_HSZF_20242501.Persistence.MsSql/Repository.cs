using HXD4UK_HSZF_20242501.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Persistence.MsSql
{
    public class Repository
    {
        public KlonokHaborujadbcontext KlonokHaborujadbcontext { get; set; }

        public Repository(KlonokHaborujadbcontext klonokHaborujadbcontext) 
        {
            this.KlonokHaborujadbcontext=klonokHaborujadbcontext;
        }

        //Clone

        public void Clone_Add(Clones clones)
        {
            if (KlonokHaborujadbcontext.Clones.Find(clones.Id) == null)
            {
                KlonokHaborujadbcontext.Clones.Add(clones);
            }
            else { throw new NotFound("There is another clone with this id"); }

            KlonokHaborujadbcontext.SaveChanges();
        }

        public void Clone_Delete(int id)
        {
            var clone = KlonokHaborujadbcontext.Clones.FirstOrDefault(s => s.Id == id);
            KlonokHaborujadbcontext.Clones.Remove(clone);
            KlonokHaborujadbcontext.SaveChanges();
        }

        

        public void Clone_Update(Clones clones)
        {
            var clone = KlonokHaborujadbcontext.Clones.FirstOrDefault(s=>s.Id == clones.Id);
            clone.Name=clones.Name;
            clone.Designation=clones.Designation;
            clone.Rank=clones.Rank;
            clone.Squad_id=clones.Squad_id;
            KlonokHaborujadbcontext.SaveChanges();
        }


        //Battle

        public void Battle_Add(Battles battles)
        {
            if (KlonokHaborujadbcontext.Battles.Find(battles.Id) == null)
            {

                KlonokHaborujadbcontext.Battles.Add(battles);
            }
            else { throw new NotFound("There is another battle with this id"); }
            KlonokHaborujadbcontext.SaveChanges();
        }

        public void Battle_Delete(int id)
        {
            var battle = KlonokHaborujadbcontext.Battles.FirstOrDefault(s => s.Id == id);
            KlonokHaborujadbcontext.Battles.Remove(battle);
            KlonokHaborujadbcontext.SaveChanges();
        }



        public void Battle_Update(Battles battles)
        {
            var battle = KlonokHaborujadbcontext.Battles.FirstOrDefault(s => s.Id == battles.Id);
            battle.Name = battles.Name;
            battle.Location = battles.Location;
            battle.Date = battles.Date;
            battle.Clones = battles.Clones;
            KlonokHaborujadbcontext.SaveChanges();
        }

        //Squads

        public void Squad_Add(Squads squads)
        {
            if (KlonokHaborujadbcontext.Squads.Find(squads.Id) == null)
            {
                KlonokHaborujadbcontext.Squads.Add(squads);
            }
            else { throw new NotFound("There is another squad with this id"); }
            KlonokHaborujadbcontext.SaveChanges();
        }

        public void Squad_Delete(int id)
        {
            var squad = KlonokHaborujadbcontext.Squads.FirstOrDefault(s => s.Id == id);
            KlonokHaborujadbcontext.Squads.Remove(squad);
            KlonokHaborujadbcontext.SaveChanges();
        }



        public void Squad_Update(Squads squads)
        {
            var squad = KlonokHaborujadbcontext.Squads.FirstOrDefault(s => s.Id == squads.Id);
            squad.Name = squads.Name;
            squad.Commander = squads.Commander;
            KlonokHaborujadbcontext.SaveChanges();
        }


    }
}
