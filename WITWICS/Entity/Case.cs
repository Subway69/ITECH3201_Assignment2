using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITWICS.Entity
{
    class Case
    {
        private int identifier;
        private String title;
        private String description;
        private Suspect villain;
        private Location startingCity;

        public Case(int id, String title, String description, Suspect villain, Location crimeLocation)
        {
            identifier = id;
            this.title = title;
            this.description = description;
            this.villain = villain;
            startingCity = crimeLocation;
        }

        public int Identifier
        {
            get { return identifier; }
            set { identifier =  value;}
        }

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public Suspect Villain
        {
            get { return villain; }
            set { villain = value; }
        }

        public Location StartingCity
        {
            get { return startingCity; }
            set { startingCity = value; }
        }
    }
}
