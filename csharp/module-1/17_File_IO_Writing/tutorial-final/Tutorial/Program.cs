using System;
using System.IO;

namespace Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            * This book-converter program opens a file that was downloaded from https://www.gutenberg.org/,
            * and converts all its text to uppercase.
            *
            * The program also writes a history log of all the files that it has converted.
            */
            
            // Prompt the user for a file path - path should look like "data/jekyll-and-hyde.txt"
            Console.Write("Enter path to the book file: ");
            string filePath = Console.ReadLine();

 
            // Setup variables used in the loop
            // Count of lines between the start and end markers.
            int lineCount = 0;

            // Create the path for the output file
            string convertedPath = getConvertedPath(filePath);
            // Open both the input and output files.
            try
            {
                using (StreamReader fileInput = new StreamReader(filePath))
                using (StreamWriter writer = new StreamWriter(convertedPath))
                {
                    // Loop until the end of file is reached
                    while (!fileInput.EndOfStream)
                    {
                        // Read the next line into 'lineOfText'
                        string lineOfText = fileInput.ReadLine();
                        lineCount++;

                        // Write the text in uppercase to the output file.
                        writer.WriteLine(lineOfText.ToUpper());
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("*** Problem converting specified file: " + ex.Message);
                return;
            }

            // Tell the user what happened.
            string message = $"Converted {lineCount} lines of file {filePath} " +
                             $"to {convertedPath} on {DateTime.Now}";
            Console.WriteLine(message);

            /*
            Open a "log" file for append, to record all of the actions taken by this program
            throughout history. If the file doesn't exist it will be created. If it already exists, its
            contents will be preserved, and the lines written here will be appended to what was already there.
             */
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
