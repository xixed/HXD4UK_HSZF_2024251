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

            
            
            

        }


        private static IServiceProvider ConfigContainer(ServiceCollection services, string connection)
        {
            return
                services
                .AddDbContext<KlonokHaborujadbcontext>(options => options.UseSqlServer(connection))
                .AddSingleton<CloneEventHandler>()
                .AddSingleton<BattleMethods>()
                .AddSingleton<CloneMethods>()
                .AddSingleton<SquadMethods>()
                .AddSingleton<Biggest>()
                .AddSingleton<AllDataQuerie>()
                .AddSingleton<_501st_Legion>()
                .AddSingleton<Kamino>()
                .AddSingleton<Geonosis>()
                .AddSingleton<CloneParty>()
                .AddSingleton<Menu>()
                .AddSingleton<WrongInput>()
                .BuildServiceProvider();


        }
    }
}
