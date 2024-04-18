using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Tutorial.Exceptions;
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

        public Sale GetSaleById(int saleId)
        {
            Sale sale = null;

            string sql = "SELECT sale_id, total, is_delivery, customer_id " +
                         "FROM sale " +
                         "WHERE sale_id = @sale_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sale_id", saleId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        sale = MapRowToSale(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred getting sale by ID", ex);
            }

            return sale;
        }

        public IList<Sale> GetSalesByCustomerId(int customerId)
        {
            List<Sale> sales = new List<Sale>();

            string sql = "SELECT sale_id, total, is_delivery, customer_id " +
                         "FROM sale " +
                         "WHERE customer_id = @customer_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@customer_id", customerId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Sale sale = MapRowToSale(reader);
                        sales.Add(sale);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred getting sales by customer ID", ex);
            }

            return sales;
        }

        public Sale CreateSale(Sale sale)
        {
            Sale newSale;

            string sql = "INSERT INTO sale (total, is_delivery, customer_id) " +
                         "OUTPUT INSERTED.sale_id " +
                         "VALUES (@total, @is_delivery, @customer_id);";

            int saleId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@total", sale.Total);
                    cmd.Parameters.AddWithValue("@is_delivery", sale.IsDelivery);
                    cmd.Parameters.AddWithValue("@customer_id", sale.CustomerId);                    

                    saleId = (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred creating sale", ex);
            }

            newSale = GetSaleById(saleId);
            return newSale;
        }

        public Sale UpdateSale(Sale sale)
        {
            Sale updatedSale;

            string sql =
                    "UPDATE sale SET total = @total, is_delivery = @is_delivery, customer_id = @customer_id " +
                    "WHERE sale_id = @sale_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@total", sale.Total);
                    cmd.Parameters.AddWithValue("@is_delivery", sale.IsDelivery);
                    cmd.Parameters.AddWithValue("@customer_id", sale.CustomerId);
                    cmd.Parameters.AddWithValue("@sale_id", sale.SaleId);

                    int numberOfRows = cmd.ExecuteNonQuery();
                    if (numberOfRows == 0)
                    {
                        throw new DaoException("Zero rows affected, expected at least one");
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred updating sale", ex);
            }

            updatedSale = GetSaleById(sale.SaleId);
            return updatedSale;
        }

        public int DeleteSaleById(int saleId)
        {
            int numberOfRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "DELETE FROM sale WHERE sale_id = @sale_id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sale_id", saleId);

                    numberOfRows = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred deleting sale", ex);
            }

            return numberOfRows;
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
