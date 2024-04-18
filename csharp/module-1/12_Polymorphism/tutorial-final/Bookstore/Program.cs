using System;

namespace TechElevator.Bookstore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Tech Elevator Bookstore");
            Console.WriteLine();

            // Step Three: Test the getters and setters
            Book twoCities = new Book();
            twoCities.Title = "A Tale of Two Cities";
            twoCities.Author = "Charles Dickens";
            twoCities.Price = 14.99M;

            // Step Five: Test the Book constructor
            Book threeMusketeers = new Book("The Three Musketeers", "Alexandre Dumas", 12.95M);
            Book childhoodEnd = new Book("Childhood's End", "Arthur C. Clark", 5.99M);

            // Step Nine: Test the ShoppingCart class
            ShoppingCart shoppingCart = new ShoppingCart();
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

            Console.WriteLine(shoppingCart.GetReceipt());
        }
    }
}
