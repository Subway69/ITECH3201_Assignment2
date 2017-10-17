using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITWICS.Entity
{
    public class Destination
    {
        private String description;
        private Location theDestination;

        public Destination (String description, Location nextDestination)
        {
            Description = description;
            TheDestination = nextDestination;
        }


        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Location TheDestination
        {
            get { return theDestination; }
            set { theDestination = value; }
        }
    }
}
