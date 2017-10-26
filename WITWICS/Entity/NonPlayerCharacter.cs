using System;


namespace WITWICS.Entity
{
    public class NonPlayerCharacter : Character
    {
        private Clue clue;

        public NonPlayerCharacter()
        {
        }

        public NonPlayerCharacter(String name, Clue clue) : base(name)
        {
            Name = name;
            Clue = clue;
        }

        public Clue Clue
        {
            get => clue;
            set => clue = value;
        }
    }
}
