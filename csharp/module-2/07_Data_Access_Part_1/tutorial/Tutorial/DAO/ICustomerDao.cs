using System.Collections.Generic;
using Tutorial.Models;

namespace Tutorial.DAO
{
    public interface ICustomerDao
    {
        // Step Four: Add a new DAO method
        


        /// <summary>
        /// Get customers whose first or last names include the given search string.
        /// </summary>
        /// <param name="search">The string to search for in customer names.</param>
        /// <param name="useWildCard">The boolean to control whether to wrap the search term with wild-card characters.</param>
        /// <returns>An IList of Customer objects.</returns>
        IList<Customer> GetCustomersByName(string search, bool useWildCard);
    }
}
