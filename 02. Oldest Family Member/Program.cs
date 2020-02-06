using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Oldest_Family_Member
{
    public class Family
    {
        public List<Person> ListOfPeople = new List<Person>();
        public Family(List<Person> listOfPeople)
        {
            this.ListOfPeople = listOfPeople;
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }

    class Program
    {

        public static Family AddMember(Family name, Person memeber)
        {
            name.ListOfPeople.Add(memeber);
            return name;
        }
        public static string GetOldestMember(Family name)
        {
            int oldestPersonAge = name.ListOfPeople[0].Age;
            string oldestPersonName = name.ListOfPeople[0].Name;

            for (int i = 0; i < name.ListOfPeople.Count; i++)
            {
                int currPeopleAge = name.ListOfPeople[i].Age;
                string currPeopleName = name.ListOfPeople[i].Name;

                if (currPeopleAge > oldestPersonAge)
                {
                    oldestPersonAge = currPeopleAge;
                    oldestPersonName = currPeopleName;
                }
            }

            return oldestPersonName;
        }
        static void Main()
        {
            int numberOFPeople = int.Parse(Console.ReadLine());
            List<Person> list = new List<Person>();
            Family newFamily = new Family(list);

            for (int i = 0; i < numberOFPeople; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();

                string name = inputInfo[0];
                int age = int.Parse(inputInfo[1]);

                Person newPerson = new Person(name, age);
                newFamily = AddMember(newFamily, newPerson);

            }

            string oldest = GetOldestMember(newFamily);
            int oldestAge = 0;
            foreach (Person curr in newFamily.ListOfPeople)
            {
                if (curr.Name == oldest)
                {
                    oldestAge = curr.Age;
                }
            }

            Console.WriteLine($"{oldest} {oldestAge}");
        }
    }
}
