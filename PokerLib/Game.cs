using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Poker.Lib
{
    class Game : IPokerGame
    {
        public event OnNewDeal NewDeal;

        public event OnSelectCardsToDiscard SelectCardsToDiscard;

        public event OnRecievedReplacementCards RecievedReplacementCards;
        public event OnShowAllHands ShowAllHands;
        public event OnWinner Winner;
        public event OnDraw Draw;

        public Deck deck = new Deck();
        public Graveyard graveyard;
        public Dealer dealer;
        


        IPlayer[] IPokerGame.Players
        {
            get { return Players; }

        }
        public Player[] Players
        {
            get;
            set;
        }

        public void RunGame()
        {
            
            while (true)
            {
                OneRunGame();
                      
            }

        }
        public bool OneRunGame()
        {

            NewDeal();
            dealer.DealCards(Players);

            // välj kort som ska kastas
            // ersätt kortet som har kastats
            foreach (Player currentPlayer in Players)
            {
                SelectCardsToDiscard(currentPlayer);
                int drawAmount = currentPlayer.MakeaMove();
                currentPlayer.PutToHand(deck.Drawcards(drawAmount));
                currentPlayer.Hand.EvaluateHand();
                RecievedReplacementCards(currentPlayer);


            }
            List<Player> winner = new List<Player>();
            winner.Add(Players[0]);
            for (int i = 1; i < Players.Length; i++)
            {
                int x = Players[i].InspectCards(winner[0].Hand);

                if (x == 1)
                {
                    winner = new List<Player>();
                    winner.Add(Players[i]);

                }
                else if (x == 0)
                {
                    winner.Add(Players[i]);

                }
            }

            ShowAllHands();
            if (winner.Count > 1)
            {
                Draw(winner.ToArray());

            }
            else
            {
                winner[0].wins++;
                Winner(winner.ToArray()[0]);
            }
            
            return true;
        }

        public void Exit()
        {
            System.Environment.Exit(1);
        }
        public void SaveGameAndExit(string fileName)
        {
            using (StreamWriter fileWriter = new StreamWriter(fileName))
            {
                foreach (Player p in Players)
                {
                    fileWriter.WriteLine($"{p.Wins} {p.Name}");
                }

            }

            System.Environment.Exit(1);
        }

        public Game(string fileName)
        {
            List<Player> players = new List<Player>();
            using (StreamReader fileReader = new StreamReader(fileName))
            {

                string line = fileReader.ReadLine();
                while (line != null)
                {

                    string[] words = line.Split(' ');
                    string winText = words[0];
                    string nameText = String.Join(" ", words.Skip(1));
                    players.Add(new Player(nameText, int.Parse(winText)));
                    line = fileReader.ReadLine();
                }

            }
            this.Players = players.ToArray();
            this.dealer = new Dealer();
            this.graveyard = new Graveyard();


        }
        public Game(string[] playerNames)
        {

            this.Players = new Player[playerNames.Length];
            for (int i = 0; i < Players.Length; i++)
            {
                Players[i] = new Player(playerNames[i], 0);
            }
            this.dealer = new Dealer();
            this.graveyard = new Graveyard();

        }

        public void CurrentPlayer()
        {

        }


    }


}