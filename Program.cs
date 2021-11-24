using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //! цикл for
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"i: {i}");
            }

            //! цикл while
            int j = 0;
            while (j <= 10)
            {
                Console.WriteLine($"j: {j}");
                j++;
            }
        }
    }
}
