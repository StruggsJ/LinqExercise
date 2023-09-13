using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers

            var totalSum = numbers.Sum();

            Console.WriteLine($"The sum of the numbers array is {totalSum}");
            Console.WriteLine("==============");

            //TODO: Print the Average of numbers

            var totalAverage = Math.Round(numbers.Average());

            Console.WriteLine($"The average of numbers from the numbers array is {totalAverage}.");
            Console.WriteLine("==============");

            //TODO: Order numbers in ascending order and print to the console

            var orderedAscend = numbers.OrderBy( x => x );
            Console.WriteLine("Numbers in ascending order:");
            Console.WriteLine("==============");

            foreach (var num in orderedAscend)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("==============");


            //TODO: Order numbers in descending order and print to the console

            var orderedDescend = numbers.OrderByDescending( x => x );
            Console.WriteLine("Numbers in descending order.");
           

            foreach (var num in orderedDescend)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("==============");

            //TODO: Print to the console only the numbers greater than 6

            var greaterSix = numbers.Where(x => x > 6);
            Console.WriteLine("Numbers that are greater than six:");
            

            foreach (var num in greaterSix)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("==============");




            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            // use .Take() - Linq

            var printFourDescend = numbers.OrderByDescending(numbers => numbers).Take(4);

            Console.WriteLine("In reverse order, showing only four numbers:");

            foreach (var num in printFourDescend)
            { 
                Console.WriteLine(num); 
            }


            Console.WriteLine("==============");


            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            // .SetValue(), have to set value into an variable to use; must use if want the order via value and not by index.

            var age = 33;

            numbers.SetValue(age, 4);
            var changedIndex = numbers.OrderByDescending(numbers=>numbers);

            Console.WriteLine("In descending order with index 4 replaced.");

            foreach (var num in changedIndex)
            {
                Console.WriteLine(num);
            }


            Console.WriteLine("==============");



            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            var filterFirstNameC = employees.Where(x => x.FirstName.StartsWith("C")).OrderBy(x => x.FullName);
            var filterFrstNameS = employees.Where(x => x.FirstName.StartsWith("S")).OrderBy (x => x.FullName);

            Console.WriteLine("Here are the employees with names beginning with the letter 'C' or 'S':");

            foreach (var num in filterFirstNameC)
            {
                Console.WriteLine(num.FullName);
            }

            foreach (var num in filterFrstNameS)
            {
                Console.WriteLine(num.FullName);
            }

            Console.WriteLine("==============");


            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            var filterAge = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).OrderBy(x => x.FirstName);

            Console.WriteLine("Here are the employees that are over the age of 26:");
            foreach (var num in filterAge)
            {
                Console.WriteLine($"Name: {num.FullName}, Age: {num.Age}");
            }

            Console.WriteLine("==============");

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            var employeeExperienceSum = employees.Where(x => x.Age > 35).Where(x => x.YearsOfExperience <= 10).Sum(x => x.YearsOfExperience);

            Console.WriteLine("The sum of years of experience from all employees over the age of 35 that has been working for ten years or less:");
            Console.WriteLine();
            Console.WriteLine(employeeExperienceSum);

            Console.WriteLine();
            Console.WriteLine();

            var employeeExperienceAverage = employees.Where(x => x.Age > 35).Where(x => x.YearsOfExperience <= 10).Average(x => x.YearsOfExperience);

            Console.WriteLine($"The average of years of experience from all employees over the age of 35 that has been working for ten years or less is:");
            Console.WriteLine();
            Console.WriteLine(Math.Round(employeeExperienceAverage));

            //TODO: Add an employee to the end of the list without using employees.Add() //.Apphend

            var newEmployee = new Employee
            {
                FirstName = "Jane",

                LastName = "Miles",

                Age = 25,

                YearsOfExperience = 0,
            };

            var addEmployee = employees.Append(newEmployee);

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
