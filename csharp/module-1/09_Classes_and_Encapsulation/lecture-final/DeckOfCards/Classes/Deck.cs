using System;
using System.Collections.Generic;

namespace DeckOfCards.Classes
{
    public class Deck
    {
        /// <summary>
        /// Represents the cards that are stored in the deck.
        /// Marked private so that outside classes can't modify its contents.
        /// </summary>
        private List<Card> Cards { get; set; } = new List<Card>();

        public Deck()
        {
            string[] suits = { "Spades", "Hearts", "Clubs", "Diamonds" };

            foreach (string suit in suits)
            {
                for (int i = 1; i <= 13; i++)
                {
                    Card c = new Card(i, suit);
                    Cards.Add(c);
                }
            }
        }

        /// <summary>
        /// Removes a single card from the top of the deck.
        /// </summary>
        /// <returns>The top card. Null if the deck is empty.</returns>
        public Card DealOne()
        {
            Card result = null;

            // If there are 1 or more cards in the "Cards" list
            if (Cards.Count > 0)
            {
                // Retrieve the first "Card"/element out of the Cards list.
                result = Cards[0];

                // Removing from the card list
                Cards.Remove(result);
            }

            // Give to the class that requested the card
            return result;
        }

        //  Fisher-Yates shuffle. Based on code from https://stackoverflow.com/a/1150699/1034308
        //  Loop through the deck. On each iteration, swap the current card with a randomly chosen one.
        public void Shuffle()
        {
            Random r = new Random();

            for (int n = Cards.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                Card temp = Cards[n];
                Cards[n] = Cards[k];
                Cards[k] = temp;
            }
        }
    }
}
