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
        private DestinationCollection destinations;
        private NPCCollection npcs;
        private String description;
        private String name;

        public Location()
        {
            destinations = new DestinationCollection();
            npcs = new NPCCollection();
        }

        public Location(String description, String name)
        {
            Description = description;
            Name = name;
            destinations = new DestinationCollection();
            npcs = new NPCCollection();
        }

        public DestinationCollection GetDestinationCollection()
        {
            return destinations;
        }

        public NPCCollection GetNPCCollection()
        {
            return npcs;
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

        public override string ToString()
        {
            StringBuilder returnString = new StringBuilder();
            returnString.Append("\n**********\n");
            returnString.Append("Location: " + Name + "\n");
            returnString.Append("You find yourself in " + Description + "\n");
            returnString.Append("**********\n");
            returnString.Append("Move \n");
            returnString.Append("**********\n");
            returnString.Append(GetDestinationCollection().ListLocations() + "\n");
            returnString.Append("Talk \n");
            returnString.Append("**********\n");
            returnString.Append(GetNPCCollection().ListNPCs() + "\n");

            return returnString.ToString();
        }
    }
}
