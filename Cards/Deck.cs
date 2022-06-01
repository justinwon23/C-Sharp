using System;
using System.Collections.Generic;

namespace Cards
{

    public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public Deck()
        {

            Reset();
        }



        public Deck Reset()
        {

            Cards = new List<Card>();

            string[] suits =
            {
                "Hearts",
                "Diamonds",
                "Spades",
                "Clubs"
            };

            Dictionary<int, string> faceCardNames = new Dictionary<int, string>()
            {
                { 1, "Ace" },
                { 11, "Jack" },
                { 12, "Queen" },
                { 13, "King" }
            };

            foreach (string suit in suits)
            {
                for (int i = 1; i < 14; i++)
                {
                    string name = i.ToString();

                    if (faceCardNames.ContainsKey(i))
                    {
                        name = faceCardNames[i];
                    }

                    Card card = new Card(name, suit, i);
                    Cards.Add(card);
                }
            }

            return this;
        }

        public Card TopMost()
        {
            if (Cards.Count > 0)
            {
                int length = this.Cards.Count;
                Card topCard = Cards[Cards.Count - 1];
                this.Cards.RemoveAt(length - 1);
                // Console.WriteLine(topCard.Name);
                // Console.WriteLine(topCard.Suit);
                return topCard;
            }
            else
            {
                return null;
            }
        }

        public Deck Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                int randomCard = random.Next(Cards.Count);
                Card temp = Cards[i];
                Cards[i] = Cards[randomCard];
                Cards[randomCard] = temp;
            }

            return this;
        }





    }



}



