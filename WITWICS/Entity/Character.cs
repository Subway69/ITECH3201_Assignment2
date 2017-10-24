using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITWICS.Entity
{
    public abstract class Character
    {
        protected String name;

        public Character()
        {
        }

        public Character(String name)
        {
            Name = name;
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
