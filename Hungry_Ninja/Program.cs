using System;

namespace Hungry_Ninja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet CoolBuffet = new Buffet();

            Ninja Justin = new Ninja();
            Justin.Eat(CoolBuffet.Serve());
            Justin.Eat(CoolBuffet.Serve());
            Justin.Eat(CoolBuffet.Serve());
            Justin.Eat(CoolBuffet.Serve());
            Justin.Eat(CoolBuffet.Serve());
            Console.WriteLine(Justin.IsFull);

        }
    }
}
