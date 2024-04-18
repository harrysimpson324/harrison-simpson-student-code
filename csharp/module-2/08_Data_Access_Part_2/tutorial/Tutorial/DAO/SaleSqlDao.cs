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

                string sql = "SELECT SUM(total) AS total FROM sale;";

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
            sale.SaleId = Convert.ToInt32(reader["sale_id"]);
            if (reader["total"] is DBNull)
            {
                sale.Total = null;
            }
            else
            {
                sale.Total = Convert.ToDecimal(reader["total"]);
            }
            sale.IsDelivery = Convert.ToBoolean(reader["is_delivery"]);
            if (reader["customer_id"] is DBNull)
            {
                sale.CustomerId = null;
            }
            else
            {
                sale.CustomerId = Convert.ToInt32(reader["customer_id"]);
            }
            
            return sale;
        }
    }
}
