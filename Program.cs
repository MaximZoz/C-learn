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
            switch (num)
            {
                case 0:
                    str = "ноль";
                    break;
                case 1:
                    str = "один";
                    break;
                default:
                    str = "не ноль и не один";
                    break;
            }
            Console.WriteLine($"вы ввели: {str}");
        }
    }
}
