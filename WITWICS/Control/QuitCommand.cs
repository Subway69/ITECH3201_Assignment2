using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WITWICS.Entity;

namespace WITWICS.Control
{
    public class QuitCommand : Command
    {
        public override CommandResponse Execute(ParsedCommand command, Detective detective)
        {
            return new CommandResponse("You've entered the Quit command", true);
        }
    }
}
