using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WITWICS.Entity;

namespace WITWICS.Control
{
    public abstract class CommandState
    {
        private Hashtable availableCommands;

        public CommandState()
        {
            AvailableCommands = new Hashtable();
            AvailableCommands.Add("move", new MoveCommand());
            AvailableCommands.Add("look", new LookCommand());
            AvailableCommands.Add("quit", new QuitCommand());
        }

        public abstract CommandState Update(Detective detective);

        public Command GetCommand(string command)
        {
            // Try and return the Command object pointer from the HashTable
            try
            {
                return (Command)AvailableCommands[command];
            }
            // Catch the exception if the command isn't in the hastable then return null
            catch(KeyNotFoundException)
            {
                return null;
            }
        }

        public Hashtable AvailableCommands
        {
            get => availableCommands;
            set => availableCommands = value;
        }

        public ArrayList GetCommandLabels()
        {
            // Return all the available commands. [ArrayList(String)]
            return new ArrayList(availableCommands.Keys);
        }
    }
}
