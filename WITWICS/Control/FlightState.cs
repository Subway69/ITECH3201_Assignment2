﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WITWICS.Entity;

namespace WITWICS.Control
{
    public class FlightState : CommandState
    {
        public FlightState()
        {
            AvailableCommands.Add("move", new MoveCommand());
            AvailableCommands.Add("quit", new QuitCommand());
            AvailableCommands.Add("command", new CommandsCommand(AvailableCommands));
            AvailableCommands.Add("commands", new CommandsCommand(AvailableCommands));
            AvailableCommands.Add("help", new CommandsCommand(AvailableCommands));
            AvailableCommands.Add("fly", new FlyCommand());
            AvailableCommands.Add("talk", new TalkSuspectCommand());
            AvailableCommands.Add("apprehend", new ApprehendCommand());
        }

        public override CommandState Update(Detective detective)
        {
            if (detective.Location is Airport)
                return this;
            return new MovementState();

        }
    }
}
