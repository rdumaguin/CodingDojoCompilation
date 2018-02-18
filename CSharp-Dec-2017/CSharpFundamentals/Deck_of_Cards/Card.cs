// Give the Card class a property "stringVal" which will hold the value of the card ex. (Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King). This "val" should be a String
// Give the Card a property "suit" which will hold the suit of the card (Clubs, Spades, Hearts, Diamonds)
// Give the Card a property "val" which will hold the numerical value of the card 1-13 as integers
namespace Deck_of_Cards{
    public class Card{
        public string _suit;
        public int _val;
        public string _stringVal{
            // Moved this code from the constructor into a getter since this string only needs to get the _val to determine the _stringVal to return
            get{
                if(_val > 1 && _val < 11){
                return _val.ToString();
                }
                else if (_val == 11){
                    return "Jack";
                }
                else if (_val == 12){
                    return "Queen";
                }
                else if (_val == 13){
                    return "King";
                }
                else if (_val == 1){
                    return "Ace";
                }
                else{
                    return null;
                }
            }
        }
        public Card(string suit, int val){ // Constructor
            _suit = suit;
            _val = val;
            // if(val > 1 && val < 11){
            //     _stringVal = val.ToString();
            // }
            // else if (val == 11){
            //     _stringVal = "Jack";
            // }
            // else if (val == 12){
            //     _stringVal = "Queen";
            // }
            // else if (val == 13){
            //     _stringVal = "King";
            // }
            // else if (val == 1){
            //     _stringVal = "Ace";
            // }
            // else{
            //     _stringVal = null;
            // }
        }

        public override string ToString(){ // Do this in order to print out the actual value instead of the type
            return _stringVal + " of " + _suit;
        }
    }
}