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
            KlonokHaborujadbcontext klonokHaborujadbcontext=new KlonokHaborujadbcontext();
            var clones = JsonConvert.DeserializeObject<List<clones>>(File.ReadAllText("clonesjson.json"));
            
            Console.WriteLine(clones.Count);

            klonokHaborujadbcontext.Clones.Add(clones[1]);
            klonokHaborujadbcontext.SaveChanges();

            ;
            
        }
    }
}
