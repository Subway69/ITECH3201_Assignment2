using System;
using WITWICS.Boundary;
using WITWICS.Entity;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITWICS
{
    class HardCodedData : IGameData
    {
        private Location startUp;
        private Case currentCase;

        public HardCodedData()
        {
            CreateWorldMap();
        }

        // Why are we using a finalizer?
        ~HardCodedData()
        {
        }

        public virtual void Dispose()
        {
        }


        public Location GetStartingLocation()
        {
            return startUp;
        }

        public Case GetCurrentCase()
        {
            return currentCase;
        }

        public String GetWelcomeMessage()
        {
            return "Carmen's gang has pulled another caper!\nAnd it's up to you to crack the case...\n";
        }

        private void CreateWorldMap()
        {
            startUp =
                new Location("a rundown open office, with yellowing paperwork on the desks and notes from old investigations written in chalk on the blackboards",
                    "ACME Headquarters");
            Location prague = new Location("The capital city of the Czech Republic", "Prague");
            Location shanghai = new Location("", "Shanghai");
            Location vienna = new Location("", "Vienna");

            startUp.AddDestination(prague.Name, new Destination(prague.Description, prague));
            startUp.AddDestination(shanghai.Name, new Destination(shanghai.Description, shanghai));
            startUp.AddDestination(vienna.Name, new Destination(vienna.Description, vienna));

            // Create suspects
            Suspect robArr = new Suspect("Rob Arr", "Male", "Brown", "Brown", "Golf", "Scar", "Volkswagon");

            // Create case
            currentCase = new Case(1, "Valuable Treasure", "preserved artifacts from Jewish synagogues", robArr, prague);
        }
    }
}
