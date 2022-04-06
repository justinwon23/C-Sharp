using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray2 = {0,1,2,3,4,6,7,8,9};
            string[] nameArr = {"Tim", "Martin", "Nikki", "Sara"};
            bool[] alternatingBools = AlternatingBooleans();
            // Console.WriteLine(alternatingBools);
            // PrintDictionary();
            IceCream();
        }

        static bool[] AlternatingBooleans()
        {
            bool[] booleans = new bool[10];

            for (int i = 0; i < 10; i++)
            {
                bool isEven = i % 2 == 0;
                booleans[i] = isEven;
            }

            return booleans;
        }
        
        // static void PrintDictionary()
        // {
        //     Dictionary<string, string> favoriteIceCreamFlavors = new Dictionary<string, string>()
        //     {
        //         {"Justin", "Mint"},
        //         {"Grant", "Chocolate"},
        //         {"Joe", "Strawberry"},
        //         {"Felix", "Banana"},
        //         {"Henry", "Peach"}
        //     }
        //     ;

        //     foreach (KeyValuePair<string, string> entry in favoriteIceCreamFlavors)
        //     {
        //         Console.WriteLine($"{entry.Key}'s favorite ice cream is: {entry.Value}");
        //     }
        // }

        static void IceCream()
        {
            List<string> ice = new List<string>();
            ice.Add("Mint");
            ice.Add("Chocolate");
            ice.Add("Strawberry");
            ice.Add("Banana");
            ice.Add("Peach");

            Console.WriteLine($"We have {ice.Count} favorites");
            Console.WriteLine(ice[2]);
            ice.Remove(ice[2]);
            Console.WriteLine(ice[2]);
            Console.WriteLine($"We have {ice.Count} favorites");
            string[] nameArr = {"Tim", "Martin", "Nikki", "Sara"};
            Dictionary<string, string> iceCreamFlavors = new Dictionary<string, string>();
            foreach (string person in nameArr)
            {
                Random randFlavor = new Random();
                iceCreamFlavors.Add(person, ice[randFlavor.Next(ice.Count)]);
            }
            Console.WriteLine(iceCreamFlavors);
            foreach (KeyValuePair<string, string> entry in iceCreamFlavors)
            {
                Console.WriteLine($"{entry.Key}'s favorite flavor is {entry.Value}");
            }


        }
        

    }
}
