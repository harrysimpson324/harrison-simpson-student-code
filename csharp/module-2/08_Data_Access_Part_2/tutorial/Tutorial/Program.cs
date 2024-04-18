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

            // Step Two: Update existing customer

            // Step Three: Delete existing customer

            // Step Four: Delete a customer with sales
        }
    }
}
