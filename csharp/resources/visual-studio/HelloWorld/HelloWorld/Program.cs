using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Today is " + DateTime.Today.ToLongDateString());
            Console.WriteLine("The current time is " + DateTime.Now.ToShortTimeString());
        }
    }
}
