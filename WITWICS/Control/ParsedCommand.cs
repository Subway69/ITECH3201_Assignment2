using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITWICS.Control
{
    public class ParsedCommand
    {
        private string command;
        // TODO: Revisit this at a later point and determine if an ArrayList is really neccessary.
        private ArrayList arguments;

        // Initialise the class with no arguments and no command.
        public ParsedCommand()
        {
            Arguments = new ArrayList();
            Command = "";
        }

        // This will be ignored by user entered commands however it can still be useful for executing system specific commands in game.
        public ParsedCommand(string command, ArrayList arguments)
        {
            Arguments = arguments;
            Command = command;
        }

        public string Command
        {
            get => command;
            set => command = value;
        }

        public ArrayList Arguments
        {
            get => arguments;
            set => arguments = value;
        }
    }
}
