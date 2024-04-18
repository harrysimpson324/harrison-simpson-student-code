namespace Tutorial.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public decimal? Total { get; set; } // decimal? because the field is nullable
        public bool IsDelivery { get; set; }
        public int? CustomerId { get; set; } // int? because customer may be null

        public override string ToString()
        {
            return $"Sale {SaleId}: ${Total} ({(IsDelivery ? "delivery" : "carryout")})";
        }
    }
}
