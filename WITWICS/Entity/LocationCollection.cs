using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITWICS.Entity
{
    public class LocationCollection
    {
        private Hashtable locations;

        public LocationCollection()
        {
            locations = new Hashtable();
        }

        public bool AddLocation(String locationLabel, Location location)
        {
            if (locations.ContainsKey(locationLabel))
            {
                return false;
            }
            locations.Add(locationLabel, location);

            return true;
        }

        public Location GetLocation(String locationLabel)
        {
            return (Location)locations[locationLabel];
        }

        public Hashtable GetLocations()
        {
            return (Hashtable)locations;
        }

        public bool HasLocation(String locationLabel)
        {
            return locations.Contains(locationLabel);
        }

        public string ListLocations()
        {
            StringBuilder returnString = new StringBuilder();
            returnString.Append("Locations found :: ");
            foreach (string location in locations.Keys)
            {
                returnString.Append("[" + location + "]");
            }
            returnString.Append("\n");

            return returnString.ToString();
        }
    }
}
