using System;
using System.Data.SqlClient;

namespace USCitiesAndParks.DAO
{
    public class ParkSqlDao : IParkDao
    {
        private readonly string connectionString;

        public ParkSqlDao(string connString)
        {
            connectionString = connString;
        }

        public int GetParkCount()
        {
            int count = 0;

            string sql = "SELECT COUNT(*) as count FROM park;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    count = Convert.ToInt32(reader["count"]);
                }
            }

            return count;

        }
    }
}
