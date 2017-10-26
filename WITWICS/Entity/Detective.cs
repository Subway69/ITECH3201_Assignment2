using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITWICS.Entity
{
    public class Detective : Character
    {
        private Location location;
        private static int casesSolved = 0;
        private ArrayList clues;

        public Detective()
        {
            clues = new ArrayList();
        }

        public Detective(String name) : base(name)
        {
            clues = new ArrayList();
        }

        public int CasesSolved
        {
            get
            {
                return casesSolved;
            }
            set
            {
                casesSolved++;
            }
        }

        public Location Location
        {
            get => location;
            set => location = value;
        }

        public String GetRank()
        {
            String rank;
            // Switch statements are a code smell however it does feel appropriate for this.
            switch (casesSolved)
            {
                case 0:
                    rank = "Rookie";
                    break;
                case 1: case 2: case 3:
                    rank = "Sleuth";
                    break;
                case 4: case 5: case 6:
                    rank = "Private Eye";
                    break;
                case 7: case 8: case 9:
                    rank = "Investigator";
                    break;
                case 10: case 11: case 12: case 13:
                    rank = "Ace Detective";
                    break;
                default:
                    rank = "Retired";
                    break;
            }
            return rank;
        }

        public bool AddClue(Clue clue)
        {
            if(clues.Contains(clue))
            {
                return false;
            }

            clues.Add(clue);
            return true;
        }

        public int CurrentClues()
        {
            return clues.Count;
        }
    }
}
