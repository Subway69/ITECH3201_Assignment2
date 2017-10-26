using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITWICS.Entity
{
    class Case
    {
        private static int identifier = 0;
        private String title;
        private String description;
        private Suspect villain;
        private Location startingCity;

        public Case(String title, String description, Suspect villain, Location crimeLocation)
        {
            identifier++;
            this.title = title;
            this.description = description;
            this.villain = villain;
            villain.IsTargetVillain = true;
            startingCity = crimeLocation;
        }

        public int Identifier
        {
            get { return identifier; }
        }

        public String Title
        {
            get { return title; }
        }

        public String Description
        {
            get { return description; }
        }

        public Suspect Villain
        {
            get { return villain; }
        }

        public Location StartingCity
        {
            get { return startingCity; }
        }
    }
}
