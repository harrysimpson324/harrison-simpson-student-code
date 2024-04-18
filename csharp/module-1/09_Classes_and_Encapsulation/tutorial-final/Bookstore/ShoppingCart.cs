using System;
using System.Collections.Generic;
using System.Text;

namespace TechElevator.Bookstore
{
    public class ShoppingCart
    {
        private List<Book> booksToBuy = new List<Book>();

        public decimal TotalPrice
        {
            get
            {
                decimal total = 0.0M;
                foreach (Book book in this.booksToBuy)
                {
                    total += book.Price;
                }
                return total;
            }
        }

        public void Add(Book bookToAdd)
        {
            booksToBuy.Add(bookToAdd);
        }

        public string GetReceipt()
        {
            string receipt = "Receipt\n";
            foreach (Book book in this.booksToBuy)
            {
                receipt += book.GetBookInfo();
                receipt += "\n";
            }
            receipt += "\nTotal: $" + this.TotalPrice;
            return receipt;
        }
    }
}
