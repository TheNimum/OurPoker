using System.Collections.Generic;
using System.Linq;

namespace Poker.Lib
{
    public class Dealer
    {

        private Player[] Hand;

        private Deck deck { get; set; }

        public Dealer()
        {
            deck = new Deck();
        }

        public void DealCards(Player[] players)
        {
            deck.Shuffle();


            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    Card[] drawncards = new Card[1];
                    drawncards[0] = deck.Drawcard();
                    players[i].PutToHand(drawncards);
                }
            }


        }
        public void newCards()
        {
            deck.Drawcard();
        }
        public void CollectCards(Player[] players)
        {
            foreach (Player player in players)
            {

                foreach (Card card in player.GiveBackHand())
                {
                    deck.InsertCard(card);
                }
            }
            while (Graveyard.CardLimit > 0)
            {
                deck.InsertCard(Graveyard.takeCard());

            }




        }
        /*public Player[] Playerwithbesthand(Player[] players)
        {
            var sortedPlayers = players.OrderByDescending(player => player.Hand);
            
            foreach (Player player in players)
            {
                player.InspectCards();
            
            }

            return players;

        }*/
    }
}