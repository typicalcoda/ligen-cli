using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ligen.Modules;
using System.Diagnostics;

namespace Ligen
{
    class Program
    {

        static void Main(string[] args)
        {



            while (true)
            {
                Console.Title = "Ligen " + Environment.CurrentDirectory;
                

                Core.Printc("Ligen $ ", ConsoleColor.Red, false);
                Debug.WriteLine("Header loaded");

                List<string> flags = Console.ReadLine().Split(' ').ToList();
                Debug.WriteLine("Command and flags separated");

                string cmd = flags[0];
                flags.Remove(cmd);
                Debug.WriteLine("Removed cmd from the last, so we have only flags");


                //check if a class has been specified, first!!
                Type t = Type.GetType("Ligen.Modules." + cmd);
                Debug.WriteLineIf(t != null, "Module found! - " + t);
                if (t != null)
                {
                    //next, find the method.
                    if (flags.Count > 0)
                    {
                        string method = flags[0];
                        flags.Remove(flags[0]); //again, trimming it to remove the function name, leaving the rest as 'pure params'
                        MethodInfo mi = t.GetMethod(method, BindingFlags.Public | BindingFlags.Static);

                        if (mi == null)
                        {
                            Core.Printc("`" + cmd + " " + method + "`", ConsoleColor.Cyan, false);
                            Console.Write(" - No such command.\r\n");
                        }
                        else
                        {

                            if (mi.GetParameters().Count() > flags.Count())
                            {
                                Core.Printc("`" + cmd + " " + mi.Name + "`", ConsoleColor.Cyan, false);
                                Console.Write(" expects " + mi.GetParameters().Count() + " arguments.\r\n");
                            }
                            else if (mi.GetParameters().Count() == flags.Count())
                            {

                                mi.Invoke(null, flags.ToArray());
                            }

                        }
                    }
                    else { Console.WriteLine("You need to execute a command."); }

                }
                else
                {
                    Debug.WriteLine("No '" + cmd + "' module found, perhaps it's a Core command? :3");

                    //searching in Core
                    Type tCore = typeof(Core);
                    MethodInfo mi = tCore.GetMethod(cmd, BindingFlags.Public | BindingFlags.Static);

                    if (mi != null)
                    {
                        if (mi.GetParameters().Count() > flags.Count())
                        {
                            Core.Printc("`" + mi.Name + "`", ConsoleColor.Cyan, false);
                            Console.Write(" expects " + mi.GetParameters().Count() + " argument(s).\r\n");
                        }
                        else if (mi.GetParameters().Count() == flags.Count())
                        {

                            mi.Invoke(null, flags.ToArray());
                        }
                    }
                    else
                    {
                        Debug.WriteLine("I'm afraid even the Core module has no '" + cmd + "' command");
                        Console.WriteLine("No '" + cmd + "' module found.");
                    }
                }


                //check if the function exists in the core

                //  MethodInfo mi = t.GetMethod(cmd);
                //  mi.Invoke(mi, flags.ToArray());

            }
        }
    }
}