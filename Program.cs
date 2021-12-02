using System;
namespace HomeWork
{
    struct employees
    {
        public string surname;

        public int salaries;
    }

    enum SortName
    {
        Alphabet = 1,
        Salary = 2,
        SalaryMoreAverage = 3,
        SalaryLessAverage = 4
    }

    class Program
    {
        static void Main(string[] args)
        {
            int quantity;

            Console.WriteLine($"Введите количество сотрудников: ");
            quantity = SetValueForValidator();

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
                    Console
                        .WriteLine($"Введите фамилию следующего сотрудника: ");
                }
                else
                {
                    Console
                        .WriteLine($"Введите фамилию последнего сотрудника: ");
                }
                surnames[i].surname = Convert.ToString(Console.ReadLine());

                string surname = surnames[i].surname;
                Console.WriteLine($"Введите зарплату сотрудника {surname}: ");

                salaries[i].salaries = SetValueForValidator();
            }

            Console.WriteLine("1,2,3,4");
            string str = CallSortingMethod();

            Console.WriteLine("N     |      Фамилия         | Зарплата |");
            Console.WriteLine("----------------------------------------");
            for (int column = 0; column < quantity; column++)
            {
                Console
                    .WriteLine($"{column + 1,-5} | " +
                    $"{surnames[column].surname,-20}" +
                    " | " +
                    $"{salaries[column].salaries,-8}" +
                    " | ");
                Console.WriteLine("----------------------------------------");
            }
            Console.Read();
        }

        static string CallSortingMethod()
        {
            byte num;
            try
            {
                num = Convert.ToByte(Console.ReadLine());
            }
            catch
            {
                num = 5;
            }
            string str;
            switch (num)
            {
                case (byte)SortName.Alphabet:
                    str = "Алфавит";
                    break;
                case (byte)SortName.Salary:
                    str = "Зарплата";
                    break;
                case (byte)SortName.SalaryMoreAverage:
                    str = "Зарплата выше среднего";
                    break;
                case (byte)SortName.SalaryLessAverage:
                    str = "Зарплата ниже среднего";
                    break;
                default:
                    str = "";
                    break;
            }
            if (str == "")
            {
                Console.WriteLine("неправильно, попробуйте снова");
                CallSortingMethod();
            }
            return str;
        }

        static int SetValueForValidator()
        {
            int val;
            try
            {
                val = Convert.ToInt32(Console.ReadLine());
                if (
                    val < 0
                )
                {
                    Console.WriteLine("Зарплата не может быть отрицательной!");
                    SetValueForValidator();
                    // val = 1;
                }
            }
            catch
            {
                Console.WriteLine("Неправильное значение, попробуйте снова!");
                SetValueForValidator();
                val = 1;
            }
            return val;
        }
    }
}
