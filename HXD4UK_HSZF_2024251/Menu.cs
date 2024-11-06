using HXD4UK_HSZF_20242501.Application;
using HXD4UK_HSZF_20242501.Model;
using HXD4UK_HSZF_20242501.Persistence.MsSql;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace HXD4UK_HSZF_2024251
{
    public class Menu
    {

        public AllDataQuerie AllDataQuerie;
        public SquadMethods SquadMethods;
        public CloneMethods CloneMethods;
        public BattleMethods BattleMethods;

        public Menu(AllDataQuerie allDataQuerie, SquadMethods squadMethods, CloneMethods cloneMethods, BattleMethods battleMethods)
        {
            this.AllDataQuerie = allDataQuerie;
            SquadMethods = squadMethods;
            CloneMethods = cloneMethods;
            BattleMethods = battleMethods;
        }


        public void Run(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {

            MainMenu(klonokHaborujadbcontext);
        }
        public void MainMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
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
        public void DatabaseMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            Console.WriteLine("Choose which one do you want to see");
            Console.WriteLine("Squads[1]");
            Console.WriteLine("Clones[2]");
            Console.WriteLine("Battles[3]");

            Console.WriteLine();
            Console.WriteLine("Back[Backspace]");
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
                else if (key == ConsoleKey.Backspace)
                {
                    MainMenu(klonokHaborujadbcontext);
                }

            }
            


        }

        //Squads

        public void SquadsMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            SquadMethods.Data();
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
        public void CLonesMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            CloneMethods.Data();
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
        public void BattlesMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            BattleMethods.Data();
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
        public void ModifyMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
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

        public void AddMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
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
        public void SquadAdd(KlonokHaborujadbcontext klonokHaborujadbcontext)
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

        //Nem jo meg a id!!!!!!!!!! int hosszusag
        public void CloneAdd(KlonokHaborujadbcontext klonokHaborujadbcontext)
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
        public void BattleAdd(KlonokHaborujadbcontext klonokHaborujadbcontext)
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
        public void DelMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
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
        public void SquadDel(KlonokHaborujadbcontext klonokHaborujadbcontext)
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
        public void CloneDel(KlonokHaborujadbcontext klonokHaborujadbcontext)
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
        public void BattleDel(KlonokHaborujadbcontext klonokHaborujadbcontext)
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

        public void UpdateMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
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
        public void SquadUpdate(KlonokHaborujadbcontext klonokHaborujadbcontext)
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
        public void CloneUpdate(KlonokHaborujadbcontext klonokHaborujadbcontext)
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
        public void BattleUpdate(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
        }

        //Queries
        
        public void QueriesMenu(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            Console.WriteLine("Choose which querie do you wanna check:");
            Console.WriteLine();
            Console.WriteLine("List all clones, squads, and battles.[1]");
            Console.WriteLine("Which battle involved the highest number of clones?[2]");
            Console.WriteLine("List the clones in the '501st Legion' squad.[3]");
            Console.WriteLine("In which battle(s) did at least 3 clones from the '501st Legion' squad participate?[4]");
            Console.WriteLine("List all clones and their ranks who participated in the Battle of Kamino.[5]");
            Console.WriteLine("List the names of all clones who are members of the '212th Attack Battalion' squad and participated in the 'Battle of Geonosis.'[6]");
            Console.WriteLine("Which clones have fought together in the most battles?[7]");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Back[Backspace]");
            

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    All(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D2)
                {
                    BiggestBattle(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D3)
                {
                    Legion(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D4)
                {
                    Min3(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D5)
                {
                    Kaminoi(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D6)
                {
                    Geonosis(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D7)
                {
                    ClonesParty(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Backspace)
                {
                    MainMenu(klonokHaborujadbcontext);
                }
                

            }

        }

        //AllData
        public void All(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            AllDataQuerie.AllData();
        }

        //Biggest battle
        public void BiggestBattle(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            
        }

        //501st Legion
        public void Legion(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            
        }

        //501st min 3 Battle
        public void Min3(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            
        }

        //Kaminoi
        public void Kaminoi(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            
        }

        //Battle of Geonosis
        public void Geonosis(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            
        }

        //clonesparty

        public void ClonesParty(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {

        }

    }
}
