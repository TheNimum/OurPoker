using System.Collections.Generic;
using System.Linq;
namespace Poker.Lib
{

    public class Player : IPlayer
    {
        private Hand hand = new Hand(); 
        


        public string Name
        {
            get;
            private set;
        }
         ICard[] IPlayer.Hand
        {
            get => hand.Cards;
            
            
        }
        public HandType HandType
        {
            get;
            private set;
        }
        public int Wins
        {
            get;
            private set;
        }
        public ICard[] Discard
        {
            get;
            set;
        }
        public Player(string name, int wins)
        {
            Name = name;
            Wins = wins;
            
        }

        public void PutToHand(Card[] cards)
        {

            foreach (Card card in cards)
            {
                hand.AddCard(card);
            }

        }
        public void InspectCards()
        {
             

        }
        public int MakeaMove()
        {
            int discardAmount = 0;

            foreach (Card card in Discard)
            {
                hand.DiscardCard(card);
                Graveyard.CardCollector(card);
                discardAmount++;
            }
            Discard = new Card[0];

            return discardAmount;
        }
        public void Showdown()
        {
            

        }
        public Card[] GiveBackHand()
        {
            Card[] removedCards = (Card[])hand.Cards.Clone(); //skapar en klon av cards till något.
            foreach(Card card in hand.Cards)
            {
                hand.DiscardCard(card);
            }
            return removedCards;
        }
    }

}