using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeProjects.DAO;
using EmployeeProjects.Models;
using System.Data.SqlClient;
using EmployeeProjects.Exceptions;

namespace EmployeeProjects.Tests.DAO
{
    [TestClass]
    public class EmployeeSqlDaoTests : BaseDaoTests
    {
        private static readonly Employee EMPLOYEE_1 =
            new Employee(1, 1, "First1", "Last1", DateTime.Parse("1981-01-01"), DateTime.Parse("2001-01-02"));
        private static readonly Employee EMPLOYEE_2 =
            new Employee(2, 2, "First2", "Last2", DateTime.Parse("1982-02-01"), DateTime.Parse("2002-02-03"));
        private static readonly Employee EMPLOYEE_3 =
            new Employee(3, 1, "First3", "Last3", DateTime.Parse("1983-03-01"), DateTime.Parse("2003-03-04"));

        private EmployeeSqlDao dao;
        private EmployeeSqlDao invalidDao;

        [TestInitialize]
        public override void Setup()
        {
            dao = new EmployeeSqlDao(ConnectionString);
            invalidDao = new EmployeeSqlDao(InvalidConnectionString);
            base.Setup();
        }

        [TestMethod]
        public void CreateEmployee_Creates_Employee()
        {
            Employee newEmployee = new Employee();
            newEmployee.DepartmentId = 1;
            newEmployee.FirstName = "Test";
            newEmployee.LastName = "Testerson";
            newEmployee.BirthDate = DateTime.Parse("2021-02-21");
            newEmployee.HireDate = DateTime.Parse("2022-02-21");

            Employee createdEmployee = dao.CreateEmployee(newEmployee);

            Assert.IsNotNull(createdEmployee, "CreateEmployees returned a null employee.");
            Assert.IsTrue(createdEmployee.EmployeeId > 0, "CreateEmployee did not return an employee with ID set.");
            Assert.AreEqual(1, newEmployee.DepartmentId, "CreateEmployee did not return an employee with the correct departmentId.");
            Assert.AreEqual("Test", newEmployee.FirstName, "CreateEmployee did not return an employee with the correct firstName.");
            Assert.AreEqual("Testerson", newEmployee.LastName, "CreateEmployee did not return an employee with the correct lastName.");
            Assert.AreEqual(DateTime.Parse("2021-02-21"), newEmployee.BirthDate, "CreateEmployee did not return an employee with the correct birthDate.");
            Assert.AreEqual(DateTime.Parse("2022-02-21"), newEmployee.HireDate, "CreateEmployee did not return an employee with the correct hireDate.");

            // verify value was saved to database, retrieve it and compare values
            Employee retrievedEmployee = GetEmployeeByIdForTestVerification(createdEmployee.EmployeeId);
            Assert.IsNotNull(retrievedEmployee, "CreateEmployee does not appear to have correctly persisted the newly created employee. It could not be found by id.");
            AssertEmployeesMatch(createdEmployee, retrievedEmployee, "CreateEmployee does not appear to have fully persisted the newly created employee. The retrieved employee is incorrect/incomplete.");
        }

        [TestMethod]
        public void CreateEmployee_Throws_Dao_Exception_For_Data_Integrity_Violaton()
        {
            Employee newEmployee = new Employee();
            newEmployee.DepartmentId = 999; // non-existent department_id
            newEmployee.FirstName = "Test";
            newEmployee.LastName = "Testerson";
            newEmployee.BirthDate = DateTime.Parse("2021-02-21");
            newEmployee.HireDate = DateTime.Parse("2022-02-21");

            string methodName = "CreateEmployee";
            try
            {
                dao.CreateEmployee(newEmployee);
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
        public void UpdateEmployee_Updates_Employee()
        {
            Employee existingEmployee = new Employee();
            existingEmployee.EmployeeId = EMPLOYEE_2.EmployeeId;
            existingEmployee.DepartmentId = 1;
            existingEmployee.FirstName = "TestUpdate";
            existingEmployee.LastName = "UpdateTesterson";
            existingEmployee.BirthDate = DateTime.Parse("2003-02-21");
            existingEmployee.HireDate = DateTime.Parse("2023-02-21");

            Employee updatedEmployee = dao.UpdateEmployee(existingEmployee);

            Assert.IsNotNull(updatedEmployee, "UpdateEmployee returned a null employee.");
            AssertEmployeesMatch(updatedEmployee, existingEmployee, "UpdateEmployee returned an incorrect/incomplete employee.");

            // verify value was saved to database, retrieve it and compare values
            Employee retrievedEmployee = GetEmployeeByIdForTestVerification(EMPLOYEE_2.EmployeeId);
            AssertEmployeesMatch(updatedEmployee, retrievedEmployee, "UpdateEmployee does not appear to have fully persisted the updated employee. The retrieved employee is incorrect/incomplete.");
        }

        [TestMethod]
        public void UpdateEmployee_Throws_Dao_Exception_For_Data_Integrity_Violaton()
        {
            Employee existingEmployee = new Employee();
            existingEmployee.EmployeeId = EMPLOYEE_2.EmployeeId;
            existingEmployee.DepartmentId = 999; // non-existent department_id
            existingEmployee.FirstName = "TestUpdate";
            existingEmployee.LastName = "UpdateTesterson";
            existingEmployee.BirthDate = DateTime.Parse("2003-02-21");
            existingEmployee.HireDate = DateTime.Parse("2023-02-21");

            string methodName = "UpdateEmployee";
            try
            {
                dao.UpdateEmployee(existingEmployee);
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
        public void DeleteEmployeeById_Deletes_Employee()
        {
            int recordsAffected = dao.DeleteEmployeeById(EMPLOYEE_1.EmployeeId);
            Assert.AreEqual(1, recordsAffected, "DeleteEmployeeById did not return the correct number of rows affected.");
            Employee retrievedEmployee = GetEmployeeByIdForTestVerification(EMPLOYEE_1.EmployeeId);
            Assert.IsNull(retrievedEmployee, "DeleteEmployeeById did not remove employee from database.");
        }

        [TestMethod]
        public void DeleteEmployeesByDepartmentId_Deletes_Employees()
        {
            int recordsAffected = dao.DeleteEmployeesByDepartmentId(EMPLOYEE_1.DepartmentId);
            Assert.AreEqual(2, recordsAffected, "DeleteEmployeesByDepartmentId did not return the correct number of rows affected.");
            Employee retrievedEmployee = GetEmployeeByIdForTestVerification(EMPLOYEE_1.EmployeeId);
            Assert.IsNull(retrievedEmployee, "DeleteEmployeesByDepartmentId did not remove employeew from database.");
        }

        [TestMethod]
        public void DeleteEmployeeById_With_Invalid_Id_Returns_Zero_Rows_Affected()
        {
            int recordsAffected = dao.DeleteEmployeeById(999); // non-existent employee_id
            Assert.AreEqual(0, recordsAffected, "DeleteEmployeeById with invalid id did not return the correct number of rows affected.");
        }

        [TestMethod]
        public void DeleteEmployeesByDepartmentId_With_Invalid_Id_Returns_Zero_Rows_Affected()
        {
            int recordsAffected = dao.DeleteEmployeesByDepartmentId(999); // non-existent department_id
            Assert.AreEqual(0, recordsAffected, "DeleteEmployeesByDepartmentId with invalid id did not return the correct number of rows affected.");
        }

        [TestMethod]
        public void EmployeeDao_GetMethods_Throw_Dao_Exception_For_Invalid_Connection()
        {
            string methodName;

            methodName = "GetEmployeeById";
            try
            {
                invalidDao.GetEmployeeById(1);
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

            methodName = "GetEmployees";
            try
            {
                invalidDao.GetEmployees();
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

            methodName = "GetEmployeesByFirstNameLastName";
            try
            {
                invalidDao.GetEmployeesByFirstNameLastName("First1", "Last1");
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

            methodName = "GetEmployeesByProjectId";
            try
            {
                invalidDao.GetEmployeesByProjectId(1);
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

            methodName = "GetEmployeesWithoutProjects";
            try
            {
                invalidDao.GetEmployeesWithoutProjects();
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
        public void EmployeeDao_Insert_Update_Delete_Methods_Throw_Dao_Exception_For_Invalid_Connection()
        {
            string methodName;

            methodName = "CreateEmployee";
            try
            {
                invalidDao.CreateEmployee(EMPLOYEE_1);
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

            methodName = "UpdateEmployee";
            try
            {
                invalidDao.UpdateEmployee(EMPLOYEE_1);
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

            methodName = "DeleteEmployeeById";
            try
            {
                invalidDao.DeleteEmployeeById(1);
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

            methodName = "DeleteEmployeesByDepartmentId";
            try
            {
                invalidDao.DeleteEmployeesByDepartmentId(1);
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

        private void AssertEmployeesMatch(Employee expected, Employee actual, string message)
        {
            Assert.AreEqual(expected.EmployeeId, actual.EmployeeId, message);
            Assert.AreEqual(expected.DepartmentId, actual.DepartmentId, message);
            Assert.AreEqual(expected.FirstName, actual.FirstName, message);
            Assert.AreEqual(expected.LastName, actual.LastName, message);
            Assert.AreEqual(expected.BirthDate, actual.BirthDate, message);
            Assert.AreEqual(expected.HireDate, actual.HireDate, message);
        }

        // test-specific implementation of GetEmployeeById to be independent of DAO class
        private Employee GetEmployeeByIdForTestVerification(int id)
        {
            Employee employee = null;
            string sql = "SELECT employee_id, department_id, first_name, last_name, birth_date, hire_date " +
                         "FROM employee WHERE employee_id = @employee_id";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@employee_id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Employee mappedEmployee = new Employee();
                    mappedEmployee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                    mappedEmployee.DepartmentId = Convert.ToInt32(reader["department_id"]);
                    mappedEmployee.FirstName = Convert.ToString(reader["first_name"]);
                    mappedEmployee.LastName = Convert.ToString(reader["last_name"]);
                    mappedEmployee.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                    mappedEmployee.HireDate = Convert.ToDateTime(reader["hire_date"]);
                    employee = mappedEmployee;
                }

                return employee;
            }
        }
    }
}
