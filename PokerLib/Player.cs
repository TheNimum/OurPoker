using System.Collections.Generic;
using System.Linq;
namespace Poker.Lib
{

    public class Player : IPlayer
    {
        private Hand hand = new Hand();

        public Hand Hand => hand;
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
            get { return hand.handType; }

        }
        public int wins = 0;
        public int Wins
        {
            get => wins;
        }
        public ICard[] Discard
        {
            get;
            set;
        }
        public Player(string name, int wins)
        {
            Name = name;
            this.wins = wins;

        }

        public void PutToHand(Card[] cards)
        {

            foreach (Card card in cards)
            {
                hand.AddCard(card);
            }
            

        }
        public int InspectCards(Hand otherHand)
        {

            return hand.compareTo(otherHand);

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
        
        public Card[] GiveBackHand()
        {
            Card[] removedCards = (Card[])hand.Cards.Clone(); //skapar en klon av cards till något.
            foreach (Card card in hand.Cards)
            {
                hand.DiscardCard(card);
            }
            return removedCards;
        }
    }

}