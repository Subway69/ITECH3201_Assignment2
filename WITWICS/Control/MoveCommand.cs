using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WITWICS.Entity;

namespace WITWICS.Control
{
    public class MoveCommand : Command
    {
        public override CommandResponse Execute(ParsedCommand command, Detective detective)
        {
            if(command.Arguments.Count == 0)
            {
                return new CommandResponse("Please let me know where you want to move to");
            }

            String destinationLabel = (String)command.Arguments[0];
            Destination destination = detective.Location.GetDestination(destinationLabel);
            if(destination == null)
            {
                return new CommandResponse("I can't move there, try going somewhere else");
            }

            detective.Location = destination.TheDestination;
            return new CommandResponse("You find yourself looking at " + detective.Location.Description);
        }
    }
}
