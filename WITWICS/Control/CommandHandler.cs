using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WITWICS.Entity;

namespace WITWICS.Control
{
    class CommandHandler
    {
        private CommandState availableCommands;
        private CommandParser commandParser;

        public CommandHandler()
        {
            // We should implement state in order to restrict our commands as shown in week 10?
            availableCommands = new FlightState();
            // Create basic commands that should always be available.
            
            // This is a stub and will cause a compile error for now whilst I assess it.
            // commandParser = new CommandParser();
        }

        public CommandResponse ProcessTurn(string input, Detective detective)
        {
            // Get the parsed command from the input provided.
            ParsedCommand parsedCommand = Parse(input);

            try
            {
                // Set the command if it exists within the availableCommands array. (This will throw an exception that is caught if the key doesn't exist)
                // TODO: Update comment
                Command command = availableCommands.GetCommand(parsedCommand.Command);
                // Execute the command on the entity. (In this case the detective)
                return command.Execute(parsedCommand, detective);
            }
            catch(KeyNotFoundException)
            {
                // If the command doesn't exist then inform the user.
                return new CommandResponse("The command you have entered is invalid, please try again!");
            }
        }

        private ParsedCommand Parse(String input)
        {
            CommandParser commandParser = new CommandParser(availableCommands.GetCommandLabels());
            return commandParser.Parse(input);
        }
    }
}
