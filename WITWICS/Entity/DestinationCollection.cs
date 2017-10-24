using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITWICS.Entity
{
    public class DestinationCollection
    {
        private Hashtable destinations;

        public DestinationCollection()
        {
            destinations = new Hashtable();
        }

        public bool AddDestination(String destinationLabel, Destination destination)
        {
            if (destinations.ContainsKey(destinationLabel))
            {
                return false;
            }
            destinations.Add(destinationLabel, destination);

            return true;
        }

        public Destination GetDestination(String destinationLabel)
        {
            return (Destination)destinations[destinationLabel];
        }

        public bool HasDestination(String destinationLabel)
        {
            return destinations.Contains(destinationLabel);
        }

        public string ListLocations()
        {
            StringBuilder returnString = new StringBuilder();
            returnString.Append("Destinations found :: ");
            foreach (string destination in destinations.Keys)
            {
                returnString.Append("[" + destination + "]");
            }
            returnString.Append("\n");

            return returnString.ToString();
        }
    }
}
