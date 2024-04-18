using System.Collections.Generic;

namespace DeckOfCards.Classes
{
    public class Card
    {
        /// <summary>
        /// The card suit.
        /// </summary>
        public string Suit { get; }

        /// <summary>
        /// The numeric value for the card.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Derived Property that calculates Red or Black based on Suit Property.
        /// </summary>
        public string Color
        {
            get
            {
                if (Suit == "Hearts" || Suit == "Diamonds")
                {
                    return "Red";
                }
                else
                {
                    return "Black";
                }
            }
        }

        /// <summary>
        /// Gets the word for face value.
        /// </summary>
        public string FaceValue
        {
            get
            {
                return faceValues[Value];
            }
        }

        /// <summary>
        /// Gets the symbol for the suit.
        /// </summary>
        public char Symbol
        {
            get
            {
                return suitSymbols[Suit];
            }
        }

        /// <summary>
        /// Boolean to indicate if card is face down or not.
        /// "private set" so can only be set within the class,
        /// i.e. Flip() is the only way to toggle between
        /// face-down and face-up.
        /// </summary>
        public bool IsFaceDown { get; private set; } = true;

        /// <summary>
        /// Toggles "face up" to "face down" and vice versa
        /// </summary>
        public void Flip()
        {
            // Toggle IsFaceDown from true -> false or false -> true
            // alternative solution: IsFaceDown = !IsFaceDown
            if (IsFaceDown)
            {
                IsFaceDown = false;
            }
            else
            {
                IsFaceDown = true;
            }
        }

        /// <summary>
        /// Constructor to create a suit
        /// </summary>
        /// <param name="value">the value the card represents</param>
        /// <param name="suit">the suit the card represents</param>
        public Card(int value, string suit)
        {
            this.Suit = suit; //'this' is optional
            Value = value;
        }

        private static readonly Dictionary<string, char> suitSymbols = new Dictionary<string, char>()
        {
            {"Spades", '\u2660'},
            {"Diamonds", '\u2666'},
            {"Clubs", '\u2663'},
            {"Hearts", '\u2665'}
        };

        private static readonly Dictionary<int, string> faceValues = new Dictionary<int, string>()
        {
            {1, "Ace" },
            {2, "Two" },
            {3, "Three" },
            {4, "Four" },
            {5, "Five" },
            {6, "Six" },
            {7, "Seven" },
            {8, "Eight" },
            {9, "Nine" },
            {10, "Ten" },
            {11, "Jack" },
            {12, "Queen" },
            {13, "King" }
        };
    }
}
