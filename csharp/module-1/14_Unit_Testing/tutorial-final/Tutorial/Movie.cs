using System;
using System.Collections.Generic;
using System.Text;

namespace TechElevator.Bookstore
{
    public class Movie : MediaItem
    {
        // Movie constructor
        public Movie(string title, string rating, int runLength, decimal price) : base(title, price)
        {
            Rating = rating;
            RunLength = runLength;
        }

        public string Rating { get; set; }
        public int RunLength { get; set; }

        public override string ToString()
        {
            return $"Movie: '{this.Title}'({this.Rating}), Price: {this.Price:C}";
        }
    }
}
