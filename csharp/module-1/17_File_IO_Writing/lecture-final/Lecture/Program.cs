using System;
using Lecture.Aids;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            // Here are a few examples of reading in a file and writing out values
            // to demonstrate their value.
            //ReadingInFiles.ReadACharacterFile();
            //ReadingInFiles.ReadInACSVFile();
            WritingTextFiles.WritingAFile();
            //BinaryFileWriter.WritePrimitiveValues();
            //BinaryImageManipulator.ReadFileIn();
            //PerformanceDemo.SlowPerformance();
            //PerformanceDemo.FastPerformance();

            // Students find value in building something useful.
            // As a group you could build something that prompts the user for data and saves it to a file.
            // OR reads a file in and "processes" the data (geocoding?)

            Console.Write("Press enter to finish");
            Console.ReadLine();
        }
    }
}
