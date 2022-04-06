using System;
using System.Collections.Generic;

namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<object> newList = new List<object>();
            
            newList.Add(7);
            newList.Add(28);
            newList.Add(-1);
            newList.Add(true);
            newList.Add("chair");

            int sum = 0;
            foreach(object entry in newList)
            {
                // Console.WriteLine(entry);
                if (entry is int)
                {
                    
                    sum += (int)entry;
                    
                    
                }
            }
            Console.WriteLine(sum);    

        }
    }
}
