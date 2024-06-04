using System;

public abstract class Mage
{
    public string Name { get; set; }
    public int MagicLevel { get; set; }
    public int Health { get; set; }

    public Mage(string name, int magicLevel)
    {
        Name = name;
        MagicLevel = magicLevel;
        Health = 100;
    }

    public abstract void Attack(Mage other);
    public abstract void Defend(int damage);

    public bool IsAlive()
    {
        return Health > 0;
    }
}

public interface ISpell
{
    int Cast();
}

public class FireSpell : ISpell
{
    public int Cast()
    {
        return 20;
    }
}

public class FireMage : Mage
{
    private ISpell Spell;

    public FireMage(string name) : base(name, 5)
    {
        Spell = new FireSpell();
    }

    public override void Attack(Mage other)
    {
        int damage = Spell.Cast();
        Console.WriteLine($"{Name} атакує вогнем на {damage} пошкодження!");
        other.Defend(damage);
    }

    public override void Defend(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} отримав  {damage} пошкоджень i має {Health} здоровя.");
    }
}

class Program
{
    static void Main()
    {
        Mage player = new FireMage("Маг-гравець");
        Mage computer = new FireMage("Комп'ютерний маг");

        Console.WriteLine("Ласкаво просимо на Битву магів!!");
        Console.WriteLine("Ви контролюєте мага-гравця. Твiй суперник - комп'ютерний маг.");

        while (player.IsAlive() && computer.IsAlive())
        {
            Console.WriteLine("Виберіть свою дію:\n1. Атакувати\n2. Пропустити хід");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                player.Attack(computer);
            }
            else
            {
                Console.WriteLine("Ви вирішили пропустити свій хiд.");
            }

            if (computer.IsAlive())
            {
                computer.Attack(player);
            }
        }

        if (player.IsAlive())
        {
            Console.WriteLine("Вітаю! Ти виграв!");
        }
        else
        {
            Console.WriteLine("Game Over! Комп'ютер переміг.");
        }
    }
}
