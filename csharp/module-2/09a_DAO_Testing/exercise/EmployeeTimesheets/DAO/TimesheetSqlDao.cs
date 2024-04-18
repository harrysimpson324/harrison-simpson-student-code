using EmployeeTimesheets.Exceptions;
using EmployeeTimesheets.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeTimesheets.DAO
{
    public class TimesheetSqlDao : ITimesheetDao
    {
        private readonly string connectionString;

        public TimesheetSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Timesheet GetTimesheetById(int timesheetId)
        {
            Timesheet timesheet = null;
            string sql = @"SELECT timesheet_id, employee_id, project_id, date_worked, hours_worked, is_billable, description 
                                                FROM timesheet 
                                                WHERE timesheet_id = @timesheet_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@timesheet_id", timesheetId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        timesheet = MapRowToTimesheet(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error getting timesheet", ex);
            }

            return timesheet;
        }

        public List<Timesheet> GetTimesheetsByEmployeeId(int employeeId)
        {
            List<Timesheet> timesheets = new List<Timesheet>();
            string sql = @"SELECT timesheet_id, employee_id, project_id, date_worked, hours_worked, is_billable, description 
                                                FROM timesheet 
                                                WHERE employee_id = @employee_id 
                                                ORDER BY timesheet_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@employee_id", employeeId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Timesheet timesheet = MapRowToTimesheet(reader);
                        timesheets.Add(timesheet);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error getting timesheets by employee Id", ex);
            }

            return timesheets;
        }

        public List<Timesheet> GetTimesheetsByProjectId(int projectId)
        {
            List<Timesheet> timesheets = new List<Timesheet>();
            string sql = @"SELECT timesheet_id, employee_id, project_id, date_worked, hours_worked, is_billable, description 
                                                FROM timesheet 
                                                WHERE employee_id = @project_id 
                                                ORDER BY timesheet_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@project_id", projectId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Timesheet timesheet = MapRowToTimesheet(reader);
                        timesheets.Add(timesheet);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error getting timesheets by project Id", ex);
            }

            return timesheets;
        }

        public Timesheet CreateTimesheet(Timesheet newTimesheet)
        {
            int timesheetId;
            string sql = @"INSERT INTO timesheet (employee_id, project_id, date_worked, hours_worked, is_billable, description) 
                                                OUTPUT INSERTED.timesheet_id 
                                                VALUES (@employee_id, @project_id, @date_worked, @hours_worked, @is_billable, @description);";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@employee_id", newTimesheet.EmployeeId);
                    cmd.Parameters.AddWithValue("@project_id", newTimesheet.ProjectId);
                    cmd.Parameters.AddWithValue("@date_worked", newTimesheet.DateWorked);
                    cmd.Parameters.AddWithValue("@hours_worked", newTimesheet.HoursWorked);
                    cmd.Parameters.AddWithValue("@is_billable", newTimesheet.IsBillable);
                    cmd.Parameters.AddWithValue("@description", newTimesheet.Description);

                    timesheetId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error creating timesheet", ex);
            }

            return GetTimesheetById(timesheetId);
        }
        public Timesheet UpdateTimesheet(Timesheet timesheet)
        {
            string sql = @"UPDATE timesheet 
                          SET employee_id = @employee_id, project_id = @project_id, date_worked = @date_worked, 
                          hours_worked = @hours_worked, description = @description 
                          WHERE timesheet_id = @timesheet_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@employee_id", timesheet.EmployeeId);
                    cmd.Parameters.AddWithValue("@project_id", timesheet.ProjectId);
                    cmd.Parameters.AddWithValue("@date_worked", timesheet.DateWorked);
                    cmd.Parameters.AddWithValue("@hours_worked", timesheet.HoursWorked);
                    cmd.Parameters.AddWithValue("@is_billable", timesheet.IsBillable);
                    cmd.Parameters.AddWithValue("@description", timesheet.Description);
                    cmd.Parameters.AddWithValue("@timesheet_id", timesheet.TimesheetId);

                    int numberOfRows = cmd.ExecuteNonQuery();
                    if (numberOfRows == 0)
                    {
                        throw new DaoException("Zero rows affected, expected at least one");
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error updating timesheet", ex);
            }

            return GetTimesheetById(timesheet.TimesheetId);
        }

        public int DeleteTimesheetById(int timesheetId)
        {
            string sql = "DELETE FROM timesheet WHERE timesheet_id = @timesheet_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@timesheet_id", timesheetId);

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error deleting timesheet", ex);
            }
        }

        public decimal GetBillableHours(int employeeId, int projectId)
        {
            decimal billableHours = 0;
            string sql = @"SELECT SUM(hours_worked) AS billable_hours 
                           FROM timesheet 
                           WHERE employee_id = @employee_id AND project_id = @project_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@employee_id", employeeId);
                    cmd.Parameters.AddWithValue("@project_id", projectId);

                    object returnedValue = cmd.ExecuteScalar();

                    // if there are no rows to count, the query returns NULL, which is represented in C# as DBNull
                    // DBNull is technically different from C#'s regular `null`
                    // Convert.ToDecimal() throws an error if passed DBNull
                    if (returnedValue != DBNull.Value)
                    {
                        billableHours = Convert.ToDecimal(returnedValue);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error getting billable hours", ex);
            }

            return billableHours;
        }

        private Timesheet MapRowToTimesheet(SqlDataReader reader)
        {
            Timesheet timesheet = new Timesheet();
            timesheet.TimesheetId = Convert.ToInt32(reader["timesheet_id"]);
            timesheet.EmployeeId = Convert.ToInt32(reader["employee_id"]);
            timesheet.ProjectId = Convert.ToInt32(reader["project_id"]);
            timesheet.DateWorked = Convert.ToDateTime(reader["date_worked"]);
            timesheet.HoursWorked = Convert.ToDecimal(reader["hours_worked"]);
            timesheet.IsBillable = Convert.ToBoolean(reader["is_billable"]);
            timesheet.Description = Convert.ToString(reader["description"]);

            return timesheet;
        }
    }
}
