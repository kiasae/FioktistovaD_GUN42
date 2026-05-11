namespace Classes2
{
    internal class Unit
    {
        public string Name { get; }

        private float _health;
        public float Health => _health;

        public Interval Damage{ get; }

        public float Armor { get; }

        public Unit() : this("Unknown Unit") { }
        public Unit(string name, int minDamage = 0, int maxDamage = 5) 
        {
            Name = name;
            Damage = new Interval(minDamage, maxDamage);
            _health = 100f;
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
