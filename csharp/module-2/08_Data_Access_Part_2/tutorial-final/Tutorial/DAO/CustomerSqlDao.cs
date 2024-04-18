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

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT customer_id, first_name, last_name, street_address, city, " +
                             "phone_number, email_address, email_offers " +
                             "FROM customer " +
                             "WHERE customer_id = @customer_id;";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@customer_id", customerId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    customer = MapRowToCustomer(reader);
                }
            }

            return customer;
        }

        public IList<Customer> GetCustomersByName(string search, bool useWildCard)
        {
            IList<Customer> customers = new List<Customer>();

            if (useWildCard)
            {
                search = "%" + search + "%";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT customer_id, first_name, last_name, street_address, city, " +
                             "phone_number, email_address, email_offers " +
                             "FROM customer " +
                             "WHERE first_name LIKE @first_name OR last_name LIKE @last_name;";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@first_name", search);
                cmd.Parameters.AddWithValue("@last_name", search);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Customer customer = MapRowToCustomer(reader);
                    customers.Add(customer);
                }
            }

            return customers;
        }

        // Step One: Create a new customer
        public Customer CreateCustomer(Customer customer)
        {
            Customer newCustomer;

            int customerId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql =
                    "INSERT INTO customer(first_name, last_name, street_address, city, phone_number, email_address, email_offers) " +
                    "OUTPUT INSERTED.customer_id " +
                    "VALUES (@first_name, @last_name, @street_address, @city, @phone_number, @email_address, @email_offers);";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@first_name", customer.FirstName);
                cmd.Parameters.AddWithValue("@last_name", customer.LastName);
                cmd.Parameters.AddWithValue("@street_address", customer.StreetAddress);
                cmd.Parameters.AddWithValue("@city", customer.City);
                cmd.Parameters.AddWithValue("@phone_number", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@email_address", customer.EmailAddress);
                cmd.Parameters.AddWithValue("@email_offers", customer.EmailOffers);

                customerId = (int)cmd.ExecuteScalar();
            }

            newCustomer = GetCustomerById(customerId);
            return newCustomer;
        }

        // Step Two: Update an existing customer
        public Customer UpdateCustomer(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = 
                    "UPDATE customer " + 
                    "SET first_name = @first_name, last_name = @last_name, street_address = @street_address, city = @city, " +
                    "phone_number = @phone_number, email_address = @email_address, email_offers = @email_offers " + 
                    "WHERE customer_id = @customer_id;";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@first_name", customer.FirstName);
                cmd.Parameters.AddWithValue("@last_name", customer.LastName);
                cmd.Parameters.AddWithValue("@street_address", customer.StreetAddress);
                cmd.Parameters.AddWithValue("@city", customer.City);
                cmd.Parameters.AddWithValue("@phone_number", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@email_address", customer.EmailAddress);
                cmd.Parameters.AddWithValue("@email_offers", customer.EmailOffers);
                cmd.Parameters.AddWithValue("@customer_id", customer.CustomerId);

                cmd.ExecuteNonQuery();
            }

            return GetCustomerById(customer.CustomerId);
        }

        // Step Three: Delete a customer
        public int DeleteCustomerById(int customerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "DELETE FROM customer WHERE customer_id = @customer_id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@customer_id", customerId);

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("Error deleting customer", ex);
            }
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
