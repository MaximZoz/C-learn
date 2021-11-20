using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello");
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();


            Console.WriteLine("How old are you?");
            int age = Convert.ToInt32(Console.ReadLine());
            string answer = $"Name: {name}, Age: {age}";

            Console.WriteLine(answer);

            int? a = null;
            a?.ToString();

            Console.WriteLine(a);




        }
    }
}
