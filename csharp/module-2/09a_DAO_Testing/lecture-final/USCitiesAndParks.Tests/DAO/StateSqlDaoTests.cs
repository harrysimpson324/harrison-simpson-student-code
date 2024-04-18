using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using USCitiesAndParks.DAO;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.Tests
{
    [TestClass]
    public class StateSqlDaoTests : BaseDaoTests
    {
        private static readonly State STATE_A = new State("AA", "State A");
        private static readonly State STATE_B = new State("BB", "State B");
        private static readonly State STATE_C = new State("CC", "State C");

        private StateSqlDao dao;

        [TestInitialize]
        public override void Setup()
        {
            dao = new StateSqlDao(ConnectionString);
            base.Setup();
        }

        [TestMethod]
        public void GetStateByAbbreviation_With_Valid_Abbreviation_Returns_Correct_State()
        {
            State state = dao.GetStateByAbbreviation("AA");
            AssertStatesMatch(STATE_A, state);

            state = dao.GetStateByAbbreviation("BB");
            AssertStatesMatch(STATE_B, state);
        }

        [TestMethod]
        public void GetStateByAbbreviation_With_Invalid_Abbreviation_Returns_Null_State()
        {
            State state = dao.GetStateByAbbreviation("XX");
            Assert.IsNull(state);
        }

        [TestMethod]
        public void GetStateByCapital_With_Valid_City_Returns_Correct_State()
        {
            State state = dao.GetStateByCapital(1);
            AssertStatesMatch(STATE_A, state);

            state = dao.GetStateByCapital(2);
            AssertStatesMatch(STATE_B, state);
        }

        [TestMethod]
        public void GetStateByCapital_With_Invalid_City_Returns_Null_State()
        {
            State state = dao.GetStateByCapital(99); // not in table
            Assert.IsNull(state);

            state = dao.GetStateByCapital(4); // in table, but not capital
            Assert.IsNull(state);
        }

        [TestMethod]
        public void GetStates_Returns_Correct_States()
        {
            IList<State> states = dao.GetStates();

            Assert.AreEqual(3, states.Count);

            AssertStatesMatch(STATE_A, states[0]);
            AssertStatesMatch(STATE_B, states[1]);
            AssertStatesMatch(STATE_C, states[2]);
        }

        private void AssertStatesMatch(State expected, State actual)
        {
            Assert.AreEqual(expected.StateAbbreviation, actual.StateAbbreviation);
            Assert.AreEqual(expected.StateName, actual.StateName);
        }
    }
}
