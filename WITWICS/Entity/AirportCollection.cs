using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITWICS.Entity
{
    class AirportCollection
    {
        private Hashtable airports;

        public AirportCollection()
        {
            airports = new Hashtable();
        }

        public bool AddAirport(String airportLabel, Airport airport)
        {
            if (airports.ContainsKey(airportLabel))
            {
                return false;
            }
            airports.Add(airportLabel, airport);

            return true;
        }

        public Airport GetAirport(String airportLabel)
        {
            return (Airport)airports[airportLabel];
        }

        public bool HasAirport(String airportLabel)
        {
            return airports.Contains(airportLabel);
        }

        public Hashtable GetAirports()
        {
            return (Hashtable)airports.Clone();
        }

        public string ListAirports()
        {
            StringBuilder returnString = new StringBuilder();
            returnString.Append("Airports found :: ");
            foreach (string airport in airports.Keys)
            {
                returnString.Append("[" + airport + "]");
            }
            returnString.Append("\n");

            return returnString.ToString();
        }
    }
}
