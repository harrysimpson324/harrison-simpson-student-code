using SearchApplication.Search;
using SearchApplication.Util;
using System;
using System.Collections.Generic;

namespace SearchApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Step Two: Create TELog, and log the start of the application.
                //
                TELog.Log("Search application started");

                // Step Four: Instantiate a Search Domain
                //
                SearchDomain sd = new SearchDomain("data");
                TELog.Log("Indexed files:\n" + sd.ToString());

                //// Step Six: Single word search
                ////
                //SearchEngine se = new SearchEngine(sd);
                //se.IndexFiles();
                //IList<string> foundInFiles = se.Search("squirrel");
                //if (foundInFiles.Count > 0)
                //{
                //    foreach (string file in foundInFiles)
                //    {
                //        Console.WriteLine(file);
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("The search term does not appear in any of the indexed files.");
                //}

                //foundInFiles = se.Search("Larry");
                //if (foundInFiles.Count > 0)
                //{
                //    foreach (string file in foundInFiles)
                //    {
                //        Console.WriteLine(file);
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("The search term does not appear in any of the indexed files.");
                //}

                // Step Seven: Multiple word search
                //
                SearchEngine se = new SearchEngine(sd);
                se.IndexFiles();
                IList<string> foundInFiles = se.Search("telephone line");
                if (foundInFiles.Count > 0)
                {
                    foreach (string file in foundInFiles)
                    {
                        Console.WriteLine(file);
                    }
                }
                else
                {
                    Console.WriteLine("The search term does not appear in any of the indexed files.");
                }
            }
            catch (SearchDomainException ex)
            {
                TELog.Log("Search domain exception occurred:\n" + ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General exception occurred:\n" + ex.StackTrace);
            }
        }
    }
}
