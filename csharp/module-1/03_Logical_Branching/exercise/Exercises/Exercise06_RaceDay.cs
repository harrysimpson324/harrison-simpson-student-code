using System;
using System.Collections.Generic;
using System.Text;

namespace TechElevator.Exercises.LogicalBranching
{
    public class RaceDay
    {
        /*
         * Registration for your company's annual 10K is underway.
         * Participants are assigned to a block based on their age (int) and whether
         * they registered early (bool).
         * 
         * Return a participant's block according to the following criteria:
         * If they are >= 18 and registered early, they join the first block.
         * If they are >= 18 and did not register early, they join the second block.
         * If they are < 18, they join the third block.
         * 
         * Given a runner's age (int) and early-registration status (bool), return
         * their assigned race block:
         * 
         * Examples:
         * DetermineRaceBlock(17, false) ➔ 3
         * DetermineRaceBlock(17, true) ➔ 3
         * DetermineRaceBlock(18, false) ➔ 2
         * DetermineRaceBlock(18, true) ➔ 1
         * DetermineRaceBlock(30, false) ➔ 2
         * DetermineRaceBlock(30, true) ➔ 1
         */
        public int DetermineRaceBlock(int age, bool isEarlyRegistration)
        {
            return 0;
        }

        /*
         * The race organizers need to assign each participant a bib number. The bib
         * number is either their registration number, or their registration number + 1000,
         * depending on the following conditions:
         * 
         * If they are >= 18 and registered early their race bib number is their
         * registration number + 1000.
         * If they are < 18, or >= 18 and did not register early, their race bib
         * number is their registration number.
         * 
         * Given a participant's age (int), their registration number (int), and whether
         * they registered early (bool), return their race bib number (int).
         * 
         * Examples:
         * GetBibNumber(17, 500, false) ➔ 500
         * GetBibNumber(17, 500, true) ➔ 500
         * GetBibNumber(18, 600, false) ➔ 600
         * GetBibNumber(18, 600, true) ➔ 1600
         * GetBibNumber(30, 700, false) ➔ 700
         * GetBibNumber(30, 700, true) ➔ 1700
         */
        public int GetBibNumber(int age, int registrationNumber, bool isEarlyRegistration)
        {
            return 0;
        }

        /*
         * As the race approaches full capacity, organizers need to adjust the bib
         * numbering system.
         * 
         * Given a participant's age (int), their registration number (int), and
         * whether they registered early (bool), return their race bib number (int).
         * Apply the same rules as above with one exception. If a runner did not
         * register early and their registration number is > 1000, return -1 to indicate
         * that there are no more spots left.
         * 
         * GetConfirmedBibNumber(17, 500, false) ➔ 500
         * GetConfirmedBibNumber(17, 500, true) ➔ 500
         * GetConfirmedBibNumber(18, 600, false) ➔ 600
         * GetConfirmedBibNumber(18, 600, true) ➔ 1600
         * GetConfirmedBibNumber(30, 700, false) ➔ 700
         * GetConfirmedBibNumber(30, 700, true) ➔ 1700
         * GetConfirmedBibNumber(30, 1001, false) ➔ -1
         * GetConfirmedBibNumber(30, 1001, true) ➔ 2001
         */
        public int GetConfirmedBibNumber(int age, int registrationNumber, bool isEarlyRegistration)
        {
            return 0;
        }
    }
}
