using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, type your name ");
            string user = Console.ReadLine();
            Console.WriteLine($"Hello {user}. Today you have to computation some formula. Smile and press OK to start!");
            Console.ReadLine();
            Console.Write("Figure out value of function y=7x^2+3x+6. Please input value of x: ");
            double valuex = Convert.ToDouble(Console.ReadLine());
            double valuey = 7 * valuex * valuex + 3 * valuex + 6;
            Console.WriteLine($"Easy {user}! Value of y = {valuey} . Press OK to pass on ");
            Console.ReadLine();
        }
    }
}