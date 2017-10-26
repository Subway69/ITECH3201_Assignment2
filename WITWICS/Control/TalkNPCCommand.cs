using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WITWICS.Entity;

namespace WITWICS.Control
{
    public class TalkNPCCommand : Command
    {
        public override CommandResponse Execute(ParsedCommand command, Detective detective)
        {
            if (command.Arguments.Count == 0)
            {
                return new CommandResponse("Please let me know who you want to talk to!");
            }

            String npcLabel = (String)command.Arguments[0];

            NonPlayerCharacter npc = detective.Location.GetNPCCollection().GetNPC(npcLabel);

            if(npc == null)
            {
                return new CommandResponse("Sorry that NPC doesn't exist!");
            }

            detective.AddClue(npc.Clue);
            return new CommandResponse("You talk to " + npc.Name + " they tell you that the villian " + npc.Clue.Description);
        }
    }
}
