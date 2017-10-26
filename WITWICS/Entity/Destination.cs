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
        private Location location;

        public Destination (String description, Location destination)
        {
            Description = description;
            Location = destination;
        }


        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Location Location
        {
            get { return location; }
            set { location = value; }
        }
    }
}
