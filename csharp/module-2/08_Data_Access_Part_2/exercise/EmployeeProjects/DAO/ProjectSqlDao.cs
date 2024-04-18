using EmployeeProjects.Exceptions;
using EmployeeProjects.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeProjects.DAO
{
    public class ProjectSqlDao : IProjectDao
    {
        private readonly string connectionString;

        public ProjectSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Project GetProjectById(int projectId)
        {
            Project project = null;
            string sql = "SELECT project_id, name, from_date, to_date FROM project WHERE project_id = @project_id;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@project_id", projectId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    project = MapRowToProject(reader);
                }
            }

            return project;
        }

        public List<Project> GetProjects()
        {
            List<Project> projects = new List<Project>();
            string sql = "SELECT project_id, name, from_date, to_date FROM project;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Project project = MapRowToProject(reader);
                    projects.Add(project);
                }
            }

            return projects;
        }

        public Project CreateProject(Project newProject)
        {
            throw new DaoException("CreateProject() not implemented");
        }

        public void LinkProjectEmployee(int projectId, int employeeId)
        {
            throw new DaoException("LinkProjectEmployee() not implemented");
        }

        public void UnlinkProjectEmployee(int projectId, int employeeId)
        {
            throw new DaoException("UnlinkProjectEmployee() not implemented");
        }

        public Project UpdateProject(Project project)
        {
            throw new DaoException("UpdateProject() not implemented");
        }

        public int DeleteProjectById(int projectId)
        {
            throw new DaoException("DeleteProjectById() not implemented");
        }

        private Project MapRowToProject(SqlDataReader reader)
        {
            Project project = new Project();
            project.ProjectId = Convert.ToInt32(reader["project_id"]);
            project.Name = Convert.ToString(reader["name"]);
            if (reader["from_date"] is DBNull)
            {
                project.FromDate = null;
            }
            else
            {
                project.FromDate = Convert.ToDateTime(reader["from_date"]);
            }
            if (reader["to_date"] is DBNull)
            {
                project.ToDate = null;
            }
            else
            {
                project.ToDate = Convert.ToDateTime(reader["to_date"]);
            }

            return project;
        }
    }
}
