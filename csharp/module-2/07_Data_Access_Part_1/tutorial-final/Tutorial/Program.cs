using System;
using System.Collections.Generic;
using Tutorial.DAO;
using Tutorial.Models;

namespace Tutorial
{
    class Program
    {
        private readonly ISaleDao saleDao;
        private readonly ICustomerDao customerDao;

        static void Main(string[] args)
        {
            // Step One: Configure the database connection
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
            Console.WriteLine($"Total Sales: ${saleDao.GetTotalSales()}");

            // Step Three: Copy returned values into an object
            Sale sale50 = saleDao.GetSaleById(50);
            Console.WriteLine(sale50);

            // Step Four: Add a new DAO method
            Customer customerForSale50 = customerDao.GetCustomerById(sale50.CustomerId.Value);
            Console.WriteLine($"Customer for that sale was {customerForSale50}");

            // Step Five: Call a DAO method that returns a List
            IList<Customer> matchingCustomers = customerDao.GetCustomersByName("Ma", true);
            Console.WriteLine("All customers with \"Ma\" in their first or last name:");
            foreach (Customer customer in matchingCustomers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
