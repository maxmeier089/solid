using RPG;

Player knight = new("Kunibert")
{
    Weapon = new Sword(),
    Shield = new LargeShield()
};

Player wizard = new("Merlin")
{
    Weapon = new MagicWand(),
    Shield = new SmallShield()
};

// returns if someone is dead
static bool attack(Player attacker, Player defender)
{
    attacker.Attack(defender);

    if (!defender.IsAlive)
    {
        Console.WriteLine(attacker.Name + " wins!");
        return true;
    }

    return false;
}

while (true)
{
    while (true)
    {
        if (attack(knight, wizard)) break;
        if (attack(wizard, knight)) break;
    }

    Console.WriteLine("\nPress enter for another game.");

    string? input = Console.ReadLine();

    if (input == "0") return;

    knight.Reset();
    wizard.Reset();
}

