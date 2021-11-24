using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = 50;
            int endNum = 100;
            Console.WriteLine($"введите целое число от {startNum} до {endNum}");

            int age = Convert.ToInt32(Console.ReadLine());
            if (age % 2 == 0 && startNum < age && age < endNum)
            {
                Console.WriteLine($"число {age} четное");
            }
            else if (age % 2 != 0 && startNum < age && age < endNum)
            {
                Console.WriteLine($"число : {age} не четноe");
            }
            else
            {
                Console
                    .WriteLine($"число : {age} не попадает в диапазон от от {startNum} до {endNum}");
            }
        }
    }
}
