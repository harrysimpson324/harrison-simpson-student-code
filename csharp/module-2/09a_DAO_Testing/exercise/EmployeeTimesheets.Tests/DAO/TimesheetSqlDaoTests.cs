using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using EmployeeTimesheets.DAO;
using EmployeeTimesheets.Models;

namespace EmployeeTimesheets.Tests.DAO
{
    [TestClass]
    public class TimesheetSqlDaoTests : BaseDaoTests
    {
        private static readonly Timesheet TIMESHEET_1 = new Timesheet(1, 1, 1, DateTime.Parse("2021-01-01"), 1.0M, true, "Timesheet 1");
        private static readonly Timesheet TIMESHEET_2 = new Timesheet(2, 1, 1, DateTime.Parse("2021-01-02"), 1.5M, true, "Timesheet 2");
        private static readonly Timesheet TIMESHEET_3 = new Timesheet(3, 2, 1, DateTime.Parse("2021-01-01"), 0.25M, true, "Timesheet 3");
        private static readonly Timesheet TIMESHEET_4 = new Timesheet(4, 2, 2, DateTime.Parse("2021-02-01"), 2.0M, false, "Timesheet 4");

        private TimesheetSqlDao dao;


        [TestInitialize]
        public override void Setup()
        {
            dao = new TimesheetSqlDao(ConnectionString);
            base.Setup();
        }

        [TestMethod]
        public void GetTimesheetById_With_Valid_Id_Returns_Correct_Timesheet()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetTimesheetById_With_Invalid_Id_Returns_Null_Timesheet()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetTimesheetsByEmployeeId_With_Valid_Employee_Id_Returns_List_Of_Timesheets_For_Employee()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetTimesheetsByEmployeeId_With_Invalid_Employee_Id_Returns_Empty_List_Of_Timesheets()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetTimesheetsByProjectId_With_Valid_Project_Id_Returns_List_Of_Timesheets_For_Project()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetTimesheetsByProjectId_With_Invalid_Project_Id_Returns_Empty_List_Of_Timesheets()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void CreateTimesheet_Creates_Timesheet()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void UpdateTimesheet_Updates_Timesheet()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void DeleteTimesheetById_Deletes_Timesheet()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetBillableHours_Returns_Correct_Total()
        {
            Assert.Fail();
        }

        private void AssertTimesheetsMatch(Timesheet expected, Timesheet actual)
        {
            Assert.AreEqual(expected.TimesheetId, actual.TimesheetId);
            Assert.AreEqual(expected.EmployeeId, actual.EmployeeId);
            Assert.AreEqual(expected.ProjectId, actual.ProjectId);
            Assert.AreEqual(expected.DateWorked, actual.DateWorked);
            Assert.AreEqual(expected.HoursWorked, actual.HoursWorked);
            Assert.AreEqual(expected.IsBillable, actual.IsBillable);
            Assert.AreEqual(expected.Description, actual.Description);
        }
    }
}
