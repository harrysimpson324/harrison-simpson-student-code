using EmployeeProjects.Exceptions;
using EmployeeProjects.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeProjects.DAO
{
    public class DepartmentSqlDao : IDepartmentDao
    {
        private readonly string connectionString;

        public DepartmentSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Department GetDepartmentById(int departmentId)
        {
            Department department = null;

            string sql = @"SELECT department_id, name FROM department 
                           WHERE department_id = @department_id;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@department_id", ((object)departmentId ?? DBNull.Value));

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    department = MapRowToDepartment(reader);
                }
            }


            return department;
        }

        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            string sql = "SELECT department_id, name FROM department;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Department department = MapRowToDepartment(reader);
                    departments.Add(department);
                }
            }
            return departments;
        }

        public Department CreateDepartment(Department department)
        {
            throw new DaoException("CreateDepartment() not implemented");
        }

        public Department UpdateDepartment(Department department)
        {
            throw new DaoException("UpdateDepartment() not implemented");
        }

        public int DeleteDepartmentById(int id)
        {
            throw new DaoException("DeleteDepartmentById() not implemented");
        }

        private Department MapRowToDepartment(SqlDataReader reader)
        {
            Department department = new Department();
            department.DepartmentId = Convert.ToInt32(reader["department_id"]);
            department.Name = Convert.ToString(reader["name"]);

            return department;
        }
    }
}
