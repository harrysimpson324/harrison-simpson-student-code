# Tutorial for file I/O: writing

In this tutorial, you'll practice opening and writing text into a file. You'll create the flagship product for your new company, Screaming Books, which reads a book file and converts all its text to uppercase.

Your program converts books downloaded from Project Gutenberg. [Project Gutenberg](https://www.gutenberg.org/) is an online library of free eBooks, whose mission is to "to encourage the creation and distribution of eBooks." You can choose from a selection of over 60,000 books to download and read.

This program also tracks the work it completes by adding a message to the end of a log file every time it converts another book.

To get started, open the `FileIOWritingTutorial.sln` solution file in Visual Studio. You'll write your code in the `Program.cs` file under the `Tutorial` project.

## Step One: Review the existing code

The starter code for this tutorial is a simpler version of the book reader you created in the previous tutorial. It asks the user for a book filename and then waits for the user to type and press **Enter**. The program then opens the book file, reads each line, and displays it on the screen. Finally, it prints a message to the user containing the number of lines displayed.

Run this program, and type a filename for a book, such as `data/sherlock-holmes.txt`. You see the book content in the console window, followed by a message showing the number of lines displayed.

## Step Two: Open a file for writing

Instead of displaying text to the user, you want your program to write uppercase lines to a new book file. In this step, you open a new file for the converted book, and write lines to the file.

Under the **Step 2:** comment, create the path for the output file, and add an additional `using` line to open a file to read from *and* a file to write to:

```csharp
// Create the path for the output file
string convertedPath = getConvertedPath(filePath);
try
{
    // Open both the input and output files.
    using (StreamReader fileInput = new StreamReader(filePath))
    using (StreamWriter writer = new StreamWriter(convertedPath))
    {
```

The `getConvertedPath()` method already exists at the bottom of `Program.cs`. Feel free to take a look at it. This method creates a file path similar to that of the book file, but with ".screaming" inserted before the file extension.

C# creates both resources, `fileInput` and `writer`, on entry into the `using` block. When the block exits, C# releases both resources.

Now that you have the output file open, you can write the converted contents of each line to that file.

Inside the loop, replace the line which calls `Console.WriteLine()` with code that writes text to a `StreamWriter`:

```csharp
// Write the text in uppercase to the output file.
writer.WriteLine(lineOfText.ToUpper());
```

The last thing you must do to complete this step is update the message to the user. Since you're no longer displaying the book, update the message which follows the loop to inform the user of the conversion:

```csharp
// Tell the user what happened.
string message = $"Converted {lineCount} lines of file {filePath} " +
                 $"to {convertedPath} on {DateTime.Now}";
Console.WriteLine(message);
```

Run the program and type in a valid book file path. You see something like this:

```
Enter path to the book file: data/sherlock-holmes.txt
Converted 12310 lines of file data/sherlock-holmes.txt to data/sherlock-holmes.screaming.txt on 10/6/2021 4:07:41 PM
```

Look in the `Tutorial/bin/Debug/net6.0/data` folder. You now see a file with a similar name, but containing ".screaming" in its name, such as `sherlock-holmes.screaming.txt`. Open that file, and notice all its text is uppercase.

## Step Three: Write a message to a log file

Next, you want your program to write a message logging its actions every time it runs. This way, you'll have a historical account of all the file conversions. To do this, you must open another file for write access.

When you opened the output file for write in the previous step, your work *overwrote* an existing file if there was one. Since you want to maintain history in a log file, you don't want this behavior. Instead you must open the file for *append*.

After the **Step 3:** comment, add the following code:

```csharp
string auditPath = "BookConverter.log";
// Using a StreamWriter with true passed into the constructor opens the file for append.
try
{
    using (StreamWriter log = new StreamWriter(auditPath, true))
    {
        log.WriteLine(message);
    }
} catch (IOException ex)
{
    Console.WriteLine("*** Problem writing log file: " + ex.Message);
}
```

This code creates a new `StreamWriter` for you to add lines to the file, but if the file previously existed, your new lines get added at the end of the file.

After you run your program a few times, look in the file `BookConverter.log`. You see new messages added each time you run it, without removing the messages that were already there:

```
Converted 12310 lines of file data/sherlock-holmes.txt to data/sherlock-holmes.screaming.txt on 10/6/2021 4:07:41 PM
Converted 6206 lines of file data/fairy-tales.txt to data/fairy-tales.screaming.txt on 10/6/2021 5:12:01 PM
Converted 2935 lines of file data/jekyll-and-hyde.txt to data/jekyll-and-hyde.screaming.txt on 10/7/2021 9:12:17 AM
```

## Next steps

Inspecting existing code is a great way to learn to program. In this tutorial, the method `getConvertedFile()` was already there for you when you started. Its job is to take a file path, and create a new path with the string ".screaming" inserted in the filename.

It uses the `string` methods `LastIndexOf()` and two overloads of `Substring()`. Examine this method until you understand how it works.