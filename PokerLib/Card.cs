using System;

namespace Poker.Lib
{
    public class Card : ICard,IComparable
    {
        public Suite Suite 
        {
        get ; 
        private set;
        }
        public Rank Rank
        {
            get; 
            private set;
        }
        public Card(Suite suite, Rank rank)
        {
           Suite = suite;
           Rank = rank;

        }

        public int CompareTo(object obj)
        {
            if(obj is Card card)
            {
               if (this.Rank < card.Rank ||(this.Rank == card.Rank && this.Suite < card.Suite)) 
               {
                   return -1;
               } else if (this.Rank == card.Rank && this.Suite == card.Suite)
               {
                   return 0;
               } else
               {
                   return 1;
               }              
                
            }
            throw new NotImplementedException();
        }
    }
}