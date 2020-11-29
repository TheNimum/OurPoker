using System.IO;
namespace Poker.Lib
{
    public static class GameFactory
    {
        public static IPokerGame NewGame(string[] playerNames)
        {
            //File.Create("fileName.txt");
            return new Game(playerNames);
        }

        public static IPokerGame LoadGame(string fileName)
        {

            //File.Open("fileName.txt", FileMode.Open);
            return new Game(fileName);
        }
    }
}