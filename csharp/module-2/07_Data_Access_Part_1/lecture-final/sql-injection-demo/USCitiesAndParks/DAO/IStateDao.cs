using System.Collections.Generic;
using System;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public interface IStateDao
    {
        State GetStateByAbbreviation(string stateAbbreviation);

        State GetStateByAbbreviationConcatenation(string stateAbbreviation);

        IList<State> GetStatesByName(string stateName);
    }
}
