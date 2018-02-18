using System;

namespace Deck_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Deck myDeck = new Deck();
            Console.WriteLine(myDeck);
            myDeck.Shuffle();
            Player myPlayer = new Player("Rommel");
            Console.WriteLine(myPlayer._name);
            myPlayer.DrawFrom(myDeck);
            myPlayer.DrawFrom(myDeck);
            myPlayer.DrawFrom(myDeck); // idx 2
            myPlayer.Discard(2); // Remove idx 2
            myPlayer.Discard(2); // Returns null
            myDeck.Reset();
        }
    }
}
