using System;
using System.IO;

namespace SearchApplication.Util
{
    public class TELog
    {
        //// Step Two: Add Log() method

        //public static void Log(string message)
        //{
        //    StreamWriter sw = new StreamWriter("logs/search.log", true);
        //    sw.WriteLine(message);
        //    sw.Close();
        //}


        //// Challenge: Avoid repeatedly opening and closing log file
        ////
        //private static StreamWriter sw = null;

        //public static void Log(string message)
        //{
        //    if (sw == null)
        //    {
        //        sw = new StreamWriter("logs/search.log", true);
        //    }
        //    sw.WriteLine(message);
        //    sw.Flush();
        //}

        // Challenge: Use DateTime in TELog
        //
        private static StreamWriter sw = null;

        public static void Log(string message)
        {
            try
            {
                if (sw == null)
                {
                    string logFileName = "logs/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                    sw = new StreamWriter(logFileName, true);
                }
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                sw.WriteLine(message);
                sw.Flush();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error occurred opening or creating log file:\n" + ex.Message);
                throw new TELogException("Error occurred opening or creating log file:\n" + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("General IO error occurred:\n" + ex.Message);
                throw new TELogException("General IO error occurred:\n" + ex.Message);
            }
        }
    }
}
