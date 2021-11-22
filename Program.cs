using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console
                .WriteLine("For figure out diameter of circle, input value of radius: ");
            double radius = Convert.ToDouble(Console.ReadLine());
            
            if (radius > 0)
            {
                double diameter = radius * 2;
                Console.WriteLine($"diameter: {diameter}");
            }
            else
            {
                Console.WriteLine("неверно, попробуйте снова");
            }
        }
    }
}
