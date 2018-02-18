using System;
using System.Collections.Generic;

// Give the Deck class a property called "cards" which is a list of Card objects
// When initializing the deck make sure that it has a list of 52 unique cards as its "cards" property
// Give the Deck a deal method that selects the "top-most" card, removes it from the list of cards, and returns the Card
// Give the Deck a reset method that resets the cards property to the contain the original 52 cards
// Give the Deck a shuffle method that randomly reorders the deck's cards

namespace Deck_of_Cards{
    public class Deck{
        public List<Card> cards;
        public Deck(){ // Constructor
            Reset();
                // Code below moved to Reset() method
            // cards = new List<Card>();
            // string[] suits = {"Clubs", "Spades", "Hearts", "Diamonds"};
            // foreach(string suit in suits){
            //     for(int val = 1; val <= 13; val++){
            //         cards.Add(new Card(suit,val));
            //     }
            // }
        }

        public Card Deal(){
            if(cards.Count > 0){
                Card temp = cards[0];
                cards.RemoveAt(0);
                return temp; // Returning the top card object
            }
            return null; // Simple way of error-checking
        }

        public Deck Shuffle(){
            Random rand = new Random();
            // for(int idx = 0; idx < cards.Count-1; idx++){
            //     Card temp = cards[idx];
            //     int randIdx = rand.Next(idx + 1, cards.Count);
            //     cards[idx] = cards[randIdx];
            //     cards[randIdx] = temp;
            // }
            for(int idx = cards.Count-1; idx > 0; idx--){ // Cleaner and more predictable
                int randIdx = rand.Next(idx); // 0 to almost idx
                Card temp = cards[randIdx];
                cards[randIdx] = cards[idx];
                cards[idx] = temp;
            }
            return this;
        }

        public Deck Reset(){ // Returns the Deck
            // Code below was grabbed from constructor to so we can run Reset() on the constructor
            cards = new List<Card>();
            string[] suits = {"Clubs", "Spades", "Hearts", "Diamonds"};
            foreach(string suit in suits){
                for(int val = 1; val <= 13; val++){
                    cards.Add(new Card(suit,val));
                }
            }
            return this;
        }

        public override string ToString(){ // Do this in order to print out the actual value instead of the type
            string output = "";
            foreach(Card card in cards){
                output += card + "\n";
            } 
            return output;
        }
    }
}