using Tutorial.Models;

namespace Tutorial.DAO
{
    public interface ISaleDao
    {
        /// <summary>
        /// Get the grand total of sales in the datastore.
        /// </summary>
        /// <returns>The total as a decimal.</returns>
        decimal GetTotalSales();

        /// <summary>
        /// Get the sale from the datastore with the given id.
        /// </summary>
        /// <param name="saleId">The id of the sale to retrieve.</param>
        /// <returns>A complete Sale object.</returns>
        Sale GetSaleById(int saleId);
    }
}
