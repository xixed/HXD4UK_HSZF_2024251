using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Application
{
    public class WrongInput
    {
        public string STR()
        {
            string str;
            while (true)
            {
                str = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(str))
                {
                    Console.WriteLine("You did not wrote anything");
                }
                else { break; }
            }
            return str;
        }
    }
}
