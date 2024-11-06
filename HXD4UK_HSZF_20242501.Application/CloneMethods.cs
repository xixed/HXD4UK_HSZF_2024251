using HXD4UK_HSZF_20242501.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public class CloneMethods
    {
        KlonokHaborujadbcontext klonokHaborujadbcontext;

        public CloneMethods(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            this.klonokHaborujadbcontext = klonokHaborujadbcontext;
        }

        public void Data()
        {
            var clones = klonokHaborujadbcontext.Clones.ToList();
            Console.WriteLine("Names".PadLeft(20) + "Designation".PadLeft(30) + "Rank".PadLeft(30) + "Squad_Id".PadLeft(20));
            Console.WriteLine();
            foreach (var item in clones)
            {
                Console.WriteLine($"{item.Name.PadLeft(20)}{item.Designation.PadLeft(30)}{item.Rank.PadLeft(30)}{item.Squad_id.ToString().PadLeft(20)}");
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
