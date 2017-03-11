using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligen.Modules
{
    public static class Say
    {

        public static void hi()
        {
            Console.WriteLine("Hello, World!");
        }

        public static void age(string year)
        {
            Console.WriteLine(DateTime.Now.Year - Convert.ToInt16(year) + " years old.");
        }

        public static void introduce(string name, string age, string gender)
        {
            Console.WriteLine(String.Format("Hey! I'm {0}, I'm currently {1} years old, and I'm {2}.", name, age, gender));
        }
    }
}
