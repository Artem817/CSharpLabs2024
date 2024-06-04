using System;

public delegate void AttackEventHandler(Mage attacker, Mage defender, int damage);
public delegate void DefenseEventHandler(Mage defender, int damage);

public abstract class Mage
{
    public string Name { get; set; }
    public int MagicLevel { get; set; }
    public int Health { get; set; }

    public event AttackEventHandler Attacked;
    public event DefenseEventHandler Defended;

    public Mage(string name, int magicLevel)
    {
        Name = name;
        MagicLevel = magicLevel;
        Health = 100;
    }

    public abstract void Attack(Mage other);
    public abstract void Defend(int damage);

    public void OnAttacked(Mage defender, int damage)
    {
        Attacked?.Invoke(this, defender, damage);
    }

    public void OnDefended(int damage)
    {
        Defended?.Invoke(this, damage);
    }

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
        OnAttacked(other, damage);
    }

    public override void Defend(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} отримав {damage} пошкоджень i має {Health} здоровя.");
        OnDefended(damage);
    }
}

class Program
{
    static void Main()
    {
        Mage player = new FireMage("Маг-гравець");
        Mage computer = new FireMage("Комп'ютерний маг");

        player.Attacked += (attacker, defender, damage) => Console.WriteLine($"Event: {attacker.Name} атакував {defender.Name} на {damage} пошкодження!");
        computer.Defended += (defender, damage) => Console.WriteLine($"Event: {defender.Name} захистився від {damage} пошкоджень!");

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
