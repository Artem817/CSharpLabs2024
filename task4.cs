using System;

class Program
{
    static void Main(string[] args)
    {
        int M = 5; 

        int[] X = new int[10 + 18 % 10]; 
        Random random = new Random();
        for (int i = 0; i < X.Length; i++)
        {
            X[i] = random.Next(-10, 11); 
        }

        int count = 0;
        foreach (var item in X)
        {
            if (Math.Abs(item) > M)
            {
                count++;
            }
        }
        int[] Y = new int[count];
        int index = 0;
        foreach (var item in X)
        {
            if (Math.Abs(item) > M)
            {
                Y[index++] = item;
            }
        }

        Console.WriteLine("Число M: " + M);
        Console.WriteLine("Масив X:");
        PrintArray(X);
        Console.WriteLine("Масив Y:");
        PrintArray(Y);

        Console.ReadLine(); 
    }

    static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
