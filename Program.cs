using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /// d = sqrt(2Rh)
            Console.Write("Введите расстояние от земли до глаз наблюдателя: ");
            double h = Convert.ToDouble(Console.ReadLine());
            double R = 63.5 * Math.Pow(10, 5); //!6350 = 63,5 * 10^5
            double d = Math.Sqrt(2 * R * h);
            Console
                .WriteLine("Расстояние до линии горизонта от точки с заданной высотой равна: {0}км",
                Math.Round(d, 0));
            Console.ReadKey();
        }
    }
}
