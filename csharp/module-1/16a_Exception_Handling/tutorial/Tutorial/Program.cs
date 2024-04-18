using System;

namespace Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 7: Create MasterCard class and replace CreditCard instance
            // Step 8: Create Visa class and replace MasterCard instance 
            CreditCard cc = new CreditCard();

            // Credit card validation loop
            while (true)
            {
                // Prompt user for credit card information
                Console.Write("Last name: ");
                cc.LastName = Console.ReadLine();
                Console.Write("First name: ");
                cc.FirstName = Console.ReadLine();
                Console.Write("Number: ");
                cc.Number = Console.ReadLine();
                Console.Write("Security code: ");
                cc.SecurityCode = Console.ReadLine();

                // Validate the credit card
                try
                {
                    cc.Validate();
                    break; // No exception thrown, credit card is valid, break out of validation loop 
                }
                catch (Exception ex) // Step 3: Modify validation loop to catch CreditCardValidationException
                {
                    Console.WriteLine($"Card is invalid: {ex.Message}\n");
                }
            }

            // Display valid CreditCard
            Console.WriteLine($"\nCard is valid - {cc.ToString()}");
        }
    }
}
