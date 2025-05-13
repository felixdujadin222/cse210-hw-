using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        
        List<int> numbers = new List<int>();
        int input;

        
        Console.WriteLine("Enter numbers (0 to stop):");

        do
        {
            Console.Write("Enter a number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }

        } while (input != 0);

        
        Console.WriteLine("\nNumbers entered:");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine("Sum: " + sum);

        
        if (numbers.Count > 0)
        {
            double average = (double)sum / numbers.Count;
            Console.WriteLine("Average: " + average);
        }
        else
        {
            Console.WriteLine("No numbers to calculate average.");
        }

        
        if (numbers.Count > 0)
        {
            int max = numbers[0];
            foreach (int num in numbers)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            Console.WriteLine("The largest number is: " + max);
        }
        else
        {
            Console.WriteLine("No numbers to find maximum.");
        }
    }
}
