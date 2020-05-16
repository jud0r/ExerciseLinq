using ExerciseLinq.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ExerciseLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            List<Employee> employees = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2],CultureInfo.InvariantCulture);
                    employees.Add(new Employee(name, email, salary));
                }
            }

            Console.Write("Enter salary: ");
            double sal = double.Parse(Console.ReadLine());
            Console.WriteLine("Email of people whose salary is more than " + sal.ToString("F2", CultureInfo.InvariantCulture) + ":");

            var emails = employees.Where(e => e.Salary > sal).Select(e => e.Email);
            foreach(string email in emails)
            {
                Console.WriteLine(email);
            }
            var sumM = employees.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);
            Console.WriteLine();
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sumM.ToString("F2", CultureInfo.InvariantCulture));
            
        }
    }
}
