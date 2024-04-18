using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using USCitiesAndParks.Exceptions;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public class ParkSqlDao : IParkDao
    {
        private readonly string connectionString;

        public ParkSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Park GetParkById(int parkId)
        {
            Park park = null;

            string sql = "SELECT park_id, park_name, date_established, area, has_camping FROM park WHERE park_id = @park_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@park_id", parkId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        park = MapRowToPark(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException($"SQL exception occurred", ex);
            }

            return park;
        }

        public IList<Park> GetParksByState(string stateAbbreviation)
        {
            IList<Park> parks = new List<Park>();

            string sql = "SELECT p.park_id, park_name, date_established, area, has_camping FROM park p " +
                         "JOIN park_state ps ON p.park_id = ps.park_id WHERE state_abbreviation = @state_abbreviation " +
                         "ORDER BY p.park_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@state_abbreviation", stateAbbreviation);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park park = MapRowToPark(reader);
                        parks.Add(park);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException($"SQL exception occurred", ex);
            }

            return parks;
        }

        public Park CreatePark(Park park)
        {
            Park newPark = null;

            string sql = "INSERT INTO park (park_name, date_established, area, has_camping) " +
                         "OUTPUT INSERTED.park_id VALUES (@park_name, @date_established, @area, @has_camping);";

            try
            {
                int newParkId;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@park_name", park.ParkName);
                    cmd.Parameters.AddWithValue("@date_established", park.DateEstablished);
                    cmd.Parameters.AddWithValue("@area", park.Area);
                    cmd.Parameters.AddWithValue("@has_camping", park.HasCamping);

                    newParkId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                newPark = GetParkById(newParkId);
            }
            catch (SqlException ex)
            {
                throw new DaoException($"SQL exception occurred", ex);
            }

            return newPark;
        }

        public Park UpdatePark(Park park)
        {
            Park updatedPark = null;

            string sql = "UPDATE park SET park_name = @park_name, date_established = @date_established, area = @area, has_camping = @has_camping WHERE park_id = @park_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@park_name", park.ParkName);
                    cmd.Parameters.AddWithValue("@date_established", park.DateEstablished);
                    cmd.Parameters.AddWithValue("@area", park.Area);
                    cmd.Parameters.AddWithValue("@has_camping", park.HasCamping);
                    cmd.Parameters.AddWithValue("@park_id", park.ParkId);

                    int numberOfRows = cmd.ExecuteNonQuery();

                    if (numberOfRows == 0)
                    {
                        throw new DaoException("Zero rows affected, expected at least one");
                    }
                }
                updatedPark = GetParkById(park.ParkId);
            }
            catch (SqlException ex)
            {
                throw new DaoException($"SQL exception occurred", ex);
            }

            return updatedPark;
        }

        public int DeleteParkById(int parkId)
        {
            int numberOfRows = 0;

            string parkStateSql = "DELETE FROM park_state WHERE park_id = @park_id;";
            string parkSql = "DELETE FROM park WHERE park_id = @park_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Must delete records in park_state first
                    SqlCommand cmd = new SqlCommand(parkStateSql, conn);
                    cmd.Parameters.AddWithValue("@park_id", parkId);
                    cmd.ExecuteNonQuery();

                    // Now safe to delete record in park
                    cmd = new SqlCommand(parkSql, conn);
                    cmd.Parameters.AddWithValue("@park_id", parkId);
                    numberOfRows = cmd.ExecuteNonQuery();

                }
            }
            catch (SqlException ex)
            {
                throw new DaoException($"SQL exception occurred", ex);
            }

            return numberOfRows;
        }

        public void LinkParkState(int parkId, string stateAbbreviation)
        {
            string sql = "INSERT INTO park_state (park_id, state_abbreviation) VALUES (@park_id, @state_abbreviation);";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@park_id", parkId);
                    cmd.Parameters.AddWithValue("@state_abbreviation", stateAbbreviation);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException($"SQL exception occurred", ex);
            }
        }

        public void UnlinkParkState(int parkId, string stateAbbreviation)
        {
            string sql = "DELETE FROM park_state WHERE park_id = @park_id AND state_abbreviation = @state_abbreviation;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@park_id", parkId);
                    cmd.Parameters.AddWithValue("@state_abbreviation", stateAbbreviation);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException($"SQL exception occurred", ex);
            }
        }

        private Park MapRowToPark(SqlDataReader reader)
        {
            Park park = new Park();
            park.ParkId = Convert.ToInt32(reader["park_id"]);
            park.ParkName = Convert.ToString(reader["park_name"]);
            park.DateEstablished = Convert.ToDateTime(reader["date_established"]);
            park.Area = Convert.ToDecimal(reader["area"]);
            park.HasCamping = Convert.ToBoolean(reader["has_camping"]);

            return park;
        }
    }
}
