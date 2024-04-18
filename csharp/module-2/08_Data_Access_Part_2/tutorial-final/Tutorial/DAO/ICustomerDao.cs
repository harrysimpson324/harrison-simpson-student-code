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
        /// Get customers whose first or last names include the given search string.
        /// </summary>
        /// <param name="search">The string to search for in customer names.</param>
        /// <param name="useWildCard">The boolean to control whether to wrap the search term with wild-card characters.</param>
        /// <returns>An IList of Customer objects.</returns>
        IList<Customer> GetCustomersByName(string search, bool useWildCard);

        // Step One: Create a new customer
        /// <summary>
        /// Create a new customer in the datastore with the given information.
        /// </summary>
        /// <param name="customer">Customer information to add.</param>
        /// <returns>Customer object with the id populated.</returns>
        Customer CreateCustomer(Customer customer);

        // Step Two: Update an existing customer
        /// <summary>
        /// Update an existing customer in the datastore with the given information.
        /// </summary>
        /// <param name="customer">Customer information to update.</param>
        /// <returns>Updated Customer object.</returns>
        Customer UpdateCustomer(Customer customer);

        // Step Three: Delete a customer
        /// <summary>
        /// Delete the customer with the given id.
        /// </summary>
        /// <param name="customerId">The id of the customer to delete.</param>
        /// <returns>Number of customers deleted.</returns>
        int DeleteCustomerById(int customerId);
    }
}
