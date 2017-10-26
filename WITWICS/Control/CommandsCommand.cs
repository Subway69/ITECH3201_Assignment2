using System.Collections;
using System.Text;
using WITWICS.Entity;

namespace WITWICS.Control
{
    public class CommandsCommand : Command
    {
        private Hashtable availableCommands;

        public CommandsCommand(Hashtable availableCommands)
        {
            this.availableCommands = availableCommands;
        }

        public override CommandResponse Execute(ParsedCommand command, Detective detective)
        {
            StringBuilder returnString = new StringBuilder();
            returnString.Append("Available Commands\n");
            returnString.Append("------------------\n");
            foreach(string theCommand in availableCommands.Keys)
            {
                returnString.Append(theCommand + "\n");
            }

            return new CommandResponse(returnString.ToString());
        }
    }
}