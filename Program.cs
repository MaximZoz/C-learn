using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("первое число:");
            string a = Console.ReadLine();
            Console.Write("второе число:");
            string b = Console.ReadLine();
            Console.Write("третье число:");
            string c = Console.ReadLine();
            Console.Write("четвётрое число:");
            string d = Console.ReadLine();
            Console.WriteLine($"Вы ввели числа: {a} {b} {c} {d}");
        }
    }
}
