using System;

class Program
{
    static void Main(string[] args)
    {
        int[] array = new int[10 + 18 % 10]; 

        Random random = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(100); 
        }

        int min = array[0];
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
            if (array[i] > max)
            {
                max = array[i];
            }
        }

        Console.WriteLine("Масив:");
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Мінімальне значення: " + min);
        Console.WriteLine("Максимальне значення: " + max);

        Console.ReadLine(); 
    }
}

