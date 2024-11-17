using HXD4UK_HSZF_20242501.Model;
using HXD4UK_HSZF_20242501.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public class SquadMethods
    {
        IKlonokHaborujadbcontext klonokHaborujadbcontext;
        IWrongInput WrongInput;


        public SquadMethods(IKlonokHaborujadbcontext klonokHaborujadbcontext, IWrongInput wrongInput)
        {
            this.klonokHaborujadbcontext = klonokHaborujadbcontext;
            WrongInput = wrongInput;
        }

        public void Data()
        {
            var squads = klonokHaborujadbcontext.Squads.ToList();
            Console.WriteLine("Names".PadLeft(30) + "Commanders".PadLeft(70));
            Console.WriteLine();
            foreach (var item in squads)
            {
                Console.WriteLine($"{item.Name.PadLeft(30)}{item.Commander.PadLeft(70)}");
            }
            Console.WriteLine();
        }


        public void Add()
        {
            Console.WriteLine("Name your squad:");
            string name = WrongInput.STR();
            Console.WriteLine("Give a commander to your squad:");
            string commander = WrongInput.STR();

            Squads squads = new Squads(name, commander);

            klonokHaborujadbcontext.Squads.Add(squads);
            klonokHaborujadbcontext.SaveChanges();

            Console.WriteLine("New Squad inserted");
            Console.WriteLine();
        }

        public void Remove()
        {
            Console.WriteLine("Choose wich Squad do you want to delete:");

            foreach (var item in klonokHaborujadbcontext.Squads)
            {

                Console.Write($"{item.Name} [{item.Id}], ");
            }
            Console.WriteLine();
            int index;
            bool isparsed;
            while (true)
            {
                string str = Console.ReadLine();
                isparsed = int.TryParse(str, out index);

                if (!isparsed)
                {
                    Console.WriteLine("Wrong data try again");
                }
                else
                {

                    var delete = klonokHaborujadbcontext.Squads.FirstOrDefault(s => s.Id == index);

                    if (delete == null)
                    {
                        Console.WriteLine("Wrong Id try again");
                        
                    }
                    else
                    {
                        klonokHaborujadbcontext.Squads.Remove(delete);
                        klonokHaborujadbcontext.SaveChanges();
                        break;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Squad deteled");
            
        }

        public void Update()
        {
            Console.WriteLine("Choose a Squad you want to update");
            Console.WriteLine();
            int options = 0;
            bool isparsed;
            foreach (var item in klonokHaborujadbcontext.Squads)
            {
                options++;
                Console.Write($"{item.Name} [{item.Id}], ");
            }
            Console.WriteLine();
            int index;
            while (true)
            {

                string str = Console.ReadLine();
                isparsed = int.TryParse(str, out index);

                if (!isparsed)
                {
                    Console.WriteLine("Wrong data try again");
                }
                else
                {

                    if (index <= options)
                        break;
                    else
                    {
                        Console.WriteLine("There are no squad with this number try again");
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Which item do you want to change?");
            var squad = klonokHaborujadbcontext.Squads.FirstOrDefault(s => s.Id == index);
            Console.WriteLine($"{squad.Name}[1]");
            Console.WriteLine($"{squad.Commander}[2]");
            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    Console.WriteLine("Changin name...");
                    string name = WrongInput.STR();
                    squad.Name = name;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
                else if (key == ConsoleKey.D2)
                {
                    Console.WriteLine("Changin commander...");
                    string commander = WrongInput.STR();
                    squad.Commander = commander;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
            }
        }
    }
}
