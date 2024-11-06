using HXD4UK_HSZF_20242501.Model;
using HXD4UK_HSZF_20242501.Persistence.MsSql;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_2024251
{
    public class Menu
    {
        public void Run(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            MainMenu(klonokHaborujadbcontext);
        }
        public static void MainMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();

            Console.WriteLine("Choose a menu");

            Console.WriteLine("Database[1]");
            Console.WriteLine("Modify[2]");
            Console.WriteLine("Queries[3]");
            
            while (true) 
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    DatabaseMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D2)
                {
                    ModifyMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D3)
                {
                    QueriesMenu(klonokHaborujadbcontext);
                }

            }

            

        }


        //Database
        public static void DatabaseMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            Console.WriteLine("Choose which one do you want to see");
            Console.WriteLine("Squads[1]");
            Console.WriteLine("Clones[2]");
            Console.WriteLine("Battles[3]");
            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    SquadsMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D2)
                {
                    CLonesMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D3)
                {
                    BattlesMenu(klonokHaborujadbcontext);
                }

            }


        }

        //Squads

        public static void SquadsMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            var squads = klonokHaborujadbcontext.Squads.ToList();
            Console.WriteLine("Names".PadLeft(30)+"Commanders".PadLeft(70));
            Console.WriteLine();
            foreach (var item in squads)
            {
                Console.WriteLine($"{item.Name.PadLeft(30)}{item.Commander.PadLeft(70)}");
            }
            Console.WriteLine();
            Console.WriteLine("Back[Backspace]");
            Console.WriteLine("Main Menu[Esc]");

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Backspace)
                {
                    DatabaseMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Escape)
                {
                    MainMenu(klonokHaborujadbcontext);
                }
            }


        }

        //Clones
        public static void CLonesMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            var clones = klonokHaborujadbcontext.Clones.ToList();
            Console.WriteLine("Names".PadLeft(20) + "Designation".PadLeft(30)+"Rank".PadLeft(30)+"Squad_Id".PadLeft(20));
            Console.WriteLine();
            foreach (var item in clones)
            {
                Console.WriteLine($"{item.Name.PadLeft(20)}{item.Designation.PadLeft(30)}{item.Rank.PadLeft(30)}{item.Squad_id.ToString().PadLeft(20)}");
            }

            Console.WriteLine();
            Console.WriteLine("Back[Backspace]");
            Console.WriteLine("Main Menu[Esc]");

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Backspace)
                {
                    DatabaseMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Escape)
                {
                    MainMenu(klonokHaborujadbcontext);
                }
            }
        }
        

        //Battles
        public static void BattlesMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            var battles = klonokHaborujadbcontext.Battles.ToList();
            Console.WriteLine("Names".PadLeft(20) + "Location".PadLeft(30) + "Date".PadLeft(30) + "Clones".PadLeft(30));
            Console.WriteLine();

            foreach (var item in battles)
            {
                
                Console.WriteLine($"{item.Name.PadLeft(20)}{item.Location.PadLeft(30)}{item.Date.PadLeft(30)}{string.Join(",",item.Clones).PadLeft(30)}");
                
                
                
            }
            Console.WriteLine();
            Console.WriteLine("Back[Backspace]");
            Console.WriteLine("Main Menu[Esc]");

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Backspace)
                {
                    DatabaseMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Escape)
                {
                    MainMenu(klonokHaborujadbcontext);
                }
            }
            
            
        }
        

        

        //Modify
        public static void ModifyMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            Console.WriteLine("Add[1]");
            Console.WriteLine("Delete[2]");
            Console.WriteLine("Update[3]");
            Console.WriteLine();
            Console.WriteLine("Back[Backspace]");
            

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    AddMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D2)
                {
                    DelMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D3)
                {
                    UpdateMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Backspace)
                {
                    MainMenu(klonokHaborujadbcontext);
                }
                

            }
        }

        //Add

        public static void AddMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            Console.WriteLine("Squad[1]");
            Console.WriteLine("Clone[2]");
            Console.WriteLine("Battle[3]");
            Console.WriteLine();
            Console.WriteLine("Back[Backspace]");
            Console.WriteLine("Main Menu[Esc]");
            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    SquadAdd(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D2)
                {
                    CloneAdd(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D3)
                {
                    BattleAdd(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Backspace)
                {
                    ModifyMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Escape)
                {
                    MainMenu(klonokHaborujadbcontext);
                }

            }
            

        }

        //Squad_Add


        //Nem jo meg a id!!!!!!!!!!
        public static void SquadAdd(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            Console.WriteLine("Name your squad:");
            string name=Console.ReadLine();
            Console.WriteLine("Give a commander to your squad:");
            string commander = Console.ReadLine();

            Squads squads = new Squads(name,commander);

            klonokHaborujadbcontext.Squads.Add(squads);
            klonokHaborujadbcontext.SaveChanges();

            Console.WriteLine("New Squad inserted");
            Console.WriteLine();
            Console.WriteLine("Do you want to add another[1] or go back[2]?");

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    SquadAdd(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D2)
                {
                    AddMenu(klonokHaborujadbcontext);
                }
                

            }

        }

        //Clone_Add

        //Nem jo meg a id!!!!!!!!!!
        public static void CloneAdd(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
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
            while(true)
            {
                
                squad_id = int.Parse(Console.ReadLine());

                if (squad_id<=options)
                    break;
                else
                    Console.WriteLine("There are no squad with this number try again");
            }
            Clones clones = new Clones(name,desigantion,rank,squad_id);

            klonokHaborujadbcontext.Clones.Add(clones);

            klonokHaborujadbcontext.SaveChanges();

            Console.WriteLine("New Clone inserted");
            Console.WriteLine();
            Console.WriteLine("Do you want to add another[1] or go back[2]?");

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    CloneAdd(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D2)
                {
                    AddMenu(klonokHaborujadbcontext);
                }


            }



        }

        //Battle_Add

        //Nem jo meg a id!!!!!!!!!!   tobbszor meg lehet adni ugyanazt a klon nemtudom baj e!!!
        public static void BattleAdd(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            Console.WriteLine("Name your battle:");
            string name = Console.ReadLine();
            Console.WriteLine("Name the location where it was:");
            string location = Console.ReadLine();
            Console.WriteLine("Name the time when it was:");
            string date = Console.ReadLine();
            Console.WriteLine($"How many different clones fought in this battle(max:{klonokHaborujadbcontext.Clones.Count()}):");
            int size;
            while (true)
            {
                Console.WriteLine();
                size = int.Parse(Console.ReadLine());

                if (0<size && size <= klonokHaborujadbcontext.Clones.Count())
                    break;
                else
                    Console.WriteLine("Wrong data try again");

            }

            Console.WriteLine($"Choose that much({size})");

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
                        clones[j-1] = int.Parse(Console.ReadLine());

                        if (clones[j-1]<=options)
                            break;
                        else
                            Console.WriteLine("There are no clone with this number try again");
                    
                }

            }


            Console.WriteLine();
            

            Battles battle = new Battles(name, location, date, clones);

            klonokHaborujadbcontext.Battles.Add(battle);

            klonokHaborujadbcontext.SaveChanges();

            Console.WriteLine("New Battle inserted");
            Console.WriteLine();
            Console.WriteLine("Do you want to add another[1] or go back[2]?");

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    BattleAdd(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D2)
                {
                    AddMenu(klonokHaborujadbcontext);
                }


            }
        }

        //Delete
        public static void DelMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            Console.WriteLine("Squad[1]");
            Console.WriteLine("Clone[2]");
            Console.WriteLine("Battle[3]");
            Console.WriteLine();
            Console.WriteLine("Back[Backspace]");
            Console.WriteLine("Main Menu[Esc]");
            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    SquadDel(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D2)
                {
                    CloneDel(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D3)
                {
                    BattleDel(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Backspace)
                {
                    ModifyMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Escape)
                {
                    MainMenu(klonokHaborujadbcontext);
                }

            }
        }



        //Squad Delete
        //wrong input nincs kezelve
        public static void SquadDel(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            Console.WriteLine("Choose wich Squad do you want to delete:");
            
            foreach (var item in klonokHaborujadbcontext.Squads)
            {
                
                Console.Write($"{item.Name} [{item.Id}], ");
            }
            Console.WriteLine();
            int index=int.Parse(Console.ReadLine());

            var delete = klonokHaborujadbcontext.Squads.FirstOrDefault(s=>s.Id == index);

             klonokHaborujadbcontext.Squads.Remove(delete);
            klonokHaborujadbcontext.SaveChanges();
            Console.WriteLine();
            Console.WriteLine("Squad deteled");
            Console.WriteLine("Do you want to delete another[1] or go back[2]");
            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    SquadDel(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D2)
                {
                    DelMenu(klonokHaborujadbcontext);
                }
            }

        }

        //Clone Delete
        //wrong input nincs kezelve
        public static void CloneDel(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            Console.WriteLine("Choose wich Clone do you want to delete:");
            
            foreach (var item in klonokHaborujadbcontext.Clones)
            {
                
                Console.Write($"{item.Name} [{item.Id}], ");
            }
            Console.WriteLine();
            int index = int.Parse(Console.ReadLine());

            var delete = klonokHaborujadbcontext.Clones.FirstOrDefault(s => s.Id == index);

            klonokHaborujadbcontext.Clones.Remove(delete);
            klonokHaborujadbcontext.SaveChanges();
            Console.WriteLine();
            Console.WriteLine("Clone deteled");
            Console.WriteLine("Do you want to delete another[1] or go back[2]");
            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    CloneDel(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D2)
                {
                    DelMenu(klonokHaborujadbcontext);
                }
            }
        }

        //Battle Delete
        //wrong input nincs kezelve
        public static void BattleDel(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            Console.WriteLine("Choose wich Battle do you want to delete:");
            
            foreach (var item in klonokHaborujadbcontext.Battles)
            {
                
                Console.Write($"{item.Name} [{item.Id}], ");
            }
            Console.WriteLine();
            int index = int.Parse(Console.ReadLine());

            var delete = klonokHaborujadbcontext.Battles.FirstOrDefault(s => s.Id == index);

            klonokHaborujadbcontext.Battles.Remove(delete);
            klonokHaborujadbcontext.SaveChanges();
            Console.WriteLine();
            Console.WriteLine("Battle deteled");
            Console.WriteLine("Do you want to delete another[1] or go back[2]");
            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    BattleDel(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D2)
                {
                    DelMenu(klonokHaborujadbcontext);
                }
            }
        }


        //Update

        public static void UpdateMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            Console.WriteLine("Squad[1]");
            Console.WriteLine("Clone[2]");
            Console.WriteLine("Battle[3]");
            Console.WriteLine();
            Console.WriteLine("Back[Backspace]");
            Console.WriteLine("Main Menu[Esc]");
            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    SquadUpdate(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D2)
                {
                    CloneUpdate(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D3)
                {
                    BattleUpdate(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Backspace)
                {
                    ModifyMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Escape)
                {
                    MainMenu(klonokHaborujadbcontext);
                }

            }
        }

        //Squad Update

        //wrong input kezeles
        public static void SquadUpdate(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            Console.WriteLine("Choose a Squad you want to update");
            Console.WriteLine();
            int options = 0;
            foreach (var item in klonokHaborujadbcontext.Squads)
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
                    Console.WriteLine("There are no squad with this number try again");
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
                    string name = Console.ReadLine();
                    squad.Name = name;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
                else if (key == ConsoleKey.D2)
                {
                    Console.WriteLine("Changin commander...");
                    string commander = Console.ReadLine();
                    squad.Commander = commander;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
            }
            Console.WriteLine("Do you want to change something else[1] or go back[2]?");
            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    SquadUpdate(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D2)
                {
                    UpdateMenu(klonokHaborujadbcontext);
                }
            }


        }

        //Clone Update
        public static void CloneUpdate(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
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
                    Console.WriteLine("Changin name...");
                    string name = Console.ReadLine();
                    clone.Name = name;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
                else if (key == ConsoleKey.D2)
                {
                    Console.WriteLine("Changin designation...");
                    string desigantion = Console.ReadLine();
                    clone.Designation = desigantion;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
                else if (key == ConsoleKey.D3)
                {
                    Console.WriteLine("Changin rank...");
                    string rank = Console.ReadLine();
                    clone.Rank = rank;
                    klonokHaborujadbcontext.SaveChanges();
                    Console.WriteLine("Changes saved");
                    break;
                }
                else if (key == ConsoleKey.D4)
                {
                    Console.WriteLine("Changin squad...");
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
            Console.WriteLine("Do you want to change something else[1] or go back[2]?");
            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    CloneUpdate(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D2)
                {
                    UpdateMenu(klonokHaborujadbcontext);
                }
            }

        }

        //Battle Update
        public static void BattleUpdate(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
        }

        public static void QueriesMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            
        }

    }
}
