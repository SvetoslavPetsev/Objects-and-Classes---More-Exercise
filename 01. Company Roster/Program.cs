using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Company_Roster
{
    public class Employes
    { 
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

        public Employes (string name, double salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }
    
    }
    class Program
    {
        static string GetMaxAverangeSalaryDepartment (List<Employes> listOfPeople)
        {
            string maxSalaryDep = listOfPeople[0].Department;
            double maxAverangeSalary = 0;

            for (int i = 0; i < listOfPeople.Count; i++)
            {
                string currDepartment = listOfPeople[i].Department;
                int counter = 0;
                double sumOfSalary = 0;
                for (int j = 0; j < listOfPeople.Count; j++)
                {
                    if (currDepartment == listOfPeople[j].Department)
                    {
                        counter++;
                        sumOfSalary += listOfPeople[j].Salary;
                    }
                }
                double averangeSalary = sumOfSalary / counter;
                if (averangeSalary > maxAverangeSalary)
                {
                    maxAverangeSalary = averangeSalary;
                    maxSalaryDep = currDepartment;
                }
            }

            return maxSalaryDep;
        }
        static void Main()
        {
            List<Employes> listOfPeople = new List<Employes>();
            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] input = Console.ReadLine().Split();

                string currName = input[0];
                double currSalary = double.Parse(input[1]);
                string currDepartment = input[2];

                Employes newPeople = new Employes(currName, currSalary, currDepartment);
                listOfPeople.Add(newPeople);
            }

            string hightSalaryDep = GetMaxAverangeSalaryDepartment(listOfPeople);
            List<Employes> hightSalaryPeople = new List<Employes>();

            for (int i = 0; i < listOfPeople.Count; i++)
            {
                Employes currpeople = listOfPeople[i];

                if (currpeople.Department == hightSalaryDep)
                {
                    hightSalaryPeople.Add(currpeople);
                }
            }
            hightSalaryPeople = hightSalaryPeople.OrderByDescending(x => x.Salary).ToList();
            Console.WriteLine($"Highest Average Salary: {hightSalaryDep}");
            foreach (var people in hightSalaryPeople)
            {
                Console.WriteLine($"{people.Name} {people.Salary:F2}");
            }
        }
    }
}
