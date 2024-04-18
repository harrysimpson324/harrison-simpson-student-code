using System;
using System.Collections.Generic;

namespace CollectionsPart2Lecture
{
    public class CollectionsPart2Lecture
	{
        static void Main(string[] args)
        {

			Console.WriteLine("####################");
			Console.WriteLine("       DICTIONARIES");
			Console.WriteLine("####################");
			Console.WriteLine();

			// Declaring and initializing a Dictionary
			Dictionary<string, string> nameToZip = new Dictionary<string, string>();

			// Adding an item to a Dictionary
			nameToZip["David"] = "44120";
			nameToZip["Dan"] = "44124";
			nameToZip["Elizabeth"] = "44012";

			// Retrieving an item from a Dictionary
			Console.WriteLine("David lives in " + nameToZip["David"]);
			Console.WriteLine("Dan lives in " + nameToZip["Dan"]);
			Console.WriteLine("Elizabeth lives in " + nameToZip["Elizabeth"]);
			Console.WriteLine();

			// Retrieving just the keys from a Dictionary
			Console.WriteLine("We can also retrieve a list of keys and iterate over them using a for loop:");

			//*** Note to instructor:
			//*** The return type of `Dictionary<string, string>.Keys` is a `Dictionary<string, string>.KeyCollection` which may look pretty confusing to students,
			//*** so probably best to use `IEnumerable` and explain it's just another collection type like `List`.
			//*** If you're wondering why not use `nameToZip.Keys.ToList()` is because that will make a *copy* of the keys,
			//*** and will throw an error if you remove one of the elements and loop through the keys again later in the lecture.

			IEnumerable<string> keys = nameToZip.Keys; // returns a Collection of all of the keys in the Dictionary
			foreach (string name in keys)
			{
				Console.WriteLine(name + " lives in " + nameToZip[name]);
			}
			Console.WriteLine();

			// Check to see if a key already exists
			if (nameToZip.ContainsKey("David"))
            {
				Console.WriteLine("David exists");
            }
			Console.WriteLine();

			Console.WriteLine("set 12345 for key David");
			//nameToZip.Add("David", "12345"); // Uncomment this to show exception. The key "David" already exists, so using Add() with a key that already exists will throw an ArgumentException

			nameToZip["David"] = "12345"; // to overwrite a value for an existing key, use the same square bracket syntax

			// Iterate through the key-value pairs in the Dictionary
			foreach (KeyValuePair<string, string> nameZip in nameToZip)
			{
				Console.WriteLine(nameZip.Key + " lives in " + nameZip.Value);
			}
			Console.WriteLine();

			// Remove an element from the Dictionary
			nameToZip.Remove("David");
			Console.WriteLine("removed David");
			Console.WriteLine();

			// loop through again to show David was removed
			foreach (KeyValuePair<string, string> nameZip in nameToZip)
			{
				Console.WriteLine(nameZip.Key + " lives in " + nameZip.Value);
			}
			Console.WriteLine();

		}
	}
}
