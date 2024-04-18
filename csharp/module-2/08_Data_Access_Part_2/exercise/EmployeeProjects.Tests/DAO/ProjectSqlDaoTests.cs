using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using EmployeeProjects.DAO;
using EmployeeProjects.Models;
using EmployeeProjects.Exceptions;
using System.Data.SqlClient;

namespace EmployeeProjects.Tests.DAO
{
    [TestClass]
    public class ProjectSqlDaoTests : BaseDaoTests
    {
        private static readonly Project PROJECT_1 = new Project(1, "Project 1", DateTime.Parse("2000-01-02"), DateTime.Parse("2000-12-31"));
        private static readonly Project PROJECT_2 = new Project(2, "Project 2", DateTime.Parse("2001-01-02"), DateTime.Parse("2001-12-31"));

        private static readonly Employee EMPLOYEE_2 = new Employee(2, 2, "First2", "Last2", DateTime.Parse("1982-02-01"), DateTime.Parse("2002-02-03"));
        private static readonly Employee EMPLOYEE_3 = new Employee(3, 1, "First3", "Last3", DateTime.Parse("1983-03-01"), DateTime.Parse("2003-03-04"));

        private ProjectSqlDao dao;
        private ProjectSqlDao invalidDao;


        [TestInitialize]
        public override void Setup()
        {
            dao = new ProjectSqlDao(ConnectionString);
            invalidDao = new ProjectSqlDao(InvalidConnectionString);

            base.Setup();
        }


        [TestMethod]
        public void CreateProject_Creates_Project()
        {
            Project newProject = new Project();
            newProject.Name = "Project Ultima";
            newProject.FromDate = DateTime.Parse("2023-02-01");
            newProject.ToDate = DateTime.Parse("2023-04-01");

            Project createdProject = dao.CreateProject(newProject);
            Assert.IsNotNull(createdProject, "CreateProject returned a null project.");
            Assert.IsTrue(createdProject.ProjectId > 0, "CreateProject did not return a project with id set.");
            Assert.AreEqual(newProject.Name, createdProject.Name, "CreateProject did not return a project with the correct name.");
            Assert.AreEqual(newProject.FromDate, createdProject.FromDate, "CreateProject did not return a project with the correct fromDate.");
            Assert.AreEqual(newProject.ToDate, createdProject.ToDate, "CreateProject did not return a project with the correct toDate.");

            // verify value was saved to database, retrieve it and compare values
            Project retrievedProject = GetProjectByIdForTestVerification(createdProject.ProjectId);
            Assert.IsNotNull(retrievedProject, "CreateProject does not appear to have correctly persisted the newly created project. It could not be found by id.");
            AssertProjectsMatch(createdProject, retrievedProject, "CreateProject does not appear to have fully persisted the newly created project. The retrieved project is incorrect/incomplete.");
        }

        [TestMethod]
        public void CreateProject_Throws_Dao_Exception_For_Data_Integrity_Violaton()
        {
            Project newProject = new Project();
            newProject.Name = PROJECT_1.Name; // non-unique name
            newProject.FromDate = DateTime.Parse("2023-02-01");
            newProject.ToDate = DateTime.Parse("2023-04-01");

            string methodName = "CreateProject";
            try
            {
                dao.CreateProject(newProject);
                Assert.Fail(DidNotThrowAnyExceptionForDataIntegrity(methodName));
            }
            catch (DaoException ex)
            {
                if (ex.Message == $"{methodName}() not implemented")
                {
                    Assert.Fail(ThrewNotImplementedException(methodName));
                }
            }
            catch (Exception)
            {
                Assert.Fail(DidNotThrowDaoExceptionForDataIntegrity(methodName));
            }
        }

        [TestMethod]
        public void LinkProjectEmployee_Adds_Employee_To_List_Of_Employees_For_Project()
        {
            // Get list of employees before link
            int preLinkEmployeeCount = GetProjectEmployeesForTestVerification(1).Count;

            dao.LinkProjectEmployee(1, 3);
            List<Employee> projectEmployees = GetProjectEmployeesForTestVerification(1);
            int postLinkEmployeeCount = projectEmployees.Count;

            Assert.AreEqual(preLinkEmployeeCount + 1, postLinkEmployeeCount, "LinkProjectEmployee did not increase number of employees for project.");
            AssertProjectEmployeesMatch(EMPLOYEE_3, projectEmployees[1], "LinkProjectEmployee did not add correct employee to project.");
        }

        [TestMethod]
        public void UnlinkProjectEmployee_Removes_Employee_From_List_Of_Employees_For_Project()
        {
            // Get list of employees before unlink
            int preUnlinkEmployeeCount = GetProjectEmployeesForTestVerification(2).Count;

            dao.UnlinkProjectEmployee(2, 3);
            List<Employee> projectEmployees = GetProjectEmployeesForTestVerification(2);
            int postUnlinkEmployeeCount = projectEmployees.Count;

            Assert.AreEqual(preUnlinkEmployeeCount - 1, postUnlinkEmployeeCount, "UnlinkProjectEmployee did not decrease number of employees for project.");
            AssertProjectEmployeesMatch(EMPLOYEE_2, projectEmployees[0], "UnlinkProjectEmployee did not remove correct employee from project.");
        }

        [TestMethod]
        public void UpdateProject_Updates_Project()
        {
            Project existingProject = new Project();
            existingProject.ProjectId = PROJECT_2.ProjectId;
            existingProject.Name = "Test Project Update";
            existingProject.FromDate = DateTime.Parse("2003-02-21");
            existingProject.ToDate = DateTime.Parse("2023-02-21");

            Project updatedProject = dao.UpdateProject(existingProject);
            Assert.IsNotNull(updatedProject, "UpdateProject returned a null project.");
            AssertProjectsMatch(updatedProject, existingProject, "UpdateProject returned an incorrect/incomplete project.");

            // verify value was saved to database, retrieve it and compare values
            Project retrievedProject = GetProjectByIdForTestVerification(PROJECT_2.ProjectId);
            AssertProjectsMatch(updatedProject, retrievedProject, "UpdateProject does not appear to have fully persisted the updated project. The retrieved project is incorrect/incomplete.");
        }

        [TestMethod]
        public void UpdateProject_Throws_Dao_Exception_For_Data_Integrity_Violaton()
        {
            Project existingProject = new Project();
            existingProject.ProjectId = PROJECT_2.ProjectId;
            existingProject.Name = PROJECT_1.Name; // non-unique name
            existingProject.FromDate = DateTime.Parse("2003-02-21");
            existingProject.ToDate = DateTime.Parse("2023-02-21");

            string methodName = "UpdateProject";
            try
            {
                dao.UpdateProject(existingProject);
                Assert.Fail(DidNotThrowAnyExceptionForDataIntegrity(methodName));
            }
            catch (DaoException ex)
            {
                if (ex.Message == $"{methodName}() not implemented")
                {
                    Assert.Fail(ThrewNotImplementedException(methodName));
                }
            }
            catch (Exception)
            {
                Assert.Fail(DidNotThrowDaoExceptionForDataIntegrity(methodName));
            }
        }

        [TestMethod]
        public void DeleteProjectById_Deletes_Project()
        {
            int recordsAffected = dao.DeleteProjectById(PROJECT_1.ProjectId);
            Assert.AreEqual(1, recordsAffected, "DeleteProjectById did not return the correct number of rows affected.");
            Project retrievedProject = GetProjectByIdForTestVerification(PROJECT_1.ProjectId);
            Assert.IsNull(retrievedProject, "DeleteProjectById did not remove the project from database.");
        }

        [TestMethod]
        public void DeleteProjectById_With_Invalid_Id_Returns_Zero_Rows_Affected()
        {
            int recordsAffected = dao.DeleteProjectById(999); // non-existent project_id
            Assert.AreEqual(0, recordsAffected, "DeleteProjectById with invalid id did not return the correct number of rows affected.");
        }

        [TestMethod]
        public void ProjectDao_GetMethods_Throw_Dao_Exception_For_Invalid_Connection()
        {
            string methodName;

            methodName = "GetProjectById";
            try
            {
                invalidDao.GetProjectById(1);
                Assert.Fail(DidNotThrowAnyExceptionForInvalidConnection(methodName));
            }
            catch (DaoException)
            {
                // this is expected outcome
            }
            catch (Exception)
            {
                Assert.Fail(DidNotThrowDaoExceptionForInvalidConnection(methodName));
            }

            methodName = "GetProjects";
            try
            {
                invalidDao.GetProjects();
                Assert.Fail(DidNotThrowAnyExceptionForInvalidConnection(methodName));
            }
            catch (DaoException)
            {
                // this is expected outcome
            }
            catch (Exception)
            {
                Assert.Fail(DidNotThrowDaoExceptionForInvalidConnection(methodName));
            }
        }

        [TestMethod]
        public void ProjectDao_Insert_Update_Delete_Methods_Throw_Dao_Exception_For_Invalid_Connection()
        {
            string methodName;

            methodName = "CreateProject";
            try
            {
                invalidDao.CreateProject(PROJECT_1);
                Assert.Fail(DidNotThrowAnyExceptionForInvalidConnection(methodName));
            }
            catch (DaoException ex)
            {
                if (ex.Message == $"{methodName}() not implemented")
                {
                    Assert.Fail(ThrewNotImplementedException(methodName));
                }
            }
            catch (Exception)
            {
                Assert.Fail(DidNotThrowDaoExceptionForInvalidConnection(methodName));
            }

            methodName = "LinkProjectEmployee";
            try
            {
                invalidDao.LinkProjectEmployee(1, 1);
                Assert.Fail(DidNotThrowAnyExceptionForInvalidConnection(methodName));
            }
            catch (DaoException ex)
            {
                if (ex.Message == $"{methodName}() not implemented")
                {
                    Assert.Fail(ThrewNotImplementedException(methodName));
                }
            }
            catch (Exception)
            {
                Assert.Fail(DidNotThrowDaoExceptionForInvalidConnection(methodName));
            }

            methodName = "UnlinkProjectEmployee";
            try
            {
                invalidDao.UnlinkProjectEmployee(1, 1);
                Assert.Fail(DidNotThrowAnyExceptionForInvalidConnection(methodName));
            }
            catch (DaoException ex)
            {
                if (ex.Message == $"{methodName}() not implemented")
                {
                    Assert.Fail(ThrewNotImplementedException(methodName));
                }
            }
            catch (Exception)
            {
                Assert.Fail(DidNotThrowDaoExceptionForInvalidConnection(methodName));
            }

            methodName = "UpdateProject";
            try
            {
                invalidDao.UpdateProject(PROJECT_1);
                Assert.Fail(DidNotThrowAnyExceptionForInvalidConnection(methodName));
            }
            catch (DaoException ex)
            {
                if (ex.Message == $"{methodName}() not implemented")
                {
                    Assert.Fail(ThrewNotImplementedException(methodName));
                }
            }
            catch (Exception)
            {
                Assert.Fail(DidNotThrowDaoExceptionForInvalidConnection(methodName));
            }

            methodName = "DeleteProjectById";
            try
            {
                invalidDao.DeleteProjectById(1);
                Assert.Fail(DidNotThrowAnyExceptionForInvalidConnection(methodName));
            }
            catch (DaoException ex)
            {
                if (ex.Message == $"{methodName}() not implemented")
                {
                    Assert.Fail(ThrewNotImplementedException(methodName));
                }
            }
            catch (Exception)
            {
                Assert.Fail(DidNotThrowDaoExceptionForInvalidConnection(methodName));
            }
        }

        private void AssertProjectsMatch(Project expected, Project actual, string message)
        {
            Assert.AreEqual(expected.ProjectId, actual.ProjectId, message);
            Assert.AreEqual(expected.Name, actual.Name, message);
            Assert.AreEqual(expected.FromDate, actual.FromDate, message);
            Assert.AreEqual(expected.ToDate, actual.ToDate, message);
        }

        public static void AssertProjectEmployeesMatch(Employee expected, Employee actual, string message)
        {
            Assert.AreEqual(expected.EmployeeId, actual.EmployeeId, message);
            Assert.AreEqual(expected.DepartmentId, actual.DepartmentId, message);
            Assert.AreEqual(expected.FirstName, actual.FirstName, message);
            Assert.AreEqual(expected.LastName, actual.LastName, message);
            Assert.AreEqual(expected.BirthDate, actual.BirthDate, message);
            Assert.AreEqual(expected.HireDate, actual.HireDate, message);
        }

        // test-specific implementations of GetProjectById and GetProjectEmployees to be independent of DAO class
        private Project GetProjectByIdForTestVerification(int id)
        {
            Project project = null;
            string sql = "SELECT project_id, name, from_date, to_date FROM project WHERE project_id = @project_id";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@project_id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Project mappedProject = new Project();
                    mappedProject.ProjectId = Convert.ToInt32(reader["project_id"]);
                    mappedProject.Name = Convert.ToString(reader["name"]);
                    if (reader["from_date"] != DBNull.Value)
                    {
                        mappedProject.FromDate = Convert.ToDateTime(reader["from_date"]);
                    }
                    if (reader["to_date"] != DBNull.Value)
                    {
                        mappedProject.ToDate = Convert.ToDateTime(reader["to_date"]);
                    }
                    project = mappedProject;
                }
            }
            return project;
        }

        private List<Employee> GetProjectEmployeesForTestVerification(int id)
        {
            List<Employee> projectEmployees = new List<Employee>();
            string sql = "SELECT e.employee_id, e.department_id, e.first_name, e.last_name, e.birth_date, e.hire_date FROM employee e " +
                    "JOIN project_employee pe ON e.employee_id = pe.employee_id " +
                    "WHERE pe.project_id = @project_id";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@project_id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee mappedEmployee = new Employee();
                    mappedEmployee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                    mappedEmployee.DepartmentId = Convert.ToInt32(reader["department_id"]);
                    mappedEmployee.FirstName = Convert.ToString(reader["first_name"]);
                    mappedEmployee.LastName = Convert.ToString(reader["last_name"]);
                    mappedEmployee.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                    mappedEmployee.HireDate = Convert.ToDateTime(reader["hire_date"]);
                    projectEmployees.Add(mappedEmployee);
                }
            }
            return projectEmployees;
        }
    }
}
