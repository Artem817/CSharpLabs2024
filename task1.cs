using System;

public abstract class Mage
{
    public string Name { get; protected set; }
    public int MagicLevel { get; protected set; }
    public int Health { get; protected set; }

    protected Mage(string name, int magicLevel, int health)
    {
        Name = name;
        MagicLevel = magicLevel;
        Health = health;
    }

    public abstract void Attack(Mage target);
    public abstract void Defend(int damage);
}

public interface ISpell
{
    void CastSpell(Mage caster, Mage target);
}

public class FireMage : Mage
{
    public FireMage(string name) : base(name, 10, 100) {}

    public override void Attack(Mage target)
    {
        Console.WriteLine($"{Name} casts a fireball at {target.Name}!");
        target.Defend(20);
    }

    public override void Defend(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} takes {damage} damage and now has {Health} health left.");
    }
}

// Клас Водяного мага
public class WaterMage : Mage
{
    public WaterMage(string name) : base(name, 10, 100) {}

    public override void Attack(Mage target)
    {
        Console.WriteLine($"{Name} casts a water blast at {target.Name}!");
        target.Defend(15);
    }

    public override void Defend(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} takes {damage} damage and now has {Health} health left.");
    }
}

// Логіка гри
public class Game
{
    private Mage player1;
    private Mage player2;

    public Game(Mage mage1, Mage mage2)
    {
        player1 = mage1;
        player2 = mage2;
    }

    public void StartBattle()
    {
        while (player1.Health > 0 && player2.Health > 0)
        {
            player1.Attack(player2);
            if (player2.Health > 0)
            {
                player2.Attack(player1);
            }
        }

        if (player1.Health > 0)
            Console.WriteLine($"{player1.Name} wins!");
        else
            Console.WriteLine($"{player2.Name} wins!");
    }
}

class Program
{
    static void Main()
    {
        Mage fireMage = new FireMage("Merlin");
        Mage waterMage = new WaterMage("Morgana");

        Game game = new Game(fireMage, waterMage);
        game.StartBattle();
    }
}
