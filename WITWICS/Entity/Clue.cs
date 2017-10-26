using System;


namespace WITWICS.Entity
{
    public class Clue
    {
        private String description;

        public Clue()
        {

        }

        public Clue(String description)
        {
            Description = description;
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
