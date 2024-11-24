using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public interface IInputReader
    {
         
        ConsoleKey ReadKey(bool intercept);
    }
    public class InputReader : IInputReader
    {
        public ConsoleKey ReadKey(bool intercept)
        {
            var key = Console.ReadKey(intercept).Key;

            return key;
        }

        
    }
}
