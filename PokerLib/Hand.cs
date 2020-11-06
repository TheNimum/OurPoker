using System.Collections.Generic;
using System.Linq;

namespace Poker.Lib
{

    public class Hand
    {
        public Card[] Cards { get { return cards.ToArray(); } }

        HandType handType { get; set; }
        public List<Card> cards;


        public Hand()
        {
            cards = new List<Card>();

        }
        public int compareTo(Hand hand)
        {

            SortHand(hand);

            return 0;
        }
        public void SortHand(Hand hand)
        {
            
            cards = hand.Cards.OrderBy(card => card.Rank).ThenBy(card => card.Suite).ToList();
        
        }
        public void AddCard(Card card)
        {
            cards.Add(card);

        }
        public void DiscardCard(Card card)
        {
            cards.Remove(card);
        }
        public void Handtype_compare(Hand hand)
        {
            foreach(Card card in hand.Cards)
            {
             

            }
           
        }

    }
}