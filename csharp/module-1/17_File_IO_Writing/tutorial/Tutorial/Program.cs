using System;
using System.IO;

namespace Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user for a file path - path should look like "data/jekyll-and-hyde.txt"
            Console.Write("Enter path to the book file: ");
            string filePath = Console.ReadLine();


            // Setup variables used in the loop
            // Count of lines between the start and end markers.
            int lineCount = 0;

            /*
            Step 2: Open a file for writing the converted text into it
            */
            try
            {
                using (StreamReader fileInput = new StreamReader(filePath))
                {
                    // Loop until the end of file is reached
                    while (!fileInput.EndOfStream)
                    {
                        // Read the next line into 'lineOfText'
                        string lineOfText = fileInput.ReadLine();
                        lineCount++;

                        // Write the text to the console.
                        Console.WriteLine(lineOfText);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("*** Problem reading specified file: " + ex.Message);
                return;
            }

            // Tell the user what happened.
            string message = $"Displayed {lineCount} lines of file {filePath}";
            Console.WriteLine(message);

            /*
            Step 3:
            Open a "log" file for append, to record all of the actions taken by this program
            throughout history. If the file doesn't exist it will be created. If it already exists, its
            contents will be preserved, and the lines written here will be appended to what was already there.
             */
            
        }

        /**
        * This method gets the filename from the path sent in the argument, and creates another
        * path based on that filename, with ".screaming" inserted before the file extension.
        * So, an input path with the filename "myFile.txt" will return a path with the filename "myFile.screaming.txt".
        * If there is no extension on the input file ("myFile"), then ".screaming" will just be appended ("myFile.screaming").
        */
        static private string getConvertedPath(string bookPath)
        {
            // Insert ".screaming" into the book file path to arrive at a name for the converted file.
            int dotIndex = bookPath.LastIndexOf('.');
            string convertedPath;
            if (dotIndex >= 0)
            {
                // found an extension, like .txt
                convertedPath = bookPath.Substring(0, dotIndex) + ".screaming." + bookPath.Substring(dotIndex + 1);
            }
            else
            {
                // There is no file extension
                convertedPath = bookPath + ".screaming";
            }
            return convertedPath;
        }
    }
}
