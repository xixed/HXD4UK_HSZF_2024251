using HXD4UK_HSZF_20242501.Model;
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
        CloneEventHandler cloneEventHandler;
        
        public CloneMethods(KlonokHaborujadbcontext klonokHaborujadbcontext, CloneEventHandler cloneEventHandler)
        {
            this.klonokHaborujadbcontext = klonokHaborujadbcontext;
            this.cloneEventHandler = cloneEventHandler;
            klonokHaborujadbcontext.cloneAdded += cloneEventHandler.CreateFile;
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
            Console.WriteLine("Name your clone:");
            string name = Console.ReadLine();
            Console.WriteLine("Give a designation to your clone:");
            string desigantion = Console.ReadLine();
            Console.WriteLine("Give a rank to your clone:");
            string rank = Console.ReadLine();
            Console.WriteLine("Choose a Squad to be your clone in:");
            int options = 0;
            foreach (var item in klonokHaborujadbcontext.Squads)
            {
                options++;
                Console.Write($"{item.Name} [{item.Id}], ");
            }
            Console.WriteLine();
            int squad_id;
            while (true)
            {

                squad_id = int.Parse(Console.ReadLine());

                if (squad_id <= options)
                    break;
                else
                    Console.WriteLine("There are no squad with this number try again");
            }
            Clones clones = new Clones(name, desigantion, rank, squad_id);

            klonokHaborujadbcontext.Clones.Add(clones);

            klonokHaborujadbcontext.SaveChanges();
           
            klonokHaborujadbcontext.OnCloneAdded(clones);
            Console.WriteLine("New Clone inserted");
            Console.WriteLine();
        }

        public void Remove()
        {
            Console.WriteLine("Choose wich Clone do you want to delete:");

            foreach (var item in klonokHaborujadbcontext.Clones)
            {

                Console.Write($"{item.Name} [{item.Id}], ");
            }
            Console.WriteLine();
            int index = int.Parse(Console.ReadLine());

            var delete = klonokHaborujadbcontext.Clones.FirstOrDefault(s => s.Id == index);
            if (delete == null)
            {
                Console.WriteLine("Wrong Id try again");
                Remove();
            }
            else
            {
                klonokHaborujadbcontext.Clones.Remove(delete);
                klonokHaborujadbcontext.SaveChanges();
            } 
            Console.WriteLine();
            Console.WriteLine("Clone deteled");
        }

        public void Update()
        {
            Console.WriteLine("Choose a Clone you want to update");
            Console.WriteLine();
            int options = 0;
            foreach (var item in klonokHaborujadbcontext.Clones)
            {
                options++;
                Console.Write($"{item.Name} [{item.Id}], ");
            }
            Console.WriteLine();
            int index;
            while (true)
            {

                index = int.Parse(Console.ReadLine());

                if (index <= options)
                    break;
                else
                    Console.WriteLine("There are no clone with this number try again");
            }
            Console.WriteLine();
            Console.WriteLine("Which item do you want to change?");
            var clone = klonokHaborujadbcontext.Clones.FirstOrDefault(s => s.Id == index);
            Console.WriteLine($"{clone.Name}[1]");
            Console.WriteLine($"{clone.Designation}[2]");
            Console.WriteLine($"{clone.Rank}[3]");
            Console.WriteLine($"{clone.Squad_id}[4]");
            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    Console.WriteLine("Changing name...");
                    string name = Console.ReadLine();
                    clone.Name = name;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
                else if (key == ConsoleKey.D2)
                {
                    Console.WriteLine("Changing designation...");
                    string desigantion = Console.ReadLine();
                    clone.Designation = desigantion;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
                else if (key == ConsoleKey.D3)
                {
                    Console.WriteLine("Changing rank...");
                    string rank = Console.ReadLine();
                    clone.Rank = rank;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
                else if (key == ConsoleKey.D4)
                {
                    Console.WriteLine("Changing squad...");
                    Console.WriteLine("Choose another squad:");
                    foreach (var item in klonokHaborujadbcontext.Squads)
                    {
                        Console.Write($"{item.Name}, [{item.Id}] ");
                    }
                    int squad = int.Parse(Console.ReadLine());
                    clone.Squad_id = squad;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
            }
        }
    }
}
