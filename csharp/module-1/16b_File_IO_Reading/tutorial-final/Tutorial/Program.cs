using System;
using System.IO;

namespace FileIOReadingTutorial
{
    class Program
    {
        private const string BEGIN_MARKER = "*** START OF";
        private const string END_MARKER = "*** END OF";
        static void Main(string[] args)
        {
             /*
             * This book-reader program opens a file that was downloaded from https://www.gutenberg.org/, reads
             * through the copyright information at the top until it finds the start of the book content, and
             * then displays the content to the user. It also counts the total lines of book content between the
             * start and the end markers.
             */

            /*
            Step 1: Prompt the user for a filename
             */
            // Prompt the user for a file path - path should look like "data/jekyll-and-hyde.txt"
            Console.Write("Enter path to the book file: ");
            string filePath = Console.ReadLine();

            /*
            Step 2: Step Two: Open the book file and handle errors
            */
            // Setup some variables used in the loop
            bool inBookText = false;    // Are you reading between the start and end markers?
            int lineCount = 0;          // Count of lines between the start and end markers.

            try
            {
                using (StreamReader fileInput = new StreamReader(filePath))
                {
                    /*
                    Step 3: Create a read loop and process the lines
                    */
                    // Loop until the end of file is reached
                    while (!fileInput.EndOfStream)
                    {
                        // Read the next line into 'lineOfText'
                        string lineOfText = fileInput.ReadLine();

                        /*
                        Step 4: Skip the header information before book content
                         */
                        if (lineOfText.StartsWith(BEGIN_MARKER))
                        {
                            inBookText = true;
                            continue;  // No need to process this line...go to the next
                        }

                        /*
                        Step 5: Skip the footer information after book content
                         */
                        if (lineOfText.StartsWith(END_MARKER))
                        {
                            break;  // Once the program finds the end, break out of the loop.
                        }

                        if (inBookText)
                        {
                            // Increment the line count.
                            lineCount++;
                            // Print the line
                            Console.WriteLine(lineCount + ": " + lineOfText);
                        }
                    }

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Tell the user how many lines of content were found.
            Console.WriteLine("Found " + lineCount + " lines of text in " + filePath);
        }
    }
}
