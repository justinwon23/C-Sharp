using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // RandomArray();
            // TossCoin();
            // TossMultipleCoins(2);
            Names();
        }


        
        static void RandomArray()
        {
            List<int> randomList = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                randomList.Add(rand.Next(5, 25));
            }

            int[] numArray = randomList.ToArray();
            foreach(int val in randomList)
            {
                Console.WriteLine(val);
            }

            int max = numArray[0];
            int min = numArray[0];
            int sum = numArray[0];

            for (int i = 0; i < numArray.Length; i++)
            {
                if (numArray[i] > max)
                {
                    max = numArray[i];
                }

                if (numArray[i] < min)
                {
                    min = numArray[i];
                }

                sum += numArray[i];
            }
            Console.Write($" max is {max}. min is {min}. sum is {sum}");
        }

        static int TossCoin()
        {
            Console.WriteLine("Tossing a Coin");
            Random rand = new Random();
            int Coin = rand.Next(1,3);
            Console.WriteLine(Coin);
            if (Coin == 1)
            {
                // Console.WriteLine("Heads");
            }
            else
            {
                // Console.WriteLine("Tails");
            }
            return Coin;
        }

        static double TossMultipleCoins(int num)
        {
            double result = 0;
            int heads = 0;
            for (int i = 1; i <= num; i++)
            {
                
                if (TossCoin() == (int)1)
                {
                    heads++;
                }
            }
            result = (double)heads / (double)num;
            Console.WriteLine(result);
            // Console.WriteLine(heads);
            return result;
        }

        static List<string> Names()
        {
            List<string> nameList = new List<string>();
            nameList.Add("Todd");
            nameList.Add("Tiffany");
            nameList.Add("Charlie");
            nameList.Add("Geneva");
            nameList.Add("Sydney");
            Console.Write(nameList);
            List<string> randNames = new List<string>();

            for (int i = 0; i <5; i++)            
            {
            Random rand = new Random();
            int idx = rand.Next(0, nameList.Count);
            randNames.Add(nameList[idx]);
            nameList.RemoveAt(idx);
            Console.WriteLine(randNames[i]);
            }
            
            for (int i = 0; i < randNames.Count; i++)
            {
                if (randNames[i].Length < 5)
                {
                    randNames.RemoveAt(i);
                }
            }
            
            for (int i = 0; i < randNames.Count; i++)
            {
                Console.WriteLine(randNames[i]);
            }

            return randNames;

            
            

        }
                
            
        

    }
}
