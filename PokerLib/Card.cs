namespace Poker.Lib
{
    public class Card : ICard
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
    }
}