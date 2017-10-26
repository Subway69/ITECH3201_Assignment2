using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WITWICS.Entity;

namespace WITWICS.Control
{
    class MovementState : CommandState
    {
        public MovementState()
        {
            AvailableCommands.Add("move", new MoveCommand());
            AvailableCommands.Add("quit", new QuitCommand());
            AvailableCommands.Add("command", new CommandsCommand(AvailableCommands));
            AvailableCommands.Add("commands", new CommandsCommand(AvailableCommands));
            AvailableCommands.Add("help", new CommandsCommand(AvailableCommands));
            AvailableCommands.Add("talk", new TalkNPCCommand());
        }

        public override CommandState Update(Detective detective)
        {
            if (!(detective.Location is Airport))
                return this;
            return new FlightState();
        }
    }
}
