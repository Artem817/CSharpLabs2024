using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть три цілих числа:");
        int number1 = int.Parse(Console.ReadLine());
        int number2 = int.Parse(Console.ReadLine());
        int number3 = int.Parse(Console.ReadLine());

        int groupNumber = 18 % 10; 

        Console.WriteLine("Числа, які належать інтервалу [1, 10+№]:");
        if (number1 >= 1 && number1 <= 10 + groupNumber)
        {
            Console.WriteLine(number1);
        }
        if (number2 >= 1 && number2 <= 10 + groupNumber)
        {
            Console.WriteLine(number2);
        }
        if (number3 >= 1 && number3 <= 10 + groupNumber)
        {
            Console.WriteLine(number3);
        }

        Console.ReadLine(); 
    }
}
