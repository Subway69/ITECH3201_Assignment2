using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WITWICS.Entity;

namespace WITWICS.Control
{
    public class FlyCommand : Command
    {
        public override CommandResponse Execute(ParsedCommand command, Detective detective)
        {
            if (command.Arguments.Count == 0)
            {
                return new CommandResponse("Please let me know where you want to fly to");
            }

            String destinationLabel = (String)command.Arguments[0];
            Airport location = (Airport)detective.Location;
            Destination destination = location.GetFlightsCollection().GetDestination(destinationLabel);
            if (destination == null)
            {
                return new CommandResponse("I can't fly there, try going somewhere else");
            }

            detective.Location = (Airport)destination.Location;

            return new CommandResponse(detective.Location.ToString());
        }
    }
}
