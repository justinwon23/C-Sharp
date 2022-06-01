using System;

namespace Cards 
{
    public class Card
    {
        public string Name {get; set;}
        public string Suit {get; set;}

        public int Val {get; set;}

        public Card (string name, string suit, int val)
        {
            Name = name;
            Suit = suit;
            Val = val;

        }

        public void Print ()
        {
            Console.WriteLine($"Name: {this.Name}, Suit: {this.Suit}, Value: {this.Val}");
        }

    }

}




















