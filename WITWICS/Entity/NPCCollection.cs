using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITWICS.Entity
{
    public class NPCCollection
    {
        private Hashtable npcs;

        public NPCCollection()
        {
            npcs = new Hashtable();
        }

        public bool AddNPC(String npcLabel, NonPlayerCharacter npc)
        {
            if(npcs.ContainsKey(npcLabel))
            {
                return false;
            }
            npcs.Add(npcLabel, npc);

            return true;
        }

        public NonPlayerCharacter GetNPC(String npcLabel)
        {
            return (NonPlayerCharacter)npcs[npcLabel];
        }

        public bool HasNPC(String npcLabel)
        {
            return npcs.Contains(npcLabel);
        }

        public string ListNPCs()
        {
            StringBuilder returnString = new StringBuilder();
            returnString.Append("NPCs found :: " + npcs.Count);
            foreach(string npc in npcs.Keys)
            {
                returnString.Append("[" + npc + "]");
            }
            returnString.Append("\n");

            return returnString.ToString();
        }
    }
}
