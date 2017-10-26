using System;
using System.Collections;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITWICS.Entity
{
   public class Location
    {
        private DestinationCollection destinations;
        private String description;
        private String name;

        public Location()
        {

        }

        public Location(String description, String name)
        {
            Description = description;
            Name = name;
            destinations = new DestinationCollection();
        }

        public Boolean AddDestination(String destinationName, Destination theDestination)
        {
            if (destinations.HasDestination(destinationName))
                return false;
            destinations.AddDestination(destinationName, theDestination);
            return true;
        }

        public Destination GetDestination(String destinationLabel)
        {
            return destinations.GetDestination(destinationLabel);
        }

        public DestinationCollection GetDestinationCollection()
        {
            return destinations;
        }


        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return "**********\n" + this.Name + "\n**********"
                + "\n" + destinations.ListLocations()
                + "\n**********\nYou find yourself in "
                + this.Description + "\n**********\n";
        }
    }
}
