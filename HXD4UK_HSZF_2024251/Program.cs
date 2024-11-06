using HXD4UK_HSZF_20242501.Application;
using HXD4UK_HSZF_20242501.Model;
using HXD4UK_HSZF_20242501.Persistence.MsSql;
using Newtonsoft.Json;
using System;

namespace HXD4UK_HSZF_2024251
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Seed();

            

        }

        private static void Seed()
        {
            KlonokHaborujadbcontext klonokHaborujadbcontext = new KlonokHaborujadbcontext(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=KlonokHaborujadbcontext;Integrated Security=True;MultipleActiveResultSets=true");
            var clones = JsonConvert.DeserializeObject<List<Clones>>(File.ReadAllText("clonesjson.json"));
            var battles = JsonConvert.DeserializeObject<List<Battles>>(File.ReadAllText("battlesjson.json"));
            var squads = JsonConvert.DeserializeObject<List<Squads>>(File.ReadAllText("squadsjson.json"));



            klonokHaborujadbcontext.Clones.AddRange(clones);
            klonokHaborujadbcontext.Battles.AddRange(battles);
            klonokHaborujadbcontext.Squads.AddRange(squads);

            



            klonokHaborujadbcontext.SaveChanges();

            BattleMethods battleMethods = new BattleMethods(klonokHaborujadbcontext);
            CloneMethods cloneMethods = new CloneMethods(klonokHaborujadbcontext);
            SquadMethods squadMethods = new SquadMethods(klonokHaborujadbcontext);

            AllDataQuerie allDataQuerie = new AllDataQuerie(klonokHaborujadbcontext,squadMethods,cloneMethods,battleMethods);
            Menu menu = new Menu(allDataQuerie, squadMethods, cloneMethods, battleMethods);

            menu.Run(klonokHaborujadbcontext);
            

        }
    }
}
