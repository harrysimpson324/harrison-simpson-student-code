using System;

namespace TechElevator.Bookstore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to The Bookstore");

            // Create three book objects and set their properties using a constructor
            Book twoCities = new Book("A Tale of Two Cities", "Charles Dickens", 14.99M);
            Book threeMusketeers = new Book("The Three Musketeers", "Alexandre Dumas", 12.95M);
            Book childhoodEnd = new Book("Childhood's End", "Arthur C. Clark", 5.99M);

            // Add all three books to the shopping cart
            ShoppingCart shoppingCart = new ShoppingCart(0.075);    // 7.5% tax rate
            shoppingCart.Add(twoCities);
            shoppingCart.Add(threeMusketeers);
            shoppingCart.Add(childhoodEnd);

            // Add some new movies and purchase them
            Movie toyStory = new Movie("Toy Story", "G", 81, 19.99M);
            shoppingCart.Add(toyStory);

            // Shirley, you can't be serious!
            Movie airplane = new Movie("Airplane!", "PG", 88, 14.99M);
            shoppingCart.Add(airplane);

            // Have a cuppa jo!
            Coffee myCoffee = new Coffee("Extra-large", "Dark Roast", new string[] { "Creme" }, (decimal)3.99);
            Coffee myFriendsCoffee = new Coffee("Medium", "House Blend", new string[] { "Soy milk", "Sugar" }, (decimal)2.79);
            shoppingCart.Add(myCoffee);
            shoppingCart.Add(myFriendsCoffee);

            // Print a receipt
            Console.WriteLine(shoppingCart.GetReceipt());
        }
    }
}
