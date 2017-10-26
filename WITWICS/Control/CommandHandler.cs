using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WITWICS.Entity;

namespace WITWICS.Control
{
    public class CommandHandler
    {
        private CommandState availableCommands;
        // private CommandParser commandParser;

        public CommandHandler()
        {
            availableCommands = new FlightState();
        }

        public CommandResponse ProcessTurn(string input, Detective detective)
        {
            // Update our state each turn changing the available commands
            availableCommands = availableCommands.Update(detective);
            // Get the parsed command from the input provided.
            ParsedCommand parsedCommand = Parse(input);

            // Set the command if it exists within the availableCommands array. (This will throw an exception that is caught if the key doesn't exist)
            // TODO: Update comment
            Command command = availableCommands.GetCommand(parsedCommand.Command);
            if(command == null)
            {
                return new CommandResponse("The command you have entered is invalid, for a list of commands use \"commands\"");
            }
            // Execute the command on the entity. (In this case the detective)
            return command.Execute(parsedCommand, detective);
        }

        private ParsedCommand Parse(String input)
        {
            CommandParser commandParser = new CommandParser(availableCommands.GetCommandLabels());
            return commandParser.Parse(input);
        }
    }
}
