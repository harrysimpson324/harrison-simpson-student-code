using System;
using System.Collections.Generic;

namespace CollectionsPart1Lecture
{
    public class CollectionsPart1Lecture
	{
        static void Main(string[] args)
        {
			Console.WriteLine("####################");
			Console.WriteLine("       LISTS");
			Console.WriteLine("####################");

			List<string> names = new List<string>();
			names.Add("Frodo");
			names.Add("Sam");
			names.Add("Pippin");
			names.Add("Merry");
			names.Add("Gandalf");
			names.Add("Aragorn");
			names.Add("Boromir");
			names.Add("Gimli");
			names.Add("Legolas");

			Console.WriteLine("####################");
			Console.WriteLine("Lists are ordered");
			Console.WriteLine("####################");

			//the elements will be returned in the same order they were added
			for (int i = 0; i < names.Count; i++)
			{
				Console.WriteLine(names[i]);
			}

			Console.WriteLine("####################");
			Console.WriteLine("Lists allow duplicates");
			Console.WriteLine("####################");

			names.Add("Sam");

			for (int i = 0; i < names.Count; i++)
			{
				Console.WriteLine(names[i]);
			}

			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be inserted in the middle");
			Console.WriteLine("####################");

			names.Insert(2, "David");

			for (int i = 0; i < names.Count; i++)
			{
				Console.WriteLine(names[i]);
			}

			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be removed by index");
			Console.WriteLine("####################");

			names.RemoveAt(2);

			for (int i = 0; i < names.Count; i++)
			{
				Console.WriteLine(names[i]);
			}

			Console.WriteLine("####################");
			Console.WriteLine("Find out if something is already in the List");
			Console.WriteLine("####################");

			bool inList = names.Contains("Samwise");
			Console.WriteLine("Samwise is in the list of names: " + inList);

			Console.WriteLine("####################");
			Console.WriteLine("Find index of item in List");
			Console.WriteLine("####################");

			int indexOfGandalf = names.IndexOf("Gandalf");
			Console.WriteLine("Gandalf is located at index: " + indexOfGandalf);

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be turned into an array");
			Console.WriteLine("####################");

			string[] namesArray = names.ToArray();
			for (int i = 0; i < namesArray.Length; i++)
			{
				Console.WriteLine(namesArray[i]);
			}

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be sorted");
			Console.WriteLine("####################");

			names.Sort(); //Sort() modifies the original list, doesn't require assignment
			for (int i = 0; i < names.Count; i++)
			{
				Console.WriteLine(names[i]);
			}

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be reversed too");
			Console.WriteLine("####################");

			names.Reverse(); //Reverse() modifies the original list, doesn't require assignment
			for (int i = 0; i < names.Count; i++)
			{
				Console.WriteLine(names[i]);
			}

			Console.WriteLine("####################");
			Console.WriteLine("       FOREACH");
			Console.WriteLine("####################");
			Console.WriteLine();

			// Let's loop through names again, but this time using a foreach loop
			// for each name in names
			foreach (string name in names)
			{
				// print the name
				Console.WriteLine(name);
			}
		}
	}
}
