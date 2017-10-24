using System;


namespace WITWICS.Entity
{
    public class NonPlayerCharacter : Character
    {
        private Clue clue;

        public NonPlayerCharacter()
        {
        }

        public NonPlayerCharacter(Clue clue)
        {
            Clue = clue;
        }

        public Clue Clue
        {
            get => clue;
            set => clue = value;
        }
    }
}
