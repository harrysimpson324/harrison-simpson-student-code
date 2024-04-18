using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        // Step Four: Add a new DAO method
        




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
