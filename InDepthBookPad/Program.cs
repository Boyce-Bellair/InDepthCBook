﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace InDepthBookPad
{
    class Program
    {

        //Our delegate
        public delegate bool FilterDelegate(Person p);
        


        static void Main(string[] args)
        {

        
        Product newProduct = new Product("Fleshpot on 42nd Street", 9.99m);
        Console.WriteLine(newProduct.ToString());
        //Create 4 Person objects
        Person p1 = new Person() { Name = "John", Age = 41 };
        Person p2 = new Person() { Name = "Jane", Age = 69 };
        Person p3 = new Person() { Name = "Jake", Age = 12 };
        Person p4 = new Person() { Name = "Jessie", Age = 25 };

            FilterDelegate myTest = new FilterDelegate(IsChild);
            FilterDelegate myTest2;
            myTest2 = IsChild;

            //Create a list of Person objects and fill it
            List<Person> people = new List<Person>() { p1, p2, p3, p4 };

        //Invoke DisplayPeople using appropriate delegate
        DisplayPeople("Children:", people, IsChild);
        DisplayPeople("Adults:", people, IsAdult);
        DisplayPeople("Seniors:", people, IsSenior);

        //testing my delegate experiments, not part of the example. 
        //shows there are three ways I know of can use delegates. 
        DisplayPeople("Children:", people, myTest);
        DisplayPeople("Children:", people, myTest2);


        Console.Read();
        }

        // <summary>
        /// A method to filter out the people you need
        /// </summary>
        /// <param name="people">A list of people</param>
        /// <param name="filter">A filter</param>
        /// <returns>A filtered list</returns>
        static void DisplayPeople(string title, List<Person> people, 
            FilterDelegate filter)
        {
            Console.WriteLine(title);

            foreach (Person p in people)
            {
                if (filter(p))
                {
                    Console.WriteLine("{0}, {1} years old", p.Name, p.Age);
                }
            }

            Console.Write("\n\n");
        }

        

        //==========FILTERS===================
        static bool IsChild(Person p)
        {
            return p.Age < 18;
        }

        static bool IsAdult(Person p)
        {
            return p.Age >= 18;
        }

        static bool IsSenior(Person p)
        {
            return p.Age >= 65;
        }

    }
}
