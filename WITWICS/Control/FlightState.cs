using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WITWICS.Entity;

namespace WITWICS.Control
{
    public class FlightState : CommandState
    {
        public FlightState() : base()
        {
            // AvailableCommands.Add("fly",);
        }

        public override CommandState Update(Detective detective)
        {
            throw new NotImplementedException();
        }
    }
}
