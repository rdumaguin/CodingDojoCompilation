using System.Collections.Generic;

// Give the Player class a name property
// Give the Player a hand property that is a List of type Card
// Give the Player a draw method of which draws a card from a deck, adds it to the player's hand and returns the Card
// Note this method will require reference to a deck object
// Give the Player a discard method which discards the Card at the specified index from the player's hand and returns this Card or null if the index does not exist.
namespace Deck_of_Cards{
    public class Player{
        public string _name;
        private List<Card> _hand;
        public Player(string name){ // Constructor
            _name = name;
            _hand = new List<Card>();
            // _hand.Add(new Card("test", 1)); // This was to test adding a hand
        }

        public void DrawFrom(Deck currentDeck){ // To pass in a reference to the deck
            _hand.Add(currentDeck.Deal()); // Return(deal) a Card and add it to our hand of type List<Card>
        }

        public Card Discard(int idx){
            if(idx < _hand.Count){ // Check if idx exists
                Card temp = _hand[idx]; // Saving a reference before we remove the card
                _hand.RemoveAt(idx);
                return temp;
            }
            return null;
        }
    }
}