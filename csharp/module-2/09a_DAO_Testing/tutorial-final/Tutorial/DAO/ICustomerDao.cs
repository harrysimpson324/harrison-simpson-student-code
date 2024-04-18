using System.Collections.Generic;
using Tutorial.Models;

namespace Tutorial.DAO
{
    public interface ICustomerDao
    {
        /// <summary>
        /// Get a customer from the datastore that has the given id.
        /// If the id is not found, return null.
        /// </summary>
        /// <param name="customerId">The id of the customer to retrieve.</param>
        /// <returns>A complete Customer object.</returns>
        Customer GetCustomerById(int customerId);

        /// <summary>
        /// Get all customers from the datastore.
        /// </summary>
        /// <returns>An IList of Customer objects.</returns>
        IList<Customer> GetCustomers();
    }
}
