using System;

namespace DiscountCalculator
{
    class Program
    {
        /// <summary>
        /// The main method is the start and end of our program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Discount Calculator");

            // Prompt the user for a discount amount
            // The answer needs to be saved as a double
            Console.Write("Enter the discount amount (w/out percentage): ");
            double discount = double.Parse(Console.ReadLine()) / 100.0;

            // Prompt the user for a series of prices
            Console.Write("Please provide a series of prices (space separated): ");
            string prices = Console.ReadLine();

            // Split the string up into separate values
            string[] priceArray = prices.Split(' ');

            // Loop through each value in the priceArray
            for(int i = 0; i < priceArray.Length; i++)
            {
                // Read the individual value as a decimal
                decimal originalPrice = decimal.Parse(priceArray[i]);

                // Cast the discount value to a decimal to allow the calculation
                decimal amountOff = originalPrice * (decimal)discount;

                // Calculate the sale price
                decimal salePrice = originalPrice - amountOff;

                Console.WriteLine($"Original Price: {originalPrice:C2} | Sale Price: {salePrice:C2}");
            }
        }
    }
}
