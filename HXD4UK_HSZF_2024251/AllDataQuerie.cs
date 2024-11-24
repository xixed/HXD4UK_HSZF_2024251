using HXD4UK_HSZF_20242501.Application;
using HXD4UK_HSZF_20242501.Model;
using HXD4UK_HSZF_20242501.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public interface IAllDataQuerie
    {
        void AllData();
    }
    public class AllDataQuerie : IAllDataQuerie
    {
        public IKlonokHaborujadbcontext klonokHaborujadbcontext;
        public IBattleMethods battleMethods;
        public ICloneMethods cloneMethods;
        public ISquadMethods squadMethods;



        public AllDataQuerie(IKlonokHaborujadbcontext klonokHaborujadbcontext, ISquadMethods squadMethods, ICloneMethods cloneMethods, IBattleMethods battleMethods)
        {
            this.klonokHaborujadbcontext = klonokHaborujadbcontext;
            this.squadMethods = squadMethods;
            this.cloneMethods = cloneMethods;
            this.battleMethods = battleMethods;
        }

        public void AllData()
        {
            Console.WriteLine("Squads:");
            List<Squads> squads =squadMethods.Data();
            Console.WriteLine("Names".PadLeft(30) + "Commanders".PadLeft(70));
            Console.WriteLine();
            foreach (var item in squads)
            {
                Console.WriteLine($"{item.Name.PadLeft(30)}{item.Commander.PadLeft(70)}");
            }
            Console.WriteLine();

            

            Console.WriteLine("Clones:");
            List<Clones>clones = cloneMethods.Data();
            Console.WriteLine("Names".PadLeft(20) + "Designation".PadLeft(30) + "Rank".PadLeft(30) + "Squad_Id".PadLeft(20));
            Console.WriteLine();
            foreach (var item in clones)
            {
                Console.WriteLine($"{item.Name.PadLeft(20)}{item.Designation.PadLeft(30)}{item.Rank.PadLeft(30)}{item.Squad_id.ToString().PadLeft(20)}");
            }
            Console.WriteLine();


            Console.WriteLine("Battles:");
            List<Battles> battles = battleMethods.Data();
            Console.WriteLine("Names".PadLeft(20) + "Location".PadLeft(30) + "Date".PadLeft(30) + "Clones".PadLeft(30));
            Console.WriteLine();

            foreach (var item in battles)
            {

                Console.WriteLine($"{item.Name.PadLeft(20)}{item.Location.PadLeft(30)}{item.Date.PadLeft(30)}{string.Join(",", item.Clones).PadLeft(30)}");



            }
        }

    }
}
