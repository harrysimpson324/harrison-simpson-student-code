using System.Collections.Generic;

namespace PetElevator.CRM
{
    public class Pet
    {
        public string PetName { get; set; }
        public string Species { get; set; }
        public List<string> Vaccinations { get; set; }

        public Pet(string petName, string species)
        {
            PetName = petName;
            Species = species;
            Vaccinations = new List<string>();
        }

        public string ListVaccinations()
        {
            string vaccString = "";
            foreach (string vaccination in Vaccinations)
            {
                vaccString += vaccination;
                if (Vaccinations.IndexOf(vaccination) < Vaccinations.Count - 1)
                {
                    vaccString += ", ";
                }
            }
            return vaccString;
        }
    }
}
