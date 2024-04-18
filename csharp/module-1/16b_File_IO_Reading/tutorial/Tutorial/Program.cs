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


        }
    }
}
