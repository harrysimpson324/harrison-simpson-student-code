# Tutorial for classes and encapsulation

In this tutorial, you'll build a bookstore application using some of the concepts and principles of encapsulation. You'll create two classes, `Book` and `ShoppingCart`, and use them in the application.

## Step One: Review and run the `Bookstore` project

To get started, open the `ClassesAndEncapsulationTutorial.sln` solution file in Visual Studio.

Next, open `Program.cs` in Solution Explorer. This is the starting point of the command line bookstore application.

Inside the `Main()` method, you'll see code that displays a welcome message, and some "step" comment lines:

```csharp
Console.WriteLine("Welcome to the Tech Elevator Bookstore");
Console.WriteLine();

// Step Three: Test the getters and setters

// Step Five: Test the Book constructor

// Step Nine: Test the ShoppingCart class
```

Before moving on to step two, you'll need to run the application to make sure it works. Look for the green "play arrow" with the word "Bookstore" next to it on the toolbar and click it to run the program. Alternatively, you may press the **F5** key. In the Console window, you'll see the welcome message:

```
Welcome to the Tech Elevator Bookstore
```

The application exits once it displays the welcome message.

## Step Two: Create the `Book` class

Now that you've reviewed the starting code and confirmed the application runs, it's time to create your first class.

You'll start with creating a `Book` class. Each instance of the `Book` class holds the information for one book. Each book has a title, an author's name, and a price.

Remember that classes combine, or *encapsulate*, *state* (instance variables) and *behavior* (instance methods). Instead of creating separate variables in the program to hold a book's title, author, and price, you keep all details of a book in one place—in a `Book` object.

In Solution Explorer, right-click the Bookstore project. From the menu that appears, select **Add > Class...**

Next, type in the class name, `Book`, in Pascal case. Press **Enter** to create the class. The file `Book.cs` appears in Solution Explorer, under the Bookstore project.

### Create the properties

The new `Book.cs` file opens in the editor.

The first thing you'll do is add the `public` modifier to the class line, so that it reads `public class Book`.

Next, begin writing the class with the *properties*. Properties are the *state* that each `Book` object holds. For this application, that's Title, Author, and Price.

Type the following into `Book.cs` within the `class` block to add the properties:

```csharp
namespace TechElevator.Bookstore
{
    public class Book
    {
        // Add the properties
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
    }
}
```

> Note: `namespace TechElevator.Bookstore` was automatically added for you when you created the class file.

These are _automatic properties_. In C#, automatic properties are both a place to store state and include getters and setters which control access to that state. In this case, all properties are `public`, which means that any outside caller can see or modify (get or set) the properties. If you wanted to make sure no external caller changes one of the properties, you could add the `private` access modifier before `set`.

## Step Three: Test the `Book` properties

Test your properties by creating an instance of `Book`, setting values for `Title`, `Author`, and `Price`, and then getting and displaying the values.

Open `Program.cs`, if not already open, and enter the following code under the "Step Three" comment line as shown.

```csharp
// Step Three: Test the getters and setters
Book twoCities = new Book();
twoCities.Title = "A Tale of Two Cities";
twoCities.Author = "Charles Dickens";
twoCities.Price = 14.99M;
Console.WriteLine($"Title: {twoCities.Title}, Author: {twoCities.Author}, Price: ${twoCities.Price}");
```

Once you've entered and saved the test code, re-run `Bookstore`. You'll see this:

```
Welcome to the Tech Elevator Bookstore

Title: A Tale of Two Cities, Author: Charles Dickens, Price: $14.99
```

## Step Four: Add constructors to the `Book` class

Properties are great, but sometimes they can be tedious to use. It might be better to include the title, author, and price when creating an instance of a `Book` instead of creating the instance and assigning a value to each instance variable one at a time.

Assigning a value to each instance variable one at a time involves additional typing, which might lead to errors. For example, forgetting to set one of the instance variables might put the object into an *inconsistent state*.

Constructors can address these concerns. Constructors allow you to create instances of a class, reduce excess code, and help eliminate inconsistent state.

By default, if you don't define a constructor, C# automatically adds a *default constructor* to your class. Default constructors set all instance variables to `null` for reference types, and `0` or `false` for value types.

Since you didn't include a constructor in the `Book` class code, the C#-generated default constructor for `Book` was called when you created an instance of the class:

```csharp
Book twoCities = new Book();
```

Because the default constructor sets all instance variables to `null` or `0`, you needed to assign values to them using their property setters:

```csharp
twoCities.Title = "A Tale of Two Cities";
twoCities.Author = "Charles Dickens";
twoCities.Price = 14.99M;
```

Fortunately, adding a custom constructor is no more difficult than writing a method. In fact, constructors are just *special* methods.

Like methods, constructors have a name, and optionally have parameters. The differences between constructors and methods are that constructors always have the same name as their class, and they never return anything, not even `void`.

Return to `Book.cs`, and type in this new constructor:

```csharp
public Book(string title, string author, decimal price)
{
    this.Title = title;
    this.Author = author;
    this.Price = price;
}
```

Once you provide a custom constructor, C# no longer generates the default one, and there's now only one way to create a new `Book` by giving the book a title, an author, and a price.

Consequently, you also need to provide the default constructor so the original code you wrote in the previous step continues to work:

```csharp
public Book()
{
}
```

## Step Five: Test the `Book` constructors

To test the new `Book` constructor, create two additional instances of `Book` using the custom constructor, and display the results. Under the "Step Five" comment in `Program.cs`, add:

```csharp
// Step Five: Test the Book constructor
Book threeMusketeers = new Book("The Three Musketeers", "Alexandre Dumas", 12.95M);
Book childhoodEnd = new Book("Childhood's End", "Arthur C. Clark", 5.99M);

Console.WriteLine($"Title: {threeMusketeers.Title}, Author: {threeMusketeers.Author}, Price: ${threeMusketeers.Price}");

Console.WriteLine($"Title: {childhoodEnd.Title}, Author: {childhoodEnd.Author}, Price: ${childhoodEnd.Price}");
```

The following results appear after you've entered and saved the test code and re-run `Bookstore`:

```
Welcome to the Tech Elevator Bookstore

Title: A Tale of Two Cities, Author: Charles Dickens, Price: $14.99
Title: The Three Musketeers, Author: Alexandre Dumas, Price: $12.95
Title: Childhood's End, Author: Arthur C. Clark, Price: $5.99
```

## Step Six: Create string representation of `Book` object

Classes frequently have a method which builds a string representation of the values of the instance variables. This can be extremely useful for testing and debugging purposes, but it's also convenient to have a way to consistently display the contents of an object.

It also helps to eliminate duplicate code by building the string representation in a single method rather than repeatedly building strings as you've seen in the code you've written in this tutorial.

Add the following method to the `Book` class:

```csharp
// Return a string representation of this book
public string GetBookInfo()
{
    return $"Title: {this.Title}, Author: {this.Author}, Price: ${this.Price}";
}

```

> Note: You'll learn the standard C# way of building string representations using the `ToString()` method in the Inheritance unit.

> Note: When you type this code, Visual Studio "grays out" the keyword `this`. It does this because in most cases, the compiler can figure out that you mean "the property `Title` on this instance", even if you don't include `this`. You can remove it and your code still works fine. It's included in these examples for completeness.

This completes the `Book` class. You now have a class that contains all the information needed to represent a book, has a convenient constructor, and a way to form a consistent string representation of it.

## Step Seven: Test the `GetBookInfo` method

Modify `Program.cs` by eliminating the redundant code which builds the display string. Replace it with the following code:

```csharp
...
//Console.WriteLine($"Title: {twoCities.Title}, Author: {twoCities.Author}, Price: ${twoCities.Price}");
Console.WriteLine(twoCities.GetBookInfo());
...
//Console.WriteLine($"Title: {threeMusketeers.Title}, Author: {threeMusketeers.Author}, Price: ${threeMusketeers.Price}");
//Console.WriteLine($"Title: {childhoodEnd.Title}, Author: {childhoodEnd.Author}, Price: ${childhoodEnd.Price}");
Console.WriteLine(threeMusketeers.GetBookInfo());
Console.WriteLine(childhoodEnd.GetBookInfo());

```

Save the replaced code, and re-run `Bookstore`. You'll see the same output you saw when testing the constructor:

```
Welcome to the Tech Elevator Bookstore

Title: A Tale of Two Cities, Author: Charles Dickens, Price: $14.99
Title: The Three Musketeers, Author: Alexandre Dumas, Price: $12.95
Title: Childhood's End, Author: Arthur C. Clark, Price: $5.99
```

## Step Eight: Create the `ShoppingCart` class

Now, you need to work on the Shopping Cart.

The `ShoppingCart` class represents a collection of books that a customer wants to buy.

Once again, in Solution Explorer, right-click the Bookstore project. From the menu that appears, select **Add > Class...** Type in the class name, `ShoppingCart` and press **Enter** to create the class. The file `ShoppingCart.cs` appears in Solution Explorer, under the Bookstore project.

Make the class public by adding the `public` modifier before `class ShoppingCart`.

You need a single instance variable to store the book objects in the shopping cart. Enter the following code into `ShoppingCart.cs`:

```csharp
private List<Book> booksToBuy = new List<Book>();
```

Since there's only the one instance variable, and it's automatically instantiated as an empty list of books, you don't need a custom constructor. The default constructor works fine.

However, you do need to be able to add books to the list, so the `ShoppingCart` needs an `Add()` method. This method takes an instance of `Book` that's the book to add to the list.

Type the following code in `ShoppingCart.cs`:

```csharp
public void Add(Book bookToAdd)
{
    booksToBuy.Add(bookToAdd);
}
```

The `ShoppingCart` also needs to get the total price for all the books currently in the cart. This is a derived property calculated by looping through the list of books and adding each book's price to the total purchase amount.

Add the following code to create a new derived property in the `ShoppingCart` class called `TotalPrice`:

```csharp
public decimal TotalPrice
{
    get
    {
        decimal total = 0.0M;
        foreach (Book book in this.booksToBuy)
        {
            total += book.Price;
        }
        return total;
    }
}
```

Finally, the `ShoppingCart` needs a `GetReceipt()` method that returns a receipt-like string representation of the shopping cart, with a listing of all the books in the cart and, at the end, the total price of everything in the cart:

```csharp
public string GetReceipt()
{
    string receipt = "Receipt\n";
    foreach (Book book in this.booksToBuy)
    {
        receipt += book.GetBookInfo();
        receipt += "\n";
    }
    receipt += "\nTotal: $" + this.TotalPrice;
    return receipt;
}
```

> Note the use of `book.GetBookInfo()` to build the string representation of the `book` object, and `TotalPrice` to calculate the derived property for the receipt.

The `ShoppingCart` is complete.

Take a minute to review how you have encapsulated the state of `ShoppingCart`. You declared the instance variable `booksToBuy` as `private` with the only way to alter it through the public `Add()` method.

The `ShoppingCart`'s state is further encapsulated with the `public` derived property, `TotalPrice`. Remember, safely encapsulating an object isn't just hiding data, but also keeping implementation details firmly embedded in the class.

## Step Nine: Test the `ShoppingCart` class

To test the `ShoppingCart`, edit `Program.cs` to add the three instances of the `Book` already created to a new `ShoppingCart`, then call `GetReceipt()` and display the returned string representation of the shopping cart:

```csharp
// Step Nine: Test the ShoppingCart class
ShoppingCart shoppingCart = new ShoppingCart();
shoppingCart.Add(twoCities);
shoppingCart.Add(threeMusketeers);
shoppingCart.Add(childhoodEnd);
Console.WriteLine(shoppingCart.GetReceipt());
```

Re-run `Bookstore` after adding and saving the test code. You'll see the following output:

```
Welcome to the Tech Elevator Bookstore

Title: A Tale of Two Cities, Author: Charles Dickens, Price: $14.99
Title: The Three Musketeers, Author: Alexandre Dumas, Price: $12.95
Title: Childhood's End, Author: Arthur C. Clark, Price: $5.99
Receipt
Title: A Tale of Two Cities, Author: Charles Dickens, Price: $14.99
Title: The Three Musketeers, Author: Alexandre Dumas, Price: $12.95
Title: Childhood's End, Author: Arthur C. Clark, Price: $5.99

Total: $33.93
```

## Summary

After completing this tutorial, you should understand:

* How to create a basic C# class.
* How to safely encapsulate state through the use of `private` and `public` access modifiers.
* How to write constructors, and their role in furthering encapsulation.
* How to create instances of a class, and make use of their `public` methods.
