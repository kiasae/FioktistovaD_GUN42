using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes2
{
    internal struct Room
    {
        public Unit Unit;
        public Weapon Weapon;

        public Room(Unit Unit, Weapon Weapon) 
        {
            this.Unit = Unit;
            this.Weapon = Weapon;
        }
    }
}
