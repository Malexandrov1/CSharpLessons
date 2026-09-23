List<string> spisok = new List<string>();
Console.Write("введите баланс ");
double balans = Convert.ToDouble(Console.ReadLine());
while (true)
{
    Console.WriteLine();
    Console.WriteLine("1 показать баланс");
    Console.WriteLine("2 пополнить счет");
    Console.WriteLine("3 снять деньги");
    Console.WriteLine("4 показать историю");
    Console.WriteLine("0 выйти");
    Console.Write("введите номер ");
    string knopka = Console.ReadLine();
    if (knopka == "1")
    {
        PrintBalans(balans);
    }
    else if (knopka == "2")
    {
        balans = DobavitMoney(balans, spisok);
    }
    else if (knopka == "3")
    {
        balans = SnatMoney(balans, spisok);
    }
    else if (knopka == "4")
    {
        PokazatHistory(spisok);
    }
    else if (knopka == "0")
    {
        break;
    }
    else
    {
        Console.WriteLine("такого пункта нет");
    }
}
static void PrintBalans(double balans, string valuta = "₽")
{
    Console.WriteLine($"ваш баланс {balans} {valuta}");
}
static double DobavitMoney(double balans, List<string> spisok)
{
    Console.Write("введите сумму пополнения ");
    double summa = Convert.ToDouble(Console.ReadLine());
    if (summa > 0)
    {
        balans = balans + summa;

        spisok.Add($"пополнение +{summa} ₽");

        Console.WriteLine("счет пополнен");
    }
    else
    {
        Console.WriteLine("сумма должна быть больше 0");
    }
    return balans;
}
static double SnatMoney(double balans, List<string> spisok)
{
    Console.Write("введите сумму снятия ");
    double summa = Convert.ToDouble(Console.ReadLine());
    if (summa <= 0)
    {
        Console.WriteLine("сумма должна быть больше 0");
    }
    else
    {
        if (summa > balans)
        {
            Console.WriteLine("недостаточно денег");
        }
        else
        {
            balans = balans - summa;

            spisok.Add($"снятие: -{summa} ₽");

            Console.WriteLine("деньги сняты");
        }
    }
    return balans;
}
static void PokazatHistory(List<string> spisok)
{
    if (spisok.Count == 0)
    {
        Console.WriteLine("история пустая");
    }
    else
    {
        for (int i = 0; i < spisok.Count; i++)
        {
            Console.WriteLine(spisok[i]);
        }
    }
}