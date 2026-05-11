using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes2
{
    internal class Unit
    {
            public string Name { get; }

            private float _health;
            public float Health => _health;

            public int Damage { get; }

            public float Armor { get; }

            public Unit() : this("Unknown Unit") { }
        public Unit(string name)
        {
            Name = name;

            _health = 100f;
            Damage = 5;
            Armor = 0.6f;
        }

        public float GetRealHealth()
        { 
            return Health * (1f + Armor); 
        }

        public bool SetDamage(float value)
        {
            _health = Health - value * Armor;

            return _health <= 0f;
        }
     
    }
}
