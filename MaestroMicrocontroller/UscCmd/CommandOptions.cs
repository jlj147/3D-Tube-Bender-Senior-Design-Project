using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace Pololu.Usc.UscCmd
{
    class CommandOptions
    {
        //  Defining attributes of the class
        //
        private string helpMessage;
        private Dictionary<string, string> privateArgs = new Dictionary<string, string>();


        //  Defining the CommandOptions to take the help message followed by the
        //  command arguments to be parsed and executed.
        //
        public CommandOptions(string help_message, string[] args)
        {
            string name = "";
            helpMessage = help_message;


            //  Parse through each argument that was sent
            //  to this function in args.
            //
            foreach (string arg in args)
            {
                //  Searches for a string, arg, in the string array, args, that
                //  matches with the format for a command.
                //
                Match m = Regex.Match(arg, "^--(.*)");

                //  Only if there is a match to "--""
                //
                if (m.Success)
                {
                    //  Set "name" to a string version of the current match
                    //  to a command in args. Next, set the privateArgs dictionary
                    //  to a blank value (will be set later).
                    //
                    name = m.Groups[1].ToString();
                    privateArgs[name] = "";
                    continue; //skip the rest of this iteration
                }

                //  No match to "--" and name has not been set
                //
                if (name == "")
                    error();

                //  Set the dictionary with the string that follows the match to
                //  the "--" argument from the input. This is the data point or
                //  filename that follows the actual command.
                //
                privateArgs[name] = arg;
            }


            //  This is the case that no matches to a command were found
            //  after going through all of args.
            //
            if (privateArgs.Count == 0)
                error();
        }


        //  What to do in case of an error.
        //  Called when there are no input arguments.
        //
        public void error()
        {
            Console.Error.WriteLine(helpMessage);
            Environment.Exit(1);
        }


        //  Same as error, but with a specific message to be printed.
        //
        public void error(string message)
        {
            Console.Error.WriteLine(message);
            Console.Error.WriteLine(helpMessage);
            Environment.Exit(1);
        }


        /// <summary>
        /// Returns the value of an argument, which is "" for arguments with no
        /// supplied parameter, or null if the argument was not supplied.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string this[string index]
        {
            get
            {
                if (privateArgs.ContainsKey(index))
                    return privateArgs[index];
                return null;
            }
        }


        /// <summary>
        /// returns the number of arguments
        /// </summary>
        /// <returns></returns>
        public int Count
        {
            get
            {
                return privateArgs.Count;
            }
        }
    }
}
