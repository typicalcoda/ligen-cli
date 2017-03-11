using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ligen.Modules
{
    public static class Core
    {
        
        public static void Printc(string text, ConsoleColor c, bool writeLine)
        {
            Console.ForegroundColor = c;

            if (writeLine) Console.WriteLine(text); else Console.Write(text);

            Console.ForegroundColor = ConsoleColor.Gray;

        }


        public static void cls()
        {
            Console.Clear();
        }

        public static void pwd()
        {
            Printc(Environment.CurrentDirectory, ConsoleColor.White, true);
        }

        public static void cd(string dir)
        {
            if (System.IO.Directory.Exists(dir))
                Environment.CurrentDirectory = dir;
            else
                Console.WriteLine("Directory doesn't exist mate.");


        }

        public static void ls()
        {
            try
            {
                System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(Environment.CurrentDirectory);

                foreach (System.IO.DirectoryInfo dI in directoryInfo.GetDirectories()) Printc(dI.Name + "/(" + dI.GetDirectories().Count() + " dirs, " + dI.GetFiles().Count() + " file(s))", ConsoleColor.DarkYellow, true);
                foreach (System.IO.FileInfo fI in directoryInfo.GetFiles()) Printc(fI.Name, ConsoleColor.White, true);

            }
            catch (Exception)
            {

            }
        }
    }
}
