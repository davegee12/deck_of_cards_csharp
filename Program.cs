using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Player dave = new Player("Dave");
            Deck fivetwo = new Deck();
            fivetwo.reset();
            fivetwo.shuffle();
            dave.showHand();
            dave.draw(fivetwo);
            dave.draw(fivetwo);
            dave.draw(fivetwo);
            dave.draw(fivetwo);
            dave.draw(fivetwo);
            dave.showHand();
            dave.discard(2);
            dave.showHand();
        }
    }
    class Card
    {
        public string stringVal;
        public string suit;
        public int val;
        public Card(string s, string strVal, int value)
        {
            suit = s;
            stringVal = strVal;
            val = value;
        }
    }
    class Deck
    {
        public List<Card> cards = new List<Card>();
        public string[] suits =
        {
            "Hearts",
            "Clubs",
            "Diamonds",
            "Spades"
        };
        public string[] stringValues =
        {
            "Ace",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
            "Ten",
            "Jack",
            "Queen",
            "King"
        };
        public Deck()
        {
            for (var j = 0; j < suits.Length; j++)
            {
                for (var i = 0; i < stringValues.Length; i++)
                {
                    Card card = new Card(suits[j], stringValues[i], i + 1);
                    cards.Add(card);
                }
            }
        }
        public Card deal()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
        public List<Card> reset()
        {
            if(cards.Count > 0)
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    Card x = cards[i];
                    cards.Remove(x);
                }
            }

            for (var j = 0; j < suits.Length; j++)
            {
                for (var i = 0; i < stringValues.Length; i++)
                {
                    Card card = new Card(suits[j], stringValues[i], i + 1);
                    cards.Add(card);
                }
            }
            return cards;
        }
        public List<Card> shuffle()
        {
            Random rand = new Random();
            for(var i = 0; i < cards.Count; i++)
            {
                int r = rand.Next(cards.Count);
                Card temp = cards[i];
                cards[i] = cards[r];
                cards[r] = temp;
            }
            return cards;
        }
    }
    class Player
    {
        public string Name;
        public List<Card> Hand = new List<Card>();
        public Player(string name)
        {
            Name = name;
        }
        public Card draw(Deck deck)
        {
            Card card = deck.deal();
            Hand.Add(card);
            return card;
        }
        public void discard(int idx)
        {
            if(Hand.Count > 0)
            {
                Card card = Hand[idx];
                Hand.Remove(card);
                foreach (Card x in Hand)
                {
                    Console.WriteLine(x);
                }
            }
            else
            {
                Console.WriteLine($"{Name}'s hand is empty! Nothing to discard!");
            }
        }
        public void showHand()
        {
            foreach (Card card in Hand)
            {
                Console.WriteLine("Suit: " +card.suit+ " Value: " +card.stringVal+ "/" +card.val);
            }
        }
    }
}
