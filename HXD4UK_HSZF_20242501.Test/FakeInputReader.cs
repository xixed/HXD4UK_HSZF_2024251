using HXD4UK_HSZF_20242501.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Test
{
    
    internal class FakeInputReader : IInputReader
    {
        private readonly Queue<ConsoleKey> _keyInputs;
        

        public FakeInputReader(Queue<ConsoleKey> consoleKeys)
        {
            _keyInputs = consoleKeys;
            
        }

        public ConsoleKey ReadKey(bool intercept)
        {
            
            return _keyInputs.Dequeue();
        }
        
    }
}
