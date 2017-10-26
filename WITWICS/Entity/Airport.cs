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

        public Airport() : base()
        {
            flights = new DestinationCollection();
        }

        public Airport(String description, String name) : base(description, name)
        {
            flights = new DestinationCollection();
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
            //
            return base.ToString() 
                + "\n*********\nFlights\n*********\n" 
                + flights.ListLocations();
        }

        

        // TODO: Add Destination/Flights collection.

        // public override Boolean AddDestination() { throw new NotImplementedException; }
    }
}
