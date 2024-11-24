using HXD4UK_HSZF_20242501.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Test
{
    internal class Fake_WrongInput : IWrongInput
    {
        
        public Queue<string> NextInputs { get; set; } = new Queue<string>();

        public string STR()
        {
            var input =NextInputs.Dequeue();
            
            return input;
        }
    }
}
