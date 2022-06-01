using System;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Card King_of_Spades = new Card("King", "Spades", 13);
            Deck NewDeck = new Deck();
            Player Justin = new Player("Justin");
            // Console.Write("Hello  World");
            NewDeck.Shuffle();
            Justin.Draw(NewDeck);
            Justin.Draw(NewDeck);
            Justin.Draw(NewDeck);
            Justin.Draw(NewDeck);
            Justin.Draw(NewDeck);
            Console.WriteLine(Justin.Hand[0].Name);
            Console.WriteLine(Justin.Hand[0].Suit);
            Console.WriteLine(Justin.Hand[1].Name);
            Console.WriteLine(Justin.Hand[1].Suit);
            Console.WriteLine(Justin.Hand[2].Name);
            Console.WriteLine(Justin.Hand[2].Suit);
            Console.WriteLine(Justin.Hand[3].Name);
            Console.WriteLine(Justin.Hand[3].Suit);
            Console.WriteLine(Justin.Hand[4].Name);
            Console.WriteLine(Justin.Hand[4].Suit);
            Justin.Discard(0);
            Console.WriteLine($" This is the new zero index card{Justin.Hand[0].Name} {Justin.Hand[0].Suit}");
            Console.WriteLine(Justin.Hand[0].Suit);
            Justin.Discard(0);
            Justin.Discard(0);

            
            
            
            


        }
    }
}
