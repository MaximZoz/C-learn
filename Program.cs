using System;

namespace HomeWork
{
    struct employees
    {
        public string surname;

        public int salaries;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int quantity;
            Console.WriteLine("Введите количество записей: ");
            quantity = Convert.ToInt32(Console.ReadLine());
            employees[] surnames = new employees[quantity];
            employees[] salaries = new employees[quantity];

            for (int i = 0; i < quantity; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"Введите фамилию сотрудника: ");
                }
                else if (i != quantity - 1)
                {
                    Console.WriteLine($"Введите фамилию следующего сотрудника: ");
                }
                else
                {
                    Console.WriteLine($"Введите фамилию последнего сотрудника: ");
                }
                surnames[i].surname = Convert.ToString(Console.ReadLine());
                Console
                    .WriteLine($"Введите зарплату сотрудника {surnames[i].surname}: ");
                salaries[i].salaries = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("N     |      Фамилия         | Зарплата |");
            Console.WriteLine("----------------------------------------");
            for (int column = 0; column < quantity; column++)
            {
                Console
                    .WriteLine($"{column + 1, -5} | " +
                    $"{surnames[column].surname, -20}" +
                    " | " +
                    $"{salaries[column].salaries, -8}" +
                    " | ");
                Console.WriteLine("----------------------------------------");
            }
            Console.Read();
        }
    }
}
