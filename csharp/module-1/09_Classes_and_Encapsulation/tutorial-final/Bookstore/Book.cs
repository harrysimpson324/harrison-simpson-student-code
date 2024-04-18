using System;
using System.Collections.Generic;
using System.Text;

namespace TechElevator.Bookstore
{
    public class Book
    {
        // Constructors for the Book class
        public Book()
        {
        }

        public Book(string title, string author, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        // Add the properties
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }

        // Return a string representation of this book
        public string GetBookInfo()
        {
            return $"Title: {this.Title}, Author: {this.Author}, Price: ${this.Price}";
        }
    }
}
