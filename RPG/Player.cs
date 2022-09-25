namespace RPG
{
    public class Player
    {

        public string Name { get; private set; }

        public bool IsAlive { get; internal set; } = true;

        public double Vitality { get; set; } = 100;

        public Weapon? Weapon { get; set; }

        public Shield? Shield { get; set; }


        private readonly Random random = new();


        public double GetDefense()
        {
            if (Shield == null)
            {
                return 0.0;
            }
            else if (Shield is SmallShield shield)
            {
                if (random.NextDouble() < shield.Accuracy)
                {
                    return 40.0;
                }
                else
                {
                    return 0.0;
                }
            }
            else if (Shield is LargeShield)
            {
                return 40.0;
            }
            else
            {
                return 0.0;
            }
        }


        public void Attack(Player enemy)
        {
            Console.WriteLine(Name + " attacks " + enemy.Name);

            if (Weapon != null)
            {
                if (Weapon is Sword)
                {
                    double defense = enemy.GetDefense();
                    double damage = Math.Max(Weapon.Strength - defense, 0.0);
                    enemy.Hit(damage);
                }
                else if (Weapon is MagicWand)
                {
                    double damage = Weapon.Strength;
                    enemy.Hit(damage);
                }
                else if (Weapon is Bow bow)
                {
                    if (random.NextDouble() < bow.Accuracy)
                    {
                        double defense = enemy.GetDefense();
                        double damage = Math.Max(Weapon.Strength - defense, 0.0);
                        enemy.Hit(damage);
                    }
                }
            }
        }

        public void Hit(double damage)
        {
            Console.WriteLine(damage + " damage for " + Name);

            Vitality = Math.Max(0.0, Vitality - damage);

            if (Vitality == 0.0)
            {
                IsAlive = false;
                Console.WriteLine(Name + " is dead.");
            }
            else
            {
                Console.WriteLine("Vitality left: " + Vitality);
            }
        }

        public void Reset()
        {
            Vitality = 100.0;
            IsAlive = true;
        }

        public Player(string name)
        {
            Name = name;
        }


    }
}
