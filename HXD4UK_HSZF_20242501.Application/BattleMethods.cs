using HXD4UK_HSZF_20242501.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public class BattleMethods
    {
        KlonokHaborujadbcontext klonokHaborujadbcontext;

        public BattleMethods(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            this.klonokHaborujadbcontext=klonokHaborujadbcontext;
        }

        public void Data()
        {
            var battles = klonokHaborujadbcontext.Battles.ToList();
            Console.WriteLine("Names".PadLeft(20) + "Location".PadLeft(30) + "Date".PadLeft(30) + "Clones".PadLeft(30));
            Console.WriteLine();

            foreach (var item in battles)
            {

                Console.WriteLine($"{item.Name.PadLeft(20)}{item.Location.PadLeft(30)}{item.Date.PadLeft(30)}{string.Join(",", item.Clones).PadLeft(30)}");



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
