using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WITWICS.Entity;

namespace WITWICS.Control
{
    public class ApprehendCommand : Command
    {
        public override CommandResponse Execute(ParsedCommand command, Detective detective)
        {
            if(command.Arguments.Count == 0)
            {
                return new CommandResponse("Please let me know who to apprehend");
            }

            Airport location = (Airport)detective.Location;
            String suspectName = (String)command.Arguments[0];
            Suspect suspect = location.Suspect;

            if(!(suspectName.Equals(suspect.Name.ToLower())))
            {
                return new CommandResponse(suspectName + " isn't here!");
            }

            if(detective.CurrentClues() < 4)
            {
                return new CommandResponse("I need to know more before I can apprehend the suspect!");
            }

            if(suspect.IsTargetVillain)
            {
                Console.WriteLine("Well done you've arrested the correct suspect!");
                Console.ReadLine();

                return new CommandResponse("You've won!", true);
            }

            Console.WriteLine("Well done you've arrested a suspect, however upon further investigation it turns out they didn't commit the crime!");
            Console.ReadLine();

            return new CommandResponse("You've lost!", true);
        }
    }
}
