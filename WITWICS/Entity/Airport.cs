using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITWICS.Entity
{
    public class Airport : Location
    {
        // Use an airport location in order to allow flights to be taken from big locations
        // whilst you can only talk to NPC's within small locations?

        // I could be looking too far into this.

        // private AirportCollection airports;
        private DestinationCollection flights;
        private Suspect suspect;

        public Airport() : base()
        {
            flights = new DestinationCollection();
        }

        public Airport(String description, String name) : base(description, name)
        {
            flights = new DestinationCollection();
        }

        // TODO: Implementation pending
        public Suspect Suspect
        {
            get => suspect;
            set => suspect = value;
        }

        public Boolean AddFlight(String destinationName, Destination theDestination)
        {
            if (flights.HasDestination(destinationName))
                return false;
            flights.AddDestination(destinationName, theDestination);
            return true;
        }

        public Destination GetFlight(String destinationLabel)
        {
            return (Destination)flights.GetDestination(destinationLabel);
        }

        public DestinationCollection GetFlightsCollection()
        {
            return flights;
        }

        public override string ToString()
        {
            StringBuilder returnString = new StringBuilder();
            returnString.Append(base.ToString());
            returnString.Append("Fly \n");
            returnString.Append("**********\n");
            returnString.Append(GetFlightsCollection().ListLocations() + "\n");

            return returnString.ToString();
        }
    }
}
