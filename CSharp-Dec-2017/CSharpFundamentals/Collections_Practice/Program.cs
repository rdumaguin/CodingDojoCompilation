using System;
using System.Collections.Generic;

namespace Collections_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // Create an array to hold integer values 0 through 9
            int[] numArr = new int[] {0,1,2,3,4,5,6,7,8,9};
            for(int i = 0; i < numArr.Length; i++)
            {
                Console.WriteLine(numArr[i]);
            }

            // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] nameArr = new string[] {"Tim", "Martin", "Nikki", "Sara"};
            for(int i = 0; i < nameArr.Length; i++)
            {
                Console.WriteLine(nameArr[i]);
            }

            // Create an array of length 10 that alternates between true and false values, starting with true            
            bool[] boolArr = new bool[10];
            for(int i = 0; i < boolArr.Length; i += 2)
            {
                boolArr[i] = true;
            }
            for(int i = 0; i < boolArr.Length; i++)
            {
                Console.WriteLine(boolArr[i]);
            }

            // With the values 1-10, use code to generate a multiplication table
            // Use a multidimensional array to store all values
            int[,] multArr = new int[10,10];
            for(int x = 0; x < 10; x++)
            {
                for(int y = 0; y < 10; y++)
                {
                    multArr[x,y] = (x + 1) * (y + 1);
                    // Console.WriteLine(multArr[x,y]);
                }
            }

            // Code to format the multiplication table
            for(int x = 0; x < 10; x++)
            {
                string multTable = "[ ";
                for(int y = 0; y < 10; y++)
                {
                    
                    multTable += multArr[x,y];
                    if(multArr[x,y] < 100)
                    {
                        multTable += ", ";
                    }
                    else
                    {
                         multTable += " "; // Removes last comma in the table
                    }
                    if(multArr[x,y] < 10)
                    {
                        multTable += " "; // Adds an extra space for single integers
                    }
                }
                multTable += "]";
                Console.WriteLine(multTable);
            }

            // Create a list of Ice Cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
            List<string> ice_cream_flavors = new List<string>();
            ice_cream_flavors.Add("Vanilla");
            ice_cream_flavors.Add("Chocolate");
            ice_cream_flavors.Add("Strawberry");
            ice_cream_flavors.Add("Green Tea");
            ice_cream_flavors.Add("Mango");
            
            for(int i = 0; i < ice_cream_flavors.Count; i++)
            {
                Console.WriteLine(ice_cream_flavors[i]);
            }

            // Output the length of this list after building it
            Console.WriteLine(ice_cream_flavors.Count);

            // Output the third flavor in the list, then remove this value.
            Console.WriteLine(ice_cream_flavors[2]);
            ice_cream_flavors.RemoveAt(2);
            
            // Output the new length of the list (Note it should just be one less~)
            Console.WriteLine(ice_cream_flavors.Count);

            // Create a Dictionary that will store both string keys as well as string values
            Dictionary<string,string> myDict = new Dictionary<string,string>();
            
            // For each name in the array of names you made previously, add it as a new key in this dictionary with value null
                for(int i = 0; i < nameArr.Length; i++)
                {
                    myDict.Add(nameArr[i], null);
                }
            
            // Loop through the Dictionary and print out each user's name and their associated ice cream flavor.
            foreach (KeyValuePair<string,string> entry in myDict)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }

            // For each name key, select a random flavor from the flavor list above and store it as the value
            Random rand = new Random();
            foreach(string name in nameArr)
                {
                    myDict[name] = ice_cream_flavors[rand.Next(ice_cream_flavors.Count)];
                }

            // Loop through the Dictionary and print out each user's name and their associated ice cream flavor.
            foreach (KeyValuePair<string,string> entry in myDict)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
