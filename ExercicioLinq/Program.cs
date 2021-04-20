using System;
using System.Globalization;
using System.IO;
using System.Linq;
using ExercicioLinq.Entities;
using System.Collections.Generic;

namespace ExercicioLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter Salary: ");
            double compSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            List<Employee> list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);

                    list.Add(new Employee(name, email, salary));
                }
            }

            var emails = list.Where(e => e.Salary > compSalary).OrderBy(e => e.email).Select(e => e.email);

            Console.WriteLine();
            Console.WriteLine("Email of people whose salary is more than $ 2000.00: ");
            Console.WriteLine();

            foreach (string s in emails)
            {
                Console.WriteLine(s);
            }

            double sum = list.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);
            Console.WriteLine();
            Console.WriteLine("Sum of salary of people whose name starts with 'M': $ " + sum.ToString("F2", CultureInfo.InvariantCulture)); ;
        }
    }
}
