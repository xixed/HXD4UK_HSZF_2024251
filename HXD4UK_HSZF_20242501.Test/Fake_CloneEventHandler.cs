using HXD4UK_HSZF_20242501.Application;
using HXD4UK_HSZF_20242501.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Test
{
    internal class Fake_CloneEventHandler : ICloneEventHandler
    {
        public void CreateFile(object sender, Clones clones)
        {
           Console.WriteLine($"{ clones.Name} event");
        }
    }
}
