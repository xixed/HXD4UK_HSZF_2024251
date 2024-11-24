using HXD4UK_HSZF_20242501.Model;
using HXD4UK_HSZF_20242501.Persistence.MsSql;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public interface ICloneMethods
    {
        List<Clones> Data();
        void Add();
        void Remove();
        void Update();

    }
    public class CloneMethods : ICloneMethods
    {
        IKlonokHaborujadbcontext klonokHaborujadbcontext;
        ICloneEventHandler cloneEventHandler;
        IWrongInput WrongInput;
        IInputReader InputReader;

        public CloneMethods(IKlonokHaborujadbcontext klonokHaborujadbcontext, ICloneEventHandler cloneEventHandler, IWrongInput wrongInput, IInputReader inputReader)
        {
            this.klonokHaborujadbcontext = klonokHaborujadbcontext;
            this.cloneEventHandler = cloneEventHandler;
            klonokHaborujadbcontext.cloneAdded += cloneEventHandler.CreateFile;
            WrongInput = wrongInput;
            InputReader = inputReader;
        }

        public List<Clones> Data()
        {
            var clones = klonokHaborujadbcontext.Clones.ToList();
            return clones;
        }


        public void Add()
        {
            Console.WriteLine("Name your clone:");
            string name = WrongInput.STR();
            Console.WriteLine("Give a designation to your clone:");
            string desigantion = WrongInput.STR();
            Console.WriteLine("Give a rank to your clone:");
            string rank = WrongInput.STR();
            Console.WriteLine("Choose a Squad to be your clone in:");
            int options = 0;
            foreach (var item in klonokHaborujadbcontext.Squads)
            {
                options++;
                Console.Write($"{item.Name} [{item.Id}], ");
            }
            Console.WriteLine();
            int squad_id;
            bool isparsed;
            while (true)
            {

                string str = WrongInput.STR();
                isparsed = int.TryParse(str, out squad_id);
                if (!isparsed)
                {
                    Console.WriteLine("Wrong data try again");
                }
                else
                {
                    if (squad_id <= options)
                        break;
                    else
                    {
                        Console.WriteLine("There are no squad with this number try again");
                    }
                }
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
            int index;
            bool isparsed;
            while (true)
            {
                string str = WrongInput.STR();
                isparsed = int.TryParse(str, out index);
                if (!isparsed)
                {
                    Console.WriteLine("Wrong data try again");
                }
                else
                {
                }

                var delete = klonokHaborujadbcontext.Clones.FirstOrDefault(s => s.Id == index);
                if (delete == null)
                {
                    Console.WriteLine("Wrong Id try again");
                    
                }
                else
                {
                    klonokHaborujadbcontext.Clones.Remove(delete);
                    klonokHaborujadbcontext.SaveChanges();
                    break;
                }
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
            bool isparsed;
            while (true)
            {

                string str = WrongInput.STR();
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
                        Console.WriteLine("There are no clone with this number try again");
                    }
                }
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
                var key = InputReader.ReadKey(true);

                if (key == ConsoleKey.D1)
                {
                    Console.WriteLine("Changing name...");
                    string name = WrongInput.STR();
                    clone.Name = name;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
                else if (key == ConsoleKey.D2)
                {
                    Console.WriteLine("Changing designation...");
                    string desigantion = WrongInput.STR();
                    clone.Designation = desigantion;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
                else if (key == ConsoleKey.D3)
                {
                    Console.WriteLine("Changing rank...");
                    string rank = WrongInput.STR();
                    clone.Rank = rank;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
                else if (key == ConsoleKey.D4)
                {
                    Console.WriteLine("Changing squad...");
                    Console.WriteLine("Choose another squad:");
                    int option = 0;
                    foreach (var item in klonokHaborujadbcontext.Squads)
                    {
                        option++;
                        Console.Write($"{item.Name}, [{item.Id}] ");
                    }
                    int squad;
                    while (true)
                    {
                        string str=Console.ReadLine();
                        isparsed=int.TryParse(str, out squad);
                        if (!isparsed)
                        {
                            Console.WriteLine("Wrong data try again");
                        }
                        else 
                        {
                            if (squad <= option)
                                break;
                            else
                            {
                                Console.WriteLine("There are no clone with this number try again");
                            }
                        }
                    }
                    clone.Squad_id = squad;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
            }
        }
    }
}
