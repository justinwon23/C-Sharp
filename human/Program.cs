using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Human Justin = new Human("Justin");
            Console.WriteLine(Justin.Strength);
        }
    }

//     class Human
// {
//     // Fields for Human
//     public string Name { get; set; }
//     public int Strength { get; set; }
    
//     public int Intelligence { get; set; }
//     public int Dexterity { get; set; }
//     private int Health { get; set; }

//     public Human (string name)
//     {
//         Name = name;
//         Strength = 3;
//         Intelligence = 3;
//         Dexterity = 3;
//         Health  = 100;
//     }

//     public Human (string name, int strength, int intelligence, int dexterity, int health)
//     {
//         Name = name;
//         Strength = strength;
//         Intelligence = intelligence;
//         Dexterity = dexterity;
//         Health = health;
//     }
     
//     public int Attack(Human target)
//     {
//         target.Health = target.Health - this.Strength * 5;
//         return target.Health;
//     }
// }
}
