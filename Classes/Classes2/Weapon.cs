using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes2
{
    internal class Weapon
    {
        public string Name { get; }

        private int MinDamage;

        private int MaxDamage;

        private void SetDamageParams(int minDamage, int maxDamage)
        {
            if (minDamage > maxDamage)
            {
                (minDamage, maxDamage) = (maxDamage, minDamage);
                Console.WriteLine($"Некорректные данные {Name}");
            }
            if (minDamage < 1)
            {
                int f = 1;
                minDamage = f;
                Console.WriteLine("Форсированная установка минимального значения");
            }
            if (maxDamage <= 1) 
            {
                maxDamage = 10;
            }
        }

        private void GetDamage(int getDamage) 
        {
            getDamage = (MinDamage + MaxDamage) / 2;
        }

        public float Durability;

        public Weapon(string name)
        {
            Name = name;
        }

        public Weapon(string name, int minDamage, int maxDamage) : this(name)
        {
            SetDamageParams(minDamage,maxDamage);
        }

    }
}
