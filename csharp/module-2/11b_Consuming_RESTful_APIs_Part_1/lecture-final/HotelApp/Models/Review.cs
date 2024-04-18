namespace HotelApp.Models
{
    public class Review
    {
        public int HotelId { get; set; }
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public string Author { get; set; }
        public int Stars { get; set; }
    }
}
