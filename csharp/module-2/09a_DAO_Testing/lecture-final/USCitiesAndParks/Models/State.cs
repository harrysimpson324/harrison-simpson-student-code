namespace USCitiesAndParks.Models
{
    public class State
    {
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }

        public State() { }

        public State(string stateAbbreviation, string stateName)
        {
            StateAbbreviation = stateAbbreviation;
            StateName = stateName;
        }
    }
}
