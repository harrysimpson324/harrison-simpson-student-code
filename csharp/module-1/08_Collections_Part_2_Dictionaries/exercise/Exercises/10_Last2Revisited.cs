using System.Collections.Generic;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Just when you thought it was safe to get back in the water --- last2Revisited!!!!
         *
         * Given an array of strings, for each string, its last2 count is the number of times that a subString length 2
         * appears in the string and also as the last 2 chars of the string.
         *
         * We don't count the end subString, so "hixxxhi" has a last2 count of 1, but the subString may overlap a prior
         * position by one.  For instance, "xxxx" has a count of 2: one pair at position 0, and the second at position 1.
         * The third pair at position 2 is the end subString, which we don't count.
         *
         * Return a Dictionary<string, int> where the keys are the strings from the array and the values are their last2 counts.
         *
         * Last2Revisited(["hixxhi", "xaxxaxaxx", "axxxaaxx"]) → {"hixxhi": 1, "xaxxaxaxx": 1, "axxxaaxx": 2}
         *
         */
        public Dictionary<string, int> Last2Revisited(string[] words)
        {
            return null;
        }
    }
}
