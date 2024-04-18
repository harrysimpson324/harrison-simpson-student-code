using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Ada Lovelace";
            Console.WriteLine(name);

            // Strings are actually arrays of characters (char).
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e
            char firstCharacter = name[0];
            char lastCharacter = name[name.Length - 1];

            Console.WriteLine($"First and Last Character. {firstCharacter} & {lastCharacter}");

            // 2. How do we write code that prints out the first three characters
            // Output: Ada
            string firstThreeCharacters = name.Substring(0, 3);
            Console.WriteLine($"First 3 characters: {firstThreeCharacters}");

            // 3. Now print out the first three and the last three characters
            // Output: Adaace
            string lastThreecharacters = name.Substring(name.Length - 3);

            Console.WriteLine($"Last 3 characters: {firstThreeCharacters}{lastThreecharacters}");

            // 4. What about the last word?
            // Output: Lovelace
            string[] words = name.Split(' ');
            string lastWord = words[words.Length - 1];

            Console.WriteLine($"Last Word: {lastWord}");

            // 5. Does the string contain inside of it "Love"?
            // Output: true
            bool containsLove = name.Contains("Love");

            Console.WriteLine($"Contains \"Love\": {containsLove}");

            // 6. Where does the string "lace" show up in name?
            // Output: 8
            int laceIndex = name.IndexOf("lace");

            Console.WriteLine($"Index of \"lace\": {laceIndex}");

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3
            int countOfAs = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if(name[i] == 'a' || name[i] == 'A')
                {
                    countOfAs++;
                }
            }

            Console.WriteLine($"Number of \"a's\": {countOfAs}");

            // 8. Replace "Ada Lovelace" with "Ada, Countess of Lovelace"
            name = name.Replace("Ada", "Ada, Countess of");

            Console.WriteLine(name);

            // 9. Set name equal to null.
            name = null;

            // 10. If name is equal to null or "", print out "All Done".
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("All Done");
            }
        }
    }
}
