using System;
using System.Collections.Generic;
using System.Text;

namespace TechElevator.Bookstore
{
    public class ShoppingCart
    {
        // Constructor
        public ShoppingCart(double taxRate)
        {
            this.taxRate = taxRate;
        }
        
        // Items in the cart
        private List<IPurchasable> itemsToBuy = new List<IPurchasable>();

        // Tax rate in this tax area
        private double taxRate;

        public decimal SubtotalPrice
        {
            get
            {
                // Sum the prices of all items
                decimal subtotal = 0.0M;
                foreach (IPurchasable item in this.itemsToBuy)
                {
                    subtotal += item.Price;
                }
                return subtotal;
            }
        }

        public decimal Tax
        {
            get
            {
                // Apply the tax rate to the price of all the taxable items
                decimal tax = 0.0M;
                foreach (IPurchasable item in this.itemsToBuy)
                {
                    if (item.IsTaxable)
                    {
                        tax += item.Price * (decimal)this.taxRate;
                    }
                }
                return tax;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return SubtotalPrice + Tax;
            }
        }

        // Add an item to the cart
        public void Add(IPurchasable itemToAdd)
        {
            itemsToBuy.Add(itemToAdd);
        }

        public string GetReceipt()
        {
            string receipt = "\nReceipt\n\n";
            foreach (IPurchasable item in this.itemsToBuy)
            {
                receipt += item;
                receipt += "\n";
            }
            receipt += $"\nSubtotal: {this.SubtotalPrice:C}";
            receipt += $"\nTax: {this.Tax:C}";
            receipt += $"\nTotal: {this.TotalPrice:C}";
            return receipt;
        }
    }
}
