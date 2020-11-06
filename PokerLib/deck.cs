using System.Collections.Generic;
using System;
namespace Poker.Lib
{

    public class Deck
    {
        private List<Card> deck;

        const int Decksize = 52;
        private static Random rng = new Random();

        public Deck()
        {
            this.deck = new List<Card>(Decksize);

            foreach (Suite s in Suite.GetValues(typeof(Suite)))
            {
                foreach (Rank r in Rank.GetValues(typeof(Rank)))
                {
                    Card CardInfo = new Card(s, r);
                    deck.Add(CardInfo);

                }
            }


        }

        public void Shuffle()
        {
            int i = this.deck.Count;
            while (i > 0)
            {
                i--;
                int k = rng.Next(deck.Count);
                Card value = deck[k];
                deck[k] = deck[i];
                deck[i] = value;
            }


        }
        public Card Drawcard()
        {
            if (!(deck.Count > 0))
            {
                return null;
            }
            Card topCard = deck[deck.Count - 1];
            deck.RemoveAt(deck.Count - 1);
            return topCard;

        }
        public Card [] Drawcards(int cardAmount)
        {
            Card [] cards = new Card[cardAmount]; 
            for (int i = 0; i < cardAmount; i++)
            {
                cards[i] = Drawcard();
                
            }
            return cards;

        }
        public void InsertCard(Card ReturnCard)
        {

            deck.Add(ReturnCard);

        }

    }
}