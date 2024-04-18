namespace TechElevator.Bookstore
{
    public abstract class MediaItem : IPurchasable
    {
        public MediaItem(string title, decimal price)
        {
            this.Title = title;
            this.Price = price;
        }

        public string Title { get; set; }
        public decimal Price { get; set; }

        public bool IsTaxable { get
            {
                return true;
            } 
        }
    }
}
