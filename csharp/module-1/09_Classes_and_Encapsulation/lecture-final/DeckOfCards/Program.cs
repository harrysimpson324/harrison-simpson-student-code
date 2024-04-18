using System;
using DeckOfCards.Classes;
using Draw.Tool;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            // ** Pencil Demo **
            WoodenPencil pencil = new WoodenPencil();
            Console.WriteLine("Pencil length: " + pencil.Length + " inches");
            Console.WriteLine("Pencil sharpness: " + pencil.Sharpness);
            Console.WriteLine();

            pencil.Sharpen();
            Console.WriteLine("Sharpening...");
            Console.WriteLine("Pencil length: " + pencil.Length + " inches");
            Console.WriteLine("Pencil sharpness: " + pencil.Sharpness);
            Console.WriteLine();

            pencil.Write();
            Console.WriteLine("Writing...");
            Console.WriteLine("Pencil sharpness: " + pencil.Sharpness);
            Console.WriteLine();

            pencil.Sharpen();
            Console.WriteLine("Sharpening...");
            Console.WriteLine("Pencil length: " + pencil.Length + " inches");
            Console.WriteLine("Pencil sharpness: " + pencil.Sharpness);
            Console.WriteLine();

            // ** Card Demo **

            Deck deck = new Deck();
            
            // Default output encoding (character set) is ASCII
            // Set it to Unicode so we can display card symbols
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            deck.Shuffle();

            for (int i = 1; i <= 52; i++)
            {
                Card topCard = deck.DealOne();

                Console.WriteLine($"{topCard.FaceValue} of {topCard.Suit} - {topCard.Symbol}");
            }

            Console.ReadLine();
        }
    }
}
