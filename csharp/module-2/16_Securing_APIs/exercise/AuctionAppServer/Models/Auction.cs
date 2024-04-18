using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Models
{
    public class Auction
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field `Title` must not be blank.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field `Description` must not be blank.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field `User` must not be blank.")]
        public string User { get; set; }

        [Range(0.01, double.PositiveInfinity, ErrorMessage = "The field `CurrentBid` must be greater than 0.")]
        public double CurrentBid { get; set; }
    }
}
