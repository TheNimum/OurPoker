using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Lib
{

    public class Hand : IComparable
    {

        public Card[] Cards { get { return cards.ToArray(); } }

        public HandType handType { get; set; }
        public List<Card> cards;


        public Hand()
        {
            cards = new List<Card>();

        }
        public int compareTo(Hand hand)
        {
            
            cards.Sort();
                       
            EvaluateHand();
            CompareTo(hand);
            return CompareTo(hand);

        }
        
        public int CompareHighCard(Hand hand)
        {
            for (int i = 4; i >= 0; --i)
            {
                if (this.Cards[i].Rank < hand.Cards[i].Rank)
                {
                    return -1;
                }
                else if (this.Cards[i].Rank > hand.Cards[i].Rank)
                {
                    return 1;
                }
            }
            return 0;
        }
        public int CompareTo(object obj)
        {
            if (obj is Hand hand)
            {
                if (this.handType < hand.handType)
                {
                    return -1;
                }
                else if (this.handType == hand.handType)
                {
                    switch (this.handType)
                    {
                        case HandType.HighCard:
                            return CompareHighCard(hand);


                        case HandType.Pair:
                            Rank thisHandPairRank = 0;
                            Rank otherHandPairRank = 0;
                            for (int i = 1; i < 5; i++)
                            {
                                if (this.Cards[i].Rank == this.Cards[i - 1].Rank)
                                {
                                    thisHandPairRank = Cards[i].Rank;
                                }
                            }
                            for (int i = 1; i < 5; i++)
                            {
                                if (hand.Cards[i].Rank == hand.Cards[i - 1].Rank)
                                {
                                    otherHandPairRank = Cards[i].Rank;
                                }

                            }
                            if (thisHandPairRank < otherHandPairRank)
                            {
                                return -1;
                            }
                            else if (thisHandPairRank > otherHandPairRank)
                            {
                                return 1;
                            }
                            else
                            {
                                return CompareHighCard(hand);
                            }



                        case HandType.TwoPairs: 
                            {
                                thisHandPairRank = 0;
                                Rank thisHandPairRankHighest = 0;
                                
                                otherHandPairRank = 0;
                                Rank otherHandPairRankHighest = 0;
                                

                                for (int i = 1; i < 4; i++)
                                {
                                    if (hand.Cards[i].Rank == hand.Cards[i - 1].Rank)
                                    {
                                        thisHandPairRank = Cards[i].Rank;
                                        
                                    }
                                }
                                for (int i = 3; i <= 0; --i)
                                {
                                    if (hand.Cards[i].Rank == hand.Cards[i + 1].Rank)
                                    {
                                        thisHandPairRank = Cards[i].Rank;
                                        
                                    }
                                }
                                
                                
                                for (int i = 1; i < 4; i++)
                                {
                                    if (hand.Cards[i].Rank == hand.Cards[i - 1].Rank)
                                    {
                                        thisHandPairRankHighest = Cards[i].Rank;
                                        
                                    }
                                }
                                for (int i = 3; i >= 0; --i) 
                                {
                                    if (hand.Cards[i].Rank == hand.Cards[i + 1].Rank)
                                    {
                                        otherHandPairRankHighest = Cards[i].Rank;
                                    }
                                }
                                
                                

                                if (thisHandPairRankHighest < otherHandPairRankHighest || (thisHandPairRankHighest == otherHandPairRankHighest && thisHandPairRank < otherHandPairRank))
                                {
                                    return -1;
                                }
                                if (thisHandPairRank > otherHandPairRank ||(thisHandPairRank == otherHandPairRankHighest && thisHandPairRank > otherHandPairRank))
                                {
                                    return 1;
                                }
                                else
                                {
                                    return CompareHighCard(hand);
                                }
                            }
                        case HandType.ThreeOfAKind:
                            {
                                thisHandPairRank = 0;
                                otherHandPairRank = 0;

                                for (int i = 3; i < 5; i++)
                                {
                                    if (this.Cards[i].Rank == this.Cards[i - 2].Rank)
                                    {
                                        thisHandPairRank = Cards[i].Rank;
                                    }
                                }
                                for (int i = 3; i < 5; i++)
                                {
                                    if (hand.Cards[i].Rank == hand.Cards[i - 2].Rank)
                                    {
                                        otherHandPairRank = Cards[i].Rank;
                                    }
                                }
                                if (thisHandPairRank < otherHandPairRank)
                                {
                                    return -1;
                                }
                                else if (thisHandPairRank > otherHandPairRank)
                                {
                                    return 1;
                                }
                                else
                                {
                                    return CompareHighCard(hand);
                                }

                            }
                        case HandType.FourOfAKind:
                            {
                                thisHandPairRank = 0;
                                otherHandPairRank = 0;

                                for (int i = 4; i < 5; i++)
                                {
                                    if (this.Cards[i].Rank == this.Cards[i - 4].Rank)
                                    {
                                        thisHandPairRank = Cards[i].Rank;
                                    }
                                }
                                for (int i = 4; i < 5; i++)
                                {
                                    if (hand.Cards[i].Rank == hand.Cards[i - 4].Rank)
                                    {
                                        otherHandPairRank = Cards[i].Rank;
                                    }
                                }
                                if (thisHandPairRank < otherHandPairRank)
                                {
                                    return -1;
                                }
                                else if (thisHandPairRank > otherHandPairRank)
                                {
                                    return 1;
                                }
                                else
                                {
                                    return CompareHighCard(hand);
                                }
                            }
                        case HandType.FullHouse:
                            {
                                thisHandPairRank = 0;
                                otherHandPairRank = 0;
                                for (int i = 5; i < 5; i++)
                                {
                                    if (hand.Cards[i].Rank == hand.Cards[i-1].Rank && hand.Cards[i-2].Rank == hand.Cards[i-4].Rank)
                                    {
                                        thisHandPairRank = hand.Cards[i].Rank;

                                    }

                                }
                                for (int i = 5; i < 5; i++)
                                {
                                    if (hand.Cards[i].Rank == hand.Cards[i-1].Rank && hand.Cards[i-2].Rank == hand.Cards[i-4].Rank)
                                    {
                                        otherHandPairRank = hand.Cards[i].Rank;

                                    }
                                }
                                if(thisHandPairRank < otherHandPairRank)
                                {
                                    return -1;
                                }
                                if(thisHandPairRank > otherHandPairRank)
                                {
                                    return 1;
                                }else
                                {
                                    return CompareHighCard(hand);
                                }
                            }


                        case HandType.Straight:
                            {
                                return CompareHighCard(hand);
                            }



                        case HandType.Flush:
                            {
                                return CompareHighCard(hand);


                            }

                        case HandType.RoyalStraightFlush:
                            {
                                return CompareHighCard(hand);
                            }
                    }


                }
                else
                {
                    return 1;
                }

            }
            throw new NotImplementedException();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
            EvaluateHand();

        }
        public void DiscardCard(Card card)
        {
            cards.Remove(card);
        }
        
        public HandType EvaluateHand()
        {
            if (RoyalStraightFlush())
            {
                return handType = HandType.RoyalStraightFlush;
            }

            else if (Pair())
            {
                return handType = HandType.Pair;
            }
            else if (TwoPair())
            {
                return handType = HandType.TwoPairs;
            }
            else if (StraightFlush())
            {
                return handType = HandType.StraightFlush;
            }
            else if (FourOfKind())
            {
                return handType = HandType.FourOfAKind;
            }
            else if (Flush())
            {
                return handType = HandType.Flush;
            }
            else if (FullHouse())
            {
                return handType = HandType.FullHouse;
            }
            else if (ThreeOfKind())
            {
                return handType = HandType.ThreeOfAKind;
            }
            else if (Straight())
            {
                return handType = HandType.Straight;
            }
            else
            {
                return handType = HandType.HighCard;
            }

        }
        /*public bool Straight()
        {
            var aceHigh = cards.Select(c => (int)c.Rank).OrderBy(x => x).ToArray();
            var aceLow = aceHigh.Select(x => x == 14 ? 1 : x).ToArray();
            return new[] { aceHigh, aceLow }.Any(cs => cs.Skip(1).Zip(cs, (c1, c0) => c1 - c0).All(x => x == 1));

        }*/
        public bool Straight()
        {
            var ordered = Cards.OrderBy(h => h.Rank).ToArray();
            var straightStart = (int)ordered.First().Rank;

            for (var i = 1; i < ordered.Length; i++)
            {
                if (ordered.Last().Rank == Rank.Ace && ordered.First().Rank == Rank.Two) { return true; }
                if ((int)ordered[i].Rank != straightStart + i) { return false; }
            }
            return true;
        }
        
        public bool StraightFlush() => this.Straight() & this.Flush();
        public bool Flush() =>
            cards.Select(x => x.Suite)
            .Distinct().Count() == 1;
        public bool ThreeOfKind() =>
            cards.GroupBy(x => x.Rank)
            .Any(x => x.Count() == 3);
        public bool FourOfKind() =>
            cards.GroupBy(x => x.Rank)
            .Any(x => x.Count() == 4);
        public bool FullHouse() =>
            cards.GroupBy(x => x.Rank)
            .Select(x => x.Count())
            .OrderBy(x => x)
            .SequenceEqual(new[] { 2, 3 });


        public bool RoyalStraightFlush()
        {
            var myCards = cards.Select(c => (int)c.Rank).Min() == 10;
            return myCards && this.Flush();
        }



        public bool Pair() =>
            cards.GroupBy(x => x.Rank)
            .Select(x => x.Count())
            .OrderBy(x => x)
            .SequenceEqual(new[] { 1, 1, 1, 2 });

        public bool TwoPair() =>
            cards.GroupBy(x => x.Rank)
            .Select(x => x.Count())
            .OrderBy(x => x)
            .SequenceEqual(new[] { 1, 2, 2 });


    }

}