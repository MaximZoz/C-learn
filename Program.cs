using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // ! так создаются массива
            // int[] numbers = new int[10];
            // numbers[0] = 1;
            // numbers[1] = 2;
            // Console.WriteLine($"numbers: {numbers}");
            // ! будет [1,2,0,0,0,0,0,0,0,0,0,0,0]
            // string[] strings = new string[10];
            // strings[0] = "Максим";
            // Console.WriteLine($"strings: {strings[0]}");
            //! динамическое создание массива
            // string[] names2 = new string[] { };
            // names2[0] = "Maxim";
            // ! или так
            // string[] names3 = { "Maxim", "Max" };
            // Console.WriteLine($"names3: {names3[1]}");
            // ! перебор массива методом foreeach
            // string[] names = { "Maxim", "Max", "Min" };
            // foreach (string i in names)
            // {
            //     Console.WriteLine (i);
            // }
            //! Получение последнего элемента
            // int[] numbers = { 1, 2, 3, 5 };
            // Console.WriteLine(numbers[numbers.Length - 1]); /*//! 5 */
            // ! Многомерные массивы
            // int[,] nums2 = { { 0, 1, 2 }, { 3, 4, 5 } };
            string[] names = { "Maxim", "Max", "Min" };

            // ! задача: вывести имена в массиве где символов больше 4
            // int min = 4;
            // foreach (var item in names)
            // {
            //     if (item.Length > min)
            //     {
            //         Console.WriteLine($"имя: {item}"); /*//! Maxim */
            //     }
            // }
        }
    }
}
