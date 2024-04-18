using System;
using System.Collections.Generic;
using Tutorial.DAO;
using Tutorial.Exceptions;
using Tutorial.Models;

namespace Tutorial
{
    class Program
    {
        private readonly ISaleDao saleDao;
        private readonly ICustomerDao customerDao;

        static void Main(string[] args)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=PizzaShop;Trusted_Connection=True;";

            Program program = new Program(connectionString);
            program.Run();
        }

        public Program(string connectionString)
        {
            saleDao = new SaleSqlDao(connectionString);
            customerDao = new CustomerSqlDao(connectionString);
        }

        private void Run()
        {
            // Step One: Create a new customer
            Customer newCustomer = new Customer();
            newCustomer.FirstName = "Lou";
            newCustomer.LastName = "Malnati";
            newCustomer.StreetAddress = "6649 North Lincoln Avenue";
            newCustomer.City = "Lincolnwood";
            newCustomer.PhoneNumber = "8476730800";
            newCustomer.EmailAddress = "lou@loutmalnatis.com";
            newCustomer.EmailOffers = true;
            
            newCustomer = customerDao.CreateCustomer(newCustomer);
            Console.WriteLine($"Customer with ID {newCustomer.CustomerId} created");

            // Step Two: Update existing customer
            newCustomer.FirstName = "Louis";
            customerDao.UpdateCustomer(newCustomer);

            Customer updatedCustomer = customerDao.GetCustomerById(newCustomer.CustomerId);
            Console.WriteLine($"In the datastore, updated customer's first name is now {updatedCustomer.FirstName}");

            // Step Three: Delete existing customer
            int numDeleted = customerDao.DeleteCustomerById(updatedCustomer.CustomerId);
            if (numDeleted == 1 )
            {
                Console.WriteLine("Customer successfully deleted");
            }
            else
            {
                Console.WriteLine("Customer NOT deleted");
            }

            // Step Four: Delete a customer with sales
            IList<Customer> customers = customerDao.GetCustomersByName("Marcome", false);
            try
            {
                customerDao.DeleteCustomerById(customers[0].CustomerId);
            }
            catch (DaoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
