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
        private Hashtable destinations;
        private String description;
        private String name;

        public Location()
        {
        }

        public Location(String description, String name)
        {
            Description = description;
            Name = name;
            destinations = new Hashtable();
        }

        public Boolean AddDestination(String destinationName, Destination theDestination)
        {
            if (destinations.ContainsKey(destinationName))
                return false;
            destinations.Add(destinationName, theDestination);
            return true;
        }

        public Destination GetDestination(String destinationLabel)
        {
            return (Destination)destinations[destinationLabel];
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
    }
}
