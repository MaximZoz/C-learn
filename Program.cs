using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork
{
    struct Employee
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

            Employee[] employees = new Employee[quantity];

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
                employees[i].surname = Convert.ToString(Console.ReadLine());
                string surname = employees[i].surname;
                Console.WriteLine($"Введите зарплату сотрудника {surname}: ");

                employees[i].salaries = SetValueForValidator();
            }

            Console.WriteLine("как вы хотите отображать сотрудников?");
            Console.WriteLine("1 - сортировать по фамилии");
            Console.WriteLine("2 - сортировать по зарплате");
            Console.WriteLine("3 - показать тех у кого зарплата выше средней");
            Console.WriteLine("4 - показать тех у кого зарплата ниже средней");


            IEnumerable<Employee> resultEmployees = CallSortingMethod(employees);

            Console.WriteLine("N     |      Фамилия         | Зарплата |");
            Console.WriteLine("----------------------------------------");

            foreach (var item in resultEmployees.Select((value, i) => new { i, value }))
            {
                var value = item.value;
                var index = item.i;

                Console
                    .WriteLine($"{index + 1,-5} | " +
                    $"{value.surname,-20}" +
                    " | " +
                    $"{value.salaries,-8}" +
                    " | ");
                Console.WriteLine("----------------------------------------");
            }


        }

        static IEnumerable<Employee> CallSortingMethod(Employee[] employees)
        {
            IEnumerable<Employee> resultEmployees;
            byte num;
            float averageSalaries = employees.Sum(e => (float)e.salaries) / employees.Length;
            try
            {
                num = Convert.ToByte(Console.ReadLine());
            }
            catch
            {
                num = 5;
            }
            switch (num)
            {
                case (byte)SortName.Alphabet: //!" сортировать по фамилии"
                    resultEmployees = employees.OrderBy(e => e.surname);
                    break;
                case (byte)SortName.Salary: //!" сортировать по зарплате"
                    resultEmployees = employees.OrderBy(e => -e.salaries);
                    break;
                case (byte)SortName.SalaryMoreAverage: //!" сортировать по зарплате выше среднего"

                    resultEmployees = employees.Where(e => e.salaries > averageSalaries).OrderBy(e => -e.salaries);

                    break;
                case (byte)SortName.SalaryLessAverage: //!"сортировать по зарплате ниже среднего"
                    resultEmployees = employees.Where(e => e.salaries < averageSalaries).OrderBy(e => e.salaries);
                    break;
                default:
                    Console.WriteLine("неправильно, попробуйте снова");
                    resultEmployees = employees.OrderBy(e => e.salaries);
                    CallSortingMethod(employees);
                    break;
            }

            return resultEmployees;
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
