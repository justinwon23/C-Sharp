using System;

namespace FundamentalsI
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <=255; i++){
                Console.WriteLine(i);
            }
            MultipliesOf3Or5();
            FizzBuzz();
        }

        static void MultipliesOf3Or5(int start = 1, int end =100)
        {
            for (int i = start; i <= end; i ++)
            {
                bool divisibleBy3 = i % 3 == 0;
                bool divisibleby5 = i % 5 ==0;
                bool divisibleByBoth = divisibleBy3 && divisibleby5;

                if (divisibleByBoth == false && (divisibleBy3 || divisibleby5))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void  FizzBuzz (int start = 1, int end = 100)
        {
            for (int i = start; i <= end; i++)
            {
                bool divisibleBy3 = i % 3 == 0;
                bool divisibleby5 = i % 5 ==0;
                bool divisibleByBoth = divisibleBy3 && divisibleby5;

                if (divisibleBy3 && !divisibleByBoth)
                {
                    // Console.WriteLine("Fizz");
                    Console.WriteLine($"{i} Fizz");
                }

                if (divisibleby5 && !divisibleByBoth)
                {
                    // Console.WriteLine("Buzz");
                    Console.WriteLine($"{i} Buzz");
                }

                if (divisibleBy3 && divisibleby5)
                {
                    // Console.WriteLine("FizzBuzz");
                    Console.WriteLine($"{i} FizzBuzz");
                }
            }
        }    


    }
}
