using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Shopping_Spree
{
    public class Person
    {
        public string Name { get; set; }

        public double Money { get; set; }

        public List<string> BoughtProducts { get; set; }

        public Person(string name, double money, List<string> list)
        {
            this.Name = name;
            this.Money = money;
            this.BoughtProducts = list;
        }

    }

    public class Product
    {
        public string Name { get; set; }
        public double Cost { get; set; }

        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
    }
    class Program
    {
        static int GetPersonIndex(List<Person> persons, string name)
        {
            int index = 0;
            for (int i = 0; i < persons.Count; i++)
            {
                string currPerson = persons[i].Name;
                if (currPerson == name)
                {
                    index = i;
                }
            }
            return index;
        }

        static int GetProductIndex(List<Product> product, string name)
        {
            int index = 0;
            for (int i = 0; i < product.Count; i++)
            {
                string currProduct = product[i].Name;
                if (currProduct == name)
                {
                    index = i;
                }
            }
            return index;
        }

        static void Main()
        {
            string[] infoAllPersons = Console.ReadLine().Split(";");
            List<Person> listOfPeson = new List<Person>();

            for (int i = 0; i < infoAllPersons.Length; i++)
            {
                string[] currPeople = infoAllPersons[i].Split("=");

                string currPeopleName = currPeople[0];
                double currPeopleMoney = double.Parse(currPeople[1]);
                List<string> currList = new List<string>();

                Person newPerson = new Person(currPeopleName, currPeopleMoney, currList);
                listOfPeson.Add(newPerson);
            }

            string[] infoAllProducts = Console.ReadLine().Split(";");
            List<Product> listOfProducts = new List<Product>();

            for (int j = 0; j < infoAllPersons.Length; j++)
            {
                string[] currProduct = infoAllProducts[j].Split("=");

                string currProductName = currProduct[0];
                double currProductCost = double.Parse(currProduct[1]);

                Product newProduct = new Product(currProductName, currProductCost);
                listOfProducts.Add(newProduct);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] command = input.Split();
                string personName = command[0];
                string productName = command[1];

                int PersonIndex = GetPersonIndex(listOfPeson, personName);
                int ProductIndex = GetProductIndex(listOfProducts, productName);

                double cost = listOfProducts[ProductIndex].Cost;
                double check = listOfPeson[PersonIndex].Money - cost;

                if (check <= 0)
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                    continue;
                }
                else
                {
                    Console.WriteLine($"{personName} bought {productName}");
                    double personMoney = listOfPeson[PersonIndex].Money;
                    listOfPeson[PersonIndex].Money = personMoney - cost;
                    listOfPeson[PersonIndex].BoughtProducts.Add(productName);
                }
            }
            foreach (Person person in listOfPeson)
            {
                if (person.BoughtProducts.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.BoughtProducts)}");
                }
            }
        }
    }
}

