﻿using System;
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
            Suspect = null;
        }

        public Airport(String description, String name) : base(description, name)
        {
            flights = new DestinationCollection();
            Suspect = null;
        }

        // TODO: Implementation pending
        public Suspect Suspect
        {
            get => suspect;
            set => suspect = value;
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
            returnString.Append("**********\n");
            if (!(Suspect == null))
            {
                returnString.Append("Suspect Found! Use talk to talk to them\n");
                returnString.Append("[" + suspect.Name + "]");
            }

            return returnString.ToString();
        }
    }
}
