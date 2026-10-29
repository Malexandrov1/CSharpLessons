using System;
class Character
{
    private string name;
    private int hp;
    private int power;
    private static int count = 0;
    public Character(string n, int h, int p)
    {
        name = n;
        hp = h;
        power = p;
        count++;
    }
    public virtual void Attack(Character enemy)
    {
        enemy.TakeDamage(power);
        Console.WriteLine(name + " атакует этого " + enemy.name);
    }
    public void GetStatus()
    {
        Console.WriteLine(Name + ": " + Hp + " HP");
    }
    public static int HowMany()
    {
        return count;
    }
    public static bool IsValidStats(int h, int p)
    {
        return h > 0 && p > 0;
    }
    public string Name
    {
        get {return name;}
    }
    public int Hp
    {
        get {return hp;}
    }
    public void TakeDamage(int damage)
    {
        hp = hp - damage;
    }
    public bool IsAlive()
    {
        return hp > 0;
    }
    public override string ToString()
    {
        return name + " (HP: " + hp + ")";
    }

    public override bool Equals(object obj)
    {
        Character other = obj as Character;
        if (other == null)
            return false;
        return name == other.Name;
    }
    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}

class Player : Character
{
    public Player(string n, int h, int p) : base(n, h, p)
    {
    }
    public override void Attack(Character enemy)
    {
        base.Attack(enemy);
        Console.WriteLine("Игрок нанёс удар пупу");
    }
}
class Enemy : Character
{
    public Enemy(string n, int h, int p) : base(n, h, p)
    {
    }
    public override void Attack(Character enemy)
    {
        base.Attack(enemy);
        Console.WriteLine("Враг нанёс удар пууппу");
    }
}

class Programm
{
    static void Main()
    {
        Player player = new Player("Игрок", 10, 3);
        Enemy enemy = new Enemy("Враг", 8, 2);
        Console.WriteLine("Создан персонаж Игрок");
        Console.WriteLine("Создан персонаж Враг");
        Console.WriteLine("Всего персонажей " + Character.HowMany());
        Console.WriteLine();
        Console.WriteLine("Бой начинается");
        Console.WriteLine();
        while (player.IsAlive() && enemy.IsAlive())
        {
            player.Attack(enemy);
            Console.WriteLine(enemy);
            Console.WriteLine();
            if (enemy.IsAlive() == false)
                break;
            enemy.Attack(player);
            Console.WriteLine(player);
            Console.WriteLine();
        }
        if (player.IsAlive())
        {
            Console.WriteLine("Враг побеждён");
            Console.WriteLine("Игрок победил");
        }
        else
        {
            Console.WriteLine("Игрок побеждён");
            Console.WriteLine("Враг победил");
        }
    }
}