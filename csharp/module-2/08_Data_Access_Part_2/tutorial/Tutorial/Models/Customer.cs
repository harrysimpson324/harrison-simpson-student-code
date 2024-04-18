namespace Tutorial.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool EmailOffers { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
