# Unit testing tutorial

In this tutorial, you'll create new units tests for an existing ("legacy") codebase. By the end of this tutorial, you'll understand:

- How to write unit tests in a legacy codebase.
- How unit testing can show that the code is functioning correctly.
- How to organize your unit tests.
- How to set up a test to _arrange_, _act_, and _assert_.
- How to debug unit tests.

## Getting started

To get started, follow these steps:

1. Open the project with Visual Studio.
2. In **Solution Explorer**, navigate to the `Tutorial` project folder.

You'll see the code for the `Tutorial` project. This is the _system under test_. You'll write unit tests for the classes that make up this application.

## Step One: Inspect the existing codebase

Before you can write tests for any existing codebase, you need to be familiar with the code's purpose and what its requirements are. For some code, there may be documentation that lists all the requirements of a system. If that exists, that's a great place to start.

For this example, you only have the code and no other documentation. So spend a few minutes looking through the class files.

Run the program by clicking on the toolbar button with the green arrow in front of the "Tutorial", or by pressing the **F5** key:

![Run project](./img/vs-run.png)

You'll see output like this in your terminal window:

```
Welcome to The Bookstore

Receipt

Book: A Tale of Two Cities by Charles Dickens, Price: $14.99
Book: The Three Musketeers by Alexandre Dumas, Price: $12.95
Book: Childhood's End by Arthur C. Clark, Price: $5.99
Movie: 'Toy Story'(G), Price: $19.99
Movie: 'Airplane!'(PG), Price: $14.99
Coffee: Extra-large Dark Roast (Creme). Price: $3.99
Coffee: Medium House Blend (Soy milk, Sugar). Price: $2.79

Subtotal: $75.69
Tax: $5.68
Total: $81.37
```

In the code, you can see the following classes:

* `Program`: the main program which creates a shopping cart, adds items to the cart, and prints a receipt.
* `ShoppingCart`: A container to hold all of the items to purchase at the store.
* `IPurchasable`: Any item that you can place into a `ShoppingCart` must implement this interface.
* `MediaItem`: The base class for books, movies and other media items that the store can sell. Implements `IPurchasable`.
* `Book`, `Movie`: Subclasses of `MediaItem` to represent specific type of media.
* `Coffee`: A purchasable item which isn't media. Implements `IPurchasable`.

## Step Two: Plan your tests and conditions

Once you understand the requirements of the program, you plan the classes and the methods within those classes that you'll test. After that, you need to think of all of the conditions you must test. Try to think of "normal" successful conditions, conditions that might cause errors, and edge cases. Write them all down before you start writing tests. You'll come back to this list as you complete the tests.

For this application, here are some tests you might create:

* `Book`, `Coffee`, and `Movie`:
  * These classes mostly consist of properties with little business logic in its methods, so there isn't a lot to test. You usually don't write tests for every getter and setter because they're often very simple, and they usually get tested while you're testing other parts of the application.
  * _Constructors_: However, each class has a non-default constructor, and in some cases that constructor calls the superclass constructor. It's a good idea to test these to make sure all the properties get set properly. Here are some conditions you could test:
    * Create a "normal" item with a title, price, and other properties, and make sure the values of those properties are correct on the object.
    * Create an item with a price of $0.00, and expect that to be the price of the item.
    * Create an item with a price that's less than $0.00. An item must never have a negative price, so expect its price to be $0.00.
    * For `Coffee`:
      * Create an item with an array of additions, and verify that the additions property has the proper value. It must have the right number of additions in it.
      * Create an item with an empty array of additions, and verify that the additions property is empty. It must be empty.
      * Create an item with a `null` array of additions, and verify that the additions property has the proper value. It must be empty.
* `ShoppingCart`:
  * _Constructor_: There's one default constructor which accepts a tax rate (applied to all taxable items). You could test these conditions:
    * Create a cart using a positive tax rate and verify the rate is set correctly.
    * Create a cart with a zero tax rate and verify the rate is zero. Jurisdictions without sales taxes are possible.
    * Create a cart with a negative tax rate. There are no negative tax jurisdictions, so expect the rate to be zero.
  * `SubtotalPrice`: This derived property calculates the total price of all the items in the cart. Here are some conditions you could test:
    * Add a few items to the cart and make sure this property returns the total of all the items' prices.
    * Call this property on a brand new, empty cart and expect a return value of $0.00.
  * `Tax`: This derived property returns the total tax due. Tax due is calculated by applying the shopping cart tax rate to each of the _taxable_ items in the cart. You might check these conditions:
    * Add a few taxable items and a few non-taxable items to the cart and make sure the tax is calculated properly by taxing only the appropriate items.
    * Add only non-taxable items to the cart and verify the property returns $0.00.
    * Call this property against an empty cart and verify the result is $0.00.
  * `TotalPrice`: This derived property returns the total of item prices plus the total tax applied. You could test these conditions:
    * Add a mix of items to the cart and verify the total is correct.
    * Call this property on an empty cart and verify it returns $0.00.

Since interfaces, such as `IPurchasable`, don't contain code (implementation), you don't test interfaces. Instead, you test the classes which implement the interface. Similarly, you'd test abstract classes like `MediaItem` through their derived concrete classes.

You can see that when you start thinking about error conditions and edge cases, the number of tests can get very large. You can probably think of even more conditions, but this is a good start. You can now start writing tests.

## Step Three: Create the `CoffeeTests` class and your first test method

In the Microsoft Test Framework you'll be using, you write your tests in a separate project within the solution. In this tutorial, the project is `Tutorial.Tests`. It's common to name the test project the same as the application project, with the ".Tests" extension.

In this tutorial, you won't create all the tests listed in step two. You'll create just a few to get practice. Start by writing tests for the `Coffee` class.

### Add the test class

The first thing you need to do is create the _test class_. This is a standard C# class whose methods contain test code.

In Visual Studio Solution Explorer, right-click on the `Tutorial.Tests` project, and select **Add > Class...** from the menu. In the dialog, type `CoffeeTests` for the class name and press **Add**.

Visual Studio creates and then opens the file `CoffeeTests.cs`. There are a couple things you must do to make this class a valid testing class in the Microsoft Testing Framework.

First, make the class `public`.

Next, add the line `using Microsoft.VisualStudio.TestTools.UnitTesting;` as the first line in the file so you can use the classes in the testing framework namespace.

Finally, add the `TestClass` _attribute_ before the class declaration:

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
namespace Tutorial.Tests
{
    [TestClass]
    public class CoffeeTests
    {
    }
}
```

You now have a test class. To this class you can add one or more test methods.

### Add a test method

Looking at the list of tests, the first one is to test calling the constructor with normal, valid parameters. This testing of normal, expected behavior is sometimes called "happy path testing."

Create a method to test the constructor. Test methods are `public`, have a `void` return type, and declare no arguments. In addition, you mark the method with the `TestMethod` attribute. The name of the method clearly indicates what's being tested. According to [Microsoft's unit testing best practices document](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices#best-practices), the name of your test should consist of three parts:

* The name of the method being tested. In this case, you're testing the constructor.
* The scenario under which it's being tested. In this case, you're passing normal, valid parameters.
* The expected behavior when the scenario is invoked. In this case, you're expecting it to set the properties correctly.

A good name for this test would be `Constructor_ValidParameters_SetsProperties`:

```csharp
[TestMethod]
public void Constructor_ValidParameters_SetsProperties()
{
}
```

The body of a test method contains the three A's: _Arrange_, _Act_, and _Assert_. It's a good idea to add a comment for each of these, which forces you to think about what you need to code:

```csharp
[TestMethod]
public void Constructor_ValidParameters_SetsProperties()
{
    // Arrange - since this is testing a constructor, there's nothing to set up

    // Act - call the constructor by creating a new object, passing valid parameters

    // Assert - verify the properties are set appropriately
}
```

Now complete the test logic. Since the test is creating a new `Coffee` object and verifying its properties, there's no logic needed under _Arrange_. In more complex tests, you might create multiple objects or arrays of data as part of the setup.

Under _Act_, add code to create a new `Coffee` instance:

```csharp
// Act - call the constructor by creating a new object with valid parameters
Coffee coffee =
    new Coffee("Large", "Decaf", new string[]{"cream", "sugar"}, 2.99M);
```

When you type this into the editor, you may see an error that states "The type or namespace Coffee could not be found." You need to add a `using` directive to reference the namespace within the `Tutorial` project. There's a quick way to do this. 

When you hover your mouse over the error, the word "Coffee" in this case, you'll see a light bulb icon with a drop-down arrow next to it. Click on the drop-down arrow for "Quick Actions." The first item in the menu says "using Techelevator.Bookstore." Select this, and Visual Studio adds the `using` directive at the top of the file:

![Quick actions: using](./img/quick-action-using.png)

The _Assert_ step is where you write code to make the test pass or fail. Under _Assert_, you verify all the things that must be true for the test to pass. These are _assertions_:

```csharp
// Assert - verify the properties are set appropriately
Assert.AreEqual("Large", coffee.Size);
Assert.AreEqual("Decaf", coffee.Blend);
Assert.AreEqual(2.99M, coffee.Price);
Assert.AreEqual(2, coffee.Additions.Length);
```

`Assert` is a class which contains static methods that compare values to determine if the assertion is true. If any of the assertions isn't true, the test fails.

The most common method in the `Assert` class is `AreEqual`, which compares values, but there are other methods you can use when creating tests. You can find more on the [documentation page for `Assert`](https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert?view=visualstudiosdk-2022#methods).

## Step Four: Run the tests

When you are writing or running tests, you use the Test Explorer window in Visual Studio. To show that window, select **Test > Test Explorer** from the menu. The window opens and scans your projects for tests. After a few moments, you'll see a list of tests. You may have to expand the tree by clicking on the caret in the test tree that's shown.

Run all tests by clicking the **Run All Tests** icon in the top left corner of Test Explorer. You'll see test results at the bottom of the window in a moment:

![Test Explorer](./img/test-explorer.png)

You can add more methods to `CoffeeTest` to implement the tests you planned in step two after you complete this tutorial. For now, move on to create tests for `ShoppingCart`.

## Step Five: Create the `ShoppingCartTests` class and test methods

It's conventional to create a test class for each class under test. To create a new test class, right-click on the `Tutorial.Tests` project in Solution Explorer, and select **Add > Class...** from the menu. In the dialog, type `ShoppingCartTests` for the class name and press **Add**.

In `ShoppingCartTests.cs`, do the required work to make this a test class:

* Mark the class `public`.
* Add `using` directives, one for the testing framework, and one for the namespace of the application you are testing.
* Add the `TestClass` attribute to the class.

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechElevator.Bookstore;

namespace Tutorial.Tests
{
    [TestClass]
    public class ShoppingCartTests
    {
    }
}
```

### Test the subtotal

Create a "happy path" test that adds items to a shopping cart, then verifies the shopping cart subtotal is accurately calculated. Add this method to the `ShoppingCartTests` class:

```csharp
[TestMethod]
public void Subtotal_ValidItems_EqualsSumOfAllItems()
{
    // Arrange - Create a shopping cart with items

    // Create a shopping cart and add both taxable and non-taxable items to it.
    ShoppingCart cart = new ShoppingCart(0.10);     // 10% tax rate

    // Taxable $10 plus $1 tax
    cart.Add(new Book("Dynamics of Software Development", "Jim McCarthy", 10.00M));
    // Taxable $20 plus $2 tax
    cart.Add(new Movie("Free Guy", "PG-13", 115, 20.00M));
    // Not taxable $10
    cart.Add(new Coffee("Jumbo", "Bold", new string[] { "cream" }, 10.00M));

    // Act - get the subtotal
    decimal subtotal = cart.SubtotalPrice;

    // Assert - Make sure value is correct
    Assert.AreEqual(40.00M, subtotal);
}
```

For shopping cart tests, you need to do more in the _arrange_ part of the test. You create a shopping cart, and fill it with some sample items. Only after that can you verify the subtotal.

Run the test and ensure it passes.

> Note: if you want to run only one test, you can right-click anywhere in the body of the test method, and select **Run Test(s)** from the menu.

### Refactor the subtotal test

Next, you want to create some "happy path" tests to verify tax calculation and total price calculation. These methods also must create a shopping cart and add some items to it. 

You can copy the _arrange_ code from `Subtotal_ValidItems_EqualsSumOfAllItems()` to create a similar cart, but that defies the **D**on't **R**epeat **Y**ourself principle. A better idea is to factor the _arrange_ code into a separate method.

Replace the `Subtotal_ValidItems_EqualsSumOfAllItems()` method with this code:

```csharp
private ShoppingCart CreateAndFillCart()
{
    // Create a shopping cart and add both taxable and non-taxable items to it.
    ShoppingCart cart = new ShoppingCart(0.10);     // 10% tax rate

    // Taxable $10 plus $1 tax
    cart.Add(new Book("Dynamics of Software Development", "Jim McCarthy", 10.00M));
    // Taxable $20 plus $2 tax
    cart.Add(new Movie("Free Guy", "PG-13", 115, 20.00M));
    // Not taxable $10
    cart.Add(new Coffee("Jumbo", "Bold", new string[] { "cream" }, 10.00M));
    return cart;
}

[TestMethod]
public void Subtotal_ValidItems_EqualsSumOfAllItems()
{
    // Arrange - Create a shopping cart with items

    // Create a shopping cart and add both taxable and non-taxable items to it.
    ShoppingCart cart = CreateAndFillCart();

    // Act - get the subtotal
    decimal subtotal = cart.SubtotalPrice;

    // Assert - Make sure value is correct
    Assert.AreEqual(40.00M, subtotal);
}
```

After factoring the setup code into this helper method, any additional test can call `CreateAndFillCart()` if it requires a similar cart.

Run the test again to make sure your refactoring didn't affect the result.

### Automatic setup using `[TestInitialize]`

If you find that most or all of your tests need this same setup code, there's one more step you can take to make this automatic. You indicate code that must run _before every test_ using the `[TestInitialize]` annotation. Once this is in place, you can remove the explicit call to `CreateAndFillCart()`. The test framework automatically calls it for you, before every test.

Replace the previous code with this:

```csharp
private ShoppingCart cart;

[TestInitialize]
public void CreateAndFillCart()
{
    // Create a shopping cart and add both taxable and non-taxable items to it.
    this.cart = new ShoppingCart(0.10);     // 10% tax rate

    // Taxable $10 plus $1 tax
    cart.Add(new Book("Dynamics of Software Development", "Jim McCarthy", 10.00M));
    // Taxable $20 plus $2 tax
    cart.Add(new Movie("Free Guy", "PG-13", 115, 20.00M));
    // Not taxable $10
    cart.Add(new Coffee("Jumbo", "Bold", new string[] { "cream" }, 10.00M));
}

[TestMethod]
public void Subtotal_ValidItems_EqualsSumOfAllItems()
{
    // Arrange - Create a shopping cart with items

    // Act - get the subtotal
    decimal subtotal = cart.SubtotalPrice;

    // Assert - Make sure value is correct
    Assert.AreEqual(40.00M, subtotal);
}
```

Notice a few things about this new code:

* You must mark `CreateAndFillCart()` as `public` so the testing framework can run it.
* Instead of returning a `ShoppingCart`, the method stores a reference to the shopping cart into a private member variable. The method now returns `void`.
* The test doesn't explicitly call the setup method. The framework calls it before calling each test.
* The test uses the private member variable `cart`.

Run the test once more to see it work.

### Add tests for tax and total

Now you can add tests to verify the tax and total price of items in the cart:

```csharp
[TestMethod]
public void Tax_TaxableItemMix_EqualsTaxOnTaxableItems()
{
    // Arrange - the [TestInitialize] method creates a cart before every test

    // Act - get the tax
    decimal tax = cart.Tax;

    // Assert - Make sure value is correct
    Assert.AreEqual(3.00M, tax);
}

[TestMethod]
public void Total_TaxableMix_EqualsSumOfItemsPlusTax()
{
    // Arrange - the [TestInitialize] method creates a cart before every test

    // Act - get the total
    decimal total = cart.TotalPrice;

    // Assert - Make sure value is correct
    Assert.AreEqual(43.00M, total);
}
```

You've now created three "happy path" tests: one each to test `SubtotalPrice`, `Tax`, and `TotalPrice`. Run the tests. Two of the three tests in `ShoppingCartTests` fail:

![Failing tests](./img/shopping-cart-fails.png)

Since you named the tests well, you can immediately see which scenarios are failing. If you select a test in the top panel, the bottom panel shows detail about the exact code that failed and the expected and actual values.

By looking at the output, You can determine that the test for tax failed, expecting a value of 3.0 but receiving a value of 4.0. You can also see that the test for total price failed, expecting a value of 43.0, but receiving a value of 44.0.  Since the total price includes the tax, and the tax is wrong, it makes sense to start your investigation in the tax test.

## Step Six: Debug the tax test

To debug the test method `Tax_TaxableItemMix_EqualsTaxOnTaxableItems()`, first add a breakpoint where you suspect there may be a problem. You want to know what's happening in the tax calculation, which is in the `ShoppingCart.Tax` property getter. 

In the `Tutorial` project, open `ShoppingCart.cs` and find the `Tax` getter. Add a breakpoint at the first line of code there by clicking in the gray column to the left of the code. A red dot appears indicating the breakpoint:

![Set a breakpoint](./img/set-breakpoint-2.png)

> Note: A _breakpoint_ is a place in the code where the debugger pauses program execution and allows you to inspect variables to determine how the code is behaving.

Also add a breakpoint where the test code calls `cart.Tax`. Return to `ShoppingCartTests.cs` and add a breakpoint inside `Tax_TaxableItemMix_EqualsTaxOnTaxableItems()`:

![Set a breakpoint](./img/set-breakpoint.png)

Now run the test in debug mode. In the code window, right-click anywhere inside the body of the test method, and select **Debug Test(s)** to start the debugger.

![Start debugging](./img/start-debugging.png)

The debugger starts and the test runs up to your breakpoint. Now you can use your debugging tools and skills to determine the problem. Step through the code by pressing **F10**. The debugger stops inside the `Tax` getter at your second breakpoint:

![Tax getter](./img/tax-getter.png)

Can you see what's wrong? The comment indicates that tax applies only to taxable items. You'd expect to see a condition checking whether the item is taxable before taxing it.

Stop the debugger by clicking on the red square in the debugger toolbar. Then change the `ShoppingCart.Tax` getter by adding in a check for taxability:

```csharp
foreach (IPurchasable item in this.itemsToBuy)
{
    if (item.IsTaxable)
    {
        tax += item.Price * (decimal)this.taxRate;
    }
}
```

If you rerun the tests, all tests pass. By correcting the `Tax` property, you changed both the tax test and the total price test from failing to passing.

## Next steps

In this tutorial, you learned how to create test classes and test methods, run those tests, and debug failing tests.

If you want more practice, you can review the test plan you created in step two, and implement as many of those tests as you'd like.

If you decide to implement these tests, you'll find that several of them uncover bugs in the application, especially around passing negative or null values into constructors. How will you modify the application to "harden" it against bad data?

