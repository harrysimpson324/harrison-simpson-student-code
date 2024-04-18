using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Tutorial.Exceptions;
using Tutorial.Models;

namespace Tutorial.DAO
{
    public class CustomerSqlDao : ICustomerDao
    {
        private readonly string connectionString;

        public CustomerSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Customer GetCustomerById(int customerId)
        {
            Customer customer = null;

            string sql = "SELECT customer_id, first_name, last_name, street_address, city, " +
                         "phone_number, email_address, email_offers " +
                         "FROM customer " +
                         "WHERE customer_id = @customer_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@customer_id", customerId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        customer = MapRowToCustomer(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred getting customer by ID", ex);
            }
            return customer;
        }

        public IList<Customer> GetCustomers()
        {
            IList<Customer> customers = new List<Customer>();

            string sql = "SELECT customer_id, first_name, last_name, street_address, city, " +
                         "phone_number, email_address, email_offers " +
                         "FROM customer;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer customer = MapRowToCustomer(reader);
                        customers.Add(customer);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred getting customers", ex);
            }

            return customers;
        }

        private Customer MapRowToCustomer(SqlDataReader reader)
        {
            Customer customer = new Customer();
            customer.CustomerId = Convert.ToInt32(reader["customer_id"]);
            customer.FirstName = Convert.ToString(reader["first_name"]);
            customer.LastName = Convert.ToString(reader["last_name"]);
            customer.StreetAddress = Convert.ToString(reader["street_address"]);
            customer.City = Convert.ToString(reader["city"]);
            if (reader["phone_number"] is DBNull)
            {
                customer.PhoneNumber = null;
            }
            else
            {
                customer.PhoneNumber = Convert.ToString(reader["phone_number"]);
            }
            if (reader["email_address"] is DBNull)
            {
                customer.EmailAddress = null;
            }
            else
            {
                customer.EmailAddress = Convert.ToString(reader["email_address"]);
            }
            customer.EmailOffers = Convert.ToBoolean(reader["email_offers"]);

            return customer;
        }
    }
}
