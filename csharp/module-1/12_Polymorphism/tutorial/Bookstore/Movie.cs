using System;
using System.Collections.Generic;
using System.Text;

namespace TechElevator.Bookstore
{
    public class Movie : MediaItem
    {
        public string Rating { get; set; }
        public int RunLength { get; set; }

        // Movie constructor
        public Movie(string title, string rating, int runLength, decimal price)
        {
            Title = title;
            Rating = rating;
            RunLength = runLength;
            Price = price;
        }

        public override string ToString()
        {
            return $"Title: {this.Title}, Rating: {this.Rating}, Time: {this.RunLength}, Price: ${this.Price}";
        }
    }
}
