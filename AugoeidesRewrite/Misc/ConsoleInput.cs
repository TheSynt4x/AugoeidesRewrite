using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugoeidesRewrite.Misc
{
    class ConsoleInput
    {
        public static T Get<T>(string prompt)
        {
            Console.WriteLine(prompt);

            string input = Console.ReadLine();
            return (T)Convert.ChangeType(input, typeof(T));
        }
    }
}
