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


namespace HXD4UK_HSZF_2024251
{
    public class Menu
    {

        public AllDataQuerie AllDataQuerie;
        public SquadMethods SquadMethods;
        public CloneMethods CloneMethods;
        public BattleMethods BattleMethods;
        public Biggest Biggest;
        public _501st_Legion _501St_Legion;
        

        public Menu(AllDataQuerie allDataQuerie, SquadMethods squadMethods, CloneMethods cloneMethods, BattleMethods battleMethods, Biggest biggest, _501st_Legion _501St_Legion)
        {
            AllDataQuerie = allDataQuerie;
            SquadMethods = squadMethods;
            CloneMethods = cloneMethods;
            BattleMethods = battleMethods;
            Biggest = biggest;
            this._501St_Legion = _501St_Legion;
            
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


       
        public void SquadAdd(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            SquadMethods.Add();
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

        //int hosszusag
        public void CloneAdd(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            CloneMethods.Add();
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

        //  tobbszor meg lehet adni ugyanazt a klon nemtudom baj e!!!
        public void BattleAdd(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            BattleMethods.Add();
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
        
        public void SquadDel(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            SquadMethods.Remove();
            
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
        
        public void CloneDel(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            CloneMethods.Remove();
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
        
        public void BattleDel(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            BattleMethods.Remove();
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

        
        public void SquadUpdate(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            SquadMethods.Update();
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
            CloneMethods.Update();
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
            BattleMethods.Update();
            Console.WriteLine("Do you want to change something else[1] or go back[2]?");
            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    BattleUpdate(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.D2)
                {
                    UpdateMenu(klonokHaborujadbcontext);
                }
            }
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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Back[Backspace]");
            Console.WriteLine("Main Menu[Esc]");


            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Backspace)
                {
                    QueriesMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Escape)
                {
                    MainMenu(klonokHaborujadbcontext);
                }
            }
        }

        //Biggest battle
        public void BiggestBattle(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            Console.WriteLine("The biggest battle was:");
            Biggest.Big();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Back[Backspace]");
            Console.WriteLine("Main Menu[Esc]");


            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Backspace)
                {
                    QueriesMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Escape)
                {
                    MainMenu(klonokHaborujadbcontext);
                }
            }
        }

        //501st Legion
        public void Legion(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            Console.WriteLine("'501 Legion' clones:");
            _501St_Legion._501_Legion();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Back[Backspace]");
            Console.WriteLine("Main Menu[Esc]");


            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Backspace)
                {
                    QueriesMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Escape)
                {
                    MainMenu(klonokHaborujadbcontext);
                }
            }
        }

        //501st min 3 Battle
        public void Min3(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {
            Console.Clear();
            Console.WriteLine("Battle(s) where at least 3 clones participated form '501st Legion':");

            _501St_Legion._3_Atleast();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Back[Backspace]");
            Console.WriteLine("Main Menu[Esc]");


            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Backspace)
                {
                    QueriesMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Escape)
                {
                    MainMenu(klonokHaborujadbcontext);
                }
            }
        }

        //Kaminoi
        public void Kaminoi(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Back[Backspace]");
            Console.WriteLine("Main Menu[Esc]");


            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Backspace)
                {
                    QueriesMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Escape)
                {
                    MainMenu(klonokHaborujadbcontext);
                }
            }
        }

        //Battle of Geonosis
        public void Geonosis(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Back[Backspace]");
            Console.WriteLine("Main Menu[Esc]");


            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Backspace)
                {
                    QueriesMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Escape)
                {
                    MainMenu(klonokHaborujadbcontext);
                }
            }
        }

        //clonesparty

        public void ClonesParty(KlonokHaborujadbcontext klonokHaborujadbcontext)
        {

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Back[Backspace]");
            Console.WriteLine("Main Menu[Esc]");


            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Backspace)
                {
                    QueriesMenu(klonokHaborujadbcontext);
                }
                else if (key == ConsoleKey.Escape)
                {
                    MainMenu(klonokHaborujadbcontext);
                }
            }
        }

    }
}
