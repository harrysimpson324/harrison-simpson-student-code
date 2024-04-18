using System.Collections.Generic;
using Tutorial.Models;

namespace Tutorial.DAO
{
    public interface ISaleDao
    {
        /// <summary>
        /// Get the sale from the datastore with the given id.
        /// </summary>
        /// <param name="saleId">The id of the sale to retrieve.</param>
        /// <returns>A complete Sale object.</returns>
        Sale GetSaleById(int saleId);

        /// <summary>
        /// Get all sales from the datastore with the given customer id.
        /// </summary>
        /// <param name="customerId">The id of the customer whose sales to retrieve.</param>
        /// <returns>An IList of Sale objects.</returns>
        IList<Sale> GetSalesByCustomerId(int customerId);

        /// <summary>
        /// Create a new sale in the datastore with the given information.
        /// </summary>
        /// <param name="sale">The sale information to add.</param>
        /// <returns>Sale object with the id populated.</returns>
        Sale CreateSale(Sale sale);

        /// <summary>
        /// Update an existing sale in the datastore with the given information.
        /// </summary>
        /// <param name="sale">The sale information to update.</param>
        /// <returns>Updated Sale object.</returns>
        Sale UpdateSale(Sale sale);

        /// <summary>
        /// Delete the sale with the given id.
        /// </summary>
        /// <param name="saleId">The id of the sale to delete.</param>
        /// <returns></returns>
        int DeleteSaleById(int saleId);
    }
}
