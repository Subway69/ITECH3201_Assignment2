using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WITWICS.Entity;

namespace WITWICS.Control
{
    public class TalkSuspectCommand : Command
    {
        public override CommandResponse Execute(ParsedCommand command, Detective detective)
        {
            if (command.Arguments.Count == 0)
            {
                return new CommandResponse("Please let me know who you want to talk to!");
            }

            String suspectName = (String)command.Arguments[0];
            String query = (String)command.Arguments[1];
            Airport location = (Airport)detective.Location;
            Suspect suspect = location.Suspect;

            if(!(suspectName.Equals(suspect.Name.ToLower())))
            {
                return new CommandResponse(suspectName + " isn't here!");
            }

            String suspectResponse = "";
            switch(query)
            {
                case "hair":
                    suspectResponse = "have" + suspect.Hair + " hair";
                    break;
                case "eyes":
                    suspectResponse = "have" + suspect.Eyes + " eyes";
                    break;
                case "hobby":
                    suspectResponse = "enjoy " + suspect.Hobby + " in their spare time";
                    break;
                case "feature":
                    suspectResponse = "are most known for their " + suspect.Feature;
                    break;
                case "vehicle":
                    suspectResponse = "drive a " + suspect.Vehicle;
                    break;
                case "sex":
                    suspectResponse = "are a " + suspect.Sex;
                    break;
                default:
                    suspectResponse = "don't want to answer that";
                    break;
            }

            return new CommandResponse("You talk to " + suspect.Name + " they tell you that they " + suspectResponse);
        }
    }
}
