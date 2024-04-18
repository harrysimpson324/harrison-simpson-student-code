# Tutorial for exception handling

In this tutorial, you'll create a custom exception, and use it to validate user input.

Exceptions and exception handling are more than ways of handling unexpected errors in your application. A custom exception and a well-placed `catch` block can lead to code code which separates detecting problems from telling users about them.

To get started, open the `ExceptionHandlingTutorial.sln` solution file in Visual Studio.

## Step One: Review the starting code

There are two class files provided: `CreditCard.cs` and `Program.cs`.

### `CreditCard.cs`

The `CreditCard` class represents a generic credit card.

It contains four properties:

* `LastName` - The last name of the cardholder.
* `FirstName` - The first name of the cardholder.
* `Number` - The card number.
* `SecurityCode` - The card security code.

The user enters values for each of the properties at runtime.

There are also three methods in the class:

* `Validate()` - This method validates the property values entered by the user. Currently, the method only contains comments listing the validations that you'll write in this tutorial.
* `ToString()` - The base `ToString()` method has been overridden to build a well-formatted string of the `CreditCard` class properties to display to the user.
* `IsDigits(string str)` - This is a helper method which confirms that the `str` argument is all numeric or *digit* characters: `'0'`-`'9'`. It returns `true` if all the characters are digits, otherwise, it returns `false`.

### `Program.cs`

`Program.cs` contains the `Main(string[] args)` method and has no properties.

The `Main()` method begins by creating an instance of a `CreditCard` object. It then starts the validation loop which runs until the user enters valid credit card information:

```csharp
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
```

The validation loop prompts the user to enter values for the `CreditCard` properties `LastName`, `FirstName`, `Number`, and `SecurityCode`.

This information is then validated from inside a `try-catch`.

If the information is valid, meaning that an exception wasn't thrown, the `break` statement runs and the validation loop ends. Otherwise, an exception gets thrown and the validation error message is displayed. The validation loop continues from the top with prompting for the credit card information and validating it.

The validation loop only ends when the credit card information is valid. The valid `CreditCard` object displays the information, and the application ends.

Run the application, and enter whatever values you like when prompted. Since the `Validate()` method has no validation code at this time, any values you enter are valid.

```
Last name: A
First name:
Number: 12345678901234567890123456789012345678901234567890
Security code: dog

Card is valid - Name: `A`, Number: 12345678901234567890123456789012345678901234567890, Security Code: dog
```

## Step Two: Create `CreditCardValidationException` class

To signal a validation error, the `CreditCard.Validate()` method needs to throw a `CreditCardValidationException` with a message detailing the validation error.

You'll need to create the `CreditCardValidationException` class, extend `Exception`, and provide the `CreditCardValidationException(string message)` constructor which accepts the message detailing the exception.

> By convention, custom exceptions always end with the word `Exception`.

```csharp
class CreditCardValidationException : Exception
{
    public CreditCardValidationException(string message) : base(message) { }
}
```

> Tip: Microsoft recommends that custom exceptions implement the following three constructors:
>
> * `MyCustomException(string message)`
> * `MyCustomException()`
> * `MyCustomException(string message, Exception exception)`
>
> In general practice, however, the first is the only constructor typically implemented. The tutorial follows this common practice.

## Step Three: Update the validation loop to catch the `CreditCardValidationException`

It's always best practice to catch the most specific exception you'll handle. Change the generic `catch(Exception ex)` in the validation loop to the specific `catch (CreditCardValidationException ex)`:

```csharp
// ...
catch (CreditCardValidationException ex) // Step 3: Modify validation loop to catch CreditCardValidationException
{
    // ...
}
// ...
```

## Step Four: Validate cardholder name

The `FirstName` and `LastName` properties can't be `null` or blank.

Add the following code in `CreditCard.cs` after the **Step 4:** comment in the `Validate()` method to validate the cardholder's first and last names:

```csharp
// Step 4: Validate cardholder name
if (string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(FirstName))
{
    throw new CreditCardValidationException($"'{FirstName} {LastName}' - Cardholder name is invalid, must provide first and last names.");
}
```

Run the application, and enter values for last name and first name. The application shows the credit card is valid provided you enter values for first two prompts:

```
Last name: Testing
First name: Test
Number:
Security code:

Card is valid - Name: `Test Testing`, Number: , Security Code:
```

## Step Five: Validate card number

The card number must be 13 or 16 characters in length, and all digits, `'0'`-`'9'`. Add this code after the **Step 5:** comment:

```csharp
// Step 5: Validate card number
if (string.IsNullOrEmpty(Number) || ((Number.Length != 13) && (Number.Length != 16)) || (!IsDigits(Number)))
{
    throw new CreditCardValidationException($"'{Number}' - Card number is too short or too long, or not all digits.");
}
```

Run the application, enter values for last name and first name, and a 13 or 16 digit numeric value for the Number. The application shows the credit card is valid if you enter values that fit the validation rules:

```
Last name: Testing
First name: Test
Number: 1234567890123456
Security code:

Card is valid - Name: 'Test Testing', Number: 1234567890123456, Security Code:
```

## Step Six: Validate security code

The security code must be 3 characters in length, and all digits, `'0'` - `'9'`. Add this code after the **Step 6:** comment:

```csharp
// Step 6: Validate security code
if (string.IsNullOrEmpty(SecurityCode) || (SecurityCode.Length != 3) || (!IsDigits(SecurityCode)))
{
    throw new CreditCardValidationException($"'{SecurityCode}' - Security code is too short or too long, or not all digits.");
}
```

Run the application, enter values for last name and first name, a 13 or 16 digit numeric value for the Number, and a 3 digit value for the security code. The application shows the credit card is valid if you enter values that fit the validation rules:

```
Last name: Testing
First name: Test
Number: 1234567890123456
Security code: 123

Card is valid - Name: 'Test Testing', Number: 1234567890123456, Security Code: 123
```

## Step Seven: Create the `MasterCard` class and replace `CreditCard` instance

The `MasterCard` class extends `CreditCard` and overrides the `Validate()` method.

In addition to the validation already performed by the base `Validate()` method, the override checks that the card number begins with a `'5'`:

```csharp
class MasterCard : CreditCard
{
    public override void Validate()
    {
        base.Validate();

        // MasterCard numbers always begin with '5'.
        if (Number[0] != '5')
        {
            throw new CreditCardValidationException($"'{Number}' - Invalid MasterCard card number, must begin with '5'.");
        }
    }
}
```

Once the `MasterCard` class is complete, replace the `CreditCard` instance with `MasterCard` in the `Main()` method.

```csharp
CreditCard cc = new MasterCard();
```

> Note: Only replace the `new CreditCard()`. The variable holding the instance of new `MasterCard` object remains of type `CreditCard`.

Run the application, enter the last and first names, a 13 or 16 digit numeric value with the first character as `'5'` for the Number, and a 3 digit value for the security code. The application shows the credit card is valid if you enter values that fit the validation rules:

```
Last name: Testing
First name: Test
Number: 5234567890123456
Security code: 123

Card is valid - Name: 'Test Testing', Number: 5234567890123456, Security Code: 123
```

## Step Eight: Create the `Visa` class and replace `MasterCard` instance

The `Visa` class extends `CreditCard` and overrides the `Validate()` method.

In addition to the validation already performed by the base `Validate()` method, the override checks that the card number begins with a `'4'`:

```csharp
class Visa : CreditCard
{
    public override void Validate()
    {
        base.Validate();

        // Visa numbers always begin with '4'.
        if (Number[0] != '4')
        {
            throw new CreditCardValidationException($"'{Number}' - Invalid Visa card number, must begin with '4'.");
        }
    }
}
```

Once the `Visa` class is complete, replace the `MasterCard` instance with `Visa` in the `Main()` method:

```csharp
CreditCard cc = new Visa();
```

> Note: Only replace the `new MasterCard()`. The variable holding the instance of new `Visa` object remains of type `CreditCard`.

Run the application, enter the last and first names, a 13 or 16 digit numeric value with the first character as `'4'` for the Number, and a 3 digit value for the security code. The application shows the credit card is valid if you enter values that fit the validation rules:

```
Last name: Testing
First name: Test
Number: 4234567890123456
Security code: 123

Card is valid - Name: 'Test Testing', Number: 4234567890123456, Security Code: 123
```

The validation for all the supported credit cards is now complete.

Once the `CreditCardValidationException` class was created, and the `catch` inside the validation loop was changed from the generic `Exception` to the more specific `CreditCardValidationException`, the validation loop remained unchanged.

The validation rules are encapsulated in their respective classes, `CreditCard`, `MasterCard`, and `Visa`, while the custom exception `CreditCardValidationException` serves as a clean separation between the code that knows the validation rules from the code in the validation loop. The `CreditCardValidationException` is thrown by the rules and caught by the application UI.

Exceptions and exception handling isn't limited to smoothing the occasional bump in your application's path. With some planning, and a little code, exceptions can help you write code that keeps separate concerns separate.

## Next steps

Long strings of digits like the value of the `Number` property tend to be broken up into segments, for instance, `"0000-0000-0000-0000"`. Modify the `Number` validation rules to accept hyphens `'-'` while preserving the existing rules of a length of 13 or 16 digits, `'0'` - `'9'`.

Inspecting existing code is a great way to learn to program. In this tutorial, the method `IsDigits()` was already there for you when you started. The method checks that the `string` argument contains only digit characters, and returns `true` is this is so, otherwise, it returns `false`.

It uses a foreach to loop through the character array of the `string` argument check for digits using the `string` `ToCharArray()` and `char` `IsDigit()` methods. Examine this method until you understand how it works. In particular, you should understand the difference between the `IsDigits()` and `IsDigit()` methods.
