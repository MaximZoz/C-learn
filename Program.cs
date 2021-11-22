using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину стороны квадрата:  ");
            float s = Convert.ToSingle(Console.ReadLine());

            if (s > 0)
            {
                float p = s * 4;
                Console.Write($"\nПериметр квадрата  = {p}");
            }
            else
                Console.Write("Введено не верное значение.");
        }
    }
}
