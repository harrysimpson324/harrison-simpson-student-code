using EmployeeProjects.Exceptions;
using EmployeeProjects.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeProjects.DAO
{
    public class EmployeeSqlDao : IEmployeeDao
    {
        private readonly string connectionString;

        public EmployeeSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();
            string sql = @"SELECT * FROM employee
                           WHERE employee_id = @employee_id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@employee_id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    employee = MapRowToEmployee(reader);
                }
            }

            return employee;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string sql = @"SELECT employee_id, department_id, first_name, last_name, birth_date, hire_date FROM employee;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = MapRowToEmployee(reader);
                    employees.Add(employee);
                }
            }

            return employees;
        }

        public List<Employee> GetEmployeesByFirstNameLastName(string firstNameSearch, string lastNameSearch)
        {
            List<Employee> employees = new List<Employee>();
            string sql = @"SELECT employee_id, department_id, first_name, last_name, birth_date, hire_date FROM employee 
                           WHERE first_name LIKE @first_name AND last_name LIKE @last_name;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@first_name", "%" + firstNameSearch + "%");
                cmd.Parameters.AddWithValue("@last_name", "%" + lastNameSearch + "%");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = MapRowToEmployee(reader);
                    employees.Add(employee);
                }
            }

            return employees;
        }

        public List<Employee> GetEmployeesByProjectId(int projectId)
        {
            List<Employee> employees = new List<Employee>();
            string sql = @"SELECT e.employee_id, department_id, first_name, last_name, birth_date, hire_date FROM employee e 
                           JOIN project_employee pe ON e.employee_id = pe.employee_id 
                           WHERE pe.project_id = @project_id;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@project_id", projectId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = MapRowToEmployee(reader);
                    employees.Add(employee);
                }
            }

            return employees;
        }

        public List<Employee> GetEmployeesWithoutProjects()
        {
            List<Employee> employees = new List<Employee>();
            string sql = @"SELECT employee_id, department_id, first_name, last_name, birth_date, hire_date FROM employee 
                           WHERE employee_id NOT IN (SELECT employee_id FROM project_employee);";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = MapRowToEmployee(reader);
                    employees.Add(employee);
                }
            }

            return employees;
        }

        public Employee CreateEmployee(Employee employee)
        {
            throw new DaoException("CreateEmployee() not implemented");
        }

        public Employee UpdateEmployee(Employee employee)
        {
            throw new DaoException("UpdateEmployee() not implemented");
        }

        public int DeleteEmployeeById(int id)
        {
            throw new DaoException("DeleteEmployeeById() not implemented");
        }

        public int DeleteEmployeesByDepartmentId(int departmentId)
        {
            throw new DaoException("DeleteEmployeesByDepartmentId() not implemented");
        }

        private Employee MapRowToEmployee(SqlDataReader reader)
        {
            Employee employee = new Employee();
            employee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
            employee.DepartmentId = Convert.ToInt32(reader["department_id"]);
            employee.FirstName = Convert.ToString(reader["first_name"]);
            employee.LastName = Convert.ToString(reader["last_name"]);
            employee.BirthDate = Convert.ToDateTime(reader["birth_date"]);
            employee.HireDate = Convert.ToDateTime(reader["hire_date"]);

            return employee;
        }


    }
}
