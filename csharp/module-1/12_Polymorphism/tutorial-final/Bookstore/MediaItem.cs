﻿namespace TechElevator.Bookstore
{
    public class MediaItem : IPurchasable
    {
        public string Title { get; private set; }
        public decimal Price { get; private set; }

        public MediaItem()
        {
        }

        public MediaItem(string title, decimal price)
        {
            Title = title;
            Price = price;
        }
    }
}
