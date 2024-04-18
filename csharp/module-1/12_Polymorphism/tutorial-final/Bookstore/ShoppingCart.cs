using System;
using System.Collections.Generic;
using System.Text;

namespace TechElevator.Bookstore
{
    public class ShoppingCart
    {
        // *** Change from MediaItem to IPurchasable
        private List<IPurchasable> itemsToBuy = new List<IPurchasable>();

        public decimal TotalPrice
        {
            get
            {
                decimal total = 0.0M;
                // *** Change from MediaItem to IPurchasable
                foreach (IPurchasable item in this.itemsToBuy)
                {
                    total += item.Price;
                }
                return total;
            }
        }

        // *** Change from MediaItem to IPurchasable
        public void Add(IPurchasable itemToAdd)
        {
            itemsToBuy.Add(itemToAdd);
        }

        public string GetReceipt()
        {
            string receipt = "Receipt\n";
            // *** Change from MediaItem to IPurchasable
            foreach (IPurchasable item in this.itemsToBuy)
            {
                receipt += item;
                receipt += "\n";
            }
            receipt += "\nTotal: $" + this.TotalPrice;
            return receipt;
        }
    }
}
