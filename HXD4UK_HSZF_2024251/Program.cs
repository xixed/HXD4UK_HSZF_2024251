
using HXD4UK_HSZF_20242501.Application;
using HXD4UK_HSZF_20242501.Model;
using HXD4UK_HSZF_20242501.Persistence.MsSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;

namespace HXD4UK_HSZF_2024251
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=KlonokHaborujadbcontext;Integrated Security=True;MultipleActiveResultSets=true";

            var serviceCollection = new ServiceCollection();

            IServiceProvider serviceProvider = ConfigContainer(serviceCollection,connectionString);

            KlonokHaborujadbcontext klonokHaborujadbcontext = serviceProvider.GetService<KlonokHaborujadbcontext>();

            Seed(klonokHaborujadbcontext);

            var menu = serviceProvider.GetService<Menu>();

            menu.Run(klonokHaborujadbcontext);
        }

        private static void Seed(KlonokHaborujadbcontext cxt)
        {
            KlonokHaborujadbcontext klonokHaborujadbcontext = cxt;
            var clones = JsonConvert.DeserializeObject<List<Clones>>(File.ReadAllText("clonesjson.json"));
            var battles = JsonConvert.DeserializeObject<List<Battles>>(File.ReadAllText("battlesjson.json"));
            var squads = JsonConvert.DeserializeObject<List<Squads>>(File.ReadAllText("squadsjson.json"));

            klonokHaborujadbcontext.Clones.AddRange(clones);
            klonokHaborujadbcontext.Battles.AddRange(battles);
            klonokHaborujadbcontext.Squads.AddRange(squads);

            klonokHaborujadbcontext.SaveChanges();

            foreach (var battle in battles)
            {
                foreach (var cloneId in battle.Clones)
                {
                    var relationship = new Battlestoclones
                    {
                        BattleId = battle.Id,
                        CloneId = cloneId
                    };

                    klonokHaborujadbcontext.Battlestoclones.Add(relationship);
                }
            }


            
            klonokHaborujadbcontext.SaveChanges();

            
            
            

        }


        private static IServiceProvider ConfigContainer(ServiceCollection services, string connection)
        {
            return
                services
                .AddDbContext<IKlonokHaborujadbcontext,KlonokHaborujadbcontext>(options => options.UseSqlServer(connection))
                .AddSingleton<ICloneEventHandler,CloneEventHandler>()
                .AddSingleton<IBattleMethods,BattleMethods>()
                .AddSingleton<ICloneMethods,CloneMethods>()
                .AddSingleton<IInputReader,InputReader>()
                .AddSingleton<ISquadMethods,SquadMethods>()
                .AddSingleton<IBiggest,Biggest>()
                .AddSingleton<IAllDataQuerie,AllDataQuerie>()
                .AddSingleton<I_501st_Legion,_501st_Legion>()
                .AddSingleton<IKamino,Kamino>()
                .AddSingleton<IGeonosis,Geonosis>()
                .AddSingleton<ICloneParty,CloneParty>()
                .AddSingleton<Menu>()
                .AddSingleton<IWrongInput,WrongInput>()
                .BuildServiceProvider();


        }
    }
}
