using Azure.Messaging;
using HXD4UK_HSZF_20242501.Model;
using HXD4UK_HSZF_20242501.Persistence.MsSql;
using Microsoft.IdentityModel.Tokens;
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
        WrongInput WrongInput;
        

        public BattleMethods(KlonokHaborujadbcontext klonokHaborujadbcontext,WrongInput wrongInput)
        {
            this.klonokHaborujadbcontext=klonokHaborujadbcontext;
            this.WrongInput = wrongInput;
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
            bool isparsed;
            Console.WriteLine("Name your battle:");
            string? name = WrongInput.STR();


            Console.WriteLine("Name the location where it was:");
            string? location = WrongInput.STR();


            Console.WriteLine("Name the time when it was:");
            string? date = WrongInput.STR();


            Console.WriteLine($"How many different clones fought in this battle(max:{klonokHaborujadbcontext.Clones.Count()}):");
            int size;
            
            while (true)
            {
                Console.WriteLine();
                string size1= Console.ReadLine();
                isparsed = int.TryParse(size1, out size);
                if (!isparsed)
                {
                    Console.WriteLine("Wrong data try again");
                }
                else
                {
                    if (0 < size && size <= klonokHaborujadbcontext.Clones.Count())
                        break;
                    else
                        Console.WriteLine("Wrong data try again");
                }
            }

            Console.WriteLine($"Choose that much ({size})");

            int options = 0;
            foreach (var item in klonokHaborujadbcontext.Clones)
            {
                options++;
                Console.Write($"{item.Name} [{item.Id}], ");
            }
            int[] clones = new int[size];
            Console.WriteLine();
            for (int j = 1; j <= size; j++)
            {
                while (true)
                {
                    Console.WriteLine($"{j}. clone");
                    string clone = Console.ReadLine();
                    isparsed = int.TryParse(clone, out clones[j - 1]);
                    
                    if (!isparsed)
                    {
                        Console.WriteLine("Wrong data try again");
                    }
                    else
                    {
                        if (clones[j - 1] <= options)
                            break;
                        else
                            Console.WriteLine("There are no clone with this number try again");
                    }
                }

            }


            Console.WriteLine();


            Battles battle = new Battles(name, location, date, clones);
            
            klonokHaborujadbcontext.Battles.Add(battle);

            klonokHaborujadbcontext.SaveChanges();

            Console.WriteLine("New Battle inserted");
            Console.WriteLine();
        }

        public void Remove()
        {
            Console.WriteLine("Choose wich Battle do you want to delete:");

            foreach (var item in klonokHaborujadbcontext.Battles)
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
                    var delete = klonokHaborujadbcontext.Battles.FirstOrDefault(s => s.Id == index);
                    if (delete == null)
                    {
                        Console.WriteLine("Wrong Id try again");
                    }
                    else
                    {
                        klonokHaborujadbcontext.Battles.Remove(delete);
                        klonokHaborujadbcontext.SaveChanges();
                        break;
                    }
                    
                    
                }
            }
            Console.WriteLine();
            Console.WriteLine("Battle deteled");



        }

        public void Update()
        {
            Console.WriteLine("Choose a Battle you want to update");
            Console.WriteLine();
            int options = 0;
            foreach (var item in klonokHaborujadbcontext.Battles)
            {
                options++;
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
                else { break; }
            }
            
            Console.WriteLine();
            Console.WriteLine("Which item do you want to change?");
            var squad = klonokHaborujadbcontext.Battles.FirstOrDefault(s => s.Id == index);
            Console.WriteLine($"{squad.Name}[1]");
            Console.WriteLine($"{squad.Location}[2]");
            Console.WriteLine($"{squad.Date}[3]");
            Console.Write("Clones[4]:") ;
            int options1 = 0;
            foreach (var item in squad.Clones)
            {
                options1++;
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
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
                    Console.WriteLine("Changin location...");
                    string location = WrongInput.STR();
                    squad.Location = location;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
                else if (key == ConsoleKey.D3)
                {
                    Console.WriteLine("Changin date...");
                    string date = WrongInput.STR();
                    squad.Date = date;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
                else if (key == ConsoleKey.D4)
                {
                    Console.WriteLine("Changin clones...");
                    Console.WriteLine($"How many different clones fought in this battle(max:{klonokHaborujadbcontext.Clones.Count()}):");
                    int size;
                    while (true)
                    {
                        string str = Console.ReadLine();
                        isparsed = int.TryParse(str, out size);
                        if (!isparsed)
                        {
                            Console.WriteLine("Wrong data try again");
                        }
                        else
                        {
                            if (0 < size && size <= klonokHaborujadbcontext.Clones.Count())
                                break;
                            else
                                Console.WriteLine("Wrong data try again");
                        }

                    }

                    Console.WriteLine($"Choose that much({size})");

                    int options2 = 0;
                    foreach (var item in klonokHaborujadbcontext.Clones)
                    {
                        options2++;
                        Console.Write($"{item.Name} [{item.Id}], ");
                    }
                    int[] clones = new int[size];
                    Console.WriteLine();
                    for (int j = 1; j <= size; j++)
                    {
                        while (true)
                        {
                            Console.WriteLine($"{j}. clone");
                            string str = Console.ReadLine();
                            isparsed = int.TryParse(str, out clones[j-1]);
                            if (!isparsed)
                            {
                                Console.WriteLine("Wrong data try again");
                            }
                            else
                            {

                                if (clones[j - 1] <= options)
                                    break;
                                else
                                    Console.WriteLine("There are no clone with this number try again");
                            }
                        }
                    }

                    squad.Clones = clones;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
            }

        }
    }
}
