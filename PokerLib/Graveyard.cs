using System.Collections.Generic;

namespace Poker.Lib
{

    public class Graveyard
    {
           static public List<Card> cards = new List<Card>();
       static public int CardLimit { get { return cards.Count; } }
       
       static public void CardCollector(Card card)
        {
            cards.Add(card);

        }
      static  public Card takeCard()  
        {
            Card cardToRemove = cards[cards.Count - 1];
            cards.Remove(cardToRemove);
            return cardToRemove;

        }


    }

}
