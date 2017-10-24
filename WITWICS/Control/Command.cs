using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WITWICS.Entity;

namespace WITWICS.Control
{
    public abstract class Command
    {
        public abstract CommandResponse Execute(ParsedCommand command, Detective detective);
    }
}
