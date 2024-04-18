# Intro to objects tutorial

In this tutorial, you'll practice creating strings and calling methods on the `string` class. By the end of this tutorial, you'll have written code that:

- Uses the `new` operator to create objects of the `string` class.
- Calls some common string methods to interrogate and manipulate strings.

To get started, open the solution file, `IntroToObjectsTutorial.sln`, in Visual Studio. You'll write your code in the `Program.cs` file.

## Step One: Create strings

In the first part of this tutorial, you'll create new strings in several ways. `string` is a *reference* type, which means that the data that makes up a string is stored in Heap memory, and a reference (the memory address or location) of that data is stored in the `string` variable on the Stack. Whenever you need to create a new instance of a reference type, you use the `new` operator.

### From a `char` array
At its heart, a string is an array of characters. As such, you can create a new string from an array of characters with the `new` operator. Under the `Step 1:` comment in your code, type or paste the following:

```csharp
// Create a new string from an array of characters
char[] helloChars = new char[] { 'h', 'e', 'l', 'l', 'o', '!' };
string greeting = new string(helloChars);
Console.WriteLine("Greeting: " + greeting);
```

In that code, you used the `new` operator to allocate a chunk of Heap memory large enough to store a string containing the characters `h`, `e`, `l`, `l`, `o`, and `!`. The `new` operator returned the address of the newly created string, and you stored that address into the `greeting` variable.

Run the program, and you'll see `Greeting: hello!` on the console.

### From a string literal

Another way to create a new string is to pass a *string literal*, which is enclosed in double-quotes. Under your previous code, type this:

```csharp
// You can also create a string by passing in a literal value, in double-quotes
string salutation = new string("Welcome my friend");
Console.WriteLine("Salutation: " + salutation);
```

When you run the program, your output looks like this:
```
Greeting: hello!
Salutation: Welcome my friend
```

### Using the string literal syntax

Since strings are so frequently used, C# allows you to *assign* a string literal to a variable. The C# compiler recognizes this as a request for new memory.

Add the following code:

```csharp
// C# allows you to skip the *new* operator when creating a new string
string toast = "May the compiler rise up to meet you.";
Console.WriteLine("Toast: " + toast);
```

This is by far the most common method of creating a new string in C#. Your output now looks like this:

```
Greeting: hello!
Salutation: Welcome my friend
Toast: May the compiler rise up to meet you.
```

## Step Two: Try out some `string` methods

Next, you'll practice using some of the more common methods on the `string` class. These methods either give you information about a string, or use a string to create a new string that has been changed in some way.

First, you'll ask the user to type in a sentence, and then you'll call methods to get variations of that sentence to display to the user.

> In these examples, the user is typing "The quick brown fox jumps over the lazy dog." You can type this or any other sentence at the prompt. Feel free to experiment; change the input sentence and see how the output changes.

Under the `Step 2:` comment, type the following:

```csharp
// Prompt the user to enter a sentence
Console.Write("Please type a sentence: ");
string sentence = Console.ReadLine();
```

This code prompts the user to type a message and waits for the user to type something and press **Enter**. Then `sentence` holds the address of the string value the user typed.

First, echo the value back to the user:

```csharp
// Print the sentence back to the user
Console.WriteLine(sentence);
```

If you run the program, you'll see the message `Please type a sentence: ` on the console. The program is waiting for you to type something. Click in the console window, and type a sentence, then press the **Enter** key. You'll see the same sentence printed on the next line.

### `ToUpper()` and `ToLower()`

Use these methods to transform the original sentence by either making every character uppercase or lowercase. Then print the results to the user:

```csharp
// Print the sentence in all upper-case
string uppercaseSentence = sentence.ToUpper();
Console.WriteLine(uppercaseSentence);

// Print the sentence in all lower-case
Console.WriteLine(sentence.ToLower());
```

Run the program, and you'll see something like this:

```
Please type a sentence: The quick brown fox jumped over the lazy dog.
The quick brown fox jumped over the lazy dog.
THE QUICK BROWN FOX JUMPED OVER THE LAZY DOG.
the quick brown fox jumped over the lazy dog.
```

### Find the length of the first word

The `Length` property contains how many characters long the string is.

The `IndexOf()` method allows you to find the first occurrence of a smaller string within the string.

You'll use these two methods to report the length of the first word in the sentence to the user. Type this code:

```csharp
// Find the first space character
int firstSpace = sentence.IndexOf(" ");
// Report the length of the first word
if (firstSpace == -1)
{
    // IndexOf returns -1 when the string is not found.
    // If there is no space, assume the whole sentence is one word.
    Console.WriteLine("The first word is " + sentence.Length + " characters long.");
}
else
{
    // Report the length of the first word
    Console.WriteLine("The first word is " + firstSpace + " characters long.");
}
```

You called `IndexOf()` to find the space character. This method returns the index of the first occurrence of that string within `sentence`. If the `" "` string is *not* found inside sentence, `IndexOf()` returns -1.

If there is no space character—meaning `IndexOf()` returned -1—then you can assume the whole sentence is one word. So you used the `Length` property to report the length of `sentence`.

If `IndexOf()` returns a non-negative number, the space was found. You report that value as the length of the first word. For example, if the sentence starts with "The quick", then `IndexOf()` returns 3 (the fourth character).  Three is the length of the first word.

Output:

```
Please type a sentence: The quick brown fox jumped over the lazy dog.
...
The first word is 3 characters long.
```
or
```
Please type a sentence: Eureka!
...
The first word is 7 characters long.
```

### Find and replace inside a string

Now you'll use the `Replace()` method to locate a substring inside the string, and replace it with another substring.

Add the following code:

```csharp
// Replace the word "the" with "the one and only"
Console.WriteLine(sentence.Replace("the", "the one and only"));
```

This finds *every* occurrence of the string "the", replaces it with the string "the one and only", and returns the resulting string. Remember that the original string isn't modified.

Output:
```
Please type a sentence: The quick brown fox jumped over the lazy dog.
...
The quick brown fox jumped over the one and only lazy dog.
```

Try it again with the initial "The" non-capitalized:

```
Please type a sentence: the quick brown fox jumped over the lazy dog.
...
the one and only quick brown fox jumped over the one and only lazy dog.
```

Did you notice the difference? In the first example, the word *The* wasn't a match for the `Replace()` method, which searches for *the*. In most string methods that involved searching or comparing, the case of the letters in the word matter. "T" isn't equal to "t."

### Split the sentence into words and reassemble it

Now, you'll change the form of `sentence` from a string into an array of strings, each element representing one word. To do that, use the `Split()` method:

```csharp
// list the words (split)
string[] words = sentence.Split(" ");
Console.WriteLine("The words in this sentence:");
for (int i = 0; i < words.Length; i++)
{
    Console.WriteLine(words[i]);
}
```

In the first line, `Split()` looks for the *delimiter*, or *separator*, within the string, and "breaks" the string up every time it finds that delimiter. You passed in a single space (" ") character as the delimiter. The return value from that method is an array of the substrings that fall between the delimiters. The delimiters are stripped away, and don't end up in the result array.

The final three lines use a *for* loop to list the individual words on the console. The output looks like this:

```
Please type a sentence: The quick brown fox jumped over the lazy dog.
...
The words in this sentence:
The
quick
brown
fox
jumped
over
the
lazy
dog.
```

Now take that array of strings (`string[]`) called `words`, and *join* each string together to form a single string again. Like `Split()`, the `Join()` method requires a *delimiter* parameter. In this case, the delimiter is *inserted* between each string element as the new string is formed.

Add this code:
```csharp
// Re-assemble the sentence with a new delimiter
string dashSentence = String.Join("-->", words);
Console.WriteLine(dashSentence);
```

Output:

```
Please type a sentence: The quick brown fox jumped over the lazy dog.
The quick brown fox jumped over the lazy dog.
...
The-->quick-->brown-->fox-->jumped-->over-->the-->lazy-->dog.
```

### Show the original string

You've called methods to uppercase, lowercase, replace, split, and join the string that's referenced by the `sentence` variable. As a reminder that *strings are immutable*, print out the original string that was typed by the user:

```csharp
// Print the initial sentence. Notice it has not changed.
Console.WriteLine(sentence);
```

When you run the program, you'll see that the printed string is the same string that you first typed into the console. This is a reminder that a string may not be changed in place. All the methods you called take the original string, manipulate its characters, and return a new string, without modifying the original.


## Next steps

You've begun to learn about the `string` class and some of its methods. You can explore more string methods in the [C# documentation.](https://learn.microsoft.com/en-us/dotnet/api/system.string?view=net-7.0&viewFallbackFrom=net-6)

Try combining the methods you have learned to solve more complex problems. For example:
- Can you find the number of words in a sentence? (Hint: use `Split()` and the `Length` property of the resulting array)
- Can you get the last character in a string? (Hint: use `Substring()` and `Length`)



