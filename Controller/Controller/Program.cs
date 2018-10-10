using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to the controller.");

            string commands = Console.ReadLine();

            if(commands.Equals("hi"))
            {
                Console.WriteLine("Good Job");
            }

            commands = Console.ReadLine();

            JrkCmd.Program(commands);



            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
}
