using System;
using System.Data.SqlClient;
using Tutorial.Models;

namespace Tutorial.DAO
{
    public class SaleSqlDao : ISaleDao
    {
        private readonly string connectionString;

        public SaleSqlDao(string connString)
        {
            connectionString = connString;
        }

        public decimal GetTotalSales()
        {
            decimal totalSales = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Step Two: Add SQL for retrieving total sales
                string sql = "SELECT 0 AS total;";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    totalSales = Convert.ToDecimal(reader["total"]);
                }
            }

            return totalSales;
        }

        public Sale GetSaleById(int saleId)
        {
            Sale sale = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT sale_id, total, is_delivery, customer_id " +
                             "FROM sale " +
                             "WHERE sale_id = @sale_id;";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sale_id", saleId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    sale = MapRowToSale(reader);
                }
            }

            return sale;
        }

        private Sale MapRowToSale(SqlDataReader reader)
        {
            Sale sale = new Sale();
            // Step Three: Copy returned values into an object
            

            
            return sale;
        }
    }
}
