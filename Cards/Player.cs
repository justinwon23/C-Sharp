using System;
using System.Collections.Generic;

namespace Cards
{
    public class Player
    {
        public string Name {get; set;}
        public List<Card> Hand {get; set;} = new List<Card>();

        public Player (string name)
        {
            Name = name;
        }

        public Card Draw(Deck deck)
        {
            Card dealtCard = deck.TopMost();
            if (dealtCard != null)
            {
                Hand.Add(dealtCard);
            }
            return dealtCard;
            
            
        }

        public Card Discard(int i)
        {
            if (i < 0 || i > Hand.Count)
            {
                return null;
            }

            else
            {
                Card CardToDrop = Hand[i];
                Hand.Remove(CardToDrop);
                return CardToDrop;
            }
        }


    }





}


























