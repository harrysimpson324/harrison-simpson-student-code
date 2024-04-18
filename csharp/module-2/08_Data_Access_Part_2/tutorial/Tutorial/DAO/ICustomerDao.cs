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

        // Step Two: Update an existing customer

        // Step Three: Delete a customer
    }
}
