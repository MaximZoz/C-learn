using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            int num = Convert.ToInt32(Console.ReadLine());
            string str = String.Empty;
            if (num == 1)
            {
                str = "один";
            }
            else if (num == 2)
            {
                str = "два";
            }
            else
            {
                str = "не один и не два ";
            }
            Console.WriteLine($"вы ввели: {str}");
        }
    }
}
