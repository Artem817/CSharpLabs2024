using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть довжини сторін трикутника:");

        Console.Write("Сторона a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Сторона b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Сторона c: ");
        double c = double.Parse(Console.ReadLine());

      
        if (IsValidTriangle(a, b, c))
        {
           
            double perimeter = a + b + c;
            Console.WriteLine("Периметр трикутника: " + perimeter);

            double s = perimeter / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            Console.WriteLine("Площа трикутника: " + area);

            if (a == b && b == c)
            {
                Console.WriteLine("Трикутник рівносторонній.");
            }
            else if (a == b || b == c || a == c)
            {
                Console.WriteLine("Трикутник рівнобедрений.");
            }
            else
            {
                Console.WriteLine("Трикутник різносторонній.");
            }
        }
        else
        {
            Console.WriteLine("Такий трикутник не існує.");
        }

        Console.ReadLine(); 
    }

    static bool IsValidTriangle(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a && a > 0 && b > 0 && c > 0;
    }
}

