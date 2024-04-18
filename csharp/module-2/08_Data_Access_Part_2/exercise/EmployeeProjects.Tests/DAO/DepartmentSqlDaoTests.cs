using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeProjects.DAO;
using EmployeeProjects.Models;
using System.Data.SqlClient;
using System;
using EmployeeProjects.Exceptions;

namespace EmployeeProjects.Tests.DAO
{
    [TestClass]
    public class DepartmentSqlDaoTests : BaseDaoTests
    {
        private static readonly Department DEPARTMENT_1 = new Department(1, "Department 1");
        private static readonly Department DEPARTMENT_2 = new Department(2, "Department 2");

        private DepartmentSqlDao dao;
        private DepartmentSqlDao invalidDao;

        [TestInitialize]
        public override void Setup()
        {
            dao = new DepartmentSqlDao(ConnectionString);
            invalidDao = new DepartmentSqlDao(InvalidConnectionString);
            base.Setup();
        }

        [TestMethod]
        public void CreateDepartment_Creates_Department()
        {
            Department newDepartment = new Department();
            newDepartment.Name = "New Department Test";

            Department createdDepartment = dao.CreateDepartment(newDepartment);
            Assert.IsNotNull(createdDepartment, "CreateDepartment returned a null department.");
            Assert.IsTrue(createdDepartment.DepartmentId > 0, "CreateDepartment did not return a department with id set");
            Assert.AreEqual(newDepartment.Name, createdDepartment.Name, "CreateDepartment did not return a department with the correct name.");

            // verify value was saved to database, retrieve it and compare values
            Department retrievedDepartment = GetDepartmentByIdForTestVerification(createdDepartment.DepartmentId);
            Assert.IsNotNull(retrievedDepartment, "CreateDepartment does not appear to have correctly persisted the newly created department. It could not be found by id.");
            AssertDepartmentsMatch(createdDepartment, retrievedDepartment, "CreateDepartment does not appear to have fully persisted the newly created department. The retrieved department is incorrect/incomplete.");
        }

        [TestMethod]
        public void CreateDepartment_Throws_Dao_Exception_For_Data_Integrity_Violaton()
        {
            Department newDepartment = new Department();
            newDepartment.Name = DEPARTMENT_1.Name; // non-unique name

            string methodName = "CreateDepartment";
            try
            {
                dao.CreateDepartment(newDepartment);
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
        public void UpdateDepartment_Updates_Department()
        {
            Department existingDepartment = new Department();
            existingDepartment.DepartmentId = DEPARTMENT_2.DepartmentId;
            existingDepartment.Name = "Test Updated Project Name";

            Department updatedDepartment = dao.UpdateDepartment(existingDepartment);
            Assert.IsNotNull(updatedDepartment, "UpdateDepartment returned a null department.");
            AssertDepartmentsMatch(existingDepartment, updatedDepartment, "UpdateDepartment returned an incorrect/incomplete department.");

            // verify value was saved to database, retrieve it and compare values
            Department retrievedDepartment = GetDepartmentByIdForTestVerification(DEPARTMENT_2.DepartmentId);
            AssertDepartmentsMatch(updatedDepartment, retrievedDepartment, "UpdateDepartment does not appear to have fully persisted the updated department. The retrieved department is incorrect/incomplete.");
        }

        [TestMethod]
        public void UpdateDepartment_Throws_Dao_Exception_For_Data_Integrity_Violaton()
        {
            Department existingDepartment = new Department();
            existingDepartment.DepartmentId = DEPARTMENT_2.DepartmentId;
            existingDepartment.Name = DEPARTMENT_1.Name; // non-unique name

            string methodName = "UpdateDepartment";
            try
            {
                dao.UpdateDepartment(existingDepartment);
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
        public void DeleteDepartmentById_Deletes_Department()
        {
            int rowsAffected = dao.DeleteDepartmentById(DEPARTMENT_1.DepartmentId);
            Assert.AreEqual(1, rowsAffected, "DeleteDepartmentById did not return correct number of rows affected.");
            Department retrievedDepartment = GetDepartmentByIdForTestVerification(DEPARTMENT_1.DepartmentId);
            Assert.IsNull(retrievedDepartment, "DeleteDepartmentById did not remove department from database.");
        }

        [TestMethod]
        public void DeleteDepartmentById_With_Invalid_Id_Returns_Zero_Rows_Affected()
        {
            int recordsAffected = dao.DeleteDepartmentById(999); // non-existent department_id
            Assert.AreEqual(0, recordsAffected, "DeleteDepartmentById with invalid id did not return the correct number of rows affected");
        }

        [TestMethod]
        public void DepartmentDao_GetMethods_Throw_Dao_Exception_For_Invalid_Connection()
        {
            string methodName;

            methodName = "GetDepartmentById";
            try
            {
                invalidDao.GetDepartmentById(1);
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

            methodName = "GetDepartments";
            try
            {
                invalidDao.GetDepartments();
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
        public void DepartmentDao_Insert_Update_Delete_Methods_Throw_Dao_Exception_For_Invalid_Connection()
        {
            string methodName;

            methodName = "CreateDepartment";
            try
            {
                invalidDao.CreateDepartment(DEPARTMENT_1);
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

            methodName = "UpdateDepartment";
            try
            {
                invalidDao.UpdateDepartment(DEPARTMENT_1);
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

            methodName = "DeleteDepartmentById";
            try
            {
                invalidDao.DeleteDepartmentById(1);
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

        private void AssertDepartmentsMatch(Department expected, Department actual, string message)
        {
            Assert.AreEqual(expected.DepartmentId, actual.DepartmentId, message);
            Assert.AreEqual(expected.Name, actual.Name, message);
        }

        // test-specific implementation of GetDepartmentById to be independent of DAO class
        private Department GetDepartmentByIdForTestVerification(int id)
        {
            Department department = null;
            string sql = "SELECT department_id, name FROM department WHERE department_id = @department_id";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@department_id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Department mappedDepartment = new Department();
                    mappedDepartment.DepartmentId = Convert.ToInt32(reader["department_id"]);
                    mappedDepartment.Name = Convert.ToString(reader["name"]);
                    department = mappedDepartment;
                }
                return department;

            };
        }
    }
}
