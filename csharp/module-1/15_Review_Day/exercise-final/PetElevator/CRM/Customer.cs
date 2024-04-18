using System.Collections.Generic;
using PetElevator.Shared;

namespace PetElevator.CRM
{
    public class Customer : Person, IBillable
    {
        public string PhoneNumber { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();

        public Customer(string firstName, string lastName) : this(firstName, lastName, "")
        {
        }
        public Customer(string firstName, string lastName, string phoneNumber) : base(firstName, lastName)
        {
            PhoneNumber = phoneNumber;
        }

        public double GetBalanceDue(Dictionary<string, double> servicesRendered)
        {
            double owes = 0.0;
            foreach (KeyValuePair<string, double> sr in servicesRendered)
            {
                owes += sr.Value;
            }
            return owes;
        }
    }
}
