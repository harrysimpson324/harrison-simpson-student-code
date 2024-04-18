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
            string connectionString = "";

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
            


            // Step Four: Add a new DAO method
            


            // Step Five: Call a DAO method that returns a List
            

        }
    }
}
